using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Report_system_model.DBModels;

[Table("ksss")]
public class KSSS
{
    [Key] [MaxLength(200)] public string value { get; set; }
}