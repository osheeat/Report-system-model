using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Report_system_model.DBModels;

[Table("directory")]
public class Directory
{
    [Key] [DatabaseGenerated(DatabaseGeneratedOption.Identity)] public int id { get; set; }
    [MaxLength(500)] public string title { get; set; }
    [MaxLength(500)] public string short_description { get; set; }
    // [MaxLength(200)] public string owner { get; set; }
    // [MaxLength(30)] public string erpp_id { get; set; }
    // [MaxLength(30)] public string nsi_id { get; set; }
    // [MaxLength(30)] public string pr_id { get; set; }
}