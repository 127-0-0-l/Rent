using System.Collections.Generic;
using System.Windows;
using Newtonsoft.Json;
using System.IO;
using System;
using System.Linq;
using System.Text;

namespace Rent
{
    public enum UserType
    {
        LandLord,
        Renter
    }

    public enum PremisesType
    {
        Room,
        Apartment
    }

    public partial class MainWindow : Window
    {
        private List<User> users;
        public User CurrentUser { get; private set; }

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            LoadUsers();
            Record.LoadCurrentID();
            RecordList.LoadRecords();
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            RecordList.SaveRecords();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if(tbLogin.Text.Length == 0)
                {
                    throw new Exception("введите логин");
                }

                if (tbPassword.Text.Length == 0)
                {
                    throw new Exception("введите пароль");
                }

                if (users.Where(u => u.Login == tbLogin.Text).Count() == 0)
                {
                    throw new Exception("пользователя не существует");
                }
                else
                {
                    var user = users.Where(u => u.Login == tbLogin.Text).FirstOrDefault();

                    if(user.Password != tbPassword.Text)
                    {
                        throw new Exception("пароль неверный");
                    }
                    else
                    {
                        CurrentUser = user;
                        grdAuthorization.Visibility = Visibility.Hidden;
                        grdMenu.Visibility = Visibility.Visible;

                        if(CurrentUser.TypeOfUser.Equals(UserType.Renter))
                        {
                            btnCreateRecord.Visibility = Visibility.Hidden;
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        private void btnCreateRecord_Click(object sender, RoutedEventArgs e)
        {
            grdMenu.Visibility = Visibility.Hidden;
            grdCreateRecord.Visibility = Visibility.Visible;
        }

        private void btnFindRecords_Click(object sender, RoutedEventArgs e)
        {
            grdMenu.Visibility = Visibility.Hidden;
            grdFindRecords.Visibility = Visibility.Visible;
            FilterData();
        }

        private void btnDeleteRecord_Click(object sender, RoutedEventArgs e)
        {
            grdMenu.Visibility = Visibility.Hidden;
            grdDeleteRecord.Visibility = Visibility.Visible;
            cbRecordID.ItemsSource = RecordList.Records.Select(o => o.ID);
            
        }

        private void btnCreateReport_Click(object sender, RoutedEventArgs e)
        {
            grdMenu.Visibility = Visibility.Hidden;
            grdCreateReport.Visibility = Visibility.Visible;
        }

        private void grdCreateRecord_MouseRightButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            grdCreateRecord.Visibility = Visibility.Hidden;
            grdMenu.Visibility = Visibility.Visible;
        }

        private void grdFindRecords_MouseRightButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            grdFindRecords.Visibility = Visibility.Hidden;
            grdMenu.Visibility = Visibility.Visible;
        }

        private void grdDeleteRecord_MouseRightButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            grdDeleteRecord.Visibility = Visibility.Hidden;
            grdMenu.Visibility = Visibility.Visible;
        }

        private void grdCreateReport_MouseRightButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            grdCreateReport.Visibility = Visibility.Hidden;
            grdMenu.Visibility = Visibility.Visible;
        }

        private void LoadUsers()
        {
            using(StreamReader file = new StreamReader(@".\Resources\Users.txt"))
            {
                users = JsonConvert.DeserializeObject<List<User>>(file.ReadToEnd());
            }
        }

        private void btnCreateRecordCreate_Click(object sender, RoutedEventArgs e)
        {
            if(tbAdress.Text.Length != 0 &&
               tbCost.Text.Length != 0 &&
               tbSquare.Text.Length != 0 &&
               tbRoomCount.Text.Length != 0)
            {
                try
                {
                    PremisesType typeOfPremisses =
                        cbPlacementType.Text == "Помещение" ?
                            PremisesType.Apartment :
                            PremisesType.Room;

                    string address = tbAdress.Text;
                    int square = int.Parse(tbSquare.Text);
                    int numberOfRooms = int.Parse(tbRoomCount.Text);
                    double price = double.Parse(tbCost.Text);

                    Record record = new Record(
                        typeOfPremisses,
                        address,
                        square,
                        numberOfRooms,
                        price,
                        CurrentUser.Name,
                        CurrentUser.PhoneNumber);
                    RecordList.AddRecord(record);

                    grdCreateRecord.Visibility = Visibility.Hidden;
                    grdMenu.Visibility = Visibility.Visible;

                    tbAdress.Text = "";
                    tbCost.Text = "";
                    tbSquare.Text = "";
                    tbRoomCount.Text = "";
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MessageBox.Show("error: empty fields");
            }
        }

        private void tbMinPrice_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            FilterData();
        }

        private void tbMaxPrice_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            FilterData();
        }

        private void tbMinSquare_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            FilterData();
        }

        private void tbMaxSquare_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            FilterData();
        }

        private void FilterData()
        {
            List<Record> records = new List<Record>(RecordList.Records);

            if (tbMinPrice.Text.Length > 0)
            {
                for (int i = 0; i < records.Count; i++)
                {
                    if (records[i].Price < int.Parse(tbMinPrice.Text))
                    {
                        records.Remove(records[i]);
                        i--;
                    }
                }
            }

            if (tbMaxPrice.Text.Length > 0)
            {
                for (int i = 0; i < records.Count; i++)
                {
                    if (records[i].Price > int.Parse(tbMaxPrice.Text))
                    {
                        records.Remove(records[i]);
                        i--;
                    }
                }
            }

            if (tbMinSquare.Text.Length > 0)
            {
                for (int i = 0; i < records.Count; i++)
                {
                    if (records[i].Square < int.Parse(tbMinSquare.Text))
                    {
                        records.Remove(records[i]);
                        i--;
                    }
                }
            }

            if (tbMaxSquare.Text.Length > 0)
            {
                for (int i = 0; i < records.Count; i++)
                {
                    if (records[i].Square < int.Parse(tbMaxSquare.Text))
                    {
                        records.Remove(records[i]);
                        i--;
                    }
                }
            }

            dtgrdTable.ItemsSource = records;
        }

        private void btnDeleteRecordDelete_Click(object sender, RoutedEventArgs e)
        {
            if (cbRecordID.Text.Length > 0)
            {
                RecordList.DeleteRecord(int.Parse(cbRecordID.Text));
                grdMenu.Visibility = Visibility.Visible;
                grdDeleteRecord.Visibility = Visibility.Hidden;
            }
        }

        private void btnCreateRecordsReport_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder str = new StringBuilder();

            foreach (var record in RecordList.Records)
            {
                str.Append(
                    $"\nID: {record.ID}" +
                    $"\nTypeOfPremises: {record.TypeOfPremises}" +
                    $"\nAddress: {record.Address}" +
                    $"\nSquare: {record.Square}" +
                    $"\nNumberOfRooms: {record.NumberOfRooms}" +
                    $"\nPrice: {record.Price}" +
                    $"\nLandLordName: {record.LandLordName}" +
                    $"\nLandLordPhoneNumber: {record.LandLordPhoneNumber}" +
                    $"\n\n");
            }

            ReportWindow window = new ReportWindow(str.ToString());
            window.Show();
        }

        private void btnCreateOperationsReport_Click(object sender, RoutedEventArgs e)
        {
            string operations;

            using (StreamReader file = new StreamReader(@".\Resources\History.txt"))
            {
                operations = file.ReadToEnd();
            }

            ReportWindow window = new ReportWindow(operations);
            window.Show();
        }
    }
}