using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Report_system_model.DBModels;

[Table("value_type")]
public class ValueType
{
    [Key] [MaxLength(25)] public string value { get; set; }
}