using System;
using System.Collections.Generic;
using System.ComponentModel;
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

namespace Projekt1
{
    /// <summary>
    /// Interaction logic for PricePrompt.xaml
    /// </summary>
    /// 
  
    public partial class PricePrompt : Window
    {
        private float _price = 0;
        public float PriceNew
        {
            get { return _price; }
            set
            {
                _price = value;
            }
        }

        public PricePrompt()
        {
            InitializeComponent();
            DataContext = this;
            setNewPrice.Text = (Globals.languageSelect == 1) ? "Set new price" : "Wpisz nowa cene";
        }

        public void Done_Click(object sender, RoutedEventArgs e)
        {
            Globals.PriceNew = this.PriceNew;
            DialogResult = true;
            Close();
        }

    }

}
