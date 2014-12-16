using System;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using Microsoft.SPOT;
using Microsoft.SPOT.Hardware;
using SecretLabs.NETMF.Hardware;
using SecretLabs.NETMF.Hardware.Netduino;
using AngrySquirrel.Netduino.ProximitySensor;

namespace RobotControl
{
    public class Program
    {
        static private Rover rover;
        static private InputPort buttonOnOff;

        public static void Main()
        {
            OutputPort onBoard_led = new OutputPort(Pins.ONBOARD_LED, false);

            buttonOnOff = new InputPort(Pins.ONBOARD_BTN, false, Port.ResistorMode.Disabled);
            //RangeSensorTest();
            // IT WORKS !!!!
            // blinkTest();
            onBoard_led.Write(true);
            Thread.Sleep(1000);
            onBoard_led.Write(false);
            Thread.Sleep(1000);

            roverTest();
            //RangeSensorTest();

            ProximitySensor ps = new ProximitySensor();
        }

        public static void blinkTest()
        {
            OutputPort onBoard_led = new OutputPort(Pins.ONBOARD_LED, false);

            while (true)
            {
                onBoard_led.Write(true);
                Thread.Sleep(1000);
                onBoard_led.Write(false);
                Thread.Sleep(1000);
            }
        }
        public static void RGBTest()
        {
            AnalogInput red = new AnalogInput(Cpu.AnalogChannel.ANALOG_0);
            AnalogInput green = new AnalogInput(Cpu.AnalogChannel.ANALOG_1);
            AnalogInput blue = new AnalogInput(Cpu.AnalogChannel.ANALOG_2);
            OutputPort ledOnSensor = new OutputPort(Pins.GPIO_PIN_D6, false);
            ledOnSensor.Write(true);
            while (true)
            {
                Debug.Print("R :" + red.Read().ToString());
                Debug.Print("G :" + green.Read().ToString());
                Debug.Print("B :" + blue.Read().ToString());
                Thread.Sleep(1000);

            }


        }
        public static void RangeSensorTest()
        {
            RangeSensor rs = new RangeSensor(Cpu.AnalogChannel.ANALOG_0, "Test");
            OutputPort redLed = new OutputPort(Pins.GPIO_PIN_D0, false);
            OutputPort yellowLed = new OutputPort(Pins.GPIO_PIN_D1, false);
            OutputPort greenLed = new OutputPort(Pins.GPIO_PIN_D2, false);

            while (true)
            {
                Thread.Sleep(10);
                double distance = rs.Read();

                if (distance > 0.8)
                {
                    yellowLed.Write(false);
                    redLed.Write(false);
                    greenLed.Write(true);
                }
                else if (distance > 0.4)
                {
                    yellowLed.Write(true);
                    redLed.Write(false);
                    greenLed.Write(false);
                }
                else if (distance > 0.2)
                {
                    yellowLed.Write(false);
                    redLed.Write(true);
                    greenLed.Write(false);
                }
                else
                {
                    yellowLed.Write(false);
                    redLed.Write(false);
                    greenLed.Write(false);
                }
            }
        }
        public static void roverTest()
        {
            rover = new Rover();
            rover.CalibrateMotors();
        }

        public static void roverTestEvoluted()
        {
            Rover rover = new Rover();
            rover.Turn();
        }

    }
}
