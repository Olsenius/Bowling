using System;
using System.Linq;
using NUnit.Framework;
using Should;

namespace Bowling1
{
    [TestFixture]
    public class BowlingTest
    {
        private Game _game;

        [SetUp]
        public void SetUp()
        {
            _game = new Game();
        }

        [Test]
        public void Gutter_game()
        {
            20.Times(() => _game.Roll(0));

            _game.Score().ShouldEqual(0);
        }

        [Test]
        public void All_ones()
        {
            20.Times(() => _game.Roll(1));

            _game.Score().ShouldEqual(20);
        }

        [Test]
        public void Spare()
        {
            _game.Roll(5);
            _game.Roll(5);
            _game.Roll(3);

            17.Times(() => _game.Roll(0));

            _game.Score().ShouldEqual(16);
        }
    }

    public class Game
    {
        private readonly int[] _rolls = new int[21];
        private int _currentRoll;

        public void Roll(int pins)
        {
            _rolls[_currentRoll++] = pins;
        }

        public int Score()
        {
            return _rolls.Sum();
        }
    }

    public static class IntExtensions
    {
        public static void Times(this int number, Action action)
        {
            for (int i = 0; i < number; i++)
                action();
        }
    }
}