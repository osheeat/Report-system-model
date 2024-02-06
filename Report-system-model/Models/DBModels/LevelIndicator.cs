using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Report_system_model.DBModels;

[Table("level_indicator")]
public class LevelIndicator
{
    [Key] [MaxLength(20)] public string value { get; set; }
}