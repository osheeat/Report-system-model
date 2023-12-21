using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Report_system_model.DBModels;

[Table("indicator_generation_method")]
public class IndicatorGenerationMethod
{
    [Key] [MaxLength(50)] public string Value { get; set; }
}