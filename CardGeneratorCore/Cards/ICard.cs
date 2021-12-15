using CardGeneratorCore.CardGenerator;

namespace CardGeneratorCore.Cards
{
    public interface ICard : ICardGenerator
    {
        public string Name { get; }

        public int Bin { get; set; }

        public int[] BinArray { get; }

        public int PrintCardCount { get; set; }
    }
}
