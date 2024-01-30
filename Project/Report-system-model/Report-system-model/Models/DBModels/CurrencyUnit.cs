using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Report_system_model.DBModels;

[Table("currency_unit")]
public class CurrencyUnit
{
    [Key] [MaxLength(250)] public string value { get; set; }
}