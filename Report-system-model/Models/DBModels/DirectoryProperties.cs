using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Report_system_model.DBModels;

[Table("directory_properties")]
public class DirectoryProperties
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int id { get; set; }

    [Column("directory_id")]
    [MaxLength(25)] public string DirectoryId { get; set; }
    public virtual Directory? VirtualDirectory { get; set; }
    
    [Column("level_indicator_id")]
    [MaxLength(25)] public string LevelIndicatorId { get; set; }
    public virtual LevelIndicator? VirtualLevelIndicator { get; set; }
    
    [Column("auxiliary_column")]
    [MaxLength(200)] public string AuxiliaryColumn { get; set; }
    
    [Column("dw_code")]
    [MaxLength(200)] public string DWCode { get; set; }    
}