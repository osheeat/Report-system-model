using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Report_system_model.DBModels;

[Table("report_title")]
public class ReportTitle
{
    [Key] [MaxLength(100)] public string value { get; set; }
}