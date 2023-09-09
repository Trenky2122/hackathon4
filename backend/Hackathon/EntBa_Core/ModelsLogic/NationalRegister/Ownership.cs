namespace EntBa_Core.ModelsLogic.NationalRegister
{
    public class Ownership
    {
        public required string BirthNumber { get; set; }
        public required IList<Location> Locations { get; set; }
    }

    public class Location
    {
        public required string Parcel { get; set; }
        public required string City { get; set; }
    }
}
