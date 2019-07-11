using System;
using System.Collections.Generic;

namespace DeckOfCards
{
    class Program
    {
        class Card 
        {
            public string stringVal; //Ace, 2, 3, 4, 5, 6, 7, 8, 9, 10, Jack, Queen, King
            public string suit; //Clubs, Spades, Hearts, Diamonds
            public int val; // the numerical value of the card 1-13
            public Card(string StringVal, string Suit, int Val)
            {
                stringVal = StringVal;
                suit = Suit;
                val = Val;
            }
        }
        class Deck
        {
            public List<Card> cards;
            public Deck()
            {
                cards = new List<Card>();
                CreateDeck(cards);
            }
            public void CreateDeck(List<Card> newDeck)
            {
                string[] StringVals = {"Ace", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine", "Ten", "Jack", "Queen", "King"};
                string[] Suits = {"Clubs", "Spades", "Hearts", "Diamonds"};
                int[] Vals = {1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13};
                foreach(string i in Suits)
                {
                    for(int j = 0; j < Vals.Length; j++)
                    {
                        newDeck.Add(new Card(i, StringVals[j], Vals[j]));
                    }
                }
            }
            public Card Deal()
            {
                Card draw = cards[0];
                cards.RemoveAt(0);
                return draw;
            }
            public void Reset()
            {
                CreateDeck(cards);
            }
            public void Shuffle()
            {
                Random rand = new Random();
                for(int i = cards.Count-1; i > 0; i--)
                {
                    int j = rand.Next(0,i+1);
                    Card temp = cards[i];
                    cards[i] = cards[j];
                    cards[j] = temp;
                }
            }
        }
        class Player
        {
            public string Name;
            public List<Card> Hand;
            public Player(string name)
            {
                Name = name;
                Hand = new List<Card>();
            }
            public Card Draw(Deck deck)
            {
                Card draw = deck.Deal();
                Hand.Add(draw);
                return draw;
            }
            public Card Discard(int idx)
            {
                if (idx < Hand.Count-1 || idx < 0)
                {
                    return null;
                }
                else
                {
                    Card discarded = Hand[idx];
                    Hand.RemoveAt(idx);
                    return discarded;
                }
            }
        }
        static void Main(string[] args)
        {
            Deck deck = new Deck();
            Player p1 = new Player("person_1");
            System.Console.WriteLine($"Player: {p1.Name}");
            deck.Shuffle();
            p1.Draw(deck);
            p1.Draw(deck);
            foreach (Card card in p1.Hand)
            {
                System.Console.WriteLine($"{card.stringVal} of {card.suit}");
            }
        }
    }
}
