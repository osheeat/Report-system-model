using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Report_system_model.DBModels;

[Table("encoding_language")]
public class EncodingLanguage
{
    [Key] [MaxLength(50)] public string value { get; set; }
}