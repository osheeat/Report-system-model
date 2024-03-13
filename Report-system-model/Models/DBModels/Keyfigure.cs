using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Report_system_model.DBModels;

[Table("keyfigure")]
public class Keyfigure
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int id { get; set; }
    [Column("sap_code")] [MaxLength(25)] public string SAPCode { get; set; }
    [Column("full_name")] [MaxLength(250)] public string FullName { get; set; }
    [Column("short_name")] [MaxLength(25)] public string ShortName { get; set; }

    [Column("value_type_id")]
    [MaxLength(25)]
    public string ValueTypeId { get; set; }

    public virtual ValueType? VirtualValueType { get; set; }

    [Column("currency_unit_id")]
    [MaxLength(250)]
    public string CurrencyUnitId { get; set; }

    public virtual CurrencyUnit? VirtualCurrencyUnit { get; set; }

    [Column("method_of_obtaining_id")]
    [MaxLength(100)]
    public string MethodOfObtainingId { get; set; }

    public virtual MethodOfObtaining? VirtualMethodOfObtaining { get; set; }

    [Column("keyfigure_category_id")]
    [MaxLength(100)]
    public string KeyfigureCategoryId { get; set; }

    public virtual KeyfigureCategory? VirtualKeyfigureCategory { get; set; }

    [Column("load_time_id")]
    [MaxLength(25)]
    public string LoadTimeId { get; set; }

    public virtual LoadTime? VirtualLoadTime { get; set; }

    [Column("upload_deadline_id")]
    [MaxLength(25)]
    public string UploadDeadlineId { get; set; }

    public virtual UploadDeadline? VirtualUploadDeadline { get; set; }

    // [Column("report_usage_indicator_id")]
    // [MaxLength(25)]
    // public string ReportUsageIndicatorId { get; set; }
    //
    // public virtual ReportUsageIndicator? VirtualReportUsageIndicator { get; set; }

    [Column("data_status_id")]
    [MaxLength(25)]
    public string DataStatusId { get; set; }
    public virtual DataStatus? VirtualDataStatus { get; set; }

    [Column("formation_methodology")]
    [MaxLength(9000)]
    public string FormationMethodology { get; set; }

    [Column("indicator_generation_method_id")]
    [MaxLength(50)]
    public string IndicatorGenerationMethodId { get; set; }

    public virtual IndicatorGenerationMethod? VirtualIndicatorGenerationMethod { get; set; }
}