using CardGeneratorCore.CardGenerator;
using CardGeneratorCore.Cards;
using System;
using System.Windows;

namespace CardGeneratorUI
{
    // TODO: Ограничить ввод колличества карт
    //       Заблокировать кнопку генерации на время работы
    //       Возможно, вывод карт по одной
    //       Вписать шрифт в окно TextBox

    public partial class MainWindow : Window
    {
        private ICard _visa;
        private ICard _masterCard;
        private ICard _mir;
        private RandomCard _customCard;

        private readonly ICardGenerator _cardgenerator;

        public ICard RandomCard { get; set; }

        public MainWindow()
        {
            InitializeComponent();

            _cardgenerator = new CardGeneratorController();
        }
        #region CardGenerateBtns

        private async void GenerateVisaBtn_Click(object sender, RoutedEventArgs e)
        {
            _visa = new Visa();

            if (VisaTab.IsSelected)
            {
                if (IsDigitsOnly(VisaCountTxtBox.Text)
                                    && !string.IsNullOrEmpty(VisaCountTxtBox.Text))
                {
                    VisaTextBoxMain.Text = await _visa.GenerateCardAsync(
                                        _visa.BinArray, int.Parse(VisaCountTxtBox.Text));
                }
                else
                    MessageBox.Show("Введите колличество карт цифрами");
            }
        }

        private async void GenerateMCardBtn_Click(object sender, RoutedEventArgs e)
        {
            _masterCard = new MasterCard();

            if (MCardTab.IsSelected)
            {
                if (IsDigitsOnly(MCardCountTxtBox.Text) &&
                    !string.IsNullOrEmpty(MCardCountTxtBox.Text))
                {
                    MCardTextBoxMain.Text = await _masterCard.GenerateCardAsync(
                                        _masterCard.BinArray, int.Parse(MCardCountTxtBox.Text));
                }
                else
                    MessageBox.Show("Введите колличество карт цифрами");
            }
        }

        private async void GenerateMirBtn_Click(object sender, RoutedEventArgs e)
        {
            _mir = new Mir();

            if (MirTab.IsSelected)
            {
                if (IsDigitsOnly(MirCountTxtBox.Text)
                    && !string.IsNullOrEmpty(MirCountTxtBox.Text))
                {
                    MirTextBoxMain.Text = await _mir.GenerateCardAsync(
                                        _mir.BinArray, int.Parse(MirCountTxtBox.Text));
                }
                else
                    MessageBox.Show("Введите колличество карт цифрами");
            }
        }

        private async void GenerateCustomBtn_Click(object sender, RoutedEventArgs e)
        {
            _customCard = new RandomCard();

            if (CustomCardTab.IsSelected)
            {
                if (!string.IsNullOrEmpty(NewBinTxtBox.Text))
                {
                    if (IsDigitsOnly(NewBinTxtBox.Text))
                    {
                        if (!string.IsNullOrEmpty(CustomCountTxtBox.Text))
                        {
                            if (IsDigitsOnly(CustomCountTxtBox.Text))
                            {
                                CustomCardTextBoxMain.Text = await _customCard.GenerateCardAsync(
                                                Int32.Parse(NewBinTxtBox.Text), int.Parse(CustomCountTxtBox.Text));
                            }
                            else
                                MessageBox.Show("Введите цифры");
                        }
                        else
                            MessageBox.Show("Введите колличество карт");
                    }
                    else
                        MessageBox.Show("Введите цифры");
                }
                else
                    MessageBox.Show("Введите Bin карты");
            }
        }

        #endregion

        #region CardValidateBtns

        private async void ValidateVisaBtn_Click(object sender, RoutedEventArgs e)
        {
            if (IsDigitsOnly(ValidateVisaTxtBox.Text) 
                && !string.IsNullOrEmpty(ValidateVisaTxtBox.Text))
            {
                bool result = await _cardgenerator.IsValidCardAsync(ValidateVisaTxtBox.Text);

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
                bool result = await _cardgenerator.IsValidCardAsync(ValidateMCardTxtBox.Text);

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
                bool result = await _cardgenerator.IsValidCardAsync(ValidateMirTxtBox.Text);

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
                bool result = await _cardgenerator.IsValidCardAsync(ValidateCustomCardTxtBox.Text);

                if (result)
                    MessageBox.Show("Карта прошла проверку");
                else
                    MessageBox.Show("Карта не валидна");
            }
            else
                MessageBox.Show("Номер карты должен состоять из цифр");
        }

        #endregion

        // Проверка на цифры полей для ввода
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
