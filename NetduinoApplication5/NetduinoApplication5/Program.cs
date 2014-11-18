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
    public class Program
    {
        static private Rover rover;
        public static void Main()
        {
            
            OutputPort led = new OutputPort(Pins.ONBOARD_LED, false);
            //OutputPort ledForStep = new OutputPort(Pins.GPIO_PIN_D0, false);
            //AnalogInput capt = new AnalogInput(Cpu.AnalogChannel.ANALOG_0);
            //double value;
            //while (true)
            //{
            //    value = capt.Read();
            //    if (41.543 * System.Math.Pow(value + 0.30221, -1.5281) < 12)
            //    {
            //        led.Write(true);
            //    }
            //    else
            //    {
            //        led.Write(false);
            //    }
            //    ledForStep.Write(true);
            //    Thread.Sleep(500);
            //    ledForStep.Write(false);
            //    Thread.Sleep(500);
            //}
           // blinkTest();
            RangeSensor rs = new RangeSensor(Cpu.AnalogChannel.ANALOG_0);
            double distance;
            while (true)
            {
                distance = rs.Read();
                if (distance == 100)
                    led.Write(false);
                else
                    led.Write(true);
            }

            
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
        public static void roverTest()
        {
            rover = new Rover();
            while (true)
            {
                rover.Move();
                Thread.Sleep(100);
            }
        }
    }
}
