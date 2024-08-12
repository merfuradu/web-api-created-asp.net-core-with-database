using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPI_week1.Models;

[Table("PersonalData")]
public class PersonalData
{
    [Key]
    public int Id { get; set; }
    public string? Name { get; set; }
    public bool IsComplete { get; set; }
    public string? PhoneNumber { get; set; }

    public ICollection<Address> Addresses { get; set; } = new List<Address>();
    //navigation property

}


