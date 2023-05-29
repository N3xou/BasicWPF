using Org.BouncyCastle.Asn1.X509;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using MySql.Data.MySqlClient;
using System.Reflection;
using System.Runtime.Remoting.Messaging;

namespace Projekt1
{
    /// <summary>
    /// Interaction logic for MainControl.xaml
    /// </summary>
    /// 
    static public class Globals
    {
        static public string MySQLConnectString = "datasource=127.0.0.1;port=3306;username=root;password=;database=projekt";
        static public int languageSelect = 1; // 1 = eng // 2 = pl
        static public float PriceNew = 0;

    }

    public class Order : INotifyPropertyChanged
    {
        public int id { get; set; }
        public float price { get; set; }

        public DateTime time { get; set; }

        public string idmeals { get; set; }

        private string textBtnDetails;
        public string TextBtnDetails
        {
            get { return textBtnDetails; }
            set
            {
                textBtnDetails = value;
                OnPropertyChanged();
            }
        }
        private string textBtnComplete;
        public string TextBtnComplete
        {
            get { return textBtnComplete; }
            set
            {
                textBtnComplete = value;
                OnPropertyChanged();
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


    }
    public partial class MainWindow : Window
    {

        
        public int LanguageSelect;
        List<Order> activeOrders = new List<Order>();

        public MainWindow()
        {
            InitializeComponent();
            LoadOrders();
            if (Globals.languageSelect == 1)
            {
                TextID.Text = "ID";
                TextOrderTime.Text = "Order Time";
                TextMenu.Text = "Menu";
                TextDetails.Text = "Details";
                TextCompletedOrders.Text = "Completed Orders";
                TextCompletedOrders.FontSize = 26;


            }
            else if (Globals.languageSelect == 2)
            {
                TextID.Text = "ID";
                TextOrderTime.Text = "Czas Zamowienia";
                TextMenu.Text = "Menu";
                TextDetails.Text = "Szczegoly";
                TextCompletedOrders.Text = "Zakonczone zamowienia";
                TextCompletedOrders.FontSize = 22;




            }

        }
        private void ButtonMenuClicked(object sender, RoutedEventArgs e)
        {
            Menu WinMenu = new Menu();
            WinMenu.Show();
            this.Close();

        }
        private void ButtonCmpOrdersClicked(object sender, RoutedEventArgs e)
        {
            CompletedOrders WinCmp = new CompletedOrders();
            WinCmp.Show();
            this.Close();

        }
        public void LanguageENGClicked(object sender, RoutedEventArgs e)
        {
            TextID.Text = "ID";
            TextOrderTime.Text = "Order Time";
            TextMenu.Text = "Menu";
            TextDetails.Text = "Details";
            TextCompletedOrders.Text = "Completed Orders";
            TextCompletedOrders.FontSize = 26;

            Globals.languageSelect = 1;
            foreach (Order Or in activeOrders)
            {
                Or.TextBtnDetails = "View";
                Or.TextBtnComplete = "Complete";
            }


        }
        public void LanguagePLClicked(object sender, RoutedEventArgs e)
        {
            TextID.Text = "ID";
            TextOrderTime.Text = "Czas Zamowienia";
            TextMenu.Text = "Menu";
            TextDetails.Text = "Szczegoly";
            TextCompletedOrders.Text = "Ukonczone zamowienia";
            TextCompletedOrders.FontSize = 22;
            foreach (Order Or in activeOrders)
            {
                Or.TextBtnDetails = "Wyswietl";
                Or.TextBtnComplete = "Zrobione";
            }
            Globals.languageSelect = 2;



        }
        public void _BtnDetails(object sender, RoutedEventArgs e)
        {
            // Get the order from the button's DataContext
            Order order = (Order)((Button)sender).DataContext;

            // Create a new instance of the WinDet window and pass the order ID as an argument
            Details winDet = new Details(order.id);
            order.price = winDet.priceTotal;
            // Show the window
            winDet.Show();
        }


        public void NextWindow()
        {
            return;
        }
        public void _BtnComplete(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = new MessageBoxResult();
            if (Globals.languageSelect == 1)
            {
                result = MessageBox.Show("Are you sure you want to complete order?", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question);
            }
            else if (Globals.languageSelect == 2)
            {
                result = MessageBox.Show("Czy na pewno zakonczyc?", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question);
            }
            if (result == MessageBoxResult.Yes)
            {
                // proceed to the next window

                MainGrid.Items.Refresh();
                Order order = (sender as FrameworkElement)?.DataContext as Order;
                if (order != null)
                {
                    // Move order to FinishedOrders table
                    string moveQuery = "INSERT INTO FinishedOrders (ID, Price, OrderTime, idmeals) VALUES (@ID, @Price, @OrderTime, @idmeals)";

                    // Remove order from ActiveOrders table
                    string removeQuery = "DELETE FROM ActiveOrders WHERE ID = @ID";
                    string MySQLConnectString = "datasource=127.0.0.1;port=3306;username=root;password=;database=projekt";
                    using (MySqlConnection databaseConnection = new MySqlConnection(MySQLConnectString))
                    {

                        MySqlCommand moveCommand = new MySqlCommand(moveQuery, databaseConnection);
                        moveCommand.Parameters.AddWithValue("@ID", order.id);
                        moveCommand.Parameters.AddWithValue("@Price", order.price);
                        moveCommand.Parameters.AddWithValue("@OrderTime", order.time);
                        moveCommand.Parameters.AddWithValue("@idmeals", order.idmeals);
                        MySqlCommand removeCommand = new MySqlCommand(removeQuery, databaseConnection);
                        removeCommand.Parameters.AddWithValue("@ID", order.id);
                        try
                        {
                            databaseConnection.Open();
                            // Move order to FinishedOrders table
                            int moveRowsAffected = moveCommand.ExecuteNonQuery();
                            if (moveRowsAffected == 1)
                            {
                                // Order successfully moved to FinishedOrders table
                                // Remove order from ActiveOrders table
                                int removeRowsAffected = removeCommand.ExecuteNonQuery();
                                if (removeRowsAffected == 1)
                                {
                                    // Order successfully removed from ActiveOrders table
                                    // Remove order from activeOrders list
                                    activeOrders.Remove(order);

                                    MainGrid.Items.Refresh();
                                }
                                else
                                {
                                    // Failed to remove order from ActiveOrders table
                                    MessageBox.Show("Failed to remove order from ActiveOrders table.");
                                }
                            }
                            else
                            {
                                // Failed to move order to FinishedOrders table
                                MessageBox.Show("Failed to move order to FinishedOrders table.");
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error: " + ex.Message);
                        }
                    }
                }
            }
        }

        public void LoadOrders()
        {
            string query = "Select * from ActiveOrders";
            MainGrid.ItemsSource = null;
            MainGrid.Items.Clear();
            MainGrid.ItemsSource = activeOrders;
            
            
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
                                idmeals = myReader.GetString(2),
                                price = (myReader.GetDataTypeName(3) == "float") ? myReader.GetFloat(3) : 0,
                                TextBtnDetails = "View",
                                TextBtnComplete = "Complete"
                            };
                            activeOrders.Add(order);
                            
                        }
                    }
                    myReader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
            MainGrid.Items.Refresh();


        }
    }
}

