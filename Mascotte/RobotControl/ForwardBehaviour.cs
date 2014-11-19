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
            _left2Motor.GoForward();
            _right2Motor.GoForward();
            _leftMotor.GoForward();
            _rightMotor.GoForward();
            return false;
        }
        public void Calibrate()
        {
            _leftMotor.SetSpeed(50);
            _rightMotor.SetSpeed(80);
            _left2Motor.SetSpeed(-50);
            _right2Motor.SetSpeed(-80);
            _left2Motor.GoForward();
            _right2Motor.GoForward();
            _leftMotor.GoForward();
            _rightMotor.GoForward();
            Thread.Sleep(2000);
            _left2Motor.StopAction();
            _right2Motor.StopAction();
            _leftMotor.StopAction();
            _rightMotor.StopAction();
        }
        public void Stop()
        {
            _left2Motor.StopAction();
            _right2Motor.StopAction();
            _leftMotor.StopAction();
            _rightMotor.StopAction();
        }

    }
}
