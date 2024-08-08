using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPI_week1;

    [Table("PersonalData")]
    public class PersonalData
    {
        [Key]
        public int Id { get; set; }
        public string? Name { get; set; }
        public bool IsComplete { get; set; }
        public string? PhoneNumber { get; set; }

        [ForeignKey("Id")]
        public int AddressId { get; set; }
        //navigation property
        public Address Address { get; set; }

    }


