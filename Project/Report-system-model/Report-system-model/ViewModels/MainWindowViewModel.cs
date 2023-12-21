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

namespace Report_system_model.ViewModels;

public class MainWindowViewModel : ViewModelBase
{
    [Reactive] public int showFullName { get; set; }
    [Reactive] public int showShortName { get; set; }
    [Reactive] public int showDataStatus { get; set; }
    [Reactive] public ObservableCollection<KeyfigureModel> keyfigureModels { get; set; }
    public ReactiveCommand<Unit, Unit> IsFullNameCheckBoxChecked { get; }
    [Reactive] public bool FullNemeCheck { get; set; }
    public MainWindowViewModel()
    {
        MyDbContext db = new MyDbContext();
        db.Database.EnsureCreated();
        KeyfigureModel tmp = new KeyfigureModel();
        keyfigureModels = new ObservableCollection<KeyfigureModel>(tmp.GetCompleteInformation().ToList());
        IsFullNameCheckBoxChecked= ReactiveCommand.Create(() =>
        {
            if (FullNemeCheck == true)
            {
                showFullName = 200;
                
            }
            else
            {
                showFullName = 0;
            }
        });
    }
}