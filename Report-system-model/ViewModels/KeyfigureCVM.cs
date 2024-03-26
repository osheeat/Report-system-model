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
using ValueType = System.ValueType;

namespace Report_system_model.ViewModels;

public class KeyfigureCVM : ViewModelBase
{
    [Reactive] public ObservableCollection<KeyfigureModel> keyfigureModels { get; set; }
    [Reactive] public ObservableCollection<KeyfigureModel> staticKeyfigureModels { get; set; }
    [Reactive] public KeyfigureModel SelectedKeyfigureModel { get; set; }

    [Reactive] public ObservableCollection<DataStatus> dataStatusFilter { get; set; }
    [Reactive] public ObservableCollection<DBModels.ValueType> valueTypeFilter { get; set; }
    [Reactive] public ObservableCollection<CurrencyUnit> сurrencyUnitFilter { get; set; }
    [Reactive] public ObservableCollection<MethodOfObtaining> methodOfObtainingFilter { get; set; }
    [Reactive] public ObservableCollection<KeyfigureCategory> keyfigureCategoryFilter { get; set; }

    [Reactive] public ObservableCollection<LoadTime> loadTimeFilter { get; set; }

    // [Reactive] public ObservableCollection<ReportUsageIndicator> reportUsageIndicatorFilter { get; set; }
    [Reactive] public ObservableCollection<UploadDeadline> uploadDeadlineFilter { get; set; }
    [Reactive] public string dataStatusSelected { get; set; }
    [Reactive] public string ValueTypeSelected { get; set; }
    [Reactive] public string currencyUnitSelected { get; set; }
    [Reactive] public string methodOfObtainingSelected { get; set; }
    [Reactive] public string keyfigureCategorySelected { get; set; }
    [Reactive] public string loadTimeSelected { get; set; }
    [Reactive] public string reportUsageIndicatorSelected { get; set; }
    [Reactive] public string uploadDeadlineSelected { get; set; }

    public ReactiveCommand<Unit, Unit> ButtonClickCommand { get; private set; }
    public ReactiveCommand<KeyfigureModel, Unit> ButtonClickCommand_1 { get; private set; }

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

        List<DataStatus> dataStatusList = new List<DataStatus>();
        List<DBModels.ValueType> valueTypeList = new List<DBModels.ValueType>();
        List<CurrencyUnit> сurrencyUnitList = new List<CurrencyUnit>();
        List<MethodOfObtaining> methodOfObtainingList = new List<MethodOfObtaining>();
        List<KeyfigureCategory> keyfigureCategoryList = new List<KeyfigureCategory>();
        List<LoadTime> loadTimeList = new List<LoadTime>();
        // List<ReportUsageIndicator> reportUsageIndicatorList = new List<ReportUsageIndicator>();
        List<UploadDeadline> uploadDeadlineList = new List<UploadDeadline>();

        dataStatusList = staticKeyfigureModels.Select(m => m.BasicInformation.DataStatus).Distinct().ToList();
        dataStatusFilter = new ObservableCollection<DataStatus>(dataStatusList);

        valueTypeList = staticKeyfigureModels.Select(m => m.ServiceInformation.ValueType).Distinct().ToList();
        valueTypeFilter = new ObservableCollection<DBModels.ValueType>(valueTypeList);

        сurrencyUnitList = staticKeyfigureModels.Select(m => m.ServiceInformation.CurrencyUnit).Distinct().ToList();
        сurrencyUnitFilter = new ObservableCollection<CurrencyUnit>(сurrencyUnitList);

        methodOfObtainingList = staticKeyfigureModels.Select(m => m.ServiceInformation.MethodOfObtaining).Distinct()
            .ToList();
        methodOfObtainingFilter = new ObservableCollection<MethodOfObtaining>(methodOfObtainingList);

        keyfigureCategoryList = staticKeyfigureModels.Select(m => m.ServiceInformation.KeyfigureCategory).Distinct()
            .ToList();
        keyfigureCategoryFilter = new ObservableCollection<KeyfigureCategory>(keyfigureCategoryList);

        loadTimeList = staticKeyfigureModels.Select(m => m.ServiceInformation.LoadTime).Distinct().ToList();
        loadTimeFilter = new ObservableCollection<LoadTime>(loadTimeList);


        uploadDeadlineList = staticKeyfigureModels.Select(m => m.ServiceInformation.UploadDeadline).Distinct().ToList();
        uploadDeadlineFilter = new ObservableCollection<UploadDeadline>(uploadDeadlineList);

        int k = 0;
        foreach (var item in keyfigureModels)
        {
            if (item.SystemSource.SourceSystem == null)
            {
                k++;
                Console.WriteLine(item.BasicInformation.Keyfigure.FullName);
            }
        }

        Console.WriteLine(k);
        Console.WriteLine(keyfigureModels.Count);
    }

    private Unit Execute(KeyfigureModel obj)
    {
        KeyfigureEditWindow newWindow = new KeyfigureEditWindow();
        KeyfigureModel objPlus = new KeyfigureModel();
        if (obj != null)
        {
            if (obj.BasicInformation.DataStatus.value == "Факт")
            {
                if (staticKeyfigureModels.Where(x =>
                        x.BasicInformation.Keyfigure.FullName == obj.BasicInformation.Keyfigure.FullName &&
                        x.BasicInformation.DataStatus.value == "План").ToList().Count != 0)
                {
                    objPlus = staticKeyfigureModels.FirstOrDefault(x =>
                        x.BasicInformation.Keyfigure.FullName == obj.BasicInformation.Keyfigure.FullName &&
                        x.BasicInformation.DataStatus.value == "План");
                    newWindow = new KeyfigureEditWindow(obj, objPlus);
                }
                else
                {
                    newWindow = new KeyfigureEditWindow(obj, objPlus);
                }
            }

            if (obj.BasicInformation.DataStatus.value == "План")
            {
                if (staticKeyfigureModels.Where(x =>
                        x.BasicInformation.Keyfigure.FullName == obj.BasicInformation.Keyfigure.FullName &&
                        x.BasicInformation.DataStatus.value == "Факт").ToList().Count != 0)
                {
                    objPlus = staticKeyfigureModels.FirstOrDefault(x =>
                        x.BasicInformation.Keyfigure.FullName == obj.BasicInformation.Keyfigure.FullName &&
                        x.BasicInformation.DataStatus.value == "Факт");
                    newWindow = new KeyfigureEditWindow(obj, objPlus);
                }
                else
                {
                    newWindow = new KeyfigureEditWindow(obj, objPlus);
                }
            }
        }
        else
        {
            newWindow = new KeyfigureEditWindow();
        }

        newWindow.Show();
        return Unit.Default;
    }

    public void FullNameSearchString_OnChange(string str)
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

    public void SwitchCollectionWithDataStatus(bool switchStatus)
    {
        if (switchStatus)
        {
            keyfigureModels = staticKeyfigureModels;
        }
        else
        {
            keyfigureModels = new ObservableCollection<KeyfigureModel>();
            foreach (var item in staticKeyfigureModels)
            {
                if (!keyfigureModels.Select(x => x.BasicInformation.Keyfigure.FullName)
                        .Contains(item.BasicInformation.Keyfigure.FullName))
                    keyfigureModels.Add(item);
            }
        }
    }
}