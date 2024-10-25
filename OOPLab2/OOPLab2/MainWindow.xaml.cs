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

namespace OOPLab2;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }

    private void calcBtn_Click(object sender, RoutedEventArgs e)
    {
        var cultureInfo = new CultureInfo("en-US");

        double x, y, z;

        if (!double.TryParse(TextBoxX.Text, NumberStyles.Float, cultureInfo, out x))
        {
            MessageBox.Show("Wrong value for x. Please, try again!", "Input Error", MessageBoxButton.OK, MessageBoxImage.Error);
            return;
        }

        if (!double.TryParse(TextBoxY.Text, NumberStyles.Float, cultureInfo, out y))
        {
            MessageBox.Show("Wrong value for y. Please, try again!", "Input Error", MessageBoxButton.OK, MessageBoxImage.Error);
            return;
        }

        if (!double.TryParse(TextBoxZ.Text, NumberStyles.Float, cultureInfo, out z))
        {
            MessageBox.Show("Wrong value for z. Please, try again!", "Input Error", MessageBoxButton.OK, MessageBoxImage.Error);
            return;
        }

        try
        {
            var numerator = (y - x) * Math.Cos(y) - (Math.Log10(z) / (x - y));
            var denominator = 1 + Math.Pow(x - z, 2);
            var s = numerator / denominator;

            ResultLabel.Content = $"S = {Math.Round(s, 3)}";
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error: {ex.Message}", "Calculation Error", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }
}