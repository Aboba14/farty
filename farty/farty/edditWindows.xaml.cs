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

namespace farty
{
    /// <summary>
    /// Логика взаимодействия для edditWindows.xaml
    /// </summary>
    public partial class edditWindows : Window
    {
        public static abobaEntities db = new abobaEntities();
        public Product CurrentProduct { get; set; }
        public IEnumerable<ProductType> productType { get; set; }


        public edditWindows(Product product)
        {
            InitializeComponent();
            DataContext = this;
            CurrentProduct = product;
            productType = Core.db.ProductType.ToArray();
        }
        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (CurrentProduct.ProductType == null)
                    throw new Exception("Не выбран тип");

                if (CurrentProduct.ID == 0)
                    Core.db.Product.Add(CurrentProduct);

                Core.db.SaveChanges();

                DialogResult = true;

            }
            catch
            {
                MessageBox.Show($"Сохранено");

                this.Close();
            }
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
