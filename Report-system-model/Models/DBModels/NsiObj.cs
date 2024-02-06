using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Report_system_model.DBModels;

[Table("nsi_obj")]
public class NsiObj
{
    [Key] [MaxLength(20)] public string value { get; set; }
}