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