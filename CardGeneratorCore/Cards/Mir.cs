using CardGeneratorCore.CardGenerator;
using System.Threading.Tasks;

namespace CardGeneratorCore.Cards
{
    public class Mir : CardGeneratorController, ICard
    {
        public string Name { get; }

        public int Bin { get; set; }

        public int[] BinArray { get; }

        public int PrintCardCount { get; set; }

        public Mir()
        {
            Name = "Mir";

            BinArray = new int[] { 2200 };
        }

        public async Task<string> GenerateCardAsync() => await GenerateCardAsync(BinArray, PrintCardCount);
    }
}
