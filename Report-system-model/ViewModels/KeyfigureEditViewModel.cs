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
    [Reactive] public KeyfigureModel currModelFact { get; set; }
    [Reactive] public KeyfigureModel currModelPlan { get; set; }
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
    [Reactive] public LoadTime selectedLoadTimeFact { get; set; } //this
    [Reactive] public LoadTime selectedLoadTimePlan { get; set; }
    [Reactive] public ObservableCollection<UploadDeadline> uploadDeadlineList { get; set; }
    [Reactive] public UploadDeadline selectedUploadDeadlineFact { get; set; } //this
    [Reactive] public UploadDeadline selectedUploadDeadlinePlan { get; set; }
    [Reactive] public ObservableCollection<SourceSystem> sourceSystemList { get; set; }
    [Reactive] public SourceSystem selectedSourceSystemFact { get; set; } //this
    [Reactive] public SourceSystem selectedSourceSystemPlan { get; set; }

    private void Initializing_additional_parameters()
    {
        var dbContext = new MyDbContext();
        dataStatusList = new ObservableCollection<DataStatus>(dbContext.DataStatuss.ToList());
        valueTypeList = new ObservableCollection<ValueType>(dbContext.ValueTypes.ToList());
        currencyUnitList = new ObservableCollection<CurrencyUnit>(dbContext.CurrencyUnits.ToList());
        keyfigureCategoryList = new ObservableCollection<KeyfigureCategory>(dbContext.KeyfigureCategories.ToList());
        methodOfObtainingList = new ObservableCollection<MethodOfObtaining>(dbContext.MethodsOfObtaining.ToList());
        loadTimeList = new ObservableCollection<LoadTime>(dbContext.LoadTimes.ToList());
        uploadDeadlineList = new ObservableCollection<UploadDeadline>(dbContext.UploadDeadlines.ToList());
        sourceSystemList = new ObservableCollection<SourceSystem>(dbContext.SourceSystems.ToList());
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

        if (currModelPlan != null)
        {
            if (currModelPlan.SystemSource != null && currModelPlan.SystemSource.SourceSystem != null)
            {
                selectedSourceSystemPlan = sourceSystemList.FirstOrDefault(value =>
                    value.title == currModelPlan.SystemSource.SourceSystem.title);
            }

            if (currModelPlan.ServiceInformation != null && currModelPlan.ServiceInformation.UploadDeadline != null)
            {
                selectedUploadDeadlinePlan = uploadDeadlineList.FirstOrDefault(value =>
                    value.value == currModelPlan.ServiceInformation.UploadDeadline.value);
            }

            if (currModelPlan.ServiceInformation != null && currModelPlan.ServiceInformation.LoadTime != null)
            {
                selectedLoadTimePlan = loadTimeList.FirstOrDefault(value =>
                    value.value == currModelPlan.ServiceInformation.LoadTime.value);
            }
        }

        if (currModelFact != null)
        {
            if (currModelFact.ServiceInformation != null && currModelFact.ServiceInformation.LoadTime != null)
            {
                selectedLoadTimeFact = loadTimeList.FirstOrDefault(value =>
                    value.value == currModelFact.ServiceInformation.LoadTime.value);
            }

            if (currModelFact.ServiceInformation != null && currModelFact.ServiceInformation.UploadDeadline != null)
            {
                selectedUploadDeadlineFact = uploadDeadlineList.FirstOrDefault(value =>
                    value.value == currModelFact.ServiceInformation.UploadDeadline.value);
            }

            if (currModelFact.SystemSource != null && currModelFact.SystemSource.SourceSystem != null)
            {
                selectedSourceSystemFact = sourceSystemList.FirstOrDefault(value =>
                    value.title == currModelFact.SystemSource.SourceSystem.title);
            }
        }
    }

    public KeyfigureEditViewModel(KeyfigureModel selectedModel, KeyfigureModel secondSelectedModel)
    {
        if (selectedModel == null)
        {
            currModel = secondSelectedModel;
        }
        else
        {
            currModel = selectedModel;
        }

        if (selectedModel.BasicInformation.DataStatus.value == "Факт")
        {
            currModelFact = selectedModel;
            currModelPlan = secondSelectedModel;
        }

        if (selectedModel.BasicInformation.DataStatus.value == "План")
        {
            currModelFact = secondSelectedModel;
            currModelPlan = selectedModel;
        }

        Initializing_additional_parameters();
    }
}