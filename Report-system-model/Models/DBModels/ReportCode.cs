using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Report_system_model.DBModels;

[Table("report_code")]
public class ReportCode
{
    [Key] [MaxLength(30)] public string value { get; set; }
}