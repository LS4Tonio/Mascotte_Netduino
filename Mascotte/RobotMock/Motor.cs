using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotMock
{
    public class Motor
    {
        private double _speedPercent;
        private bool _direction;
        private bool _isRunning;
        private const double MAX_SPEED = 2000;

        public Motor(bool direction)
        {
            _direction = direction;
            _speedPercent = 0;
            _isRunning = false;
        }

        /// <summary>
        /// Gets motor speed in Hz.
        /// </summary>
        public double Speed
        {
            get { return MAX_SPEED * _speedPercent; }
        }
        /// <summary>
        /// Gets speed percent according MAX_SPEED.
        /// </summary>
        public double SpeedPercent
        {
            get { return this.Speed * 100 / MAX_SPEED; }
        }
        /// <summary>
        /// Gets direction of the motor.
        /// To go forward, forwards motors are true
        /// backwards motors are false.
        /// </summary>
        public bool Direction
        {
            get { return _direction; }
            set { _direction = value; }
        }
        /// <summary>
        /// Gets state of motor.
        /// </summary>
        public bool IsRunning
        {
            get { return _isRunning; }
        }

        /// <summary>
        /// Change speed of the motor.
        /// Negative value will result of change direction.
        /// Scale between 0 and 1.
        /// </summary>
        /// <param name="percent"></param>
        public void SetSpeed(double percent)
        {
            if (percent < 0 || percent > 1)
                throw new ArgumentOutOfRangeException();
                
            _speedPercent = percent;
        }
        /// <summary>
        /// Stop motor.
        /// </summary>
        public void Stop()
        {
            SetSpeed(0);
            _isRunning = false;
        }
        /// <summary>
        /// Execute movement.
        /// </summary>
        public void Run()
        {
            _isRunning = true;
            //TO DO: Make rotation of motor
        }
    }
}
