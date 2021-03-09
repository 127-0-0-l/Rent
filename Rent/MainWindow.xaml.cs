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

                        if(CurrentUser.TypeOfUser == (int)UserType.LandLord)
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

        private void LoadUsers()
        {
            using(StreamReader file = new StreamReader(@".\Resources\Users.txt"))
            {
                users = JsonConvert.DeserializeObject<List<User>>(file.ReadToEnd());
            }
        }
    }
}