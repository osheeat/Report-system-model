using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Report_system_model.DBModels;

[Table("indicator_source_system")]
public class IndicatorSourceSystem
{
    public int id { get; set; }
    public int keyfigureId { get; set; }
    public virtual Keyfigure? virtualKeyfigure { get; set; }
    public int companyId { get; set; }
    public virtual Company? virtualCompany { get; set; }
    public int sourceSystemId { get; set; }
    public virtual SourceSystem? virtualSourceSystem { get; set; }
    [MaxLength(50)] public string releaseId { get; set; }
    public virtual Release? virtualRelease { get; set; }
}