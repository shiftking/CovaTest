using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
/// <summary>
/// Description Library for playing a simplified game of poker:
///  Only plays of a subset of hands:
///                         - Flush
///                         - Three of a kind
///                         - One Pair
///                         - High card
/// Assumptions:
///     - Ace is always high, so rank 13
///     - 
/// </summary>
namespace PokerShowdown
{


    public class PokerShowdown
    {
        /// <summary>
        ///  Purpose: Determines winners in a game of poker
        ///  Description: Will return a list of players that are winning, from a list of players
        /// 
        /// </summary>


         
        public static List<Player> GetWinner(List<Player> players)
        {
            List<Player> winners = new List<Player>();
            foreach(Player player in players)
            {
                
                //iterates through the players and determines the winners
                // if the list doesn't have a winner, add the next one to the list
                
                if (winners.Count == 0)
                {
                    winners.Add(player);
                    
                }
                else
                {
                    
                    foreach(Player winner in winners.ToList())
                    {
                        if(winner.GetHand() < player.GetHand())
                        {

                            winners.Clear();                            
                            winners.Add(player);
                            break;

                            //if the next player is a higher rank then we know that all other 
                            //winners are not winners, so the winner list gets cleared, and this new one gets added

                        }else if (winner.GetHand() == player.GetHand())
                        {
                            winners.Add(player);
                            //if the current player and the top winner are the same, than we add it to the list of winners

                        }
                        
                    }
                    
                }
                
            }
            return winners;
        }

        

    }

    public class Player
    {
        String name;
        private Hand hand;


        public Player(List<Card> _hand,String _name)
        {
            this.name = _name;
            if(_hand.Count != 5)
            {
                throw new Exception("Not the correct number of cards");
            }
            this.hand = new Hand(_hand);
        }
        public  Hand GetHand()
        {
            return hand;
        }
        public String getName()
        {
            return this.name;
        }
        
    }
    public class Hand
    {
        private List<Card> cards;
        
