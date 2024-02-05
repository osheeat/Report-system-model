using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Report_system_model.DBModels;

[Table("analytical_feature")]
public class AnalyticalFeature
{
    [Key] [MaxLength(200)] public string value { get; set; }
}