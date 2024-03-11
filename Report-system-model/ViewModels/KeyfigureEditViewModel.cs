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
using ValueType = Report_system_model.DBModels.ValueType;


namespace Report_system_model.ViewModels;

public class KeyfigureEditViewModel
{
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    public KeyfigureEditViewModel()
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    {
    }
    [Reactive] public KeyfigureModel currModel { get; set; }
    [Reactive] public ObservableCollection<DataStatus> dataStatusList { get; set; }
    [Reactive] public DataStatus selectedDataStatus { get; set; }
    [Reactive] public ObservableCollection<DBModels.ValueType> valueTypeList { get; set; }
    [Reactive] public DBModels.ValueType selectedValueType { get; set; }
    [Reactive] public ObservableCollection<CurrencyUnit> currencyUnitList { get; set; }
    [Reactive] public CurrencyUnit selectedCurrencyUnit { get; set; }
    [Reactive] public ObservableCollection<MethodOfObtaining> methodOfObtainingList { get; set; }
    [Reactive] public MethodOfObtaining selectedMethodOfObtaining { get; set; }
    [Reactive] public ObservableCollection<KeyfigureCategory> keyfigureCategoryList { get; set; }
    [Reactive] public KeyfigureCategory selectedKeyfigureCategory { get; set; }
    [Reactive] public ObservableCollection<LoadTime> loadTimeList { get; set; }
    [Reactive] public LoadTime selectedLoadTime { get; set; }
    [Reactive] public ObservableCollection<UploadDeadline> uploadDeadlineList { get; set; }
    [Reactive] public UploadDeadline selectedUploadDeadline { get; set; }
    [Reactive] public ObservableCollection<ReportUsageIndicator> reportUsageIndicatorList { get; set; }
    [Reactive] public ReportUsageIndicator selectedReportUsageIndicator { get; set; }
    public KeyfigureEditViewModel(KeyfigureModel selectedModel)
    {
        currModel = selectedModel;
        var dbContext = new MyDbContext();
        dataStatusList = new ObservableCollection<DataStatus>(dbContext.DataStatuss.ToList());
        valueTypeList = new ObservableCollection<ValueType>(dbContext.ValueTypes.ToList());
        currencyUnitList = new ObservableCollection<CurrencyUnit>(dbContext.CurrencyUnits.ToList());
        keyfigureCategoryList = new ObservableCollection<KeyfigureCategory>(dbContext.KeyfigureCategories.ToList());
        methodOfObtainingList = new ObservableCollection<MethodOfObtaining>(dbContext.MethodsOfObtaining.ToList());
        loadTimeList = new ObservableCollection<LoadTime>(dbContext.LoadTimes.ToList());
        uploadDeadlineList = new ObservableCollection<UploadDeadline>(dbContext.UploadDeadlines.ToList());
        reportUsageIndicatorList = new ObservableCollection<ReportUsageIndicator>(dbContext.ReportUsageIndicators.ToList());
        if (currModel.BasicInformation != null && currModel.BasicInformation.DataStatus != null)
        {
            selectedDataStatus = dataStatusList.FirstOrDefault(status => 
                status.value == currModel.BasicInformation.DataStatus.value);
        }
        if (currModel.ServiceInformation != null && currModel.ServiceInformation.ValueType != null)
        {
            selectedValueType = valueTypeList.FirstOrDefault(value => 
                value.value == currModel.ServiceInformation.ValueType.value);
        }
        if (currModel.ServiceInformation != null && currModel.ServiceInformation.CurrencyUnit != null)
        {
            selectedCurrencyUnit = currencyUnitList.FirstOrDefault(value => 
                value.value == currModel.ServiceInformation.CurrencyUnit.value);
        }
        if (currModel.ServiceInformation != null && currModel.ServiceInformation.MethodOfObtaining != null)
        {
            selectedMethodOfObtaining = methodOfObtainingList.FirstOrDefault(value => 
                value.value == currModel.ServiceInformation.MethodOfObtaining.value);
        }
        if (currModel.ServiceInformation != null && currModel.ServiceInformation.KeyfigureCategory != null)
        {
            selectedKeyfigureCategory = keyfigureCategoryList.FirstOrDefault(value => 
                value.value == currModel.ServiceInformation.KeyfigureCategory.value);
        }
        if (currModel.ServiceInformation != null && currModel.ServiceInformation.LoadTime != null)
        {
            selectedLoadTime = loadTimeList.FirstOrDefault(value => 
                value.value == currModel.ServiceInformation.LoadTime.value);
        }
        if (currModel.ServiceInformation != null && currModel.ServiceInformation.UploadDeadline != null)
        {
            selectedUploadDeadline = uploadDeadlineList.FirstOrDefault(value => 
                value.value == currModel.ServiceInformation.UploadDeadline.value);
        }
        if (currModel.ServiceInformation != null && currModel.ServiceInformation.ReportUsageIndicator != null)
        {
            selectedReportUsageIndicator = reportUsageIndicatorList.FirstOrDefault(value => 
                value.value == currModel.ServiceInformation.ReportUsageIndicator.value);
        }
    }
}