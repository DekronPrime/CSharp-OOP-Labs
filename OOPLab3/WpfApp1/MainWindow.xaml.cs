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

namespace WpfApp1
{
    public partial class MainWindow : Window
    {
        private double[] array;
        private const double MinValue = -14.2;
        private const double MaxValue = 18.3;
        public MainWindow()
        {
            InitializeComponent();
            MinEdgeTb.Text = MinValue.ToString();
            MaxEdgeTb.Text = MaxValue.ToString();
        }

        private void GenerateArrayBtn_Click(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(InputNTb.Text, out int n) && n > 0)
            {
                Random random = new Random();
                array = new double[n];

                for (int i = 0; i < n; i++)
                {
                    var r = random.NextDouble();
                    array[i] = Math.Round(r * (MaxValue - MinValue) + MinValue, 1);
                }

                ArrayListBox.Items.Clear();
                foreach (var item in array)
                {
                    ArrayListBox.Items.Add(item);
                }

                int minElemIndex = Array.IndexOf(array, array.Min());
                int maxElemIndex = Array.IndexOf(array, array.Max());
                MinElIndexTb.Text = minElemIndex.ToString();
                MaxElIndexTb.Text = maxElemIndex.ToString();

                int startIndex = Math.Min(minElemIndex, maxElemIndex);
                int endIndex = Math.Max(minElemIndex, maxElemIndex);
                int sum = 0;
                for (int i = startIndex + 1; i < endIndex; i++)
                {
                    sum += i;
                }
                SumIndecesTb.Text = sum.ToString();

                ArrayBeforeSwappingListBox.Items.Clear();
                foreach (var item in array)
                {
                    ArrayBeforeSwappingListBox.Items.Add(item);
                }

                Array.Reverse(array, startIndex + 1, endIndex - startIndex - 1);

                ArrayAfterSwappingListBox.Items.Clear();
                foreach (var item in array)
                {
                    ArrayAfterSwappingListBox.Items.Add(item);
                }
            }
            else
            {
                MessageBox.Show("Неправильне значення n. Це має бути ціле число більше 0.", "Помилка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}