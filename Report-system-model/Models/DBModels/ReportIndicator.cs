using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Report_system_model.DBModels;

[Table("report_indicator")]
public class ReportIndicator
{
    [Key] [MaxLength(50)] public string value { get; set; }
}