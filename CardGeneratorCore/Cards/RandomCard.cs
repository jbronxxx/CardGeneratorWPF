using CardGeneratorCore.CardGenerator;
using System;
using System.Threading.Tasks;

namespace CardGeneratorCore.Cards
{
    public class RandomCard : CardGeneratorController, ICard
    {
        public string Name { get; }

        public int Bin { get; set; }

        public int[] BinArray { get; }

        public int PrintCardCount { get; set; }

        public async Task<string> GenerateCardAsync(int bin, int printCardCount)
        {
            string printCard = null;

            for (int i = 0; i < printCardCount; i++)
            {
                string tempCard = await GeneratePanAsync(Convert.ToString(bin), 16);

                printCard += tempCard + "\n";
            }

            return printCard;
        }
    }
}
