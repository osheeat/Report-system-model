using Report_system_model.AppModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Reactive;
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

public class ReportCVM : ViewModelBase
{
    //[Reactive] public ObservableCollection<KeyfigureModel> keyfigureModels { get; set; }
    
    [Reactive] public ObservableCollection<Report> ReportModels { get; set; }
    [Reactive] KeyfigureModel SelectedKeyfigureModel { get; set; }
    [Reactive] public string searchString { get; set; }
    public ReactiveCommand<KeyfigureModel, Unit> ButtonClickCommand_1 { get; private set; }

    private MyDbContext Context;
    
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

        ReportModels = new(items);
    }
}