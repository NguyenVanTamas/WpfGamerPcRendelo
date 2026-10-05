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

namespace WpfGamerPcRendelo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
            if (!isNameValid()) { return; }
            if (!isAgeValid()) { return; }
            if (!isEmailValid()) { return; }
            if (!isCpuChosen()) { return; }
            if (!isGpuChosen()) { return; }
            if (!isRamChosen()) { return; }
            if (!isAmountValid()) { return; }
            if (!areTermsAccepted()) { return; }

            int price = 0;
            int pricePerPc = 0;
            int pcAmount = Convert.ToInt32(tbAmount.Text.Trim());
            int cpu1 = 70000; int cpu2 = 110000; int cpu3 = 65000; int cpu4 = 105000;
            int gpu1 = 130000; int gpu2 = 220000; int gpu3 = 400000;
            int ram1 = 20000; int ram2 = 35000; int ram3 = 65000;
            int extra1 = 15000; int extra2 = 45000; int extra3 = 25000; int extra4 = 18000;
            int warranty1 = 0; int warranty2 = 30000; int warranty3 = 60000;

            if (combCpu.SelectedIndex == 0){ pricePerPc += cpu1; }
            if (combCpu.SelectedIndex == 1) { pricePerPc += cpu2; }
            if (combCpu.SelectedIndex == 2) { pricePerPc += cpu3; }
            if (combCpu.SelectedIndex == 3) { pricePerPc += cpu4; }

            if (rbGpu1.IsChecked == true) {  pricePerPc += gpu1; }
            if (rbGpu2.IsChecked == true) { pricePerPc += gpu2; }
            if (rbGpu3.IsChecked == true) { pricePerPc += gpu3; }

            if (rbRam1.IsChecked == true) { pricePerPc += ram1; }
            if (rbRam2.IsChecked == true) { pricePerPc += ram2; }
            if (rbRam3.IsChecked == true) { pricePerPc += ram3; }

            if (cbExtra1.IsChecked == true) { pricePerPc += extra1; }
            if (cbExtra2.IsChecked == true) { pricePerPc += extra2; }
            if (cbExtra3.IsChecked == true) { pricePerPc += extra3; }
            if (cbExtra4.IsChecked == true) { pricePerPc += extra4; }

            if (cbWarranty1.IsChecked == true) { pricePerPc *= warranty1; }
            if (cbWarranty2.IsChecked == true) { pricePerPc *= warranty2; }
            if (cbWarranty3.IsChecked == true) { pricePerPc *= warranty3; }

            price = pricePerPc * pcAmount;
            MessageBox.Show(
                $"Sikeres rendelés!\n" +
                $"Név: {tbName.Text.Trim()}\n" +
                $"E-mail: {tbEmail.Text.Trim()}\n" +
                $"Vásárolt gépek ára darabonként: {pricePerPc}\n" +
                $"Vásárolt gépek száma: {pcAmount}\n" +
                $"Összár: {price}"
                );
        }
        private bool isNameValid()
        {
            if (tbName.Text == "")
            {
                MessageBox.Show(
                    "A név mező nem lehet üres!",
                    "Hiba",
                    MessageBoxButton.OK,
                    MessageBoxImage.Error
                    );
                return false;
            }
            if (tbName.Text.Trim().Length < 3)
            {
                MessageBox.Show(
                    "A névnek legalább 3 karakter hosszúnak kell lennie!",
                    "Hiba",
                    MessageBoxButton.OK,
                    MessageBoxImage.Error
                    );
                return false;
            }
            return true;
        }
        private bool isAgeValid()
        {
            try
            {
                int age = Int32.Parse(tbAge.Text.Trim());
            }
            catch(FormatException)
            {
                MessageBox.Show(
                    "Az életkornak számnak kell lennie!",
                    "Hiba",
                    MessageBoxButton.OK,
                    MessageBoxImage.Error
                    );
                return false;
            }
            if (Int32.Parse(tbAge.Text.Trim()) < 14)
            {
                MessageBox.Show(
                    "Az életkornak legalább 14-nek kell lennie!",
                    "Hiba",
                    MessageBoxButton.OK,
                    MessageBoxImage.Error
                    );
                return false;
            }
            if (Int32.Parse(tbAge.Text.Trim()) > 120)
            {
                MessageBox.Show(
                    "Az életkor legfeljebb 120 lehet!",
                    "Hiba",
                    MessageBoxButton.OK,
                    MessageBoxImage.Error
                    );
                return false;
            }
            return true;
        }
        private bool isEmailValid()
        {
            if (tbEmail.Text == "")
            {
                MessageBox.Show(
                    "Az E-mail mező nem lehet üres!",
                    "Hiba",
                    MessageBoxButton.OK,
                    MessageBoxImage.Error
                    );
                return false;
            }
            if (!(tbEmail.Text.Trim().Contains("@")))
            {
                MessageBox.Show(
                    "Az E-mailnek tartalmaznia kell @ karaktert!",
                    "Hiba",
                    MessageBoxButton.OK,
                    MessageBoxImage.Error
                    );
                return false;
            }
            if (!(tbEmail.Text.Trim().Contains(".")))
            {
                MessageBox.Show(
                    "Az E-mailnek tartalmaznia kell . karaktert!",
                    "Hiba",
                    MessageBoxButton.OK,
                    MessageBoxImage.Error
                    );
                return false;
            }
            if (tbEmail.Text.Trim().Contains(" "))
            {
                MessageBox.Show(
                    "Az E-mail nem tartalmazhat szóközt!",
                    "Hiba",
                    MessageBoxButton.OK,
                    MessageBoxImage.Error
                    );
                return false;
            }
            return true;
        }
        private bool isCpuChosen()
        {
            if (combCpu.SelectedItem == null)
            {
                MessageBox.Show(
                    "Ki kell választanod egy processzort!",
                    "Hiba",
                    MessageBoxButton.OK,
                    MessageBoxImage.Error
                    );
                return false;
            }
            return true;
        }
        private bool isGpuChosen()
        {
            bool chosen = false;
            if (rbGpu1.IsChecked == true){chosen = true;}
            if (rbGpu2.IsChecked == true){chosen = true;}
            if (rbGpu3.IsChecked == true){chosen = true;}
            if (!chosen)
            {
                MessageBox.Show(
                    "Ki kell választanod egy videokártyát!",
                    "Hiba",
                    MessageBoxButton.OK,
                    MessageBoxImage.Error
                    );
                return false;
            }
            return true;
        }
        private bool isRamChosen()
        {
            bool chosen = false;
            if (rbRam1.IsChecked == true){chosen = true;}
            if (rbRam2.IsChecked == true){chosen = true;}
            if (rbRam3.IsChecked == true){chosen = true;}
            if (!chosen)
            {
                MessageBox.Show(
                    "Ki kell választanod egy memória mennyiséget!",
                    "Hiba",
                    MessageBoxButton.OK,
                    MessageBoxImage.Error
                    );
                return false;
            }
            return true;
        }
        private bool isAmountValid()
        {
            try
            {
                int amount = Int32.Parse(tbAmount.Text.Trim());
            }
            catch (FormatException)
            {
                MessageBox.Show(
                    "A darabszámnak számnak kell lennie!",
                    "Hiba",
                    MessageBoxButton.OK,
                    MessageBoxImage.Error
                    );
                return false;
            }
            if (Int32.Parse(tbAmount.Text.Trim()) < 1)
            {
                MessageBox.Show(
                    "A darabszámnak legalább 1-nek kell lennie!",
                    "Hiba",
                    MessageBoxButton.OK,
                    MessageBoxImage.Error
                    );
                return false;
            }
            if (Int32.Parse(tbAmount.Text.Trim()) > 5)
            {
                MessageBox.Show(
                    "A darabszám legfeljebb 5 lehet!",
                    "Hiba",
                    MessageBoxButton.OK,
                    MessageBoxImage.Error
                    );
                return false;
            }
            return true;
        }
        private bool areTermsAccepted()
        {
            if (cbTerms.IsChecked == false)
            {
                MessageBox.Show(
                    "El kell adnod a lelked!",
                    "Hiba",
                    MessageBoxButton.OK,
                    MessageBoxImage.Error
                    );
                return false;
            }
            return true;
        }
    }
}