using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Report_system_model.DBModels;

[Table("method_of_obtaining")]
public class MethodOfObtaining
{
    [Key] [MaxLength(100)] public string Value { get; set; }
}