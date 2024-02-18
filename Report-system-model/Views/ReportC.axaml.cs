using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Controls;
using System.Linq;
using Avalonia.Interactivity;
using ReactiveUI.Fody.Helpers;
using Report_system_model.ViewModels;

namespace Report_system_model.Views;

public partial class ReportC : UserControl
{
    public ReportC()
    {
        InitializeComponent();
        DataContext = new ReportCVM();
        MainDataGrid.Columns[0].IsVisible = false;
        MainDataGrid.Columns[1].IsVisible = false;
        MainDataGrid.Columns[2].IsVisible = false;
        MainDataGrid.Columns[3].IsVisible = false;
        MainDataGrid.Columns[4].IsVisible = false;
        MainDataGrid.Columns[5].IsVisible = false;
        MainDataGrid.Columns[6].IsVisible = false;
        MainDataGrid.Columns[7].IsVisible = false;
        MainDataGrid.Columns[8].IsVisible = false;
        MainDataGrid.Columns[9].IsVisible = false;
        MainDataGrid.Columns[10].IsVisible = false;
        MainDataGrid.Columns[11].IsVisible = false;
        
    }
    
    private void IsIndicatorCheckBoxChecked(object? sender, RoutedEventArgs e)
    {
        if (Box0.IsChecked.Value) MainDataGrid.Columns[0].IsVisible = true;
        else MainDataGrid.Columns[0].IsVisible = false;
    }

    private void IsReleaseCheckBoxChecked(object? sender, RoutedEventArgs e)
    {
        if (Box1.IsChecked.Value) MainDataGrid.Columns[1].IsVisible = true;
        else MainDataGrid.Columns[1].IsVisible = false;
    }

    private void IsReportCodeCheckBoxChecked(object? sender, RoutedEventArgs e)
    {
        if (Box2.IsChecked.Value) MainDataGrid.Columns[2].IsVisible = true;
        else MainDataGrid.Columns[2].IsVisible = false;
    }

    private void IsReportIdCheckBoxChecked(object? sender, RoutedEventArgs e)
    {
        if (Box3.IsChecked.Value) MainDataGrid.Columns[3].IsVisible = true;
        else MainDataGrid.Columns[3].IsVisible = false;
    }

    private void IsReportTitleCheckBoxChecked(object? sender, RoutedEventArgs e)
    {
        if (Box4.IsChecked.Value) MainDataGrid.Columns[4].IsVisible = true;
        else MainDataGrid.Columns[4].IsVisible = false;
    }

    private void IsPeriodicityCheckBoxChecked(object? sender, RoutedEventArgs e)
    {
        if (Box5.IsChecked.Value) MainDataGrid.Columns[5].IsVisible = true;
        else MainDataGrid.Columns[5].IsVisible = false;
    }

    private void IsBusinessProcessCheckBoxChecked(object? sender, RoutedEventArgs e)
    {
        if (Box6.IsChecked.Value) MainDataGrid.Columns[6].IsVisible = true;
        else MainDataGrid.Columns[6].IsVisible = false;
    }

    private void IsKeyfigureCodeCheckBoxChecked(object? sender, RoutedEventArgs e)
    {
        if (Box7.IsChecked.Value) MainDataGrid.Columns[7].IsVisible = true;
        else MainDataGrid.Columns[7].IsVisible = false;
    }

    private void IsKeyfigTitleChecked(object? sender, RoutedEventArgs e)
    {
        if (Box8.IsChecked.Value) MainDataGrid.Columns[8].IsVisible = true;
        else MainDataGrid.Columns[8].IsVisible = false;
    }
    
    private void IsDataStatusCheckBoxChecked(object? sender, RoutedEventArgs e)
    {
        if (Box9.IsChecked.Value) MainDataGrid.Columns[9].IsVisible = true;
        else MainDataGrid.Columns[9].IsVisible = false;
    }
    
    private void IsKeyfigTypeCheckBoxChecked(object? sender, RoutedEventArgs e)
    {
        if (Box10.IsChecked.Value) MainDataGrid.Columns[10].IsVisible = true;
        else MainDataGrid.Columns[10].IsVisible = false;
    }
    
    private void IsAnalytAttributeTitleChecked(object? sender, RoutedEventArgs e)
    {
        if (Box11.IsChecked.Value) MainDataGrid.Columns[11].IsVisible = true;
        else MainDataGrid.Columns[11].IsVisible = false;
    }
    private void FullNameStrChanged(object? sender, TextChangedEventArgs e)
    {
        //((MainWindowViewModel)DataContext).SearchString_OnChange(FullNameStr.Text);
    }
}