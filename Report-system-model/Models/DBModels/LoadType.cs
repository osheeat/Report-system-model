using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Report_system_model.DBModels;

[Table("load type ")]
public class LoadType
{
    [Key] [MaxLength(50)] public string value { get; set; }
}