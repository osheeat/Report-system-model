using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Report_system_model.DBModels;

[Table("business_process")]
public class BusinessProcess
{
    [Key] [MaxLength(200)] public string bp_name { get; set; }
}