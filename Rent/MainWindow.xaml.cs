using System.Collections.Generic;
using System.Windows;
using Newtonsoft.Json;
using System.IO;

namespace Rent
{
    enum UserType
    {
        LandLord,
        Renter
    }

    enum PremisesType
    {
        Room,
        Apartment
    }

    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
    }
}