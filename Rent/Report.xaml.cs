using System.Windows;
using Microsoft.Win32;

namespace Rent
{
    public partial class ReportWindow : Window
    {
        public ReportWindow(string reportText)
        {
            InitializeComponent();

            rtbReport.AppendText(reportText);
        }

        private void btnSaveReport_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.ShowDialog();
        }
    }
}
