namespace EntBa_Core.ModelsLogic.Registration
{
    public class User
    {
        public required string Name { get; set; }
        public required string Surname { get; set; }
        public required string Email { get; set; }
        public required string Password { get; set; }
        public string? PhoneNumber { get; set; }
        public string? IdCardNumber { get; set; }
    }
}
