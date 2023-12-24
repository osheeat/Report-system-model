using Report_system_model.AppModels;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Reactive;
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
    [Reactive] public KeyfigureModel SelectedKeyfigureModel { get; set; }
    public MainWindowViewModel()
    {
        MyDbContext db = new MyDbContext();
        db.Database.EnsureCreated();
        KeyfigureModel tmp = new KeyfigureModel();
        SelectedKeyfigureModel = new KeyfigureModel();
        keyfigureModels = new ObservableCollection<KeyfigureModel>(tmp.GetCompleteInformation().ToList());
    }
}