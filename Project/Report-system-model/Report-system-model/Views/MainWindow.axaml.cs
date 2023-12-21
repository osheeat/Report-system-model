using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Interactivity;

namespace Report_system_model.Views;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        grGrid.ColumnDefinitions[0].Width  = new GridLength(0);
        grGrid.ColumnDefinitions[1].Width  = new GridLength(0);
        grGrid.ColumnDefinitions[2].Width  = new GridLength(0);
        grGrid.ColumnDefinitions[3].Width  = new GridLength(0);
        grGrid.ColumnDefinitions[4].Width  = new GridLength(0);
    }

    private void IsFullNameCheckBoxChecked(object? sender, RoutedEventArgs e)
    {
        if (Box1.IsChecked.Value)
        {
            grGrid.ColumnDefinitions[0].Width = new GridLength(1000, GridUnitType.Star);
        }
        else
        {
            grGrid.ColumnDefinitions[0].Width  = new GridLength(0);
        }
    }
    private void IsShortNameCheckBoxChecked(object? sender, RoutedEventArgs e)
    {
        if (Box2.IsChecked.Value)
        {
            grGrid.ColumnDefinitions[1].Width = new GridLength(1000, GridUnitType.Star);
        }
        else
        {
            grGrid.ColumnDefinitions[1].Width  = new GridLength(0);
        }
    }
    private void IsDataStatusCheckBoxChecked(object? sender, RoutedEventArgs e)
    {
        if (Box3.IsChecked.Value)
        {
            grGrid.ColumnDefinitions[2].Width = new GridLength(1000, GridUnitType.Star);
        }
        else
        {
            grGrid.ColumnDefinitions[2].Width  = new GridLength(0);
        }
    }
    private void IsValueTypeCheckBoxChecked(object? sender, RoutedEventArgs e)
    {
        if (Box4.IsChecked.Value)
        {
            grGrid.ColumnDefinitions[3].Width = new GridLength(1000, GridUnitType.Star);
        }
        else
        {
            grGrid.ColumnDefinitions[3].Width  = new GridLength(0);
        }
    }
    private void IsUnitheckBoxChecked(object? sender, RoutedEventArgs e)
    {
        if (Box5.IsChecked.Value)
        {
            grGrid.ColumnDefinitions[4].Width = new GridLength(1000, GridUnitType.Star);
        }
        else
        {
            grGrid.ColumnDefinitions[4].Width  = new GridLength(0);
        }
    }

}