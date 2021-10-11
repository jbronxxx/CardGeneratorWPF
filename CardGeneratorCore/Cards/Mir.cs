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

            BinArray = new int[] { 35629900, 35629910, 35629920, 35629950, 35629980, 35646600, 35646700,
                      35646800, 35650400, 35650403, 35650405, 35650430, 35650433, 35650435,
                      35651400, 35651401, 35651402, 35651403, 35654602, 35770400, 35770500,
                      35770600, 35770800, 35770900, 35771000,
                      62344610, 62915700, 62924402, 67118230, 67634750, 67645440, 67645441,
                      67645442, 67645443, 67645444, 67645445, 67645449, 67645460, 67645461,
                      67645462, 67645463, 67645464, 67645465, 67645469, 67645470, 67645471,
                      67645472, 67645473, 67645474, 67645475, 67645479, 67645480, 67653175,
                      67653176, 67688490, 67690700, 67722700, 67731900, 67738420};
        }

        public async Task<string> GenerateCardAsync() => await GenerateCardAsync(BinArray, PrintCardCount);
    }
}
