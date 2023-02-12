using System;

namespace DeckOfCards
{

    class GameRummy
    {
        private String __sardVal = "23456789TJQKA";
        private String __sardSuite = "CDHS";
        int[] _ajCards;
        public GameRummy()
        {
            _ajCards = new int[54];
            for (int j = 0; j < _ajCards.Length; j++)
            {
                _ajCards[j] = j;
            }
            shuffle();
        }

        private void shuffle()
        {
            Random rng = new Random();
            for (int j = 0; j < _ajCards.Length; j++) 
            {
                int jCard2bSwapped = rng.Next(_ajCards.Length);
                int jTemp = _ajCards[j];
                _ajCards[j] = _ajCards[jCard2bSwapped];
                _ajCards[jCard2bSwapped] = jTemp;
            }

        }

        public void printAllCards()
        {
            for (int j = 0; j < _ajCards.Length; j++)
            {
                Console.WriteLine(getCardString(_ajCards[j]));
            }
        }
        public String getCardString(int jCard)
        {
            String sRet = "UNKNOWN CARD";
            //0-12 S
            //13-25 H
            // 26 -38 D
            //39 -51 C
            //52,53 J

            int jSuite = jCard / 13;
            if (jSuite > 3)
            {
                sRet = "JOKER";
            }
            else
            {
                int jVal = jCard % 13;
                sRet = __sardSuite[jSuite] + "-" + __sardVal[jVal];
            }
            return sRet;
        }

    }

    class Program
    {
        static void Main(string[] args)
        {
            GameRummy game = new GameRummy();
            game.printAllCards();

        }
    }
}
