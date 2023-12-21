using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Report_system_model.DBModels;

[Table ("data_status")]
public class DataStatus
{
    [Key] [MaxLength(25)] public string Value { get; set; }
}