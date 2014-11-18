using System;
using Microsoft.SPOT;

namespace NetduinoApplication5
{
    class ForwardBehaviour : IBehaviour
    {
        private Motor _leftMotor;
        private Motor _rightMotor;

        public ForwardBehaviour(Motor leftMotor, Motor rightMotor)
        {
            _leftMotor = leftMotor;
            _rightMotor = rightMotor;
            
        }

        public bool Execute()
        {
            _leftMotor.SetSpeed(50);
            _rightMotor.SetSpeed(50);
            _leftMotor.GoForward();
            _rightMotor.GoForward();
            return false;
        }
    }
}
