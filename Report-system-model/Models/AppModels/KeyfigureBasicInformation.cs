using Report_system_model.DBModels;
using ValueType = Report_system_model.DBModels.ValueType;

namespace Report_system_model.AppModels;

public class KeyfigureBasicInformation
{
    public Keyfigure Keyfigure { get; set; }
    public DataStatus DataStatus { get; set; }
}