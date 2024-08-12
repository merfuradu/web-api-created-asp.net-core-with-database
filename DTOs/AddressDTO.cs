using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPI_week1.DTOs
{
    public class AddressDTO
    {
        public int Id { get; set; }
        public string? Street { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public string? PostalCode { get; set; }
        public int? PersonalDataId { get; set; }
    }
}
