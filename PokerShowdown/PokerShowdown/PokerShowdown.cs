using System;
using System.Collections.Generic;
using System.Text;

namespace PokerShowdown
{
    public class PokerShowdown
    {
        /*
        Purpose
        Description
         */
        public static List<Player> GetWinner(List<Player> players)
        {

            return players;
        }
        

    }

    public class Player
    {
        String name;
        List<Card> hand;

        public Player(List<Card> _hand)
        {
            this.hand = _hand;
        }
        bool IsFlush()
        {
            return false;
        }
        bool IsThreeofKind()
        {
            return false;
        }
        bool IsOnePair()
        {
            return false;
        }
        Card IsHighCard()
        {
            return new Card();
        }

    }
    public class Card
    {
        private int rank;
        private Char suite;
        public Card()
        {
            rank = -1;
            suite = 'A';
        }
        Card(int _rank,char _suite)
        {
            this.suite = _suite;
            this.rank = _rank;
        }
        public int GetRank()
        {
            return this.rank;
        }
        public char GetFace()
        {
            return this.suite;
        }
    }
}
