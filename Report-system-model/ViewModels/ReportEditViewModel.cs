using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reactive;
using System.Reactive.Linq;
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
    [Reactive] public ObservableCollection<KeyfigureCategory> KeyfigureTypes { get; set; }
    [Reactive] public ObservableCollection<AnalyticalFeature> AnalytFeatures { get; set; }
    [Reactive] public DataStatus SelectedDataStatus { get; set; }
    [Reactive] public KeyfigureCategory SelectedKeyfigType { get; set; }
    [Reactive] public string? currFeature { get; set; }
    [Reactive] public ObservableCollection<AnalyticalFeature> FeaturesFilterByName { get; set; }
    
    
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
        
        var types = Context.KeyfigureCategories.ToList();
        KeyfigureTypes = new(types);
        
        var features = Context.AnalyticalFeatures.ToList();
        AnalytFeatures = new(features);
        
        this.WhenAnyValue(vm => vm.currFeature)
            .Do(val => FilterAnalytFeature(currFeature))
            .Subscribe();

        if (DataStatuses != null)
        {
            SelectedDataStatus = DataStatuses.FirstOrDefault(val => val.value == Report.VirtualDataStatus.value);
        }
        if (KeyfigureTypes != null)
        {
            SelectedKeyfigType = KeyfigureTypes.FirstOrDefault(val => val.value == Report.VirtualKeyfigureCategory.value);
        }
    }

    
    private void FilterAnalytFeature(string? filter)
    {
        //if (af is null) return;
        filter ??= "";
        
        var items = AnalytFeatures
            .Where(r => r.value.ToLower().Contains(filter.ToLower()));
        FeaturesFilterByName = new(items);
    }
    public void Save()
    {
        // Context = new MyDbContext();
        // Context.Database.EnsureCreated();
    }
}