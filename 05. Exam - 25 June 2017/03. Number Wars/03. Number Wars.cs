using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Number_Wars
{
    class Program
    {
        private static Queue<KeyValuePair<int, char>> deck1;
        private static Queue<KeyValuePair<int, char>> deck2;
        private static Dictionary<char, int> lettersPower;
        private static List<KeyValuePair<int, char>> fieldCards;

        public static void Main()
        {
            deck1 = ReadDeck();
            deck2 = ReadDeck();

            lettersPower = GetLetterPowers();

            int turns = 0;
            while (true)
            {
                fieldCards = new List<KeyValuePair<int, char>>();

                if (deck1.Count >= 0 && deck2.Count == 0)
                    break;

                if (deck2.Count >= 0 && deck1.Count == 0)
                    break;

                KeyValuePair<int, char> player1Card = deck1.Dequeue();
                KeyValuePair<int, char> player2Card = deck2.Dequeue();

                fieldCards.Add(player1Card);
                fieldCards.Add(player2Card);

                if (player1Card.Key > player2Card.Key)
                    AddCards(deck1);
                else if (player2Card.Key > player1Card.Key)
                    AddCards(deck2);
                else
                    War();

                if (turns == 1000000)
                    break;

                turns++;
            }

            if (deck1.Count > deck2.Count)
                Console.WriteLine($"First player wins after {turns} turns");
            else if (deck2.Count > deck1.Count)
                Console.WriteLine($"Second player wins after {turns} turns");
            else
                Console.WriteLine($"Draw after {turns} turns");
        }

        private static void War()
        {
            while (true)
            {
                if (deck1.Count >= deck2.Count && deck2.Count < 3)
                    break;

                if (deck2.Count >= deck1.Count && deck1.Count < 3)
                    break;

                int player1Sum = GetSumAndDrawCards(deck1);
                int player2Sum = GetSumAndDrawCards(deck2);

                if (player1Sum > player2Sum)
                {
                    AddCards(deck1);
                    break;
                }
                if (player2Sum > player1Sum)
                {
                    AddCards(deck2);
                    break;
                }
            }
        }

        private static int GetSumAndDrawCards(Queue<KeyValuePair<int, char>> deck)
        {
            int sum = 0;
            for (int i = 0; i < 3; i++)
            {
                KeyValuePair<int, char> card = deck.Dequeue();
                sum += lettersPower[card.Value];
                fieldCards.Add(card);
            }

            return sum;
        }

        private static void AddCards(Queue<KeyValuePair<int, char>> deck)
        {
            foreach (var card in fieldCards.OrderByDescending(c => c.Key).ThenByDescending(c => c.Value))
            {
                deck.Enqueue(card);
            }
        }

        private static Dictionary<char, int> GetLetterPowers()
        {
            Dictionary<char, int> letterPowers = new Dictionary<char, int>();

            int power = 1;
            for (char i = 'a'; i <= 'z'; i++)
            {
                letterPowers.Add(i, power++);
            }

            return letterPowers;
        }

        private static Queue<KeyValuePair<int, char>> ReadDeck()
        {
            Queue<KeyValuePair<int, char>> deck = new Queue<KeyValuePair<int, char>>();

            string[] cards = Console.ReadLine()
                .Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries);

            foreach (var card in cards)
            {
                int power = int.Parse(card.Substring(0, card.Length - 1));
                char suit = card[card.Length - 1];

                deck.Enqueue(new KeyValuePair<int, char>(power, suit));
            }

            return deck;
        }
    }
}
