using System.Globalization;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp2
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void OnCalculateButtonClick(object sender, RoutedEventArgs e)
        {
            var cultureInfo = new CultureInfo("en-US");

            double a, b, c;

            if (!double.TryParse(TextBoxA.Text, NumberStyles.Float, cultureInfo, out a) || a == 0)
            {
                MessageBox.Show("Неправильне значення для a. Це має бути число. Спробуйте ще раз!", "Input Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (!double.TryParse(TextBoxB.Text, NumberStyles.Float, cultureInfo, out b))
            {
                MessageBox.Show("Неправильне значення для b. Це має бути число. Спробуйте ще раз!", "Input Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (!double.TryParse(TextBoxC.Text, NumberStyles.Float, cultureInfo, out c))
            {
                MessageBox.Show("Неправильне значення для c. Це має бути число. Спробуйте ще раз!", "Input Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            double discriminant = Math.Pow(b, 2) - 4 * a * c;

            if (discriminant > 0)
            {
                double x1 = (-b + Math.Sqrt(discriminant)) / (2 * a);
                double x2 = (-b - Math.Sqrt(discriminant)) / (2 * a);
                messageLbl.Content = "Дане рівняння має 2 корені";
                LblX1.Visibility = Visibility.Visible;
                TbX1.Visibility = Visibility.Visible;
                LblX2.Visibility = Visibility.Visible;
                TbX2.Visibility = Visibility.Visible;
                TbX1.Text = x1.ToString();
                TbX2.Text = x2.ToString();
            }
            else if (discriminant == 0)
            {
                double x = -b / (2 * a);
                messageLbl.Content = "Дане рівняння має 1 корінь";
                LblX1.Visibility = Visibility.Visible;
                TbX1.Visibility = Visibility.Visible;
                LblX2.Visibility = Visibility.Hidden;
                TbX2.Visibility = Visibility.Hidden;
                TbX1.Text = x.ToString();
            }
            else
            {
                messageLbl.Content = "Дане рівняння не має коренів";
                LblX1.Visibility = Visibility.Hidden;
                TbX1.Visibility = Visibility.Hidden;
                LblX2.Visibility = Visibility.Hidden;
                TbX2.Visibility = Visibility.Hidden;
            }
        }
    }
}