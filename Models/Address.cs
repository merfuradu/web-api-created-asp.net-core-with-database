using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WebAPI_week1.Models
{
    public class Address
    {
        [Key]
        public int Id { get; set; }
        public string? Street { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public string? PostalCode { get; set; }
        [ForeignKey("Id")]
        public int? PersonalDataId { get; set; }

        //navigation property
        public PersonalData? PersonalData { get; set; }

    }
}
