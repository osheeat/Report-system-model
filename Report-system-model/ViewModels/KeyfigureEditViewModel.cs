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
using SkiaSharp;
using Report_system_model.Views;


namespace Report_system_model.ViewModels;

public class KeyfigureEditViewModel
{
    [Reactive] public KeyfigureModel currModel { get; set; }

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    public KeyfigureEditViewModel()
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    {
    }

    public KeyfigureEditViewModel(KeyfigureModel selectedModel)
    {
        currModel = selectedModel;
        try
        {
            Console.WriteLine(currModel.BasicInformation.Keyfigure.FullName);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}