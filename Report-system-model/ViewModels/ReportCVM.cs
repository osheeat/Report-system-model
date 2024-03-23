using Report_system_model.AppModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reactive;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using Microsoft.EntityFrameworkCore;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using Report_system_model.DBModels;
using Report_system_model.Views;

namespace Report_system_model.ViewModels;

class ReportPComparer : IEqualityComparer<Report>
{
    public bool Equals(Report x, Report y)
    {
        if (ReferenceEquals(x, y)) return true;
        
        if (ReferenceEquals(x, null)) return false;
        if (ReferenceEquals(y, null)) return false;
        
        if (x.GetType() != y.GetType()) return false;
        
        return x.ReportIdId == y.ReportIdId && x.ReportTitleId == y.ReportTitleId;
    }

    public int GetHashCode(Report obj)
    {
        return HashCode.Combine(obj.ReportIdId, obj.ReportTitleId);
    }
}

public class ReportCVM : ViewModelBase
{
    [Reactive] public ObservableCollection<Report> ReportModelsToList { get; set; }
    [Reactive] public ObservableCollection<ReportId> ReportIDs { get; set; }
    [Reactive] public ObservableCollection<Report> ReportModels { get; set; }
    [Reactive] public ObservableCollection<ReportIndicator> ReportIndicators { get; set; }
    // [Reactive] public ObservableCollection<Release> ReportReleases { get; set; }
    [Reactive] public ObservableCollection<FormationFrequency> FormationPeriodicity { get; set; }
    [Reactive] public ObservableCollection<BusinessProcess> BusinessProcess { get; set; }
    [Reactive] public ObservableCollection<DataStatus> DataStatuses { get; set; }
    [Reactive] public ObservableCollection<KeyfigureCategory> KeyfigureTypes { get; set; }
    [Reactive] public ObservableCollection<Report> ReportsFilterByBusinessProcess { get; set; }
    
    [Reactive] public ObservableCollection<Report> KeyfiguresFilterByReport{ get; set; }
    [Reactive] Report SelectedKeyfigureModel { get; set; }
    
    [Reactive] public string searchString { get; set; }
    public ReactiveCommand<KeyfigureModel, Unit> ButtonClickCommand_1 { get; private set; }

    private MyDbContext Context;
    
    [Reactive] public Report? SelectedReport { get; set; }
    [Reactive] public BusinessProcess? SelectedBusinessProcess { get; set; }
    
    [Reactive] public string? ReportTitleFilter { get; set; }
    
    public ReactiveCommand<Report, Unit> OpenEditForm { get; private set; }
    
    public ReportCVM()
    {
        Context = new MyDbContext();
        Context.Database.EnsureCreated();
        OpenEditForm = ReactiveCommand.Create<Report, Unit>(Execute);

        this.WhenAnyValue(vm => vm.SelectedKeyfigureModel)
            .Do(_ => { })
            .Subscribe();

        var items = Context.Reports
            //.Include(x => x.VirtualReportCode)
            .Include(x => x.VirtualReportId)
            .Include(x => x.VirtualReportTitle)
            .Include(x => x.VirtualFormationFrequency)
            .Include(x => x.VirtualBusinessProcess)
            .Include(x => x.VirtualKeyfigure).ThenInclude(y => y.VirtualDataStatus)
            .Include(x => x.VirtualKeyfigure).ThenInclude(y => y.VirtualKeyfigureCategory)
            .Include(x => x.VirtualAnalyticalFeature)
            .ToList();

        var cbItems = Context.ReportIndicators.ToList();
        //var relItems = Context.Releases.ToList();
        var periodItems = Context.FormationFrequencies.ToList();
        var bpItems = Context.BusinessProcesses.ToList();
        var statuses = Context.DataStatuss.ToList();
        var categories = Context.KeyfigureCategories.ToList();
        var ids = Context.ReportIds.ToList();
        
        var models = items.Distinct(new ReportPComparer());
        

        ReportModelsToList = new(models);
        
        ReportIDs = new(ids);
        ReportIndicators = new(cbItems);
        //ReportReleases = new(relItems);
        FormationPeriodicity = new(periodItems);
        BusinessProcess = new(bpItems);
        DataStatuses = new(statuses);
        KeyfigureTypes = new(categories);
        
        
        var itemsForBP = Context.Reports
            //.Include(x => x.VirtualRelease)
            .Include(x => x.VirtualReportCode)
            .Include(x => x.VirtualReportId)
            .Include(x => x.VirtualReportTitle)
            .Include(x => x.VirtualFormationFrequency)
            .Include(x => x.VirtualBusinessProcess)
            .Include(x => x.VirtualKeyfigure).ThenInclude(y => y.VirtualDataStatus)
            .Include(x => x.VirtualKeyfigure).ThenInclude(y => y.VirtualKeyfigureCategory)
            .Include(x => x.VirtualAnalyticalFeature)
            .ToList();
        
        ReportModels = new(itemsForBP);

        this.WhenAnyValue(vm => vm.SelectedBusinessProcess, vm => vm.ReportTitleFilter)
            .Do(val => FilterBProcesses(val.Item1, val.Item2))
            .Subscribe();

        this.WhenAnyValue(vm => vm.SelectedReport)
            .Do(val => FilterByReport(val))
            .Subscribe();
    }

    private Unit Execute(Report obj)
    {
        ReportEditWindow newWindow;
        if (obj != null)
        {
            newWindow = new ReportEditWindow(obj);
        }
        else
        {
            newWindow = new ReportEditWindow();
        }

        newWindow.Show();
        return Unit.Default;
    }
    
    
    private void FilterByReport(Report? report)
    {
        if (report is null) return;

        var items = ReportModels;
        var t1 = items.Where(r => r.ReportIdId == report.ReportIdId).ToList();
        KeyfiguresFilterByReport = new(t1);
    }
    
    private void FilterBProcesses(BusinessProcess? bp, string? filter)
    {
        if (bp is null) return;
        filter ??= "";
        
        var items = ReportModelsToList
            .Where(r => r.BusinessProcessId == bp.value && r.ReportTitleId.ToLower().Contains(filter.ToLower()));
        ReportsFilterByBusinessProcess = new(items);
    }
}