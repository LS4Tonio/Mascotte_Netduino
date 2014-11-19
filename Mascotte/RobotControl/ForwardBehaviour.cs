using System;
using Microsoft.SPOT;
using System.Threading;

namespace NetduinoApplication5
{
    class ForwardBehaviour : IBehaviour
    {
        private Motor _leftMotor;
        private Motor _rightMotor;
        private Motor _left2Motor;
        private Motor _right2Motor;

        public ForwardBehaviour(Motor leftMotor, Motor rightMotor, Motor left2Motor, Motor right2Motor)
        {
            _leftMotor = leftMotor;
            _rightMotor = rightMotor;
            _left2Motor = left2Motor;
            _right2Motor = right2Motor;
        }

        public bool Execute()
        {
            _leftMotor.SetSpeed(50);
            _rightMotor.SetSpeed(80);
            _left2Motor.SetSpeed(-50);
            _right2Motor.SetSpeed(-80);
            _left2Motor.Start();
            _right2Motor.Start();
            _leftMotor.Start();
            _rightMotor.Start();
            return false;
        }
        public void Calibrate()
        {
            _leftMotor.SetSpeed(50);
            _rightMotor.SetSpeed(80);
            _left2Motor.SetSpeed(-50);
            _right2Motor.SetSpeed(-80);
            _left2Motor.Start();
            _right2Motor.Start();
            _leftMotor.Start();
            _rightMotor.Start();
            Thread.Sleep(2000);
            _left2Motor.Stop();
            _right2Motor.Stop();
            _leftMotor.Stop();
            _rightMotor.Stop();
        }
        public void Stop()
        {
            _left2Motor.Stop();
            _right2Motor.Stop();
            _leftMotor.Stop();
            _rightMotor.Stop();
        }

    }
}
