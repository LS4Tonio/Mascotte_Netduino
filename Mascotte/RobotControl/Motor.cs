using System;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using Microsoft.SPOT;
using Microsoft.SPOT.Hardware;
using SecretLabs.NETMF.Hardware;
using SecretLabs.NETMF.Hardware.Netduino;

namespace RobotControl
{
    public class Motor
    {
        private PWM _motor;
        private OutputPort _direction;
        private int _correction;
 
        // private const uint PERIOD = 1000 * 50; // NOT USED
        private const int TOP_SPEED = 100;

        /// <summary>
        /// Gets the PWM motor
        /// </summary>
        public PWM PWMMotor
        {
            get { return _motor; }
        }
        /// <summary>
        /// Gets or sets the direction of the motor
        /// </summary>
        public OutputPort Direction
        {
            get { return _direction; }
            set { _direction = value; }
        }
        /// <summary>
        /// Gets the correction of the motor
        /// </summary>
        private int Correction
        {
            get { return _correction; }
        }
 
        /// <summary>
        /// Public constructor
        /// </summary>
        /// <param name="pwm"></param>
        /// <param name="direction"></param>
        /// <param name="correction"></param>
        public Motor(Cpu.PWMChannel pwm, Cpu.Pin direction, int correction)
        {
            _motor = new PWM(pwm, 261, 0.50, false);
            _direction = new OutputPort(direction, true);
            _correction = correction;
        }
 
        /// <summary>
        /// Sets the speed of the motor
        /// </summary>
        /// <param name="percent"></param>
        public void SetSpeed(double percent)
        {
            // Set direction
            this.Direction.Write(true);
            if (percent < 0)
            {
                this.Direction.Write(false);
                percent = percent * -1;
            }

            // Set pulse width modulation (PWM)
            //this.PWMMotor.Frequency = percent * TOP_SPEED + this.Correction;
            this.PWMMotor.Frequency = percent * TOP_SPEED;
            //this.PWMMotor.Frequency = percent;
            //this.PWMMotor.Frequency = 5320;
        }
        /// <summary>
        /// Start the motor
        /// </summary>
        public void Start()
        {
            this.PWMMotor.Start();
        }
        /// <summary>
        /// Stop the motor
        /// </summary>
        public void Stop()
        {
            this.PWMMotor.Stop();
        }
    }
}
