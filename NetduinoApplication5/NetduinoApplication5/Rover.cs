using System;
using Microsoft.SPOT;
using SecretLabs.NETMF.Hardware.Netduino;
using Microsoft.SPOT.Hardware;

namespace NetduinoApplication5
{
    class Rover
    {
        private Motor _leftMotor;
        private Motor _rightMotor;
        private RangeSensor _leftSensor;
        private RangeSensor _rightSensor;
        private IBehaviour[] _behaviours;
        private int STEER_CORRECTION = 320;

        public Rover()
        {
            // Define outputs
            _leftMotor = new Motor(Cpu.PWMChannel.PWM_0, Pins.GPIO_PIN_D1, STEER_CORRECTION);
            _rightMotor = new Motor(Cpu.PWMChannel.PWM_2, Pins.GPIO_PIN_D3, STEER_CORRECTION * -1);
            _leftMotor.SetSpeed(50);
            _rightMotor.SetSpeed(50);

            // Define inputs
            _leftSensor = new RangeSensor(Cpu.AnalogChannel.ANALOG_1);
            _rightSensor = new RangeSensor(Cpu.AnalogChannel.ANALOG_2);

            // Define the behaviours you want - the order is very important!
            _behaviours = new IBehaviour[2];
            _behaviours[0] = new ReverseBehaviour(_leftMotor, _rightMotor, _leftSensor, _rightSensor);
            _behaviours[1] = new ForwardBehaviour(_leftMotor, _rightMotor);
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
            (new ForwardBehaviour(_leftMotor, _rightMotor)).Execute();
        }
    }
}
