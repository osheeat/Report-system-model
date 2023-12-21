using Report_system_model.AppModels;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
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
    public ReactiveCommand<Unit, Unit> IsFullNameCheckBoxChecked { get; set; }
    [Reactive] public bool FullNemeCheck { get; set; }
    [Reactive] public int showFullName { get; set; }
    [Reactive] public int showShortName { get; set; }
    [Reactive] public int showDataStatus { get; set; }
    public MainWindowViewModel()
    {
        MyDbContext db = new MyDbContext();
        db.Database.EnsureCreated();
        KeyfigureModel tmp = new KeyfigureModel();
        keyfigureModels = new ObservableCollection<KeyfigureModel>(tmp.GetCompleteInformation().ToList());

        IsFullNameCheckBoxChecked = ReactiveCommand.Create(FullNameCheckBoxChecked);
    }
    private void FullNameCheckBoxChecked()
    {
        if (FullNemeCheck == true)
        {
            showFullName = 200;
            
        }
        else
        {
            showFullName = 0;
        }
    }
}