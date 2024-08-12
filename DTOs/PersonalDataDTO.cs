namespace WebAPI_week1.DTOs
{
    public class PersonalDataDTO
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public bool IsComplete { get; set; }
        public string? PhoneNumber { get; set; }

        public ICollection<AddressDTO> Addresses { get; set; } = new List<AddressDTO>();
        //navigation property

    }
}
