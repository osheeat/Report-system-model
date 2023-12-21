using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Report_system_model.DBModels;

[Table("release")]
public class Release
{
    [Key] [MaxLength(50)] public string Value { get; set; }
}