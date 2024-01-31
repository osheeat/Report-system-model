using Report_system_model.DBModels;
using ValueType = Report_system_model.DBModels.ValueType;

namespace Report_system_model.AppModels;
public class KeyfigureSystemSource
{
    public Company Company { get; set; }
    public IndicatorGenerationMethod IndicatorGenerationMethod { get; set; }
    public IndicatorSourceSystem IndicatorSourceSystem { get; set; }
    public Release Release { get; set; }
    public SourceSystem SourceSystem { get; set; }
}