using CardGeneratorCore.CardGenerator;
using CardGeneratorCore.Cards;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CardGeneratorUI
{
    public partial class MainWindow : Window
    {
        private readonly ICard _visa;
        private readonly ICard _masterCard;
        private readonly ICard _mir;
        private readonly RandomCard _customCard;
        private readonly ICard[] _cards;

        private readonly ICardGenerator _cardgenerator;

        public ICard RandomCard { get; set; }

        public MainWindow()
        {
            InitializeComponent();

            _visa = new Visa();

            _masterCard = new MasterCard();

            _mir = new Mir();

            _customCard = new RandomCard();

            _cardgenerator = new CardGeneratorController();

            _cards = new ICard[]
            {
                _visa,
                _masterCard,
                _mir,
                _customCard
            };
        }
        #region CardGenerateBtns

        private async void GenerateVisaBtn_Click(object sender, RoutedEventArgs e)
        {
            if (VisaTab.IsSelected)
            {
                if (IsDigitsOnly(VisaCountTxtBox.Text)
                                    && !string.IsNullOrEmpty(VisaCountTxtBox.Text))
                {
                    VisaTextBoxMain.Text = await _cards[0].GenerateCardAsync(
                                        _visa.BinArray, int.Parse(VisaCountTxtBox.Text));
                }
            }
        }

        private async void GenerateMCardBtn_Click(object sender, RoutedEventArgs e)
        {
            if (MCardTab.IsSelected)
            {
                if (IsDigitsOnly(MCardCountTxtBox.Text) &&
                    !string.IsNullOrEmpty(MCardCountTxtBox.Text))
                {
                    MCardTextBoxMain.Text = await _cards[1].GenerateCardAsync(
                                        _masterCard.BinArray, int.Parse(MCardCountTxtBox.Text));
                }
            }
        }

        private async void GenerateMirBtn_Click(object sender, RoutedEventArgs e)
        {
            if (MirTab.IsSelected)
            {
                if (IsDigitsOnly(MirCountTxtBox.Text)
                    && !string.IsNullOrEmpty(MirCountTxtBox.Text))
                {
                    MirTextBoxMain.Text = await _cards[2].GenerateCardAsync(
                                        _mir.BinArray, int.Parse(MirCountTxtBox.Text));
                }
            }
        }

        private async void GenerateCustomBtn_Click(object sender, RoutedEventArgs e)
        {
            if (CustomCardTab.IsSelected)
            {
                if (IsDigitsOnly(CustomCountTxtBox.Text)
                    && !string.IsNullOrEmpty(CustomCountTxtBox.Text)
                    && IsDigitsOnly(NewBinTxtBox.Text)
                    && !string.IsNullOrEmpty(NewBinTxtBox.Text))
                {
                    CustomCardTextBoxMain.Text = await _customCard.GenerateCardAsync(
                                        Int32.Parse(NewBinTxtBox.Text), int.Parse(CustomCountTxtBox.Text));
                }
            }
        }

        #endregion

        #region CardValidateBtns

        private async void ValidateVisaBtn_Click(object sender, RoutedEventArgs e)
        {
            if (IsDigitsOnly(ValidateVisaTxtBox.Text) 
                && !string.IsNullOrEmpty(ValidateVisaTxtBox.Text))
            {
                bool result = await _cardgenerator.LuhnAlgorithmValidationAsync(ValidateVisaTxtBox.Text);

                if (result)
                    MessageBox.Show("Карта прошла проверку");
                else
                    MessageBox.Show("Карта не валидна");
            }
            else
                MessageBox.Show("Номер карты должен состоять из цифр");
        }

        private async void ValidateMCardBtn_Click(object sender, RoutedEventArgs e)
        {
            if (IsDigitsOnly(ValidateMCardTxtBox.Text)
                && !string.IsNullOrEmpty(ValidateMCardTxtBox.Text))
            {
                bool result = await _cardgenerator.LuhnAlgorithmValidationAsync(ValidateMCardTxtBox.Text);

                if (result)
                    MessageBox.Show("Карта прошла проверку");
                else
                    MessageBox.Show("Карта не валидна");
            }
            else
                MessageBox.Show("Номер карты должен состоять из цифр");
        }

        private async void ValidaetMirBtn_Click(object sender, RoutedEventArgs e)
        {
            if (IsDigitsOnly(ValidateMirTxtBox.Text)
                && !string.IsNullOrEmpty(ValidateMirTxtBox.Text))
            {
                bool result = await _cardgenerator.LuhnAlgorithmValidationAsync(ValidateMirTxtBox.Text);

                if (result)
                    MessageBox.Show("Карта прошла проверку");
                else
                    MessageBox.Show("Карта не валидна");
            }
            else
                MessageBox.Show("Номер карты должен состоять из цифр");
        }

        private async void ValidaetCustomBtn_Click(object sender, RoutedEventArgs e)
        {
            if (IsDigitsOnly(ValidateCustomCardTxtBox.Text)
                && !string.IsNullOrEmpty(ValidateCustomCardTxtBox.Text))
            {
                bool result = await _cardgenerator.LuhnAlgorithmValidationAsync(ValidateCustomCardTxtBox.Text);

                if (result)
                    MessageBox.Show("Карта прошла проверку");
                else
                    MessageBox.Show("Карта не валидна");
            }
            else
                MessageBox.Show("Номер карты должен состоять из цифр");
        }

        #endregion

        static bool IsDigitsOnly(string str)
        {
            foreach (char c in str)
            {
                if (c < '0' || c > '9')
                    return false;
            }

            return true;
        }
    }
}
