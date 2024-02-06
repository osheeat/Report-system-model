using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Report_system_model.DBModels;

[Table("indicator_source_system")]
public class IndicatorSourceSystem
{
    public int id { get; set; }
    [Column("keyfigure_id")] public int KeyfigureId { get; set; }
    public virtual Keyfigure? VirtualKeyfigure { get; set; }
    [Column("company_id")] public int CompanyId { get; set; }
    public virtual Company? VirtualCompany { get; set; }
    [Column("source_system_id")] public int SourceSystemId { get; set; }
    public virtual SourceSystem? VirtualSourceSystem { get; set; }
}