using Microsoft.VisualStudio.TestTools.UnitTesting;
using PokerShowdown;

using System.IO;
using System;
using System.Collections.Generic;

namespace PokerShowdownTesting
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestIsFlsuh()

        {
            List<PokerShowdown.Card> hand = new List<Card>();
            hand.Add(new Card(13, 'D'));
            hand.Add(new Card(12, 'D'));
            hand.Add(new Card(11, 'D'));
            hand.Add(new Card(10, 'D'));
            hand.Add(new Card(9, 'D'));
            PokerShowdown.Player player = new Player(hand,"Dylan");

            Assert.AreEqual(true, player.GetHand().IsFlush());

            hand = new List<Card>();
            hand.Add(new Card(13, 'D'));
            hand.Add(new Card(12, 'D'));
            hand.Add(new Card(11, 'S'));
            hand.Add(new Card(10, 'D'));
            hand.Add(new Card(9, 'D'));
            player = new Player(hand, "Dylan");
            Assert.AreEqual(false, player.GetHand().IsFlush());
        }
        [TestMethod]
        ///Test the three of kind check
        public void TestIsThreeOfKind()

        {

            List<PokerShowdown.Card> hand = new List<Card>();
            hand.Add(new Card(13, 'D'));
            hand.Add(new Card(13, 'S'));
            hand.Add(new Card(13, 'C'));
            hand.Add(new Card(10, 'D'));
            hand.Add(new Card(9, 'D'));
            PokerShowdown.Player player = new Player(hand, "Dylan");

            Assert.AreEqual(true, player.GetHand().IsThreeofKind());

            hand = new List<Card>();
            hand.Add(new Card(13, 'D'));
            hand.Add(new Card(13, 'S'));
            hand.Add(new Card(12, 'C'));
            hand.Add(new Card(10, 'D'));
            hand.Add(new Card(9, 'D'));
            player = new Player(hand, "Dylan");

            Assert.AreEqual(false, player.GetHand().IsThreeofKind());
            hand = new List<Card>();
            hand.Add(new Card(13, 'D'));
            hand.Add(new Card(13, 'S'));
            hand.Add(new Card(12, 'C'));
            hand.Add(new Card(13, 'C'));
            hand.Add(new Card(9, 'D'));
            player = new Player(hand, "Dylan");

            Assert.AreEqual(true, player.GetHand().IsThreeofKind());
        }
        [TestMethod]
        public void TestIsOnePair()

        {

            List<PokerShowdown.Card> hand = new List<Card>();
            hand.Add(new Card(13, 'D'));
            hand.Add(new Card(13, 'S'));
            hand.Add(new Card(10, 'C'));
            hand.Add(new Card(1, 'D'));
            hand.Add(new Card(9, 'D'));
            PokerShowdown.Player player = new Player(hand, "Dylan");

            Assert.AreEqual(true, player.GetHand().IsOnePair());

            hand = new List<Card>();
            hand.Add(new Card(13, 'D'));
            hand.Add(new Card(11, 'S'));
            hand.Add(new Card(12, 'C'));
            hand.Add(new Card(10, 'D'));
            hand.Add(new Card(9, 'D'));
            player = new Player(hand, "Dylan");

            Assert.AreEqual(false, player.GetHand().IsOnePair());
            hand = new List<Card>();
            hand.Add(new Card(12, 'D'));
            hand.Add(new Card(10, 'S'));
            hand.Add(new Card(12, 'C'));
            hand.Add(new Card(13, 'C'));
            hand.Add(new Card(9, 'D'));
            player = new Player(hand, "Dylan");

            Assert.AreEqual(true, player.GetHand().IsOnePair());
        }
        [TestMethod]
        public void TestHighCard()

        {

            List<PokerShowdown.Card> hand = new List<Card>();
            hand.Add(new Card(13, 'D'));
            hand.Add(new Card(13, 'S'));
            hand.Add(new Card(10, 'C'));
            hand.Add(new Card(1, 'D'));
            hand.Add(new Card(9, 'D'));
            PokerShowdown.Player player = new Player(hand, "Dylan");

            Assert.AreEqual(13, player.GetHand().HighCard().GetRank());

            hand = new List<Card>();
            hand.Add(new Card(10, 'D'));
            hand.Add(new Card(11, 'S'));
            hand.Add(new Card(12, 'C'));
            hand.Add(new Card(10, 'D'));
            hand.Add(new Card(9, 'D'));
            player = new Player(hand, "Dylan");

            Assert.AreEqual(12, player.GetHand().HighCard().GetRank());

            hand = new List<Card>();
            hand.Add(new Card(4, 'D'));
            hand.Add(new Card(1, 'S'));
            hand.Add(new Card(1, 'C'));
            hand.Add(new Card(4, 'C'));
            hand.Add(new Card(9, 'D'));
            player = new Player(hand, "Dylan");

            Assert.AreEqual(9, player.GetHand().HighCard().GetRank());
        }

        [TestMethod]
        public void TestGetCard()

        {

            List<PokerShowdown.Card> hand = new List<Card>();
            hand.Add(new Card(13, 'D'));
            hand.Add(new Card(13, 'S'));
            hand.Add(new Card(10, 'C'));
            hand.Add(new Card(1, 'D'));
            hand.Add(new Card(9, 'D'));
            PokerShowdown.Player player = new Player(hand, "Dylan");
            //should pull the highest card
            Assert.AreEqual(13, player.GetHand().getCard(0).GetRank());

            hand = new List<Card>();
            hand.Add(new Card(10, 'D'));
            hand.Add(new Card(11, 'S'));
            hand.Add(new Card(12, 'C'));
            hand.Add(new Card(10, 'D'));
            hand.Add(new Card(9, 'D'));
            player = new Player(hand, "Dylan");
            //third highest card
            Assert.AreEqual(10, player.GetHand().getCard(2).GetRank());

            hand = new List<Card>();
            hand.Add(new Card(4, 'D'));
            hand.Add(new Card(1, 'S'));
            hand.Add(new Card(1, 'C'));
            hand.Add(new Card(4, 'C'));
            hand.Add(new Card(9, 'D'));
            player = new Player(hand, "Dylan");
            //getting 2nd highest card
            Assert.AreEqual(4, player.GetHand().getCard(1).GetRank());
        }
        [TestMethod]
        public void TestGetDouplicate()

        {

            List<PokerShowdown.Card> hand = new List<Card>();
            hand.Add(new Card(13, 'D'));
            hand.Add(new Card(13, 'S'));
            hand.Add(new Card(10, 'C'));
            hand.Add(new Card(1, 'D'));
            hand.Add(new Card(9, 'D'));
            PokerShowdown.Player player = new Player(hand, "Dylan");
            //should pull the highest card
            Assert.AreEqual(13, player.GetHand().GetDouplicate().GetRank());

            hand = new List<Card>();
            hand.Add(new Card(10, 'D'));
            hand.Add(new Card(11, 'S'));
            hand.Add(new Card(12, 'C'));
            hand.Add(new Card(10, 'D'));
            hand.Add(new Card(9, 'D'));
            player = new Player(hand, "Dylan");
            //third highest card
            Assert.AreEqual(10, player.GetHand().GetDouplicate().GetRank());

            hand = new List<Card>();
            hand.Add(new Card(4, 'D'));
            hand.Add(new Card(1, 'S'));
            hand.Add(new Card(1, 'C'));
            hand.Add(new Card(4, 'C'));
            hand.Add(new Card(9, 'D'));
            player = new Player(hand, "Dylan");
            //getting 2nd highest card
            Assert.AreEqual(4, player.GetHand().GetDouplicate().GetRank());
            hand = new List<Card>();
            hand.Add(new Card(4, 'D'));
            hand.Add(new Card(1, 'S'));
            hand.Add(new Card(2, 'C'));
            hand.Add(new Card(3, 'C'));
            hand.Add(new Card(9, 'D'));
            player = new Player(hand, "Dylan");
            //getting 2nd highest card
            Assert.AreEqual(-1, player.GetHand().GetDouplicate().GetRank());
        }
        [TestMethod]
        public void TestGetWinners()

        {

            List<PokerShowdown.Card> hand = new List<Card>();
            hand.Add(new Card(13, 'D'));
            hand.Add(new Card(13, 'S'));
            hand.Add(new Card(10, 'C'));
            hand.Add(new Card(1, 'D'));
            hand.Add(new Card(9, 'D'));
            PokerShowdown.Player player1 = new Player(hand, "Dylan");

            hand = new List<Card>();
            hand.Add(new Card(10, 'D'));
            hand.Add(new Card(11, 'S'));
            hand.Add(new Card(12, 'C'));
            hand.Add(new Card(10, 'D'));
            hand.Add(new Card(9, 'D'));
            PokerShowdown.Player player2 = new Player(hand, "Robert");
            

            hand = new List<Card>();
            hand.Add(new Card(4, 'D'));
            hand.Add(new Card(1, 'S'));
            hand.Add(new Card(1, 'C'));
            hand.Add(new Card(4, 'C'));
            hand.Add(new Card(9, 'D'));
            PokerShowdown.Player player3 = new Player(hand, "Bill");

            hand = new List<Card>();
            hand.Add(new Card(4, 'D'));
            hand.Add(new Card(1, 'S'));
            hand.Add(new Card(2, 'C'));
            hand.Add(new Card(3, 'C'));
            hand.Add(new Card(9, 'D'));
            PokerShowdown.Player player4 = new Player(hand, "Ted");
            List<Player> players = new List<Player>();
            players.Add(player1);
            players.Add(player2);
            players.Add(player3);
            players.Add(player4);

            Assert.AreEqual(player1.getName(), PokerShowdown.PokerShowdown.GetWinner(players).ToArray()[0].getName());

        }
        [TestMethod]
        public void TestGetWinnersTie()

        {

            List<PokerShowdown.Card> hand = new List<Card>();
            hand.Add(new Card(13, 'D'));
            hand.Add(new Card(13, 'S'));
            hand.Add(new Card(10, 'C'));
            hand.Add(new Card(1, 'D'));
            hand.Add(new Card(9, 'D'));
            PokerShowdown.Player player1 = new Player(hand, "Dylan");

            hand = new List<Card>();
            hand.Add(new Card(13, 'C'));
            hand.Add(new Card(13, 'H'));
            hand.Add(new Card(10, 'D'));
            hand.Add(new Card(1, 'C'));
            hand.Add(new Card(9, 'S'));
            PokerShowdown.Player player2 = new Player(hand, "Robert");


            
            List<Player> players = new List<Player>();
            players.Add(player1);
            players.Add(player2);
            

            Assert.AreEqual(2, PokerShowdown.PokerShowdown.GetWinner(players).Count);

        }

    }


}
