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
        [ExpectedException(typeof(ArgumentException))]
        [TestMethod]
        public void TestIsSuiteValid()

        {
            List<PokerShowdown.Card> hand = new List<Card>();
            hand.Add(new Card(13, 'D'));
            hand.Add(new Card(12, 'D'));
            hand.Add(new Card(11, 'B'));
            hand.Add(new Card(10, 'D'));
            hand.Add(new Card(9, 'D'));
            PokerShowdown.Player player = new Player(hand, "Dylan");

            

        }
        [ExpectedException(typeof(ArgumentException))]
        [TestMethod]
        public void TestIsRankValid()

        {
            List<PokerShowdown.Card> hand = new List<Card>();
            hand.Add(new Card(13, 'D'));
            hand.Add(new Card(12, 'D'));
            hand.Add(new Card(11, 'D'));
            hand.Add(new Card(15, 'D'));
            hand.Add(new Card(9, 'D'));
            PokerShowdown.Player player = new Player(hand, "Dylan");

           
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
            hand.Add(new Card(3, 'D'));
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
            hand.Add(new Card(3, 'D'));
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
            hand.Add(new Card(3, 'S'));
            hand.Add(new Card(3, 'C'));
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
            hand.Add(new Card(3, 'D'));
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
            //getting 2nd highest card
            Assert.AreEqual(11, player.GetHand().getCard(1).GetRank());

            hand = new List<Card>();
            hand.Add(new Card(4, 'D'));
            hand.Add(new Card(3, 'S'));
            hand.Add(new Card(2, 'C'));
            hand.Add(new Card(4, 'C'));
            hand.Add(new Card(9, 'D'));
            player = new Player(hand, "Dylan");
            //getting 3rd highest card
            Assert.AreEqual(4, player.GetHand().getCard(2).GetRank());
        }
        [TestMethod]
        public void TestGetDouplicate()

        {

            List<PokerShowdown.Card> hand = new List<Card>();
            hand.Add(new Card(13, 'D'));
            hand.Add(new Card(13, 'S'));
            hand.Add(new Card(10, 'C'));
            hand.Add(new Card(3, 'D'));
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
            hand.Add(new Card(3, 'S'));
            hand.Add(new Card(3, 'C'));
            hand.Add(new Card(4, 'C'));
            hand.Add(new Card(9, 'D'));
            player = new Player(hand, "Dylan");
            //getting 2nd highest card
            Assert.AreEqual(4, player.GetHand().GetDouplicate().GetRank());
            hand = new List<Card>();
            hand.Add(new Card(4, 'D'));
            hand.Add(new Card(3, 'S'));
            hand.Add(new Card(2, 'C'));
            hand.Add(new Card(10, 'C'));
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
            hand.Add(new Card(3, 'D'));
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
            hand.Add(new Card(3, 'S'));
            hand.Add(new Card(3, 'C'));
            hand.Add(new Card(4, 'C'));
            hand.Add(new Card(9, 'D'));
            PokerShowdown.Player player3 = new Player(hand, "Bill");

            hand = new List<Card>();
            hand.Add(new Card(4, 'D'));
            hand.Add(new Card(3, 'S'));
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
            hand.Add(new Card(3, 'D'));
            hand.Add(new Card(9, 'D'));
            PokerShowdown.Player player1 = new Player(hand, "Dylan");

            hand = new List<Card>();
            hand.Add(new Card(13, 'C'));
            hand.Add(new Card(13, 'H'));
            hand.Add(new Card(10, 'D'));
            hand.Add(new Card(3, 'C'));
            hand.Add(new Card(9, 'S'));
            PokerShowdown.Player player2 = new Player(hand, "Robert");


            
            List<Player> players = new List<Player>();
            players.Add(player1);
            players.Add(player2);
            

            Assert.AreEqual(2, PokerShowdown.PokerShowdown.GetWinner(players).Count);

        }
        [TestMethod]
        public void TestGetWinnersHighCardWin()

        {

            List<PokerShowdown.Card> hand = new List<Card>();
            hand.Add(new Card(13, 'D'));
            hand.Add(new Card(12, 'S'));
            hand.Add(new Card(10, 'C'));
            hand.Add(new Card(3, 'D'));
            hand.Add(new Card(9, 'D'));
            PokerShowdown.Player player1 = new Player(hand, "Dylan");

            hand = new List<Card>();
            hand.Add(new Card(7, 'C'));
            hand.Add(new Card(9, 'H'));
            hand.Add(new Card(10, 'D'));
            hand.Add(new Card(5, 'C'));
            hand.Add(new Card(3, 'S'));
            PokerShowdown.Player player2 = new Player(hand, "Robert");



            List<Player> players = new List<Player>();
            players.Add(player1);
            players.Add(player2);


            Assert.AreEqual(player1, PokerShowdown.PokerShowdown.GetWinner(players).ToArray()[0]);

        }
        [TestMethod]
        public void TestGetWinnersFlushWin()

        {

            List<PokerShowdown.Card> hand = new List<Card>();
            hand.Add(new Card(13, 'D'));
            hand.Add(new Card(12, 'D'));
            hand.Add(new Card(10, 'D'));
            hand.Add(new Card(3, 'D'));
            hand.Add(new Card(9, 'D'));
            PokerShowdown.Player player1 = new Player(hand, "Dylan");

            hand = new List<Card>();
            hand.Add(new Card(7, 'C'));
            hand.Add(new Card(9, 'H'));
            hand.Add(new Card(4, 'D'));
            hand.Add(new Card(3, 'C'));
            hand.Add(new Card(9, 'S'));
            PokerShowdown.Player player2 = new Player(hand, "Robert");



            List<Player> players = new List<Player>();
            players.Add(player1);
            players.Add(player2);


            Assert.AreEqual(player1, PokerShowdown.PokerShowdown.GetWinner(players).ToArray()[0]);

        }
        [TestMethod]
        public void TestGetWinnersThreeOfAKindWin()

        {

            List<PokerShowdown.Card> hand = new List<Card>();
            hand.Add(new Card(13, 'D'));
            hand.Add(new Card(12, 'D'));
            hand.Add(new Card(10, 'S'));
            hand.Add(new Card(3, 'D'));
            hand.Add(new Card(9, 'D'));
            PokerShowdown.Player player1 = new Player(hand, "Dylan");

            hand = new List<Card>();
            hand.Add(new Card(7, 'C'));
            hand.Add(new Card(7, 'H'));
            hand.Add(new Card(7, 'D'));
            hand.Add(new Card(3, 'C'));
            hand.Add(new Card(9, 'S'));
            PokerShowdown.Player player2 = new Player(hand, "Robert");



            List<Player> players = new List<Player>();
            players.Add(player1);
            players.Add(player2);


            Assert.AreEqual(player2, PokerShowdown.PokerShowdown.GetWinner(players).ToArray()[0]);

        }
        [TestMethod]
        public void TestGetWinnersOnePairWin()

        {

            List<PokerShowdown.Card> hand = new List<Card>();
            hand.Add(new Card(13, 'D'));
            hand.Add(new Card(12, 'D'));
            hand.Add(new Card(10, 'S'));
            hand.Add(new Card(3, 'D'));
            hand.Add(new Card(9, 'D'));
            PokerShowdown.Player player1 = new Player(hand, "Dylan");

            hand = new List<Card>();
            hand.Add(new Card(7, 'C'));
            hand.Add(new Card(7, 'H'));
            hand.Add(new Card(2, 'D'));
            hand.Add(new Card(3, 'C'));
            hand.Add(new Card(9, 'S'));
            PokerShowdown.Player player2 = new Player(hand, "Robert");

            hand = new List<Card>();
            hand.Add(new Card(13, 'H'));
            hand.Add(new Card(12, 'H'));
            hand.Add(new Card(10, 'D'));
            hand.Add(new Card(3, 'C'));
            hand.Add(new Card(9, 'C'));
            PokerShowdown.Player player3 = new Player(hand, "Bill");


            List<Player> players = new List<Player>();
            players.Add(player1);
            players.Add(player2);
            players.Add(player3);


            Assert.AreEqual(player2, PokerShowdown.PokerShowdown.GetWinner(players).ToArray()[0]);

        }
        [TestMethod]
        public void TestGetWinnersFlushWinTie()

        {

            List<PokerShowdown.Card> hand = new List<Card>();
            hand.Add(new Card(13, 'D'));
            hand.Add(new Card(12, 'D'));
            hand.Add(new Card(10, 'D'));
            hand.Add(new Card(3, 'D'));
            hand.Add(new Card(9, 'D'));
            PokerShowdown.Player player1 = new Player(hand, "Dylan");

            hand = new List<Card>();
            hand.Add(new Card(7, 'C'));
            hand.Add(new Card(7, 'H'));
            hand.Add(new Card(2, 'D'));
            hand.Add(new Card(3, 'C'));
            hand.Add(new Card(9, 'S'));
            PokerShowdown.Player player2 = new Player(hand, "Robert");

            hand = new List<Card>();
            hand.Add(new Card(13, 'H'));
            hand.Add(new Card(12, 'H'));
            hand.Add(new Card(10, 'H'));
            hand.Add(new Card(3, 'H'));
            hand.Add(new Card(9, 'H'));
            PokerShowdown.Player player3 = new Player(hand, "Bill");


            List<Player> players = new List<Player>();
            players.Add(player1);
            players.Add(player2);
            players.Add(player3);


            Assert.AreEqual(2, PokerShowdown.PokerShowdown.GetWinner(players).Count);

        }
        [TestMethod]
        public void TestGetWinnersThreeofKindWinTie()

        {
            ///This should never happen in a real game since there can only be 4 of one rank of card.
            ///
            List<PokerShowdown.Card> hand = new List<Card>();
            hand.Add(new Card(13, 'D'));
            hand.Add(new Card(13, 'S'));
            hand.Add(new Card(13, 'H'));
            hand.Add(new Card(3, 'D'));
            hand.Add(new Card(9, 'D'));
            PokerShowdown.Player player1 = new Player(hand, "Dylan");

            hand = new List<Card>();
            hand.Add(new Card(7, 'C'));
            hand.Add(new Card(11, 'H'));
            hand.Add(new Card(2, 'D'));
            hand.Add(new Card(3, 'C'));
            hand.Add(new Card(9, 'S'));
            PokerShowdown.Player player2 = new Player(hand, "Robert");

            hand = new List<Card>();
            hand.Add(new Card(13, 'H'));
            hand.Add(new Card(13, 'C'));
            hand.Add(new Card(13, 'H'));
            hand.Add(new Card(3, 'H'));
            hand.Add(new Card(9, 'H'));
            PokerShowdown.Player player3 = new Player(hand, "Bill");


            List<Player> players = new List<Player>();
            players.Add(player1);
            players.Add(player2);
            players.Add(player3);


            Assert.AreEqual(2, PokerShowdown.PokerShowdown.GetWinner(players).Count);

        }
        [TestMethod]
        public void TestGetWinnersOnePairWinTie()

        {

            List<PokerShowdown.Card> hand = new List<Card>();
            hand.Add(new Card(13, 'D'));
            hand.Add(new Card(13, 'S'));
            hand.Add(new Card(10, 'S'));
            hand.Add(new Card(3, 'D'));
            hand.Add(new Card(9, 'D'));
            PokerShowdown.Player player1 = new Player(hand, "Dylan");

            hand = new List<Card>();
            hand.Add(new Card(7, 'C'));
            hand.Add(new Card(11, 'H'));
            hand.Add(new Card(2, 'D'));
            hand.Add(new Card(3, 'C'));
            hand.Add(new Card(9, 'S'));
            PokerShowdown.Player player2 = new Player(hand, "Robert");

            hand = new List<Card>();
            hand.Add(new Card(13, 'H'));
            hand.Add(new Card(13, 'C'));
            hand.Add(new Card(10, 'H'));
            hand.Add(new Card(3, 'H'));
            hand.Add(new Card(9, 'H'));
            PokerShowdown.Player player3 = new Player(hand, "Bill");


            List<Player> players = new List<Player>();
            players.Add(player1);
            players.Add(player2);
            players.Add(player3);


            Assert.AreEqual(2, PokerShowdown.PokerShowdown.GetWinner(players).Count);

        }
        [TestMethod]
        public void TestGetWinnersHighCardWinTie()

        {

            List<PokerShowdown.Card> hand = new List<Card>();
            hand.Add(new Card(13, 'D'));
            hand.Add(new Card(9, 'S'));
            hand.Add(new Card(2, 'S'));
            hand.Add(new Card(3, 'D'));
            hand.Add(new Card(9, 'D'));
            PokerShowdown.Player player1 = new Player(hand, "Dylan");

            hand = new List<Card>();
            hand.Add(new Card(7, 'C'));
            hand.Add(new Card(11, 'H'));
            hand.Add(new Card(2, 'D'));
            hand.Add(new Card(3, 'C'));
            hand.Add(new Card(9, 'S'));
            PokerShowdown.Player player2 = new Player(hand, "Robert");

            hand = new List<Card>();
            hand.Add(new Card(13, 'H'));
            hand.Add(new Card(9, 'H'));
            hand.Add(new Card(2, 'H'));
            hand.Add(new Card(3, 'H'));
            hand.Add(new Card(9, 'C'));
            PokerShowdown.Player player3 = new Player(hand, "Bill");


            List<Player> players = new List<Player>();
            players.Add(player1);
            players.Add(player2);
            players.Add(player3);


            Assert.AreEqual(2, PokerShowdown.PokerShowdown.GetWinner(players).Count);

        }

        [TestMethod]
        public void TestGetWinnersFlushWithThreeOfKindWin()

        {

            List<PokerShowdown.Card> hand = new List<Card>();
            hand.Add(new Card(13, 'D'));
            hand.Add(new Card(9, 'S'));
            hand.Add(new Card(2, 'S'));
            hand.Add(new Card(3, 'D'));
            hand.Add(new Card(9, 'D'));
            PokerShowdown.Player player1 = new Player(hand, "Dylan");

            hand = new List<Card>();
            hand.Add(new Card(7, 'C'));
            hand.Add(new Card(7, 'H'));
            hand.Add(new Card(7, 'D'));
            hand.Add(new Card(3, 'C'));
            hand.Add(new Card(9, 'S'));
            PokerShowdown.Player player2 = new Player(hand, "Robert");

            hand = new List<Card>();
            hand.Add(new Card(13, 'H'));
            hand.Add(new Card(9, 'H'));
            hand.Add(new Card(2, 'H'));
            hand.Add(new Card(3, 'H'));
            hand.Add(new Card(9, 'H'));
            PokerShowdown.Player player3 = new Player(hand, "Bill");


            List<Player> players = new List<Player>();
            players.Add(player1);
            players.Add(player2);
            players.Add(player3);


            Assert.AreEqual(player3, PokerShowdown.PokerShowdown.GetWinner(players).ToArray()[0]);

        }
        [TestMethod]
        public void TestGetWinnersTwoFlushOneWin()

        {

            List<PokerShowdown.Card> hand = new List<Card>();
            hand.Add(new Card(13, 'D'));
            hand.Add(new Card(9, 'D'));
            hand.Add(new Card(2, 'D'));
            hand.Add(new Card(3, 'D'));
            hand.Add(new Card(5, 'D'));
            PokerShowdown.Player player1 = new Player(hand, "Dylan");

            hand = new List<Card>();
            hand.Add(new Card(7, 'C'));
            hand.Add(new Card(7, 'H'));
            hand.Add(new Card(7, 'D'));
            hand.Add(new Card(3, 'C'));
            hand.Add(new Card(9, 'S'));
            PokerShowdown.Player player2 = new Player(hand, "Robert");

            hand = new List<Card>();
            hand.Add(new Card(12, 'H'));
            hand.Add(new Card(9, 'H'));
            hand.Add(new Card(2, 'H'));
            hand.Add(new Card(3, 'H'));
            hand.Add(new Card(9, 'H'));
            PokerShowdown.Player player3 = new Player(hand, "Bill");


            List<Player> players = new List<Player>();
            players.Add(player1);
            players.Add(player2);
            players.Add(player3);


            Assert.AreEqual(player1, PokerShowdown.PokerShowdown.GetWinner(players).ToArray()[0]);

        }
        [TestMethod]
        public void TestGetWinnersOneOfEachHand()

        {

            List<PokerShowdown.Card> hand = new List<Card>();
            hand.Add(new Card(13, 'D'));
            hand.Add(new Card(9, 'D'));
            hand.Add(new Card(2, 'D'));
            hand.Add(new Card(3, 'D'));
            hand.Add(new Card(5, 'D'));
            PokerShowdown.Player player1 = new Player(hand, "Dylan");

            hand = new List<Card>();
            hand.Add(new Card(7, 'C'));
            hand.Add(new Card(7, 'H'));
            hand.Add(new Card(7, 'D'));
            hand.Add(new Card(3, 'C'));
            hand.Add(new Card(9, 'S'));
            PokerShowdown.Player player2 = new Player(hand, "Robert");

            hand = new List<Card>();
            hand.Add(new Card(12, 'H'));
            hand.Add(new Card(13, 'H'));
            hand.Add(new Card(2, 'H'));
            hand.Add(new Card(3, 'H'));
            hand.Add(new Card(13, 'H'));
            PokerShowdown.Player player3 = new Player(hand, "Bill");

            hand = new List<Card>();
            hand.Add(new Card(13, 'D'));
            hand.Add(new Card(9, 'D'));
            hand.Add(new Card(2, 'D'));
            hand.Add(new Card(3, 'S'));
            hand.Add(new Card(5, 'D'));
            PokerShowdown.Player player4 = new Player(hand, "Dylan");

            List<Player> players = new List<Player>();
            players.Add(player1);
            players.Add(player2);
            players.Add(player3);
            players.Add(player4);


            Assert.AreEqual(player1, PokerShowdown.PokerShowdown.GetWinner(players).ToArray()[0]);

        }
        [TestMethod]
        public void TestGetWinnersTenPlayers()

        {

            List<PokerShowdown.Card> hand = new List<Card>();
            hand.Add(new Card(13, 'D'));
            hand.Add(new Card(9, 'D'));
            hand.Add(new Card(2, 'D'));
            hand.Add(new Card(3, 'D'));
            hand.Add(new Card(5, 'D'));
            PokerShowdown.Player player1 = new Player(hand, "Dylan");

            hand = new List<Card>();
            hand.Add(new Card(7, 'C'));
            hand.Add(new Card(7, 'H'));
            hand.Add(new Card(7, 'D'));
            hand.Add(new Card(3, 'C'));
            hand.Add(new Card(9, 'S'));
            PokerShowdown.Player player2 = new Player(hand, "Robert");

            hand = new List<Card>();
            hand.Add(new Card(12, 'H'));
            hand.Add(new Card(13, 'H'));
            hand.Add(new Card(2, 'H'));
            hand.Add(new Card(3, 'H'));
            hand.Add(new Card(13, 'H'));
            PokerShowdown.Player player3 = new Player(hand, "Bill");

            hand = new List<Card>();
            hand.Add(new Card(13, 'D'));
            hand.Add(new Card(9, 'D'));
            hand.Add(new Card(2, 'D'));
            hand.Add(new Card(3, 'S'));
            hand.Add(new Card(5, 'D'));
            PokerShowdown.Player player4 = new Player(hand, "Rodger");

            hand = new List<Card>();
            hand.Add(new Card(13, 'D'));
            hand.Add(new Card(9, 'D'));
            hand.Add(new Card(2, 'D'));
            hand.Add(new Card(3, 'S'));
            hand.Add(new Card(5, 'D'));
            PokerShowdown.Player player5 = new Player(hand, "Jordan");

            hand = new List<Card>();
            hand.Add(new Card(13, 'D'));
            hand.Add(new Card(9, 'D'));
            hand.Add(new Card(13, 'D'));
            hand.Add(new Card(3, 'S'));
            hand.Add(new Card(13, 'H'));
            PokerShowdown.Player player6 = new Player(hand, "Wilson");

            hand = new List<Card>();
            hand.Add(new Card(9, 'D'));
            hand.Add(new Card(2, 'D'));
            hand.Add(new Card(13, 'D'));
            hand.Add(new Card(13, 'C'));
            hand.Add(new Card(13, 'H'));
            PokerShowdown.Player player7 = new Player(hand, "Donald");

            hand = new List<Card>();
            hand.Add(new Card(13, 'D'));
            hand.Add(new Card(9, 'D'));
            hand.Add(new Card(2, 'D'));
            hand.Add(new Card(3, 'S'));
            hand.Add(new Card(5, 'D'));
            PokerShowdown.Player player8 = new Player(hand, "Even");

            hand = new List<Card>();
            hand.Add(new Card(13, 'D'));
            hand.Add(new Card(9, 'D'));
            hand.Add(new Card(13, 'C'));
            hand.Add(new Card(13, 'H'));
            hand.Add(new Card(5, 'D'));
            PokerShowdown.Player player9 = new Player(hand, "Wally");

            hand = new List<Card>();
            hand.Add(new Card(13, 'C'));
            hand.Add(new Card(13, 'H'));
            hand.Add(new Card(10, 'D'));
            hand.Add(new Card(3, 'C'));
            hand.Add(new Card(9, 'S'));
            PokerShowdown.Player player10 = new Player(hand, "Joe");

            List<Player> players = new List<Player>();
            players.Add(player1);
            players.Add(player2);
            players.Add(player3);
            players.Add(player4);

            //Dylan should win with a flush
            Assert.AreEqual(player1, PokerShowdown.PokerShowdown.GetWinner(players).ToArray()[0]);

        }


    }


}
