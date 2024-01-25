using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Report_system_model.DBModels;

[Table("keyfigure")]
public class Keyfigure
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int id { get; set; }
    [MaxLength(25)] public string sap_code { get; set; }
    [MaxLength(250)] public string full_name { get; set; }
    [MaxLength(25)] public string short_name { get; set; }
    
    [MaxLength(25)] public string value_type_id { get; set; }
    public virtual ValueType? virtual_value_type { get; set; }
    
    [MaxLength(250)] public string currency_unit_id { get; set; }
    public virtual CurrencyUnit? virtual_currency_unit { get; set; }
    
    [MaxLength(100)] public string method_of_obtaining_id { get; set; }
    public virtual MethodOfObtaining? virtual_method_of_obtaining { get; set; }
    
    [MaxLength(100)] public string keyfigure_category_id { get; set; }
    public virtual KeyfigureCategory? virtual_keyfigure_category { get; set; }
    
    [MaxLength(25)] public string load_time_id { get; set; }
    public virtual LoadTime? virtual_load_time { get; set; }
    
    [MaxLength(25)] public string upload_deadline_id { get; set; }
    public virtual UploadDeadline? virtual_upload_deadline { get; set; }
    
    [MaxLength(25)] public string report_usage_indicator_id { get; set; }
    public virtual ReportUsageIndicator? virtual_report_usage_indicatore { get; set; }
    
    [MaxLength(25)] public string data_status_id { get; set; }
    public virtual DataStatus? virtual_data_status { get; set; }
    
    [MaxLength(9000)] public string formation_methodology { get; set; }
    
    [MaxLength(50)] public string indicator_generation_method_id { get; set; }
    public virtual IndicatorGenerationMethod? virtual_indicator_generation_method { get; set; }
}