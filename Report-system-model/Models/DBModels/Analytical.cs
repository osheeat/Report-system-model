using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Report_system_model.DBModels;

[Table("analytical")]
public class Analytical
{
    [Key] [MaxLength(20)] public string value { get; set; }
}