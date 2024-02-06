using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Report_system_model.DBModels;

[Table("directory_property_hierarchy_level")]
public class DirectoryPropertyHierarchyLevel
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int id { get; set; }
    
    [Column("attribute_directory_id")]
    [MaxLength(25)]  public string HierarchyLevelId { get; set; }
    public virtual HierarchyLevel? VirtualHierarchyLevel { get; set; }
    
    [Column("directory_properties_id")]
    public int DirectoryPropertiesId { get; set; }
    public virtual DirectoryProperties? VirtualDirectoryProperties { get; set; }
}