using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Report_system_model.DBModels;

[Table("upload_deadline")]
public class UploadDeadline
{
    [Key] [MaxLength(25)] public string Value { get; set; }
}