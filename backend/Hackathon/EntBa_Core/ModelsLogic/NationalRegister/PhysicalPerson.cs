namespace EntBa_Core.ModelsLogic.NationalRegister
{
    public class PhysicalPerson
    {
        public required string Name { get; set; }
        public required string Surname { get; set; }
        public required string BirthNumber { get; set; }
        public required string IdCardNumber { get; set; }
        public required Address Address { get; set; }
    }

    public class Address
    {
        public required string Street { get; set; }
        public required string City { get; set; }
        public required string Number { get; set; }

    }
}
