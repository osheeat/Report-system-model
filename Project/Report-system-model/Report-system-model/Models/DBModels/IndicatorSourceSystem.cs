using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Report_system_model.DBModels;

[Table("indicator_source_system")]
public class IndicatorSourceSystem
{
    public int Id { get; set; }
    public int KeyfigureId { get; set; }
    public virtual Keyfigure? VirtualKeyfigure { get; set; }
    public int CompanyId { get; set; }
    public virtual Company? VirtualCompany { get; set; }
    public int SourceSystemId { get; set; }
    public virtual SourceSystem? VirtualSourceSystem { get; set; }
    [MaxLength(50)] public string ReleaseId { get; set; }
    public virtual Release? VirtualRelease { get; set; }
}