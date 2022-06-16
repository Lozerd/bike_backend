using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace bike_backend.Models;

[Table("BikeType")]
public class BikeType
{
    [Microsoft.Build.Framework.Required]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    [Microsoft.Build.Framework.Required]
    [StringLength(255)]
    [DataType(DataType.Text)]
    public string Title { get; set; }
}