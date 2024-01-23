using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Report_system_model.DBModels;

[Table("keyfigure")]
public class Keyfigure
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    [MaxLength(25)] public string sapCode { get; set; }
    [MaxLength(250)] public string fullName { get; set; }
    [MaxLength(25)] public string shortName { get; set; }
    
    [MaxLength(25)] public string valueTypeId { get; set; }
    public virtual ValueType? virtualValueType { get; set; }
    
    [MaxLength(250)] public string currencyUnitId { get; set; }
    public virtual CurrencyUnit? virtualCurrencyUnit { get; set; }
    
    [MaxLength(100)] public string methodOfObtainingId { get; set; }
    public virtual MethodOfObtaining? virtualMethodOfObtaining { get; set; }
    
    [MaxLength(100)] public string keyfigureCategoryId { get; set; }
    public virtual KeyfigureCategory? virtualKeyfigureCategory { get; set; }
    
    [MaxLength(25)] public string loadTimeId { get; set; }
    public virtual LoadTime? virtualLoadTime { get; set; }
    
    [MaxLength(25)] public string uploadDeadlineId { get; set; }
    public virtual UploadDeadline? virtualUploadDeadline { get; set; }
    
    [MaxLength(25)] public string reportUsageIndicatorId { get; set; }
    public virtual ReportUsageIndicator? virtualReportUsageIndicatore { get; set; }
    
    [MaxLength(25)] public string dataStatusId { get; set; }
    public virtual DataStatus? virtualDataStatus { get; set; }
    
    [MaxLength(9000)] public string formationMethodology { get; set; }
    
    [MaxLength(50)] public string indicatorGenerationMethodId { get; set; }
    public virtual IndicatorGenerationMethod? virtualIndicatorGenerationMethod { get; set; }
}