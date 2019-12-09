using Microsoft.VisualStudio.TestTools.UnitTesting;
using RobotsProblem.Entities;
using RobotsProblem.Entities.Enums;
using RobotsProblem.Exceptions;
using RobotsProblemTest.Fixtures;

namespace RobotsProblemTest
{
    // Because the robots are not stackable, we should write new default positions to add robots on grid for each test.
    // Otherwise, the robots will collide and we'll receive an unhandled exceptions which will state that
    // the cell where we want to add robot is already occupied.

    [TestClass]
    public class RobotTests
    {
        [TestMethod]
        public void RunCircleAcrossTheBorderTest()
        {
            // because the previous tests may scent some border cells, we should reinitalize grid for this test.

            GridFixture.InitializeFixture();

            var robot = new Robot(GridFixture.RobotOperator, GridFixture.Grid, (0, 0), Orientation.East);

            for (var i = 0; i < GridFixture.DefinedGridSize.Item1; i++)
            {
                robot.MoveForward();
            }

            robot.TurnLeft();

            for (var i = 0; i < GridFixture.DefinedGridSize.Item2; i++)
            {
                robot.MoveForward();
            }

            robot.TurnLeft();

            for (var i = GridFixture.DefinedGridSize.Item1; i > 0; i--)
            {
                robot.MoveForward();
            }

            robot.TurnLeft();

            for (var i = GridFixture.DefinedGridSize.Item2; i > 0; i--)
            {
                robot.MoveForward();
            }

            Assert.IsFalse(GridFixture.Grid.GetCellInfo(new GridPosition
            {
                X = GridFixture.DefinedGridSize.Item1,
                Y = GridFixture.DefinedGridSize.Item2
            }).IsOccupied);

            Assert.IsTrue(robot.CurrentPosition.X == 0);
            Assert.IsTrue(robot.CurrentPosition.Y == 0);
        }

        [TestMethod]
        [ExpectedException(typeof(RobotOutOfBoundsException))]
        public void CheckThatRobotDestroyedOnBoundaryCrossTest()
        {
            var robot = new Robot(GridFixture.RobotOperator, GridFixture.Grid, (1, 1), Orientation.East);

            for (var i = 0; i < 5; i++)
            {
                robot.MoveForward();
            }
        }

        [TestMethod]
        public void CheckThatRobotDoesNotListenToCommandsAfterItsLostTest()
        {
            var robot = new Robot(GridFixture.RobotOperator, GridFixture.Grid, (2, 1), Orientation.East);

            try
            {
                for (var i = 0; i < 5; i++)
                {
                    robot.MoveForward();
                }
            }
            catch (RobotOutOfBoundsException)
            {
                Assert.IsTrue(robot.IsLost);

                robot.TurnRight();
                Assert.IsTrue(robot.CurrentOrientation == Orientation.East);
            }
        }

        [TestMethod]
        public void RunToOpposeDirectionWhereAlreadyHasBeenTest()
        {
            var robot = new Robot(GridFixture.RobotOperator, GridFixture.Grid, (2, 2), Orientation.East);

            robot.MoveForward();

            robot.TurnRight();
            robot.TurnRight();

            robot.MoveForward();

            Assert.IsTrue(robot.CurrentPosition.X == 2);
            Assert.IsTrue(robot.CurrentPosition.Y == 2);
        }

        [TestMethod]
        public void RunCircleInsideBorderTest()
        {
            var robot = new Robot(GridFixture.RobotOperator, GridFixture.Grid, (3, 3), Orientation.East);

            for (int i = 0; i < 4; i++)
            {
                robot.TurnRight();
                robot.MoveForward();
            }

            Assert.IsTrue(robot.CurrentPosition.X == 3);
            Assert.IsTrue(robot.CurrentPosition.Y == 3);

            Assert.IsTrue(robot.CurrentOrientation == Orientation.East);
        }

        [TestMethod]
        [ExpectedException(typeof(RobotMovedIntoOccupiedCellException))]
        public void TryToCreateTwoRobotsOnSamePlace()
        {
            var robot = new Robot(GridFixture.RobotOperator, GridFixture.Grid, (4, 3), Orientation.East);

            var secondRobot = new Robot(GridFixture.RobotOperator, GridFixture.Grid, (4, 3), Orientation.West);
        }

        [TestMethod]
        public void TwoRobotsCollide()
        {
            var robot = new Robot(GridFixture.RobotOperator, GridFixture.Grid, (1, 2), Orientation.East);
            var secondRobot = new Robot(GridFixture.RobotOperator, GridFixture.Grid, (1, 3), Orientation.East);

            try
            {
                secondRobot.MoveForward();
                secondRobot.TurnRight();
                secondRobot.TurnRight();
                secondRobot.MoveForward();

                robot.MoveForward();
                robot.MoveForward();
            }
            catch (RobotMovedIntoOccupiedCellException)
            {
                Assert.IsTrue(robot.CurrentPosition.X == 2);
            }
        }

        [TestMethod]
        public void TryToMoveRobotOutOfBoundariesAfterOtherRobotHasBeenMovedOutThroughSameBoundary()
        {
            var robot = new Robot(GridFixture.RobotOperator, GridFixture.Grid, (2, 1), Orientation.East);

            try
            {
                for (var i = 0; i < 5; i++)
                {
                    robot.MoveForward();
                }
            }
            catch (RobotOutOfBoundsException)
            {
                var newRobot = new Robot(GridFixture.RobotOperator, GridFixture.Grid, (2, 1), Orientation.East);

                for (var i = 0; i < 5; i++)
                {
                    newRobot.MoveForward();
                }

                Assert.IsFalse(newRobot.IsLost);
            }
        }
    }
}
