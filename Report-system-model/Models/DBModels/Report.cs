using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Report_system_model.DBModels;

[Table("report")]
public class Report
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int id { get; set; }

    [Column("report_indicator_id")]
    [MaxLength(50)] public string ReportIndicatorId { get; set; }
    public virtual ReportIndicator? VirtualReportIndicator { get; set; }

    [Column("report_code_id")]
    [MaxLength(30)] public string ReportCodeId { get; set; }
    public virtual ReportCode? VirtualReportCode { get; set; }

    [Column("report_id_id")]
    [MaxLength(30)] public string ReportIdId { get; set; }
    public virtual ReportId? VirtualReportId { get; set; }

    [Column("report_title_id")]
    [MaxLength(30)] public string ReportTitleId { get; set; }
    public virtual ReportTitle? VirtualReportTitle { get; set; }

    [Column("business_process_id")]
    [MaxLength(200)] public string BusinessProcessId { get; set; }
    public virtual BusinessProcess? VirtualBusinessProcess { get; set; }

    [Column("formation_frequency_id")]
    [MaxLength(100)] public string FormationFrequencyId { get; set; }
    public virtual FormationFrequency? VirtualFormationFrequency { get; set; }

    [Column("analytical_feature_id")]
    [MaxLength(200)] public string AnalyticalFeatureId { get; set; }
    public virtual AnalyticalFeature? VirtualAnalyticalFeature { get; set; }

    [Column("data_status_id")]
    [MaxLength(25)] public string DataStatusId { get; set; }
    public virtual DataStatus? VirtualDataStatus { get; set; }

    [Column("keyfigure_category_id")]
    [MaxLength(100)] public string KeyfigureCategoryId { get; set; }
    public virtual KeyfigureCategory? VirtualKeyfigureCategory { get; set; }

    [Column("release_id")] 
    [MaxLength(50)] public string ReleaseId { get; set; }
    public virtual Release? VirtualRelease { get; set; }

    [Column("keyfigure_id")]
    public int KeyfigureId { get; set; }
    public virtual Keyfigure? VirtualKeyfigure { get; set; }
}