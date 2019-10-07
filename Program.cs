using System;
using System.Collections.Generic;

namespace deck_of_cards
{
    class Program
    {
        static void Main(string[] args)
        {
            // Console.WriteLine("Hello World!");
            Deck cur_deck = new Deck();
            cur_deck.Shuffle();
            // Confirming cur_deck's list of cards has been shuffled
            // for(int i = 0; i < cur_deck.cards.Count - 1; i++)
            // {
            //     System.Console.WriteLine($"{cur_deck.cards[i].stringVal} of {cur_deck.cards[i].suit}");
            // }
            Player player1 = new Player("Sam");
            System.Console.WriteLine(player1.Name);
            player1.Draw(cur_deck);
            for(int i = 0; i < player1.Hand.Count; i++)
            {
                System.Console.WriteLine(player1.Hand[i]);
            }
            System.Console.WriteLine(player1.Hand.Count);
            player1.Discard(0);
            System.Console.WriteLine(player1.Hand.Count);
            System.Console.WriteLine(cur_deck.cards.Count);
        }
    }
    class Card
    {
        public string stringVal{get; set;}
        public string suit{get; set;}
        public int val{get; set;}
        public Card(string _stringVal, string _suit, int _val)
        {
            stringVal = _stringVal;
            suit = _suit;
            val = _val;
        }
    }
    class Deck
    {
        public List<Card> cards;

        public Deck()
        {
            cards = new List<Card>();
            string[] suits = {"Clubs", "Spades", "Hearts", "Diamonds"};
            string[] stringVals = {"Ace", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine", "Ten", "Jack", "Queen", "King"};
            for(int i = 0; i <=12; i++)
            {
                foreach(string suit in suits)
                {
                    Card new_card = new Card(stringVals[i], suit, i+1);
                    cards.Add(new_card);
                    // System.Console.WriteLine($"This card is the {new_card.stringVal} of {new_card.suit} (value is {new_card.val})"); //Printing out each new card (should print 13 of each suit);
                }
            }
        }
        public void Reset()
        {
            cards.RemoveRange(0, cards.Count);
            string[] suits = {"Clubs", "Spades", "Hearts", "Diamonds"};
            string[] stringVals = {"Ace", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine", "Ten", "Jack", "Queen", "King"};
            for(int i = 0; i <=12; i++)
            {
                foreach(string suit in suits)
                {
                    Card new_card = new Card(stringVals[i], suit, i);
                    cards.Add(new_card);
                    System.Console.WriteLine($"This card is the {new_card.stringVal} of {new_card.suit} (value is {new_card.val})"); //Printing out each new card (should print 13 of each suit);
                }
            }
        }
        public void Shuffle()
        {
            Random rand = new Random();
            for(int i = 0; i <= cards.Count - 1; i++)
            {
                int random_int = rand.Next(0, cards.Count - 1);
                Card temp = cards[i];
                cards[i] = cards[random_int];
                cards[random_int] = temp;
            }
        }
        public Card Deal()
        {
            Card dealt_card = cards[0];
            cards.RemoveAt(0);
            return dealt_card;
        }
    }
    class Player
    {
        public string Name{get; set;}
        public List<Card> Hand{get; set;}
        public Player(string _Name)
        {
            Name = _Name;
            Hand = new List<Card>();
        }
        public void Draw(Deck deck)
        {
            Hand.Add(deck.Deal());
        }
        public Card Discard(int index)
        {
            Card discarded_card = Hand[index];
            Hand.RemoveAt(index);
            return discarded_card;
        }
    }
}
