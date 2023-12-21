using Report_system_model.AppModels;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Reactive;
using Avalonia.Media;
using Microsoft.EntityFrameworkCore;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;

namespace Report_system_model.ViewModels;

public class MainWindowViewModel : ViewModelBase
{
    public MainWindowViewModel()
    {   
        MyDbContext db = new MyDbContext();
        db.Database.EnsureCreated();
        KeyfigureModel tmp = new KeyfigureModel();
        keyfigureModels = new ObservableCollection<KeyfigureModel>(tmp.GetCompleteInformation().ToList());
    }

    [Reactive] public ObservableCollection<KeyfigureModel> keyfigureModels { get; set; }
}