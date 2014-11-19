using System;
using Microsoft.SPOT;
using SecretLabs.NETMF.Hardware.Netduino;
using Microsoft.SPOT.Hardware;

namespace RobotControl
{
    class Rover
    {
        private Motor _leftForwardMotor;
        private Motor _leftBackwardMotor;
        private Motor _rightForwardMotor;
        private Motor _rightBackwardMotor;
        private RangeSensor _leftSensor;
        private RangeSensor _rightSensor;
        private RangeSensor _frontSensor;
        //private IBehaviour[] _behaviours;

        private const int STEER_CORRECTION = 320;

        /// <summary>
        /// Gets front left motor
        /// </summary>
        public Motor LeftForwardMotor
        {
            get { return _leftForwardMotor; }
        }
        /// <summary>
        /// Gets front right motor
        /// </summary>
        public Motor RightForwardMotor
        {
            get { return _rightForwardMotor; }
        }
        /// <summary>
        /// Gets back left motor
        /// </summary>
        public Motor LeftBackwardMotor
        {
            get { return _leftBackwardMotor; }
        }
        /// <summary>
        /// Gets back right motor
        /// </summary>
        public Motor RightBackwardMotor
        {
            get { return _rightBackwardMotor; }
        }
        /// <summary>
        /// Gets left infrared sensor
        /// </summary>
        public RangeSensor LeftSensor
        {
            get { return _leftSensor; }
        }
        /// <summary>
        /// Gets right infrared sensor
        /// </summary>
        public RangeSensor RightSensor
        {
            get { return _rightSensor; }
        }
        /// <summary>
        /// Gets front infrared sensor
        /// </summary>
        public RangeSensor FrontSensor
        {
            get { return FrontSensor; }
        }

        /// <summary>
        /// Public constructor
        /// </summary>
        public Rover()
        {
            // Define outputs
            _leftForwardMotor = new Motor(PWMChannels.PWM_PIN_D5, Pins.GPIO_PIN_D0, STEER_CORRECTION);      //CH1
            _leftBackwardMotor = new Motor(PWMChannels.PWM_PIN_D6, Pins.GPIO_PIN_D1, STEER_CORRECTION);     //CH2
            _rightForwardMotor = new Motor(PWMChannels.PWM_PIN_D9, Pins.GPIO_PIN_D2, STEER_CORRECTION);     //CH3
            _rightBackwardMotor = new Motor(PWMChannels.PWM_PIN_D10, Pins.GPIO_PIN_D4, STEER_CORRECTION);   //CH4

            //// Define inputs
            _frontSensor = new RangeSensor(Cpu.AnalogChannel.ANALOG_0);
            _leftSensor = new RangeSensor(Cpu.AnalogChannel.ANALOG_1);
            _rightSensor = new RangeSensor(Cpu.AnalogChannel.ANALOG_2);
        }

        /// <summary>
        /// Makes rover movement
        /// </summary>
        public void Move()
        {
            //TO DO
            //behaviour1.Execute();
        }
        /// <summary>
        /// Makes rover rotation
        /// </summary>
        public void Turn()
        {
            //TO DO
            //behaviour1.Stop();
            //behaviour2.Execute();
        }
        /// <summary>
        /// Makes rover stop
        /// </summary>
        public void Stop()
        {
            //TO DO
            //behaviour1.Stop();
        }
        /// <summary>
        /// Calibrate rover motor
        /// </summary>
        public void CalibrateMotors()
        {
            //TO DO
            //behaviour1.Calibrate();
        }
    }
}
