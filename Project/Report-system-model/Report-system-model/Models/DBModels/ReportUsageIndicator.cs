using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Report_system_model.DBModels;

[Table("report_usage_indicator")]
public class ReportUsageIndicator
{
    [Key] [MaxLength(50)] public string value { get; set; }
}