using System;
using Microsoft.SPOT;

namespace NetduinoApplication5
{
    public class TurnRightBehaviour : IBehaviour
    {
        private Motor _leftMotor;
        private Motor _rightMotor;
        private Motor _left2Motor;
        private Motor _right2Motor;

        public TurnRightBehaviour(Motor leftMotor, Motor rightMotor, Motor left2Motor, Motor right2Motor)
        {
            _leftMotor = leftMotor;
            _rightMotor = rightMotor;
            _left2Motor = left2Motor;
            _right2Motor = right2Motor;
        }
        public bool Execute()
        {
            _leftMotor.SetSpeed(-50);
            _rightMotor.SetSpeed(50);
            _left2Motor.SetSpeed(50);
            _right2Motor.SetSpeed(-50);
            _left2Motor.Start();
            _right2Motor.Start();
            _leftMotor.Start();
            _rightMotor.Start();
            return false;
        }
    }
}
