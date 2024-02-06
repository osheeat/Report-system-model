using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Report_system_model.DBModels;

[Table("source_table_in_dw")]
public class SourceTableInDW
{
    [Key] [MaxLength(50)] public string value { get; set; }
}