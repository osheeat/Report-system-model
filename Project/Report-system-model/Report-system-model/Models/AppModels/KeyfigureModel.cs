using System;
using System.Collections.Generic;
using Report_system_model.DBModels;
using System.Linq;
using ValueType = Report_system_model.DBModels.ValueType;

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
            KeyfigureModel model = new KeyfigureModel();
            model.SystemSource = new KeyfigureSystemSource();
            model.ServiceInformation = new KeyfigureServiceInformation();
            model.BasicInformation = new KeyfigureBasicInformation();
            var dbContext = new MyDbContext();
            var collection = dbContext.Keyfigures.ToList();
            foreach (var item in collection)
            {
                model.BasicInformation.Keyfigure = item;
                IndicatorSourceSystem curIndicatorSourceSystem =
                    dbContext.IndicatorSourceSystems.FirstOrDefault(p => p.KeyfigureId.Equals(item.Id));

                model.SystemSource.Company =
                    dbContext.Companies.FirstOrDefault(p => p.Id.Equals(curIndicatorSourceSystem.CompanyId));

                model.ServiceInformation.CurrencyUnit = dbContext.CurrencyUnits.FirstOrDefault(p => p.Value.Equals(item.CurrencyUnitId));

                model.BasicInformation.DataStatus = dbContext.DataStatuss.FirstOrDefault(p => p.Value.Equals(item.DataStatusId));

                model.SystemSource.IndicatorGenerationMethod =
                    dbContext.IndicatorGenerationMethods.FirstOrDefault(p =>
                        p.Value.Equals(item.IndicatorGenerationMethodId));

                model.SystemSource.IndicatorSourceSystem =
                    dbContext.IndicatorSourceSystems.FirstOrDefault(p =>
                        p.Id.Equals(curIndicatorSourceSystem.SourceSystemId));

                model.ServiceInformation.KeyfigureCategory =
                    dbContext.KeyfigureCategories.FirstOrDefault(p => p.Value.Equals(item.KeyfigureCategoryId));

                model.ServiceInformation.LoadTime = dbContext.LoadTimes.FirstOrDefault(p => p.Value.Equals(item.LoadTimeId));

                model.ServiceInformation.MethodOfObtaining =
                    dbContext.MethodsOfObtaining.FirstOrDefault(p => p.Value.Equals(item.MethodOfObtainingId));

                model.SystemSource.Release =
                    dbContext.Releases.FirstOrDefault(p => p.Value.Equals(curIndicatorSourceSystem.ReleaseId));

                model.ServiceInformation.ReportUsageIndicator =
                    dbContext.ReportUsageIndicators.FirstOrDefault(p => p.Value.Equals(item.ReportUsageIndicatorId));

                model.SystemSource.SourceSystem =
                    dbContext.SourceSystems.FirstOrDefault(p => p.Id.Equals(curIndicatorSourceSystem.Id));

                model.ServiceInformation.UploadDeadline =
                    dbContext.UploadDeadlines.FirstOrDefault(p => p.Value.Equals(item.UploadDeadlineId));

                model.ServiceInformation.ValueType = dbContext.ValueTypes.FirstOrDefault(p => p.Value.Equals(item.ValueTypeId));

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