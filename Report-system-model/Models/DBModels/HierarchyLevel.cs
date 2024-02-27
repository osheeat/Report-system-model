using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Report_system_model.DBModels;

[Table("hierarchy_level")]
public class HierarchyLevel
{
    [Key] public int value { get; set; }
}