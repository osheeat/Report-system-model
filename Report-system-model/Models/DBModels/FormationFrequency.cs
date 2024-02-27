using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Report_system_model.DBModels;

[Table("formation_frequency")]
public class FormationFrequency
{
    [Key] [MaxLength(100)] public string value { get; set; }
}