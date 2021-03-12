using System.Collections.Generic;
using System.Windows;
using Newtonsoft.Json;
using System.IO;
using System;
using System.Linq;
using System.Windows.Media;

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
        }

        private void btnDeleteRecord_Click(object sender, RoutedEventArgs e)
        {
            grdMenu.Visibility = Visibility.Hidden;
            grdDeleteRecord.Visibility = Visibility.Visible;
        }

        private void btnCreateReport_Click(object sender, RoutedEventArgs e)
        {
            grdMenu.Visibility = Visibility.Hidden;
            grdCreateReport.Visibility = Visibility.Visible;
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

                    Record record = new Record(typeOfPremisses, address, square, numberOfRooms, price, CurrentUser);
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
        }
    }
}