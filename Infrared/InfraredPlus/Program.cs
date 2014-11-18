using System;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using Microsoft.SPOT;
using Microsoft.SPOT.Hardware;
using SecretLabs.NETMF.Hardware;
using SecretLabs.NETMF.Hardware.Netduino;

namespace Infrared
{
    public class Program
    {
        // Blink method
        public static void blinkLed(OutputPort led, Int32 time)
        {
            led.Write(true);
            Thread.Sleep(time);
            led.Write(false);
        }

        public static void Main()
        {
            // Infrared sensor
            AnalogInput infraredSensor = new AnalogInput(Cpu.AnalogChannel.ANALOG_0);
            // On board LED
            OutputPort onBoardLed = new OutputPort(Pins.ONBOARD_LED, false);

            //Thread.Sleep(2000); // 2s break on start

            //while (true)
            //{
            //    Thread.Sleep(1000);

            //    int distanceValue = (1000 - (int)infraredSensor.Read()) * 0.1;
            //    if (distanceValue < 30)
            //    {
            //        onBoardLed.Write(true);
            //    }
            //    else
            //    {
            //        onBoardLed.Write(false);
            //    }
            //}

            while (true)
            {
                blinkLed(onBoardLed, 250);
                Thread.Sleep(500);
            }
        }
    }
}