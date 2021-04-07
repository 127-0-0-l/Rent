using System.Windows;
using Microsoft.Win32;
using System.IO;
using System.Windows.Controls;
using System.Windows.Documents;

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

            if (dialog.ShowDialog() == true)
            {
                using (StreamWriter sw = new StreamWriter(dialog.FileName))
                {
                    sw.Write(rtbReport.GetText());
                }
            }
        }
    }
}
