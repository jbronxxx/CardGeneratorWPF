using CardGeneratorCore.CardGenerator;
using System.Threading.Tasks;

namespace CardGeneratorCore.Cards
{
    public class Visa : CardGeneratorController, ICard
    {
        public string Name { get; }

        public int Bin { get; set; }

        public int[] BinArray { get; }

        public int PrintCardCount { get; set; }

        public Visa()
        {
            Name = "Visa";

            BinArray = new int[] { 4, 4026, 417500, 4508, 4844, 4913, 491 };
        }

        public async Task<string> GenerateCardAsync() => await GenerateCardAsync(BinArray, PrintCardCount);
    }
}
