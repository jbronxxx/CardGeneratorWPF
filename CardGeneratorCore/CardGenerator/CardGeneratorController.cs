using System;
using System.Text;
using System.Threading.Tasks;

namespace CardGeneratorCore.CardGenerator
{
    public class CardGeneratorController : ICardGenerator
    {
        private readonly Random _random;

        public CardGeneratorController() => _random = new Random();

        public Task<string> GenerateCardAsync(int[] binArray, int numberOfCards)
        {
            return Task.Run(() =>
            {
                string printCard = "";

                for (int i = 0; i < numberOfCards; i++)
                {
                    string tempCard = GeneratePanAsync(bin: Convert.ToString(binArray[
                                                          GenrateBin(0, binArray.Length - 1)])
                                                          , cardLenth: 16).Result;

                    printCard += tempCard + "\n";
                }

                return printCard;
            });
            
        }

        /*
            Генерирует Bin карты (первые цифры),
            начиная с первого элемента массива 
         */

        private int GenrateBin(int first, int last)
        {
            return _random.Next(first, last);
        }

        /*
            bin - первые цифры карты,
            cardLenth - общее колличество цифр в номере карты
            loopLength - разница между длины строкового представления bin 
            плюс 1 чтобы получить 15 цифр
            Цикл for склеивает bin с loopLength + последнюю цифру из метода Луна
         */

        public async Task<string> GeneratePanAsync(string bin, int cardLenth)
        {
            int loopLength = cardLenth - (bin.Length + 1);

            StringBuilder stringBuilder = new(bin);

            for (int i = 0; i < loopLength; i++)
            {
                int cardTail = _random.Next(10);

                stringBuilder.Append(cardTail);
            }

            int checkValid = await LuhnAlgorithmAsync(stringBuilder.ToString());

            stringBuilder.Append(checkValid);

            return stringBuilder.ToString();
        }

        #region Luhn Algorithm
        /*
          Алгоритм Луна для проверки правильности Bin:
         1. Цифры проверяемой последовательности нумеруются справа налево.
         2. Цифры, оказавшиеся на нечётных местах, остаются без изменений.
         3. Цифры, стоящие на чётных местах, умножаются на 2.
         4. Если в результате такого умножения возникает число больше 9, 
            оно заменяется суммой цифр получившегося произведения — 
            однозначным числом, то есть цифрой.
         5. Все полученные в результате преобразования цифры складываются.
            Если сумма кратна 10, то исходные данные верны.
         */

        /* 
            Метод получает 15 цифр с метода GenerateCard, 
            проверяет их по алгоритму Луна и добавляет на его основе 16 цифру
            обратно в метод GenerateCard, где склеивает ее с остальными 15
         */

        private static async Task<int> LuhnAlgorithmAsync(string cardToCheck)
        {
            return await Task.Run(() =>
            {
                int sum = 0;

                for (int i = 0; i < cardToCheck.Length; i++)
                {

                    int tempIndex = int.Parse(cardToCheck.Substring(i, 1));

                    if ((i % 2) == 0)
                    {
                        tempIndex *= 2;

                        if (tempIndex > 9)
                            tempIndex = (tempIndex / 10) + (tempIndex % 10);
                    }

                    sum += tempIndex;
                }

                int check = sum % 10;

                return (check == 0) ? 0 : 10 - check;
            });
        }

        #endregion

        #region LuhnAlgorithmValidationAsync
        /*
         * Алгоритм для проверки карты на валидность.
         * Метод такой же как LuhnAlgorithmAsync, но принимает на вход целый номер карты
         * и, возвращает true, если карта валидна.
         */
        public async Task<bool> LuhnAlgorithmValidationAsync(string cardToCheck)
        {
            int sum = 0;

            for (int i = 0; i < cardToCheck.Length; i++)
            {

                int tempIndex = int.Parse(cardToCheck.Substring(i, 1));

                if ((i % 2) == 0)
                {
                    tempIndex *= 2;

                    if (tempIndex > 9)
                        tempIndex = (tempIndex / 10) + (tempIndex % 10);
                }

                sum += tempIndex;
            }

            int check = sum % 10;

            if (check == 0)
                return await Task.FromResult(true);

            return false;
        }

        #endregion 
    }
}
