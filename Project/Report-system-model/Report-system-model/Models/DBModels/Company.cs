﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Report_system_model.DBModels;

[Table ("company")]
public class Company
{
    public int Id { get; set; }
    [MaxLength(500)] public string Title { get; set; }
}