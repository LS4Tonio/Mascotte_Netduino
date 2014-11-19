using System;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using Microsoft.SPOT;
using Microsoft.SPOT.Hardware;
using SecretLabs.NETMF.Hardware;
using SecretLabs.NETMF.Hardware.Netduino;

namespace NetduinoApplication5
{
    public class Motor
    {
        private PWM _motor;
        private OutputPort _direction;
        private int _correction;
 
        private const uint PERIOD = 1000 * 50;
        private const int TOP_SPEED = 10;
 
        public Motor(Cpu.PWMChannel pwm, Cpu.Pin direction, int correction)
        {
            _motor = new PWM(pwm, 261, 0.50, false);
            _direction = new OutputPort(direction, true);
            _correction = correction;
        }
 
        // Sets the motor speed and direction on a scale of -1 to 1
        public void SetSpeed(double percent)
        {
            // Set direction
            if (percent < 0)
            {
                _direction.Write(false);
                percent = percent * -1;
            }
            else
                _direction.Write(true);
 
            // If the percent is negative, make it positive
            //if (percent < 0)
            //    percent = percent * -1;
 
            // Set pulse width modulation (PWM)
            double duration = percent * TOP_SPEED;
            duration += _correction;
            _motor.Frequency = duration;
        }
        public void GoForward()
        {
            _motor.Start();
        }
        public void StopAction()
        {
            _motor.Stop();
        }
    
    }
}
