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

namespace Weddeberekening_2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        float SCALE0 = 0.2F;
        float SCALE1 = 0.3F;
        float SCALE2 = 0.4F;
        float SCALE3 = 0.5F;
        double TAX;
        double NETTO;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void calcButton_Click(object sender, RoutedEventArgs e)
        {
            double income = double.Parse(uurLoon.Text) * double.Parse(aantalUren.Text);
            if (income <= 10000)
            {
                TAX = 0;
            }
            else if (10000 < income && income <= 15000)
            {
                TAX = 5000 * SCALE0;

            }
            else if (15000 < income && income <= 25000)
            {
                TAX = 5000 * SCALE0 + 10000 * SCALE1;
            }
            else if (25000 < income && income <= 50000)
            {
                TAX =  ((income - 25000) * SCALE2) + (5000 * SCALE0) + (10000 * SCALE1);
            }
            else
            {
                TAX = income * SCALE3;
            }
            NETTO = income - TAX ;
            outputBox.Text = $"LOONFICHE VAN {personeelsLid.Text} \b\nAantal gewerkte uren : {aantalUren.Text} \b\nUurloon : {double.Parse(uurLoon.Text):c}\b\nBrutojaarwedde : {income:c} \b\nBelasting : {TAX:c}\b\nNettojaarwaarde : {NETTO:c}";
        }

        private void clearButton_Click(object sender, RoutedEventArgs e)
        {
            personeelsLid.Clear();
            uurLoon.Clear();
            aantalUren.Clear();
            outputBox.Text = $"LOONFICHE VAN  \b\nAantal gewerkte uren :  \b\nUurloon :\b\nBrutojaarwedde : \b\nBelasting : \b\nNettojaarwaarde :";
            personeelsLid.Focus();
        }

        private void closeButton_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}