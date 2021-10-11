using CardGeneratorCore.CardGenerator;
using System.Threading.Tasks;

namespace CardGeneratorCore.Cards
{
    public class MasterCard : CardGeneratorController, ICard
    {
        public string Name { get; }

        public int Bin { get; set; }

        public int[] BinArray { get; }

        public int PrintCardCount { get; set; }

        public MasterCard()
        {
            Name = "MasterCard";

            BinArray = new int[] { 51, 52, 53, 54, 55 };
        }

        public async Task<string> GenerateCardAsync() => await GenerateCardAsync(BinArray, PrintCardCount);
    }
}
