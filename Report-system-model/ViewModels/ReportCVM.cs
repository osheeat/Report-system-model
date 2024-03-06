using Report_system_model.AppModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Reactive;
using System.Reactive.Linq;
using System.Threading;
using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Interactivity;
using Avalonia.Media;
using Microsoft.EntityFrameworkCore;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using Report_system_model.DBModels;
using SkiaSharp;
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
    [Reactive] public ObservableCollection<Release> ReportReleases { get; set; }
    [Reactive] public ObservableCollection<FormationFrequency> FormationPeriodicity { get; set; }
    [Reactive] public ObservableCollection<BusinessProcess> BusinessProcess { get; set; }
    [Reactive] public ObservableCollection<DataStatus> DataStatuses { get; set; }
    [Reactive] public ObservableCollection<KeyfigureCategory> KeyfigureTypes { get; set; }
    
    [Reactive] public ObservableCollection<Report> ReportsFilterByBusinessProcess { get; set; }
    [Reactive] KeyfigureModel SelectedKeyfigureModel { get; set; }
    [Reactive] public string searchString { get; set; }
    public ReactiveCommand<KeyfigureModel, Unit> ButtonClickCommand_1 { get; private set; }

    private MyDbContext Context;
    
    [Reactive] public BusinessProcess? SelectedBusinessProcess { get; set; }
    
    [Reactive] public string? ReportTitleFilter { get; set; }
    
    public ReportCVM()
    {
        Context = new MyDbContext();
        Context.Database.EnsureCreated();

        var items = Context.Reports
            .Include(x => x.VirtualRelease)
            .Include(x => x.VirtualReportCode)
            .Include(x => x.VirtualReportId)
            .Include(x => x.VirtualReportTitle)
            .Include(x => x.VirtualFormationFrequency)
            .Include(x => x.VirtualBusinessProcess)
            .Include(x => x.VirtualKeyfigure).ThenInclude(y => y.VirtualDataStatus)
            .Include(x => x.VirtualKeyfigure).ThenInclude(y => y.VirtualKeyfigureCategory)
            .Include(x => x.VirtualAnalyticalFeature)
            .ToList();

        var cbItems = Context.ReportIndicators.ToList();
        var relItems = Context.Releases.ToList();
        var periodItems = Context.FormationFrequencies.ToList();
        var bpItems = Context.BusinessProcesses.ToList();
        var statuses = Context.DataStatuss.ToList();
        var categories = Context.KeyfigureCategories.ToList();
        var ids = Context.ReportIds.ToList();
        
        var models = items.Distinct(new ReportPComparer());

        ReportModelsToList = new(models);
        
        ReportIDs = new(ids);
        ReportIndicators = new(cbItems);
        ReportReleases = new(relItems);
        FormationPeriodicity = new(periodItems);
        BusinessProcess = new(bpItems);
        DataStatuses = new(statuses);
        KeyfigureTypes = new(categories);
        
        //написать запрос по которому в списке отчетов будут только те, которые фомируются согласно выбранному БП
        var itemsForBP = Context.Reports
            .Include(x => x.VirtualRelease)
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
            .Do(val => F(val.Item1, val.Item2))
            .Subscribe();
    }

    private void F(BusinessProcess? bp, string? filter)
    {
        if (bp is null) return;
        filter ??= "";
        
        var items = ReportModelsToList
            .Where(r => r.BusinessProcessId == bp.value && r.ReportTitleId.ToLower().Contains(filter.ToLower()));
        ReportsFilterByBusinessProcess = new(items);

        
        
    }
    
}