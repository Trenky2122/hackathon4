using EntBa_Core.Enums;

namespace EntBa_Core.ModelsLogic.Admin
{
    public class EntranceRequestBase
    {
        public int Id { get; set; }
        public required RequestStateEnum RequestState { get; set; }
        public required RequestTypeEnum RequestType { get; set; }
        public required string RequesterName { get; set; }
        public required string RequesterSurname { get; set; }
        public required string Caption { get; set; }
        public required DateTime Date { get; set; }

    }
}
