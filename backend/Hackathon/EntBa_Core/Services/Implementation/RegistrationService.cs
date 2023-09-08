using EntBa_Core.Database.Entities.SystemUsers;
using EntBa_Core.DbContext;
using EntBa_Core.Enums;
using EntBa_Core.ModelsLogic.Registration;
using EntBa_Core.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EntBa_Core.Services.Implementation
{
    public class RegistrationService : BaseService, IRegistrationService
    {
        private const int VerificationLimitHours = 24;

        public RegistrationService(DatabaseContext dbContext) : base(dbContext)
        {
        }
        public async Task<RegistrationResultEnum> CreateRegistrationLink(string email)
        {
            if (DbContext.Users.Count(u => u.Email.Equals(email)) != 0)
                return RegistrationResultEnum.UserExists;

            var creationTime = await DbContext.UserLinks.OrderByDescending(x => x.CreationTime).Where(e => e.Email.Equals(email))
                .Select(x => x.CreationTime).FirstOrDefaultAsync();
            if (creationTime >= DateTime.Now.AddHours(-VerificationLimitHours))
                return RegistrationResultEnum.LinkExists;

            var userLink = new UserLinkDbo
            {
                CreationTime = DateTime.UtcNow,
                Email = email,
                LinkGiud = Guid.NewGuid()
            };

            await DbContext.AddAsync(userLink);
            await DbContext.SaveChangesAsync();

            return RegistrationResultEnum.Ok;
        }

        public async Task<LinkVerificationResult> VerifyLink(Guid link)
        {
            var userLink = await DbContext.UserLinks.FirstOrDefaultAsync(x => x.LinkGiud.Equals(link));
            if (userLink is null || userLink.CreationTime >= DateTime.Now.AddHours(-VerificationLimitHours))
            {
                return new LinkVerificationResult
                {
                    IsValid = false,
                    Email = null
                };
            }

            return new LinkVerificationResult
            {
                Email = userLink.Email,
                IsValid = true
            };
        }

        public async Task Register(User user)
        {
            await DeleteRegistrationLinks(user.Email);

            var userDbo = CreateUserDbo(user);
            var userId = await SaveUser(userDbo);

            if (user.IdCardNumber is not null)
            {
                var cardDbo = new CardDbo
                {
                    UserId = userId,
                    CardType = CardTypeEnum.IdCard,
                    Country = "SK",
                    Number = user.IdCardNumber
                };
                await SaveCard(cardDbo);
            }
        }

        private async Task DeleteRegistrationLinks(string email)
        {
            DbContext.UserLinks.RemoveRange(DbContext.UserLinks.Where(x => x.Email == email));
            await DbContext.SaveChangesAsync();
        }

        private static UserDbo CreateUserDbo(User user)
        {
            var salt = BCrypt.Net.BCrypt.GenerateSalt();
            var hashedPassword = BCrypt.Net.BCrypt.HashPassword(user.Password, salt);
            return new UserDbo
            {
                Email = user.Email,
                Name = user.Name,
                Surname = user.Surname,
                PwdHash = hashedPassword,
                Salt = salt
            };
        }

        private async Task<int> SaveUser(UserDbo userDbo)
        {
            await DbContext.Users.AddAsync(userDbo);
            await DbContext.SaveChangesAsync();
            return userDbo.Id;
        }

        private async Task SaveCard(CardDbo cardDbo)
        {
            await DbContext.Cards.AddAsync(cardDbo);
            await DbContext.SaveChangesAsync();
        }
    }
}
