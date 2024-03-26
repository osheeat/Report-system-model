using System;
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
                
                IndicatorSourceSystem ISS =
                    dbContext.IndicatorSourceSystems.FirstOrDefault(p => p.KeyfigureId.Equals(item.id));
                
                model.ServiceInformation.CurrencyUnit =
                    dbContext.CurrencyUnits.FirstOrDefault(p => p.value.Equals(item.CurrencyUnitId));

                model.BasicInformation.DataStatus =
                    dbContext.DataStatuss.FirstOrDefault(p => p.value.Equals(item.DataStatusId));

                model.SystemSource.IndicatorGenerationMethod =
                    dbContext.IndicatorGenerationMethods.FirstOrDefault(p =>
                        p.value.Equals(item.IndicatorGenerationMethodId));

                model.ServiceInformation.KeyfigureCategory =
                    dbContext.KeyfigureCategories.FirstOrDefault(p => p.value.Equals(item.KeyfigureCategoryId));

                model.ServiceInformation.LoadTime =
                    dbContext.LoadTimes.FirstOrDefault(p => p.value.Equals(item.LoadTimeId));

                model.ServiceInformation.MethodOfObtaining =
                    dbContext.MethodsOfObtaining.FirstOrDefault(p => p.value.Equals(item.MethodOfObtainingId));

                model.ServiceInformation.UploadDeadline =
                    dbContext.UploadDeadlines.FirstOrDefault(p => p.value.Equals(item.UploadDeadlineId));

                model.ServiceInformation.ValueType =
                    dbContext.ValueTypes.FirstOrDefault(p => p.value.Equals(item.ValueTypeId));
                
                model.SystemSource.SourceSystem =
                    dbContext.SourceSystems.FirstOrDefault(p => p.id.Equals(dbContext.IndicatorSourceSystems.FirstOrDefault(p => p.KeyfigureId.Equals(item.id)).SourceSystemId));

                if (model.SystemSource.SourceSystem == null)
                {
                    // Console.WriteLine("NULL:\t"+dbContext.IndicatorSourceSystems.FirstOrDefault(p => p.KeyfigureId.Equals(item.id)));
                    // Console.WriteLine(item.id);
                    // Console.WriteLine(item.FullName);
                    model.SystemSource.SourceSystem = dbContext.SourceSystems.FirstOrDefault(p => p.id.Equals(1));
                }
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