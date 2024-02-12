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

public class ReportCVM : ViewModelBase
{
    [Reactive] public ObservableCollection<KeyfigureModel> keyfigureModels { get; set; }
    [Reactive] KeyfigureModel SelectedKeyfigureModel { get; set; }
    [Reactive] public string searchString { get; set; }
    public ReactiveCommand<KeyfigureModel, Unit> ButtonClickCommand_1 { get; private set; }
}