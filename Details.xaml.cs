using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
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
using static System.Net.Mime.MediaTypeNames;

namespace Projekt1
{
    /// <summary>
    /// Interaction logic for Details.xaml
    /// </summary>
    /// 
    public class Meal
    {
        public int id { get; set; }
        public string pathtoimg { get; set;}
        public string name { get; set;}
        public float price { get; set;}
        public int amount { get; set; }


    }
    public partial class Details : Window
    {
        public float priceTotal;
        public int idOrder;
        public string cmp="";
        List<Meal> Meals = new List<Meal>();
        public Details(int idOrder)
        {
            this.idOrder = idOrder;
            InitializeComponent();
            LoadDetails();


            if (Globals.languageSelect == 1)
            {
                //eng
                TextName.Text = "Name";
                TextImage.Text = "Image";
                TextPrice.Text = "Price";
                TextAmount.Text = "Amount";
                TextON.Text = "Order number: ";
                TextTP.Text = "Total price: ";
            }
            else if (Globals.languageSelect == 2)
            {
                //pl
                TextName.Text = "Nazwa";
                TextImage.Text = "Zdjecie";
                TextPrice.Text = "Cena";
                TextAmount.Text = "Ilosc";
                TextON.Text = "Numer zamowienia: ";
                TextTP.Text = "Cena razem: ";
            }
        }
        public Details(int idOrder, string cmp)
        {
            this.cmp = cmp;
            this.idOrder = idOrder;
            InitializeComponent();
            LoadDetails();


            if (Globals.languageSelect == 1)
            {
                //eng
                TextName.Text = "Name";
                TextImage.Text = "Image";
                TextPrice.Text = "Price";
                TextAmount.Text = "Amount";
                TextON.Text = "Order number: ";
                TextTP.Text = "Total price: ";
            }
            else if (Globals.languageSelect == 2)
            {
                //pl
                TextName.Text = "Nazwa";
                TextImage.Text = "Zdjecie";
                TextPrice.Text = "Cena";
                TextAmount.Text = "Ilosc";
                TextON.Text = "Numer zamowienia: ";
                TextTP.Text = "Cena razem: ";
            }
        }
        private void _BtnReturnDet(object sender, RoutedEventArgs e)
        {
            
            this.Close();
        }
        public void LoadDetails()
        {
            DetailsGrid.ItemsSource = null;
            DetailsGrid.Items.Clear();
            //DetailsGrid.ItemsSource = meals;

            // 1. Connect to the database
            MySqlConnection databaseConnection = new MySqlConnection(Globals.MySQLConnectString);
            databaseConnection.Open();

            // 2. Retrieve varchar value of "IDmeals" column where order id = this.idOrder
            string query;
            query = (cmp == "cmp") ? "SELECT idmeals FROM finishedorders WHERE ID = " + this.idOrder : "SELECT idmeals FROM activeorders WHERE ID = " + this.idOrder;
            MySqlCommand commandDatabase = new MySqlCommand(query, databaseConnection);
            MySqlDataReader reader = commandDatabase.ExecuteReader();
            // 3. Parse the varchar 
            List<int> mealIDs = new List<int>();
            while (reader.Read())
            {
                string[] ids = reader.GetString(0).Split(' ');
                foreach (string id in ids)
                {
                    mealIDs.Add(Int32.Parse(id));
                }
            }

            reader.Close();


            


            // 4. Retrieve Meals from the database

            query = (Globals.languageSelect == 1) ? "SELECT * FROM menu" : "SELECT * FROM menuPL";
            commandDatabase = new MySqlCommand(query, databaseConnection);
            reader = commandDatabase.ExecuteReader();
            int idm = 0;
            Dictionary<int, Meal> mealsDict = new Dictionary<int, Meal>();
            while (idm < mealIDs.Count)
            {
                reader.Read();
                int mealID = mealIDs[idm];
                if (!mealsDict.ContainsKey(mealID))
                {
                    Meal meal = new Meal()
                    {
                        id = mealID,
                        pathtoimg = reader.GetString(1),
                        name = reader.GetString(2),
                        price = reader.GetFloat(3),
                        amount = 1
                    };
                    mealsDict.Add(mealID, meal);
                }
                else
                {
                    mealsDict[mealID].amount++;
                }
                
                idm++;
            }

            reader.Close();

            // 5. Display the meals 
            List<Meal> meals = mealsDict.Values.ToList();
            DetailsGrid.ItemsSource = null;
            DetailsGrid.Items.Clear();
            DetailsGrid.ItemsSource = meals;

            // 6. add the price values into total price
            this.priceTotal = 0;

            foreach (Meal meal in meals)
            {
                this.priceTotal += meal.price * meal.amount;
                totalPrice.Text = this.priceTotal.ToString();
            }
            this.totalPrice.Text += "$";
            orderNum.Text = this.idOrder.ToString();


            query = "UPDATE activeorders SET price = @price WHERE ID = " + this.idOrder;

            commandDatabase = new MySqlCommand(query, databaseConnection);


            commandDatabase.Parameters.AddWithValue("@price", priceTotal);
            try
            {
                commandDatabase.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error:" + ex.Message);
            }


            DetailsGrid.Items.Refresh();
        }


    }
}
// 4. Retrieve Meals from the database 
// 5. Display the meals that ID's are in the list of the earlier created integers 
// 6. Only display each ID item ONCE but if there are multiple occurences, incriment the "amount" value
// 7. add the price values into total price