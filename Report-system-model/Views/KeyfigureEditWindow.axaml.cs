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
        DataContext = new KeyfigureEditViewModel();
    }
    
    public KeyfigureEditWindow(KeyfigureModel model)
    {
        InitializeComponent();
        DataContext = new KeyfigureEditViewModel(model);

    
    public KeyfigureEditWindow()
    {
        InitializeComponent();

    }
}