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
using Avalonia.Markup.Xaml;
using Avalonia.Media;
using Microsoft.EntityFrameworkCore;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using Report_system_model.DBModels;
using SkiaSharp;
using Report_system_model.Views;

namespace Report_system_model.ViewModels;

public class KeyfigureCVM : ViewModelBase
{
    [Reactive] public ObservableCollection<KeyfigureModel> keyfigureModels { get; set; }
    [Reactive] public ObservableCollection<KeyfigureModel> staticKeyfigureModels { get; set; }
    [Reactive] public KeyfigureModel SelectedKeyfigureModel { get; set; }
    [Reactive] public string searchString { get; set; }

    private List<KeyfigureModel> keyList;
    public ReactiveCommand<Unit, Unit> ButtonClickCommand { get; private set; }

    public ReactiveCommand<KeyfigureModel, Unit> ButtonClickCommand_1 { get; private set; }
    [Reactive] public ObservableCollection<DataStatus> dataStatusFilter { get; set; }
    [Reactive] public string dataStatusSelected { get; set; }

    public KeyfigureCVM()
    {
        MyDbContext db = new MyDbContext();
        db.Database.EnsureCreated();
        KeyfigureModel tmp = new KeyfigureModel();
        List<KeyfigureModel> keyList = tmp.GetCompleteInformation().ToList();
        SelectedKeyfigureModel = new KeyfigureModel();
        staticKeyfigureModels = new ObservableCollection<KeyfigureModel>(keyList);
        keyfigureModels = new ObservableCollection<KeyfigureModel>(keyList);
        ButtonClickCommand_1 = ReactiveCommand.Create<KeyfigureModel, Unit>(Execute);
        List<DataStatus> tempList = new List<DataStatus>();
        tempList = staticKeyfigureModels
            .Select(m => m.BasicInformation.DataStatus).Distinct().ToList();
        dataStatusFilter = new ObservableCollection<DataStatus>(tempList);

    }

    private Unit Execute(KeyfigureModel obj)
    {
        KeyfigureEditWindow newWindow;
        if (obj != null)
        {
            newWindow = new KeyfigureEditWindow(obj);
        }
        else
        {
            newWindow = new KeyfigureEditWindow();
        }

        newWindow.Show();
        return Unit.Default;
    }

    public void SearchString_OnChange(string str)
    {
        List<KeyfigureModel> tmpList = new List<KeyfigureModel>();
        if (str != "")
        {
            tmpList = staticKeyfigureModels.Where(x => x.BasicInformation.Keyfigure.FullName.Contains(str))
                .ToList();
            keyfigureModels = new ObservableCollection<KeyfigureModel>(tmpList);
        }
        else
        {
            keyfigureModels = staticKeyfigureModels;
        }
    }

    /// <summary>
    /// Это очень сложная и тонкая вешь ю ноу блин
    /// </summary>
    /// <param name="switchStatus">Отображается ли столбец со статусом данных</param>
    public void SwitchCollectionWithDataStatus(bool switchStatus)
    {
        // List<string> uniqueListStr = staticKeyfigureModels
        //     .Select(m => m.BasicInformation.Keyfigure.FullName)
        //     .Distinct()
        //     .ToList();
        // List<KeyfigureModel> uniqueList = new List<KeyfigureModel>();
        // if (switchStatus == true)
        // {
        //     // foreach (var item in staticKeyfigureModels)
        //     // {
        //     //     if (uniqueList.Count != 0)
        //     //         foreach (var iqwe in uniqueList)
        //     //         {
        //     //             if (ComparisonByDataStatus(item, iqwe))
        //     //             {
        //     //                 uniqueList.Add(item);
        //     //             }
        //     //         }
        //     //     else uniqueList.Add(item);
        //     // }
        //     keyfigureModels = new ObservableCollection<KeyfigureModel>(uniqueList);
        // }
        // else
        // {
        //     keyfigureModels = staticKeyfigureModels;
        // }
        keyfigureModels = staticKeyfigureModels;
    }

    public bool ComparisonByDataStatus(KeyfigureModel a, KeyfigureModel b)
    {
        if (a.BasicInformation.Keyfigure.FullName == b.BasicInformation.Keyfigure.FullName &&
            a.BasicInformation.DataStatus.value != b.BasicInformation.DataStatus.value) return true;
        else return false;
    }
}