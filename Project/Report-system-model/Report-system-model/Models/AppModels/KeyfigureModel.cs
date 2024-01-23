﻿using System;
using System.Collections.Generic;
using Report_system_model.DBModels;
using System.Linq;
using valueType = Report_system_model.DBModels.ValueType;

namespace Report_system_model.AppModels;

public class KeyfigureModel
{
    public KeyfigureBasicInformation BasicInformation { get; set; }
    public KeyfigureServiceInformation ServiceInformation { get; set; }
    public KeyfigureSystemSource SystemSource { get; set; }
    public List<KeyfigureModel> GetCompleteInformation()
    {
        List<KeyfigureModel> curList = new List<KeyfigureModel>();
        try
        {
            KeyfigureModel model;
            var dbContext = new MyDbContext();
            var collection = dbContext.Keyfigures.ToList();
            foreach (var item in collection)
            {
                model = new KeyfigureModel();
                model.SystemSource = new KeyfigureSystemSource();
                model.ServiceInformation = new KeyfigureServiceInformation();
                model.BasicInformation = new KeyfigureBasicInformation();
                model.BasicInformation.Keyfigure = item;
                // IndicatorSourceSystem curIndicatorSourceSystem =
                //     dbContext.IndicatorSourceSystems.FirstOrDefault(p => p.KeyfigureId.Equals(item.Id));

                // model.SystemSource.Company =
                //     dbContext.Companies.FirstOrDefault(p => p.Id.Equals(curIndicatorSourceSystem.CompanyId));

                model.ServiceInformation.CurrencyUnit = dbContext.CurrencyUnits.FirstOrDefault(p => p.value.Equals(item.currencyUnitId));

                model.BasicInformation.DataStatus = dbContext.DataStatuss.FirstOrDefault(p => p.value.Equals(item.dataStatusId));

                model.SystemSource.IndicatorGenerationMethod =
                    dbContext.IndicatorGenerationMethods.FirstOrDefault(p =>
                        p.value.Equals(item.indicatorGenerationMethodId));

                // model.SystemSource.IndicatorSourceSystem =
                //     dbContext.IndicatorSourceSystems.FirstOrDefault(p =>
                //         p.Id.Equals(curIndicatorSourceSystem.SourceSystemId));

                model.ServiceInformation.KeyfigureCategory =
                    dbContext.KeyfigureCategories.FirstOrDefault(p => p.value.Equals(item.keyfigureCategoryId));

                model.ServiceInformation.LoadTime = dbContext.LoadTimes.FirstOrDefault(p => p.value.Equals(item.loadTimeId));

                model.ServiceInformation.MethodOfObtaining =
                    dbContext.MethodsOfObtaining.FirstOrDefault(p => p.value.Equals(item.methodOfObtainingId));

                // model.SystemSource.Release =
                //     dbContext.Releases.FirstOrDefault(p => p.value.Equals(curIndicatorSourceSystem.ReleaseId));

                model.ServiceInformation.ReportUsageIndicator =
                    dbContext.ReportUsageIndicators.FirstOrDefault(p => p.value.Equals(item.reportUsageIndicatorId));

                // model.SystemSource.SourceSystem =
                //     dbContext.SourceSystems.FirstOrDefault(p => p.Id.Equals(curIndicatorSourceSystem.Id));

                model.ServiceInformation.UploadDeadline =
                    dbContext.UploadDeadlines.FirstOrDefault(p => p.value.Equals(item.uploadDeadlineId));

                model.ServiceInformation.ValueType = dbContext.ValueTypes.FirstOrDefault(p => p.value.Equals(item.valueTypeId));

                curList.Add(model);
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
        return curList;
    }
}