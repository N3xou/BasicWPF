using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Projekt1
{
    /// <summary>
    /// Interaction logic for TodayOrders.xaml
    /// </summary>
    public partial class CompletedOrders : Window
    {
        List<Order> completedOrders = new List<Order>();
        public CompletedOrders()
        {
            
            InitializeComponent();
            LoadCompletedOrders();
                if (Globals.languageSelect == 1)
                {
                    //eng
                    TextID.Text = "ID";
                    TextOrderTime.Text = "Order Time";
                    TextDetails.Text = "Details";
            }
                else if (Globals.languageSelect == 2)
                {
                //pl
                    TextID.Text = "ID";
                    TextOrderTime.Text = "Data zamowienia";
                    TextDetails.Text = "Szczegoly";
            }
        }

        public void _BtnDetails(object sender, RoutedEventArgs e)
        {
            // Get the order from the button's DataContext
            Order order = (Order)((Button)sender).DataContext;

            // Create a new instance of the WinDet window and pass the order ID as an argument
            Details winDet = new Details(order.id, "cmp");
            
            // Show the window
            winDet.Show();
        }
        private void _BtnReturn(object sender, RoutedEventArgs e)
        {
            MainWindow WinMain = new MainWindow();
            WinMain.Show();
            this.Close();
        }
        private void LoadCompletedOrders()
        {
            string query = "Select * from finishedOrders";
            completedGrid.ItemsSource = null;
            completedGrid.Items.Clear();
            completedGrid.ItemsSource = completedOrders;


            using (MySqlConnection databaseConnection = new MySqlConnection(Globals.MySQLConnectString))
            {
                MySqlCommand commandDatabase = new MySqlCommand(query, databaseConnection);
                try
                {
                    databaseConnection.Open();
                    MySqlDataReader myReader = commandDatabase.ExecuteReader();
                    if (myReader.HasRows)
                    {
                        while (myReader.Read())
                        {

                            Order order = new Order()
                            {
                                id = myReader.GetInt32(0),
                                time = myReader.GetFieldValue<DateTime>(1),
                                price = myReader.GetFloat(3),
                                TextBtnDetails = (Globals.languageSelect == 1) ?"View": "Wyswietl"
                            };
                            completedOrders.Add(order);

                        }
                    }
                    myReader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
            completedGrid.Items.Refresh();
        }
    }
}
