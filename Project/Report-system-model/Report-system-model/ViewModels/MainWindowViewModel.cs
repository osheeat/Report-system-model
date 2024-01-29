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
using Avalonia.Media;
using Microsoft.EntityFrameworkCore;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using SkiaSharp;
using Report_system_model.Views;

namespace Report_system_model.ViewModels;

public class MainWindowViewModel : ViewModelBase
{
    [Reactive] public ObservableCollection<KeyfigureModel> keyfigureModels { get; set; }
    [Reactive] public ObservableCollection<KeyfigureModel> staticKeyfigureModels { get; set; }
    [Reactive] public KeyfigureModel SelectedKeyfigureModel { get; set; }
    [Reactive] public string searchString { get; set; }
    private List<KeyfigureModel> keyList;
    
    public MainWindowViewModel()
    {
        MyDbContext db = new MyDbContext();
        db.Database.EnsureCreated();
        KeyfigureModel tmp = new KeyfigureModel();
        keyList = tmp.GetCompleteInformation().ToList();
        SelectedKeyfigureModel = new KeyfigureModel();
        staticKeyfigureModels = new ObservableCollection<KeyfigureModel>(keyList);
        keyfigureModels = new ObservableCollection<KeyfigureModel>(keyList);

        Console.WriteLine("dfse'liegjsdljg");
    }
}