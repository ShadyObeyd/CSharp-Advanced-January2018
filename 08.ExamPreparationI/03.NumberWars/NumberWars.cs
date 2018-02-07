using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.NumberWars
{
    class NumberWars
    {
        static void Main()
        {
            Queue<string> firstPlayerCards = ReadInput(Console.ReadLine());
            Queue<string> secondPlayerCards = ReadInput(Console.ReadLine());

            int turnCounter = 0;

            bool gameHasEnded = false;

            while (turnCounter < 1_000_000 && firstPlayerCards.Count > 0 && secondPlayerCards.Count > 0 && !gameHasEnded)
            {
                string firstPlayerCard = firstPlayerCards.Dequeue();
                string secondPlayerCard = secondPlayerCards.Dequeue();

                if (GetNumber(firstPlayerCard) > GetNumber(secondPlayerCard))
                {
                    firstPlayerCards.Enqueue(firstPlayerCard);
                    firstPlayerCards.Enqueue(secondPlayerCard);
                }
                else if (GetNumber(firstPlayerCard) < GetNumber(secondPlayerCard))
                {
                    secondPlayerCards.Enqueue(secondPlayerCard);
                    secondPlayerCards.Enqueue(firstPlayerCard);
                }
                else if (GetNumber(firstPlayerCard) == GetNumber(secondPlayerCard))
                {
                    List<string> currentHand = new List<string> { firstPlayerCard, secondPlayerCard };

                    War(firstPlayerCards, secondPlayerCards, currentHand, ref gameHasEnded);
                }
                turnCounter++;
            }

            string result = string.Empty;

            if (firstPlayerCards.Count > secondPlayerCards.Count)
            {
                result = "First player wins";
            }
            else if (firstPlayerCards.Count < secondPlayerCards.Count)
            {
                result = "Second player wins";
            }
            else
            {
                result = "Draw";
            }

            Console.WriteLine($"{result} after {turnCounter} turns");
        }

        static void War(Queue<string> firstPlayerCards, Queue<string> secondPlayerCards, List<string> currentHand, ref bool gameHasEnded)
        {
            while (!gameHasEnded)
            {
                if (firstPlayerCards.Count >= 3 && secondPlayerCards.Count >= 3)
                {
                    int firstSum = 0;
                    int secondSum = 0;

                    for (int i = 0; i < 3; i++)
                    {
                        string currentFirstPlayerCard = firstPlayerCards.Dequeue();
                        string currentSecondPlayerCard = secondPlayerCards.Dequeue();

                        firstSum += GetCharNum(currentFirstPlayerCard);
                        secondSum += GetCharNum(currentSecondPlayerCard);

                        currentHand.Add(currentFirstPlayerCard);
                        currentHand.Add(currentSecondPlayerCard);
                    }

                    if (firstSum > secondSum)
                    {
                        AddCards(currentHand, firstPlayerCards);
                        break;
                    }
                    else if (firstSum < secondSum)
                    {
                        AddCards(currentHand, secondPlayerCards);
                        break;
                    }
                }
                else
                {
                    gameHasEnded = true;
                }
            }
        }

        private static void AddCards(List<string> currentHand, Queue<string> playerCards)
        {
            foreach (string card in currentHand.OrderByDescending(c => GetNumber(c)).ThenByDescending(c => GetCharNum(c)))
            {
                playerCards.Enqueue(card);
            }
        }

        static int GetCharNum(string card)
        {
            return card[card.Length - 1];
        }

        static int GetNumber(string card)
        {
            return int.Parse(card.Substring(0, card.Length - 1));
        }

        static Queue<string> ReadInput(string input)
        {
            return new Queue<string>(input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries));
        }
    }
}