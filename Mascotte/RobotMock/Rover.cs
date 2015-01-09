using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotMock
{
    public class Rover
    {
        private Motor _leftForwardMotor;
        private Motor _leftBackwardMotor;
        private Motor _rightForwardMotor;
        private Motor _rightBackwardMotor;
        private Motor[] _leftMotors;
        private Motor[] _rightMotors;
        private Motor[] _motors;
        private bool _isMoving;
        private int _xPos;
        private int _yPos;
        private int _direction;

        public Rover()
        {
            _leftForwardMotor = new Motor(true);
            _leftBackwardMotor = new Motor(false);
            _rightForwardMotor = new Motor(true);
            _rightBackwardMotor = new Motor(false);

            _leftMotors = new Motor[2] { _leftForwardMotor, _leftBackwardMotor };
            _rightMotors = new Motor[2] { _rightForwardMotor, _rightBackwardMotor };
            _motors = new Motor[4] { _leftForwardMotor, _leftBackwardMotor, _rightForwardMotor, _rightBackwardMotor };
        }
        public Rover(int x, int y)
        {
            _leftForwardMotor = new Motor(true);
            _leftBackwardMotor = new Motor(false);
            _rightForwardMotor = new Motor(true);
            _rightBackwardMotor = new Motor(false);

            _leftMotors = new Motor[2] { _leftForwardMotor, _leftBackwardMotor };
            _rightMotors = new Motor[2] { _rightForwardMotor, _rightBackwardMotor };
            _motors = new Motor[4] { _leftForwardMotor, _leftBackwardMotor, _rightForwardMotor, _rightBackwardMotor };

            _xPos = x;
            _yPos = y;
        }

        /// <summary>
        /// Gets left motors array.
        /// </summary>
        public Motor[] LeftMotors
        {
            get { return _leftMotors; }
        }
        /// <summary>
        /// Gets right motors array.
        /// </summary>
        public Motor[] RightMotors
        {
            get { return _rightMotors; }
        }
        /// <summary>
        /// Gets if motors are moving.
        /// </summary>
        public bool IsMoving
        {
            get { return _isMoving; }
        }
        /// <summary>
        /// Gets X position of the robot.
        /// </summary>
        public int XPos
        {
            get { return _xPos; }
        }
        /// <summary>
        /// Gets Y position of the robot.
        /// </summary>
        public int YPos
        {
            get { return _xPos; }
        }
        /// <summary>
        /// Gets Rover's direction exprimed with angle.
        /// 0 (or 360): up, 180: down, 90: left, 270: right
        /// </summary>
        public int Direction
        {
            get { return _direction; }
        }

        /// <summary>
        /// Change speed of one motors side.
        /// Scale between -1 et 1.
        /// </summary>
        /// <param name="motors"></param>
        /// <param name="speed"></param>
        private void ChangeSpeed(Motor[] motors, double speed)
        {
            if (speed < -1 || speed > 1)
                throw new ArgumentOutOfRangeException();

            foreach (Motor m in motors)
                m.SetSpeed(speed);
        }
        /// <summary>
        /// Apply changes on robot.
        /// </summary>
        /// <returns></returns>
        private void Run()
        {
            foreach (Motor m in _motors)
                m.Run();
        }
        /// <summary>
        /// Change motors direction to backward.
        /// Must be array of 2 motors.
        /// Throws ArgumentOutOfRangeException.
        /// </summary>
        /// <param name="m"></param>
        private void SetBackward(Motor[] m)
        {
            if (m.Length != 2)
                throw new ArgumentOutOfRangeException();

            if (m[0].Direction)
                m[0].Direction = false;
            if (!m[1].Direction)
                m[1].Direction = true;
        }
        /// <summary>
        /// Change motors direction to forward.
        /// Must be array of 2 motors.
        /// Throws ArgumentOutOfRangeException.
        /// </summary>
        /// <param name="m"></param>
        private void SetForward(Motor[] m)
        {
            if (m.Length != 2)
                throw new ArgumentOutOfRangeException();

            if (!m[0].Direction)
                m[0].Direction = true;
            if (m[1].Direction)
                m[1].Direction = false;
        }
        /// <summary>
        /// Move the robot.
        /// If movementSpeed is negative, the robot will go backward
        /// </summary>
        /// <param name="movementSpeed"></param>
        public void Move(bool isforward, double movementSpeed)
        {
            // Stop robot
            Stop();

            // Set direction
            if (isforward)
            {
                SetForward(_leftMotors);
                SetForward(_rightMotors);
            }
            else
            {
                SetBackward(_leftMotors);
                SetBackward(_rightMotors);
            }

            // Change Speed
            foreach (Motor m in _motors)
                m.SetSpeed(movementSpeed);

            // Execute changes
            _isMoving = true;
            Run();
        }
        /// <summary>
        /// Rotates the robot.
        /// If true, the robot will turn right else turn left.
        /// Rotation speed must be between 0 & 1.
        /// Angle is between 0 and 360.
        /// </summary>
        /// <param name="turnRight"></param>
        /// <param name="rotationSpeed"></param>
        /// <param name="angle"></param>
        public void Turn(bool turnRight, double rotationSpeed, int angle)
        {
            if(angle < 0 || angle > 360)
                angle = 0;

            // Stop robot
            Stop();

            // Turn robot
            if (turnRight)
            {
                // Rotate left motors forward
                if (!_leftMotors[0].Direction)
                    _leftMotors[0].Direction = true;
                if (_leftMotors[1].Direction)
                    _leftMotors[1].Direction = false;

                // Rotate right motors backward
                if (_rightMotors[0].Direction)
                    _rightMotors[0].Direction = false;
                if (!_rightMotors[1].Direction)
                    _rightMotors[1].Direction = true;

                // Change direction angle
                _direction += angle;
                if (_direction >= 360)
                    _direction -= 360;
            }
            else
            {
                // Rotate left motors forward
                if (_leftMotors[0].Direction)
                    _leftMotors[0].Direction = false;
                if (!_leftMotors[1].Direction)
                    _leftMotors[1].Direction = true;

                // Rotate right motors backward
                if (!_rightMotors[0].Direction)
                    _rightMotors[0].Direction = true;
                if (_rightMotors[1].Direction)
                    _rightMotors[1].Direction = false;

                // Change direction angle
                _direction -= angle;
                if (_direction <= 0)
                    _direction += 360;
            }

            // Set same speed to all motors
            foreach (Motor m in _motors)
                m.SetSpeed(rotationSpeed);

            // Execute changes
            _isMoving = true;
            Run();
        }
        /// <summary>
        /// Stops all motors.
        /// </summary>
        public void Stop()
        {
            foreach (Motor m in _motors)
                m.Stop();

            _isMoving = false;
        }
        /// <summary>
        /// Generate gap when robot is moving.
        /// It acts on the motors' speed.
        /// </summary>
        /// <param name="isRotating"></param>
        public void GenerateMovementGap(int RandomSeed, Motor[] oneMotorSide)
        {
            if (oneMotorSide.Length != 2)
                throw new ArgumentException("oneMotorSide must have 2 motors");

            Random random = new Random(RandomSeed);
            double gap = (double)random.Next(0, 200) * 0.05;
            double actualSpeedPercent = oneMotorSide[0].SpeedPercent;

            foreach (Motor m in oneMotorSide)
                m.SetSpeed(actualSpeedPercent - gap);
        }
    }
}