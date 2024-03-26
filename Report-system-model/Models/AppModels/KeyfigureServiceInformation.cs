using Report_system_model.DBModels;
using ValueType = Report_system_model.DBModels.ValueType;

namespace Report_system_model.AppModels;
public class KeyfigureServiceInformation
{
    public ValueType ValueType { get; set; }
    public CurrencyUnit CurrencyUnit { get; set; }
    public MethodOfObtaining MethodOfObtaining { get; set; }
    public KeyfigureCategory KeyfigureCategory { get; set; }
    public LoadTime LoadTime { get; set; }
    public UploadDeadline UploadDeadline { get; set; }
}