using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Report_system_model.DBModels;

[Table ("formation_methodology")]
public class FormationMethodology
{
    [Key] [MaxLength(500)] public string Value { get; set; }
}