using System;
using Microsoft.SPOT;

namespace NetduinoApplication5
{
    class ReverseBehaviour : IBehaviour
    {
        private Motor _leftMotor;
        private Motor _rightMotor;
        private RangeSensor _leftSensor;
        private RangeSensor _rightSensor;

        public ReverseBehaviour(Motor leftMotor, Motor rightMotor, RangeSensor leftSensor, RangeSensor rightSensor)
        {
            _leftMotor = leftMotor;
            _rightMotor = rightMotor;
            _leftSensor = leftSensor;
            _rightSensor = rightSensor;
        }

        public bool Execute()
        {
            // Are we going to hit somthing?
            if (_leftSensor.Read() < 10 || _rightSensor.Read() < 10)
            {
                // Slow reverse
                _leftMotor.SetSpeed(-0.8);
                _rightMotor.SetSpeed(-0.8);
                return true;
            }
            return false;
        }
    }
}
