using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Report_system_model.AppModels;
using Report_system_model.ViewModels;
using Report_system_model.DBModels;

namespace Report_system_model.Views;

public partial class ReportEditWindow : Window
{
    public ReportEditWindow()
    {
        InitializeComponent();
        DataContext = new ReportEditViewModel();
    }
    
    public ReportEditWindow(Report selectedReport)
    {
        InitializeComponent();
        DataContext = new ReportEditViewModel(selectedReport);
        
    }
}