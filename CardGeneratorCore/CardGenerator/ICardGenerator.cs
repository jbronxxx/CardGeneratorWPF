using System.Threading.Tasks;

namespace CardGeneratorCore.CardGenerator
{
    public interface ICardGenerator
    {
        public Task<string> GenerateCardAsync(int[] binArray, int printCardCount);

        public Task<bool> IsValidCardAsync(string cardToCheck);
    }
}
