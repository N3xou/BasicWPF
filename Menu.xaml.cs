using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
using System.Xml.Linq;
using MaterialDesignThemes;
namespace Projekt1
{
    /// <summary>
    /// Interaction logic for Menu.xaml
    /// </summary>


    public class Item : INotifyPropertyChanged
    {
        public int Id { get; set; }
        public string Pathtoimg { set; get; }
        public string Name { set; get; }
        public float Price { set; get; }
        public string Status { set; get; }

        private string textChangePrice;
        public string TextChangePrice
        {
            get { return textChangePrice; }
            set
            {
                textChangePrice = value;
                OnPropertyChanged();
            }
        }
        private string textSetStatus;
        public string TextSetStatus
        {
            get { return textSetStatus; }
            set
            {
                textSetStatus = value;
                OnPropertyChanged();
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }


    public partial class Menu : Window
    {
        /// <summary>
        ///public string TTT { set; get; }
        /// </summary>


        public string ChangePrice { set; get; }
        public string TextSoldOut { set; get; }
        List<Item> Items = new List<Item>();

        public void _BtnReturn(object sender, RoutedEventArgs e)
        {
            MainWindow WinMain = new MainWindow();
            WinMain.Show();
            this.Close();
        }
        public Menu()
        {
            InitializeComponent();



            DataContext = this;
            //LoadMenuOLD();
            LoadMenu();


            if (Globals.languageSelect == 1)
            {
                //eng
                TextImage.Text = "Image";
                TextName.Text = "Name";
                TextPrice.Text = "Price";
                TextActions.Text = "Actions";
                // changePriceButton.Content = "Change Price ";
                //StackPanel s = FindName("Stack") as StackPanel;

                //TextBox foundTextBox = FindChild<TextBox>(Application.Current.MainWindow, "myTextBoxName");
                foreach (Item It in Items)
                {
                    It.TextChangePrice = "Change Price";
                    It.TextSetStatus = "Change Status";
                }





            }
            else if (Globals.languageSelect == 2)
            {
                //pl
                TextImage.Text = "Zdjecie";
                TextName.Text = "Nazwa";
                TextPrice.Text = "Cena";
                TextActions.Text = "Opcje";
                ChangePrice = "Edytuj cene";
                TextSoldOut = "Sprzedane/Dostepne";
                foreach (Item It in Items)
                {
                    It.TextChangePrice = "Ustaw Cene";
                    It.TextSetStatus = "Zmien Status";
                }

            }
        }
        ~Menu()
        {
            //close DB connection
        }

        public void BtnChangePrice(object sender, RoutedEventArgs e)
        {
            // Get the item from the button's DataContext
            Item item = (sender as FrameworkElement)?.DataContext as Item;

            // Create an input dialog to get the new price

            // Update the item's price in the database
            PricePrompt pricePrompt = new PricePrompt();
            pricePrompt.ShowDialog();
            if (pricePrompt.DialogResult == true && Globals.PriceNew != 0)
            {
                // zmiana angielskiego menu
                string query = "UPDATE Menu SET price = @price WHERE ID = @id";
                using (MySqlConnection databaseConnection = new MySqlConnection(Globals.MySQLConnectString))
                {
                    MySqlCommand commandDatabase = new MySqlCommand(query, databaseConnection);
                    commandDatabase.Parameters.AddWithValue("@price", Globals.PriceNew);
                    commandDatabase.Parameters.AddWithValue("@id", item.Id);
                    try
                    {
                        databaseConnection.Open();
                        commandDatabase.ExecuteNonQuery();
                        //MessageBox.Show("Success");
                       
                        item.Price = Globals.PriceNew;
                        MenuGrid.Items.Refresh();

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex.Message);
                    }

                }
                // zmiana polskiego menu
                query = "UPDATE MenuPL SET price = @price WHERE ID = @id";
                using (MySqlConnection databaseConnection = new MySqlConnection(Globals.MySQLConnectString))
                {
                    MySqlCommand commandDatabase = new MySqlCommand(query, databaseConnection);
                    commandDatabase.Parameters.AddWithValue("@price", Globals.PriceNew);
                    commandDatabase.Parameters.AddWithValue("@id", item.Id);
                    try
                    {
                        databaseConnection.Open();
                        commandDatabase.ExecuteNonQuery();
                        //MessageBox.Show("Success");
                        // the refresh is not working. it only refreshes after closing and opening the window !!!!!!!
                        item.Price = Globals.PriceNew;
                        MenuGrid.Items.Refresh();

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex.Message);
                    }

                }
                Globals.PriceNew = 0;

            }

        }


