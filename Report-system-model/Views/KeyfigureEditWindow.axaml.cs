using System;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using ReactiveUI.Fody.Helpers;
using Report_system_model.AppModels;
using Report_system_model.ViewModels;

namespace Report_system_model.Views;

public partial class KeyfigureEditWindow : Window
{
    
    public KeyfigureEditWindow()
    {
        InitializeComponent();
    }
    
    public KeyfigureEditWindow(KeyfigureModel obj)
    {
        InitializeComponent();
        DataContext = new KeyfigureEditViewModel(obj);
    }
}