        public Hand(List<Card> _cards)
        {
            
            this.cards = _cards;
            this.cards.Sort();

        }
        public bool IsFlush()
        {
            //get the suite of the first card
            char handSuite = this.cards.ToArray()[0].GetSuite();

            foreach (Card card in this.cards)
            {
                if (card.GetSuite() != handSuite)
                {
                    return false;
                }

            }
            return true;
        }
        public bool IsThreeofKind()
        {
            foreach (Card card in this.cards)
            {
                List<Card> likeCards = this.cards.FindAll(delegate (Card c) { return c.GetRank() == card.GetRank(); });
                if(likeCards.Count == 3)
                {
                    
                    return true;
                }
            }
            return false;
        }
        public bool IsOnePair()
        {

            foreach (Card card in this.cards)
            {
                List<Card> likeCards = this.cards.FindAll(delegate (Card c) { return c.GetRank() == card.GetRank(); });
                if (likeCards.Count == 2)
                {
                    
                    return true;
                }
            }
            return false;
        }
        public Card HighCard()
        {
            return this.cards.ToArray()[0];
        }
        public Card GetDouplicate()
        {
            foreach (Card card in this.cards)
            {
                List<Card> likeCards = this.cards.FindAll(delegate (Card c) { return c.GetRank() == card.GetRank(); });
                if (likeCards.Count >= 2)
                {

                    return card;
                }
            }
            return new Card();
        }
        public Card getCard(int i)
        {
            if (i < 0 || i >= 5)
            {
                throw new IndexOutOfRangeException("Can only access 0-4 index for hands");
            }
            return this.cards.ToArray()[i];
        }
        public static bool operator == (Hand a, Hand b)
        {
            if (a.IsFlush())
            {
                if (b.IsFlush()) { 
                    for (int i = 0; i < a.cards.Count; i++)
                    {
                        if (a.getCard(i) != a.getCard(i))
                        {
                            return false;
                        }
                    }
                    return true;
                }
                return false;
                
            }
            else if (b.IsFlush())
            {
                return false;
            }
            if (a.IsThreeofKind())
            {
                if (b.IsThreeofKind())
                {
                    for (int i = 0; i < a.cards.Count; i++)
                    {
                        if (a.getCard(i) != a.getCard(i))
                        {
                            return false;
                        }
                    }

                    return true;
                }
                return false;
            }else if (b.IsThreeofKind())
            {
                return false;
            }
            if (a.IsOnePair())
            {
                if (b.IsOnePair())
                {
                    if (a.GetDouplicate() == b.GetDouplicate())
                    {
                        for (int i = 0; i < a.cards.Count; i++)
                        {
                            if (a.getCard(i) != a.getCard(i))
                            {
                                return false;
                            }
                        }
                        return true;
                    }
                }
                return false;

            }
            else if (b.IsOnePair())
            {
                return false;
            }
            if (a.HighCard() == b.HighCard())
            {
                for (int i = 0; i < b.cards.Count; i++)
                {
                    if (a.getCard(i) != b.getCard(i))
                    {
                        return false;
                    }
                }
                return true;
            }

            return false;
        }
        public override bool Equals(object o)
        {
            if(o == null)
            {
                return false;
            }
            var b = o as Hand;
            if (this.IsFlush())
            {
                if (b.IsFlush())
                {
                    for (int i = 0; i < this.cards.Count; i++)
                    {
                        if (this.getCard(i) != this.getCard(i))
                        {
                            return false;
                        }
                    }
                    return true;
                }
                return false;

            }
            else if (b.IsFlush())
            {
                return false;
            }
            if (this.IsThreeofKind())
            {
                if (b.IsThreeofKind())
                {
                    for (int i = 0; i < this.cards.Count; i++)
                    {
                        if (this.getCard(i) != this.getCard(i))
                        {
                            return false;
                        }
                    }

                    return true;
                }
                return false;
            }
            else if (b.IsThreeofKind())
            {
                return false;
            }
            if (this.IsOnePair())
            {
                if (b.IsOnePair())
                {
                    if (this.GetDouplicate() == b.GetDouplicate())
                    {
                        for (int i = 0; i < this.cards.Count; i++)
                        {
                            if (this.getCard(i) != this.getCard(i))
                            {
                                return false;
                            }
                        }
                        return true;
                    }
                }
                return false;

            }
            else if (b.IsOnePair())
            {
                return false;
            }
            if (this.HighCard() == b.HighCard())
            {
                for (int i = 0; i < b.cards.Count; i++)
                {
                    if (this.getCard(i) != b.getCard(i))
                    {
                        return false;
                    }
                }
                return true;
            }

            return false;
        }
        public override int GetHashCode()
        {
            return this.cards.Count;
        }
        public static bool operator < (Hand a, Hand b)
        {

            if (b.IsFlush())
            {
                if (a.IsFlush())
                {
                    for(int i = 0; i < 5; i++)
                    {
                        if (a.getCard(i) > b.getCard(i))
                        {
                            return false;
                        }
                    }
                    return false;
                   
                }
                return true;
            }else if (a.IsFlush())
            {
                return false;
            }
            if (b.IsThreeofKind())
            {
                if (a.IsThreeofKind())
                {
                    if (a.GetDouplicate() > b.GetDouplicate())
                    {
                        return false;
                    }
                    else
                    {
                        for (int i = 0; i < 5; i++)
                        {
                            if (a.getCard(i) > b.getCard(i))
                            {
                                return false;
                            }
                        }
                    }
                    return false;
                }
                return true;
            }else if (a.IsThreeofKind())
            {
                return false;
            }
            if (b.IsOnePair())
            {
                if (a.IsOnePair())
                {
                    if (a.GetDouplicate() > b.GetDouplicate())
                    {
                        return false;
                    }
                    else
                    {
                        for (int i = 0; i < 5; i++)
                        {
                            if (a.getCard(i) > b.getCard(i))
                            {
                                return false;
                            }
                        }
                    }
                    return false;
                }
                return true;

            }
            else if (a.IsOnePair())
            {
                return false;
            }

            else if(a.HighCard() < b.HighCard())
            {
                return true;
            }
            return false;
        }
        public static bool operator > (Hand a, Hand b)
        {
            if (a.IsFlush())
            {
                if (b.IsFlush())
                {
                    for (int i = 0; i < 5; i++)
                    {
                        if (a.getCard(i) < b.getCard(i))
                        {
                            return false;
                        }
                    }

                }
                return true;
            }
            else if (b.IsFlush())
            {
                return false;
            }
            if (a.IsThreeofKind())
            {
                if (b.IsThreeofKind())
                {
                    if (a.GetDouplicate() < b.GetDouplicate())
                    {
                        return false;
                    }
                    else
                    {
                        for (int i = 0; i < 5; i++)
                        {
                            if (a.getCard(i) > b.getCard(i))
                            {
                                return false;
                            }
                        }
                    }
                }
                return true;
            }
            else if (b.IsThreeofKind())
            {
                return false;
            }
            if (b.IsOnePair())
            {
                if (a.IsOnePair())
                {
                    if (a.GetDouplicate() > b.GetDouplicate())
                    {
                        return false;
                    }
                    else
                    {
                        for (int i = 0; i < 5; i++)
                        {
                            if (a.getCard(i) > b.getCard(i))
                            {
                                return false;
                            }
                        }
                    }
                }
                return true;

            }
            else if (a.IsOnePair())
            {
                return false;
            }

            else if (a.HighCard() < b.HighCard())
            {
                return false;
            }
            return false;
        }
        public static bool operator !=(Hand a, Hand b)
        {
            return true;
        }

    }
   /// <summary>
   /// Purpose: Represents a card in a poker game
   /// Description: Holds the information that represents a valid card
   /// [1 - 13] [Clubs(C), Hearts(H), Spades(S), Diamonds(D)] 
   /// </summary>
    public class Card : IComparable
    {
        private int rank;
        private Char suite;
        private List<Char> suites;
        public Card()
        {
            rank = -1;
            suite = 'A';

        }

        public Card(int _rank, char _suite)
        {
            this.suites =  new List<char>();
            
            if (_rank <= 1 || _rank > 14) {
                throw new Exception("Rank out of range");
            }

            if(_suite != 'D' && _suite != 'C' && _suite != 'S'&& _suite != 'H'){
                throw new Exception("Suite not valid");
            }
            this.suite = _suite;
            this.rank = _rank;
        }
        public int GetRank()
        {
            return this.rank;
        }
        public char GetSuite()
        {
            return this.suite;
        }

        public int  CompareTo(object other)
        {
            if(other == null)
            {
                return 1;
            }
            var card = other as Card;
                           
            return card.rank.CompareTo(this.rank);
            
        }

        public static bool operator == (Card a, Card b)
        {
            return a.rank == b.rank;
        }
        public static bool operator !=(Card a, Card b)
        {
            return a.rank != b.rank;
        }
        public static bool operator >(Card a, Card b)
        {
            return a.rank > b.rank;
        }
        public static bool operator <(Card a, Card b)
        {
            return a.rank < b.rank;
        }
    }
        
}
