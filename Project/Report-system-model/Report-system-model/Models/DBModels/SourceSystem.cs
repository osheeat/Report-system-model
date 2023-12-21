using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Report_system_model.DBModels;

[Table("source_system")]
public class SourceSystem
{
    public int Id { get; set; }
    [MaxLength(250)] public string Title { get; set; }
}