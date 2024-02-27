using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Report_system_model.DBModels;

[Table("report_id")]
public class ReportId
{
    [Key] [MaxLength(30)] public string value { get; set; }
}