using System;
using System.Collections.Generic;

namespace WarCardGame
{
    public static class WarCardGame
    {
        private const int Draw = -1;
        public static int Play(IEnumerable<IComparable> hand1, IEnumerable<IComparable> hand2)
        {
            var players = new[]
            {
                new Player(hand1),
                new Player(hand2),
            };
            var winner = Draw;
            while (players[0].HasCards && players[1].HasCards)
            {
                var cards = new[] {players[0].PlayCard(), players[1].PlayCard()};
                if (cards[0].CompareTo(cards[1]) != 0)
                {
                    winner = cards[0].CompareTo(cards[1]) > 0 ? 0 : 1;
                    var loser = winner ^ 1;
                    players[winner].TakeCard(cards[winner]);
                    players[winner].TakeCard(cards[loser]);
                }
                else
                {
                    winner = FightWar(players[0], players[1]);
                    if (winner == Draw)
                    {
                        return 0;
                    }
                    players[winner].TakeCards(cards);
                }
            }
            return winner + 1;
        }

        private static int FightWar(Player player1, Player player2)
        {
            var players = new[] {player1, player2};
            var warCards = new[] {new Queue<IComparable>(), new Queue<IComparable>()};
            var drawCount = 4;
            if (!players[0].CanPlay(drawCount) || !players[1].CanPlay(drawCount))
            {
                if (!players[0].HasCards && !players[1].HasCards)
                {
                    return Draw;
                }
                var smallestDeck = players[0].CardCount < players[1].CardCount ? 0 : 1;
                drawCount = players[smallestDeck].CardCount;
            }
            for (var i = 0; i < drawCount; i++)
            {
                warCards[0].Enqueue(players[0].PlayCard());
                warCards[1].Enqueue(players[1].PlayCard());
            }
            int winner;
            if (warCards[0].Peek().CompareTo(warCards[1].Peek()) == 0)
            {
                winner = FightWar(players[0], players[1]);
                if (winner == Draw)
                {
                    return Draw;
                }
            }
            else
            {
                winner = warCards[0].Peek().CompareTo(warCards[1].Peek()) > 0 ? 0 : 1;
            }
            var loser = winner ^ 1;
            players[winner].TakeCards(warCards[winner].ToArray());
            players[winner].TakeCards(warCards[loser].ToArray());

            return winner;
        }
    }
}