        private void BtnSoldOut(object sender, RoutedEventArgs e)
        {
            // set database value to sold out
            // do not display if it's sold out on client end
            Item item = (sender as FrameworkElement)?.DataContext as Item;



            // zmiana angielskiego menu
            string query = "UPDATE Menu SET status = @status WHERE ID = @id";
            using (MySqlConnection databaseConnection = new MySqlConnection(Globals.MySQLConnectString))
            {
                string stat = (item.Status == "Available") ? "Sold Out" : "Available";
                MySqlCommand commandDatabase = new MySqlCommand(query, databaseConnection);
                commandDatabase.Parameters.AddWithValue("@status", stat);
                commandDatabase.Parameters.AddWithValue("@id", item.Id);
                try
                {
                    databaseConnection.Open();
                    commandDatabase.ExecuteNonQuery();
                    //MessageBox.Show("Success");
                    // the refresh is not working. it only refreshes after closing and opening the window !!!!!!!
                    item.Status = stat;
                    MenuGrid.Items.Refresh();

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }

            }
            query = "UPDATE menupl SET status = @status WHERE ID = @id";
            using (MySqlConnection databaseConnection = new MySqlConnection(Globals.MySQLConnectString))
            {
                string stat = (item.Status == "Dostepny") ? "Wyprzedane" : "Dostepny";
                MySqlCommand commandDatabase = new MySqlCommand(query, databaseConnection);
                commandDatabase.Parameters.AddWithValue("@status", stat);
                commandDatabase.Parameters.AddWithValue("@id", item.Id);
                try
                {
                    databaseConnection.Open();
                    commandDatabase.ExecuteNonQuery();
                    //MessageBox.Show("Success");
                    // the refresh is not working. it only refreshes after closing and opening the window !!!!!!!
                    //item.Status = stat;
                    MenuGrid.Items.Refresh();

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }

            }

        




        }

    // zmiana statusu w menu
    //using (MySqlConnection databaseConnection = new MySqlConnection(Globals.MySQLConnectString))
    //{
    //    MySqlCommand commandDatabase = new MySqlCommand(query, databaseConnection);
    //    MySqlCommand commandDatabasePL = new MySqlCommand(queryPL, databaseConnection);

    //    string stat = (item.Status == "Available") ? "Sold Out" : "Available";
    //    string statPL = (item.Status == "Dostepny") ? "Wyprzedane" : "Dostepny";

    //    commandDatabase.Parameters.AddWithValue("@status", stat);
    //    commandDatabase.Parameters.AddWithValue("@id", item.Id);

    //    commandDatabasePL.Parameters.AddWithValue("@status", statPL);
    //    commandDatabasePL.Parameters.AddWithValue("@id", item.Id);

    //    try
    //    {
    //        databaseConnection.Open();
    //        commandDatabase.ExecuteNonQuery();
    //        commandDatabasePL.ExecuteNonQuery();

    //        if (Globals.languageSelect == 1)
    //        {
    //            item.Status = stat;
    //        }
    //        else if (Globals.languageSelect == 2)
    //        {
    //            item.Status = statPL;
    //        }

    //        MenuGrid.Items.Refresh();
    //    }
    //    catch (Exception ex)
    //    {
    //        MessageBox.Show("Error:" + ex.Message);
    //    }

    //}



    //public static T FindChild<T>(DependencyObject parent, string childName) where T : DependencyObject
    //{
    //    if (parent == null) { return null; }
    //    T foundChild = null;
    //    int childrenCount = VisualTreeHelper.GetChildrenCount(parent);
    //    for (int i =0; i < childrenCount; i++)
    //    {
    //        var child = VisualTreeHelper.GetChild(parent, i);
    //        T childType = child as T;
    //        if (childType == null) 
    //        {
    //            foundChild = FindChild<T>(child, childName);
    //            if (foundChild != null) break;
    //        }
    //        else if (!string.IsNullOrEmpty(childName))
    //        {
    //            var frameworkElement = child as FrameworkElement;
    //            if (frameworkElement != null && frameworkElement.Name == childName)
    //            {
    //                foundChild = (T)child;
    //                    break;
    //            }
    //        }
    //        else
    //        {
    //            foundChild = (T)child;
    //            break;
    //        }
    //    }
    //    return foundChild;
    //}

    public void LoadMenu()
        {
            string query = (Globals.languageSelect == 1) ? "Select * from Menu" : "Select * from MenuPL";
            MenuGrid.ItemsSource = null;
            MenuGrid.Items.Clear();
            MenuGrid.ItemsSource = Items;


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

                            Item item = new Item()
                            {
                                Id = myReader.GetInt32(0),
                                Pathtoimg = myReader.GetString(1),
                                Name = myReader.GetString(2),
                                Price = myReader.GetFloat(3),
                                Status = myReader.GetString(4)
                            };
                            Items.Add(item);

                        }
                    }
                    myReader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
            MenuGrid.Items.Refresh();


        }


    }
}
// https://www.i-programmer.info/programming/wpf-workings/620-using-the-wpf-net-40-datagrid-.html?start=2
// https://www.youtube.com/watch?time_continue=241&v=OPDPI5exPp8&embeds_euri=https%3A%2F%2Fwww.google.com%2Fsearch%3Fq%3Dcreating%2Ba%2Blocal%2Bmysql%2Bdatabase%2Bfor%2Bwpf%26rlz%3D1C1CHBF_frFR1045FR1045%26sxsrf%3DAJOqlzXrKVAID4_zE-BuyIA&source_ve_path=Mjg2NjY&feature=emb_logo