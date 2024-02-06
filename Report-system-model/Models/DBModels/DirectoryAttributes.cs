using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Report_system_model.DBModels;

[Table("directory_attributes")]
public class DirectoryAttributes
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int id { get; set; }
    
    [Column("tech_name")]
    [MaxLength(200)] public string TechName { get; set; }    
    
    [Column("time_dependence")]
    [MaxLength(200)] public string TimeDependence { get; set; }    
    
    [Column("load_type_id")]
    [MaxLength(25)] public string LoadTypeId { get; set; }
    public virtual LoadType? VirtualLoadType { get; set; }
    
    [Column("directory_id")]
    [MaxLength(25)] public string DirectoryId { get; set; }
    public virtual Directory? VirtualDirectory { get; set; }
    
    [Column("attribute_directory_id")]
    [MaxLength(25)] public string AttributeDirectoryId { get; set; }
    public virtual Directory? VirtualAttributeDirectory { get; set; }
    
    [Column("comment")]
    [MaxLength(200)] public string Comment { get; set; }    
}