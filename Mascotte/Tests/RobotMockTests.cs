using NUnit.Framework;
using RobotMock;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests
{
    public class RobotMockTests
    {
        [Test]
        public void MotorTests()
        {
            Motor m1 = new Motor(true);
            Motor m2 = new Motor(false);
            Assert.IsNotNull(m1);
            Assert.IsNotNull(m2);

            // Check speed
            Assert.AreEqual(m1.Speed, 0, "m1 speed != 0");
            Assert.AreEqual(m2.Speed, 0, "m2 speed != 0");

            // Change speed
            m1.SetSpeed(0.5);
            Assert.AreEqual(m1.Speed, 1000, "m1 speed != 1000 Hz");
            Assert.AreEqual(m2.Speed, 0, "m2 speed != 0 Hz");
            m2.SetSpeed(0.2);
            Assert.AreEqual(m2.Speed, 400, "m2 speed != 400 Hz");
            Assert.AreEqual(m1.Speed, 1000, "m1 speed != 1000 Hz");

            // Change direction
            m1.Direction = !m1.Direction;
            Assert.AreEqual(m1.Speed, 1000, "m1 speed != 1000 Hz");
            Assert.AreEqual(m1.Direction, false, "m1 direction != false");
            m2.Direction = !m2.Direction;
            Assert.AreEqual(m2.Speed, 400, "m2 speed != 400 Hz");
            Assert.AreEqual(m2.Direction, true, "m2 direction != true");

            // Run motors
            Assert.AreEqual(m1.IsRunning, false, "m1 is running");
            Assert.AreEqual(m2.IsRunning, false, "m2 is running");
            
            m1.Run();
            m2.Run();
            Assert.AreEqual(m1.IsRunning, true, "m1 is stopped");
            Assert.AreEqual(m2.IsRunning, true, "m2 is stopped");

            // Stop motors
            m1.Stop();
            m2.Stop();
            Assert.AreEqual(m1.Speed, 0, "m1 didn't stop");
            Assert.AreEqual(m2.Speed, 0, "m2 didn't stop");
            Assert.AreEqual(m1.IsRunning, false, "m1 still running");
            Assert.AreEqual(m2.IsRunning, false, "m2 still running");
        }
        [Test]
        public void RoverTests()
        {
            Rover r = new Rover();
            Assert.NotNull(r, "r doen't exist");

            // Check motors
            Assert.AreEqual(r.LeftMotors[0].Direction, true, "Motor Left 0 direction != true");
            Assert.AreEqual(r.LeftMotors[1].Direction, false, "Motor Left 1 direction != false");
            Assert.AreEqual(r.RightMotors[0].Direction, true, "Motor Right 0 direction != true");
            Assert.AreEqual(r.RightMotors[1].Direction, false, "Motor Right 1 direction != false");
            Assert.AreEqual(r.LeftMotors[0].Speed, 0, "Motor Left 0 speed != 0");
            Assert.AreEqual(r.LeftMotors[1].Speed, 0, "Motor Left 1 speed != 0");
            Assert.AreEqual(r.RightMotors[0].Speed, 0, "Motor Right 0 speed != 0");
            Assert.AreEqual(r.RightMotors[1].Speed, 0, "Motor Right 1 speed != 0");
            Assert.AreEqual(r.LeftMotors[0].IsRunning, false, "Motor left 0 is running");
            Assert.AreEqual(r.LeftMotors[1].IsRunning, false, "Motor left 1 is running");
            Assert.AreEqual(r.RightMotors[0].IsRunning, false, "Motor right 0 is running");
            Assert.AreEqual(r.RightMotors[1].IsRunning, false, "Motor right 1 is running");

            // Move robot
            r.Move(true, 0.5);
            Assert.AreEqual(r.LeftMotors[0].Direction, true, "Motor Left 0 direction != true");
            Assert.AreEqual(r.LeftMotors[1].Direction, false, "Motor Left 1 direction != false");
            Assert.AreEqual(r.RightMotors[0].Direction, true, "Motor Right 0 direction != true");
            Assert.AreEqual(r.RightMotors[1].Direction, false, "Motor Right 1 direction != false");
            Assert.AreEqual(r.LeftMotors[0].Speed, 1000, "Motor Left 0 speed != 1000");
            Assert.AreEqual(r.LeftMotors[1].Speed, 1000, "Motor Left 1 speed != 1000");
            Assert.AreEqual(r.RightMotors[0].Speed, 1000, "Motor Right 0 speed != 1000");
            Assert.AreEqual(r.RightMotors[1].Speed, 1000, "Motor Right 1 speed != 1000");
            Assert.AreEqual(r.LeftMotors[0].IsRunning, true, "Motor left 0 is stopped");
            Assert.AreEqual(r.LeftMotors[1].IsRunning, true, "Motor left 1 is stopped");
            Assert.AreEqual(r.RightMotors[0].IsRunning, true, "Motor right 0 is stopped");
            Assert.AreEqual(r.RightMotors[1].IsRunning, true, "Motor right 1 is stopped");
            
            // Move backward
            r.Move(false, 0.5);
            Assert.AreEqual(r.LeftMotors[0].Direction, false, "Motor Left 0 direction != false");
            Assert.AreEqual(r.LeftMotors[1].Direction, true, "Motor Left 1 direction != true");
            Assert.AreEqual(r.RightMotors[0].Direction, false, "Motor Right 0 direction != false");
            Assert.AreEqual(r.RightMotors[1].Direction, true, "Motor Right 1 direction != true");
            Assert.AreEqual(r.LeftMotors[0].Speed, 1000, "Motor Left 0 speed != 1000");
            Assert.AreEqual(r.LeftMotors[1].Speed, 1000, "Motor Left 1 speed != 1000");
            Assert.AreEqual(r.RightMotors[0].Speed, 1000, "Motor Right 0 speed != 1000");
            Assert.AreEqual(r.RightMotors[1].Speed, 1000, "Motor Right 1 speed != 1000");
            Assert.AreEqual(r.LeftMotors[0].IsRunning, true, "Motor left 0 is stopped");
            Assert.AreEqual(r.LeftMotors[1].IsRunning, true, "Motor left 1 is stopped");
            Assert.AreEqual(r.RightMotors[0].IsRunning, true, "Motor right 0 is stopped");
            Assert.AreEqual(r.RightMotors[1].IsRunning, true, "Motor right 1 is stopped");

            // Turn left
            r.Turn(false, 0.1, 90);
            Assert.AreEqual(r.LeftMotors[0].Direction, false, "Motor Left 0 direction != false");
            Assert.AreEqual(r.LeftMotors[1].Direction, true, "Motor Left 1 direction != true");
            Assert.AreEqual(r.RightMotors[0].Direction, true, "Motor Right 0 direction != true");
            Assert.AreEqual(r.RightMotors[1].Direction, false, "Motor Right 1 direction != false");
            Assert.AreEqual(r.LeftMotors[0].Speed, 200, "Motor Left 0 speed != 200");
            Assert.AreEqual(r.LeftMotors[1].Speed, 200, "Motor Left 1 speed != 200");
            Assert.AreEqual(r.RightMotors[0].Speed, 200, "Motor Right 0 speed != 200");
            Assert.AreEqual(r.RightMotors[1].Speed, 200, "Motor Right 1 speed != 200");
            Assert.AreEqual(r.LeftMotors[0].IsRunning, true, "Motor left 0 is stopped");
            Assert.AreEqual(r.LeftMotors[1].IsRunning, true, "Motor left 1 is stopped");
            Assert.AreEqual(r.RightMotors[0].IsRunning, true, "Motor right 0 is stopped");
            Assert.AreEqual(r.RightMotors[1].IsRunning, true, "Motor right 1 is stopped");

            // Turn right
            r.Turn(true, 0.1, 90);
            Assert.AreEqual(r.LeftMotors[0].Direction, true, "Motor Left 0 direction != true");
            Assert.AreEqual(r.LeftMotors[1].Direction, false, "Motor Left 1 direction != false");
            Assert.AreEqual(r.RightMotors[0].Direction, false, "Motor Right 0 direction != false");
            Assert.AreEqual(r.RightMotors[1].Direction, true, "Motor Right 1 direction != true");
            Assert.AreEqual(r.LeftMotors[0].Speed, 200, "Motor Left 0 speed != 200");
            Assert.AreEqual(r.LeftMotors[1].Speed, 200, "Motor Left 1 speed != 200");
            Assert.AreEqual(r.RightMotors[0].Speed, 200, "Motor Right 0 speed != 200");
            Assert.AreEqual(r.RightMotors[1].Speed, 200, "Motor Right 1 speed != 200");
            Assert.AreEqual(r.LeftMotors[0].IsRunning, true, "Motor left 0 is stopped");
            Assert.AreEqual(r.LeftMotors[1].IsRunning, true, "Motor left 1 is stopped");
            Assert.AreEqual(r.RightMotors[0].IsRunning, true, "Motor right 0 is stopped");
            Assert.AreEqual(r.RightMotors[1].IsRunning, true, "Motor right 1 is stopped");

            // Stop
            r.Stop();
            Assert.AreEqual(r.LeftMotors[0].Direction, true, "Motor Left 0 direction != true");
            Assert.AreEqual(r.LeftMotors[1].Direction, false, "Motor Left 1 direction != false");
            Assert.AreEqual(r.RightMotors[0].Direction, false, "Motor Right 0 direction != false");
            Assert.AreEqual(r.RightMotors[1].Direction, true, "Motor Right 1 direction != true");
            Assert.AreEqual(r.LeftMotors[0].Speed, 0, "Motor Left 0 speed != 0");
            Assert.AreEqual(r.LeftMotors[1].Speed, 0, "Motor Left 1 speed != 0");
            Assert.AreEqual(r.RightMotors[0].Speed, 0, "Motor Right 0 speed != 0");
            Assert.AreEqual(r.RightMotors[1].Speed, 0, "Motor Right 1 speed != 0");
            Assert.AreEqual(r.LeftMotors[0].IsRunning, false, "Motor left 0 is running");
            Assert.AreEqual(r.LeftMotors[1].IsRunning, false, "Motor left 1 is running");
            Assert.AreEqual(r.RightMotors[0].IsRunning, false, "Motor right 0 is running");
            Assert.AreEqual(r.RightMotors[1].IsRunning, false, "Motor right 1 is running");
        }
        [Test]
        public void InfraredSensorTests()
        {
            InfraredSensor ir = new InfraredSensor('F');
            Assert.NotNull(ir, "ir doesn't exist");

            // Read distance between sensor & obstacle

        }
        [Test]
        public void WifiTests()
        {
            Wifi w = new Wifi();
            Assert.NotNull(w, "wifi doesn't exist");
        }
        [Test]
        public void RobotTests()
        {
            Robot r = new Robot();
            Assert.NotNull(r, "robot doesn't exist");

            r.Rover.Move(true, 0.75);
        }
    }
}
