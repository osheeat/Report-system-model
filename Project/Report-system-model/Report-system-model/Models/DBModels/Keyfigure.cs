using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Report_system_model.DBModels;

[Table("Keyfigure")]
public class Keyfigure
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    [MaxLength(25)] public string SAPCode { get; set; }
    [MaxLength(250)] public string FullName { get; set; }
    [MaxLength(25)] public string ShortName { get; set; }
    
    [MaxLength(25)] public string ValueTypeId { get; set; }
    public virtual ValueType? VirtualValueType { get; set; }
    
    [MaxLength(250)] public string CurrencyUnitId { get; set; }
    public virtual CurrencyUnit? VirtualCurrencyUnit { get; set; }
    
    [MaxLength(100)] public string MethodOfObtainingId { get; set; }
    public virtual MethodOfObtaining? VirtualMethodOfObtaining { get; set; }
    
    [MaxLength(100)] public string KeyfigureCategoryId { get; set; }
    public virtual KeyfigureCategory? VirtualKeyfigureCategory { get; set; }
    
    [MaxLength(25)] public string LoadTimeId { get; set; }
    public virtual LoadTime? VirtualLoadTime { get; set; }
    
    [MaxLength(25)] public string UploadDeadlineId { get; set; }
    public virtual UploadDeadline? VirtualUploadDeadline { get; set; }
    
    [MaxLength(25)] public string ReportUsageIndicatorId { get; set; }
    public virtual ReportUsageIndicator? VirtualReportUsageIndicatore { get; set; }
    
    [MaxLength(25)] public string DataStatusId { get; set; }
    public virtual DataStatus? VirtualDataStatus { get; set; }
    
    [MaxLength(9000)] public string FormationMethodology { get; set; }
    
    [MaxLength(50)] public string IndicatorGenerationMethodId { get; set; }
    public virtual IndicatorGenerationMethod? VirtualIndicatorGenerationMethod { get; set; }
}