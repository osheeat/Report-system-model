using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Report_system_model.DBModels;

[Table("load_time")]
public class LoadTime
{
    [Key] [MaxLength(25)] public string value { get; set; }
}