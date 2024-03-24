using System.Collections.ObjectModel;
using System.Linq;
using System.Reactive;
using Report_system_model.AppModels;
using Report_system_model.DBModels;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;

namespace Report_system_model.ViewModels;

public class ReportEditViewModel
{
    
    private MyDbContext Context;
    
    [Reactive] public Report? Report { get; set; }
    [Reactive] public KeyfigureModel? Keyfigure { get; set; }
    
    [Reactive] public ObservableCollection<DataStatus> DataStatuses { get; set; }
    
    
    public ReportEditViewModel()
    {
        //для авалонии
    }
    
    public ReportEditViewModel(Report selectedReport)
    {
        Context = new MyDbContext();
        Context.Database.EnsureCreated();

        Report = selectedReport;
        
        var statuses = Context.DataStatuss.ToList();
        DataStatuses = new(statuses);
    }

    public void Save()
    {
        // Context = new MyDbContext();
        // Context.Database.EnsureCreated();
        // OpenEditForm = ReactiveCommand.Create<Report, Unit>(Execute);
    }
}