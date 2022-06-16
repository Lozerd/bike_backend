using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace bike_backend.Models;

[Table("Bike")]
public class Bike
{
    [Microsoft.Build.Framework.Required]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    [Microsoft.Build.Framework.Required]
    [DataType(DataType.Text)]
    [StringLength(255)]
    public string Title { get; set; }
    public int? Type { get; set; }
    [DataType(DataType.Currency)]
    public int Price { get; set; }
}