namespace BalloonsPopConsoleApp.Tests.Models
{
    using System;

    using NUnit.Framework;

    using BalloonsPop;
    using BalloonsPopConsoleApp.Effects;
    using BalloonsPopConsoleApp.Models;
    using Memory;

    [TestFixture]
    public class BoardTests
    {
        [Test]
        public void BoardWithValidRowsAndColumnsParametersShouldBeCreated(
            [Values(5, 7, 10, 13, 15)] int validSize)
        {
            var board = new Board(validSize, validSize);
        }

        [Test]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void BoardWithInvalidRowsAndColumnsParametersShouldThrow(
            [Values(1, 3, 16, 17)] int invalidSize)
        {
            var board = new Board(invalidSize, invalidSize);
        }

        [Test]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void BoardWithValidRowsAndInvalidColumnsParametersShouldThrow()
        {
            var board = new Board(5, 4);
        }

        [Test]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void BoardWithInvalidRowsAndValidColumnsParametersShouldThrow()
        {
            var board = new Board(4, 5);
        }

        [Test]
        public void BoardContainsDifferentValuesAfterResetIsExecuted()
        {
            var size = 5;
            var board = new Board(size, size);

            var oldBoard = new int[size, size];

            for (int i = 0; i < board.Rows; i++)
            {
                for (int j = 0; j < board.Cols; j++)
                {
                    oldBoard[i, j] = board[i, j].Value;
                }
            }

            board.Reset();

            var matricesAreDifferent = false;

            for (int i = 0; i < board.Rows; i++)
            {
                for (int j = 0; j < board.Cols; j++)
                {
                    if (oldBoard[i, j] != board[i, j].Value)
                    {
                        matricesAreDifferent = true;
                    }
                }
            }

            Assert.IsTrue(matricesAreDifferent);
        }

        [Test]
        public void BoardUnpoppedBalloonsCountShouldReturnInitialAmountOfBalloons()
        {
            var size = 5;
            var board = new Board(size, size);

            var initialBalloonsCount = board.UnpoppedBalloonsCount;
            var expected = size * size;

            Assert.AreEqual(expected, initialBalloonsCount);
        }

        [Test]
        public void BoardUnpoppedBalloonsCountShouldReturnValidAmountWhenThereArePoppedBalloons()
        {
            var size = 5;
            var board = new Board(size, size);

            board[3, 3] = null;
            board[2, 2] = null;

            var balloonsCount = board.UnpoppedBalloonsCount;
            var expected = (size * size) - 2;

            Assert.AreEqual(expected, balloonsCount);
        }

        [Test]
        public void BoardSaveMementoShouldReturnAMemento()
        {
            var board = new Board(5, 5);
            var memento = board.SaveMemento().Board;

            var boardAsMatrix = new IBalloon[5, 5];

            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    boardAsMatrix[i, j] = board[i, j];
                }
            }

            var anotherMemento = new Memento(boardAsMatrix).Board;

            Assert.AreEqual(memento, anotherMemento);
        }

        [Test]
        public void BoardRestoreMementoShouldRestoreBoardToPreviousState()
        {
            var board = new Board(5, 5);
            var memento = board.SaveMemento();

            board[0, 0] = null;
            board[1, 1] = null;
            board[1, 0] = null;

            board.RestoreMemento(memento);

            if (board[0, 0] != null && board[1, 1] != null && board[1, 0] != null)
            {
                Assert.Pass();
            }
            else
            {
                Assert.Fail();
            }
        }

        [Test]
        public void BoardIsValidPopShouldReturnFalseWhenNullBalloonPositionsArePassed()
        {
            var board = new Board(5, 5);

            board[1, 1] = null;

            Assert.IsFalse(board.IsValidPop(1, 1));
        }

        [Test]
        public void BoardIsValidPopShouldReturnFalseWhenInvalidArgumentsAreProvided()
        {
            var board = new Board(5, 5);

            Assert.IsFalse(board.IsValidPop(6, 6));
        }

        [Test]
        public void BoardIsValidPopShouldReturnTrueWhenExistingValuesAreProvided()
        {
            var board = new Board(5, 5);

            Assert.IsTrue(board.IsValidPop(3, 3));
        }

        [Test]
        public void BoardToStringShouldReturnValidStringRepresentation()
        {
            var board = new Board(5, 5);
            var expectedString =
                "    0 1 2 3 4 \r\n    ----------\r\n0 | . 1 1 1 1 | \r\n1 | 1 1 1 1 1 | \r\n2 | 1 1 1 1 1 | \r\n3 | 1 1 1 1 1 | \r\n4 | 1 1 1 1 1 | \r\n    ----------\r\n";

            SetBoardMatrix(board);

            var resultingString = board.ToString();

            Assert.AreEqual(expectedString, resultingString);
        }

        private void SetBoardMatrix(IBoard board)
        {
            for (int i = 0; i < board.Rows; i++)
            {
                for (int j = 0; j < board.Cols; j++)
                {
                    board[i, j] = new Balloon(1, new AreaPopEffect());
                }
            }

            board[0, 0] = Balloon.Default;
        }
    }
}
