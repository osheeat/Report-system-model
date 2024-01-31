using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Report_system_model.DBModels;

[Table("keyfigure_category")]
public class KeyfigureCategory
{
    [Key] [MaxLength(100)] public string value { get; set; }
}