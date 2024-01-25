using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Report_system_model.DBModels;

[Table("indicator_source_system")]
public class IndicatorSourceSystem
{
    public int id { get; set; }
    public int keyfigure_id { get; set; }
    public virtual Keyfigure? virtual_keyfigure { get; set; }
    public int company_id { get; set; }
    public virtual Company? virtual_company { get; set; }
    public int source_systemId { get; set; }
    public virtual SourceSystem? virtual_source_system { get; set; }
    [MaxLength(50)] public string release_id { get; set; }
    public virtual Release? virtual_release { get; set; }
}