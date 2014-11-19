using System;
using Microsoft.SPOT;
using SecretLabs.NETMF.Hardware.Netduino;
using Microsoft.SPOT.Hardware;

namespace RobotControl
{
    class Rover
    {
        private Motor _leftMotor;
        private Motor _rightMotor;
        private Motor _left2Motor;
        private Motor _right2Motor;
        private RangeSensor _leftSensor;
        private RangeSensor _rightSensor;
        private ForwardBehaviour behaviour1;
        private TurnRightBehaviour behaviour2;
        private int STEER_CORRECTION = 320;

        public Rover()
        {
            // Define outputs
            _leftMotor = new Motor(PWMChannels.PWM_PIN_D5, Pins.GPIO_PIN_D0, STEER_CORRECTION);
            _rightMotor = new Motor(PWMChannels.PWM_PIN_D6, Pins.GPIO_PIN_D1, STEER_CORRECTION);
            _left2Motor = new Motor(PWMChannels.PWM_PIN_D9, Pins.GPIO_PIN_D2, STEER_CORRECTION);
            _right2Motor = new Motor(PWMChannels.PWM_PIN_D10, Pins.GPIO_PIN_D4, STEER_CORRECTION);


            //// Define inputs
            //_leftSensor = new RangeSensor(Cpu.AnalogChannel.ANALOG_1);
            //_rightSensor = new RangeSensor(Cpu.AnalogChannel.ANALOG_2);

            // Define the behaviours you want - the order is very important!
        //    _behaviours[0] = new ReverseBehaviour(_leftMotor, _rightMotor, _leftSensor, _rightSensor);
        //    _behaviours[1] = new ForwardBehaviour(_leftMotor, _rightMotor, _left2Motor, _right2Motor);
        }

        public void Move()
        {
            //foreach (var behaviour in _behaviours)
            //{
            //    var hasFired = behaviour.Execute();

            //    // If this behaviour fired, stop processing other behaviours in the array
            //    if (hasFired)
            //        break;
            //}
            behaviour1.Execute();
        }
        public void Turn()
        {
            behaviour1.Stop();
            behaviour2.Execute();
        }
        public void Stop()
        {
            behaviour1.Stop();
        }

    }
}
