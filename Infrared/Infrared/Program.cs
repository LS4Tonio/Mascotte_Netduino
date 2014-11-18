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
        public static void blinkLed(OutputPort led, Int32 onTime, Int32 offTime)
        {
            led.Write(true);
            Thread.Sleep(onTime);
            led.Write(false);
            Thread.Sleep(offTime);
        }

        public static void Main()
        {
            AnalogInput infraredSensor = new AnalogInput(Cpu.AnalogChannel.ANALOG_0);
            OutputPort onBoardLed = new OutputPort(Pins.ONBOARD_LED, false);
            OutputPort yellowLed = new OutputPort(Pins.GPIO_PIN_D0, false);
            OutputPort yellowLed2 = new OutputPort(Pins.GPIO_PIN_D3, false);
            OutputPort redLed = new OutputPort(Pins.GPIO_PIN_D1, false);
            OutputPort redLed2 = new OutputPort(Pins.GPIO_PIN_D4, false);
            OutputPort greenLed = new OutputPort(Pins.GPIO_PIN_D2, false);

            for (int i = 0; i < 5; i++)
            {
                blinkLed(onBoardLed, 250, 100);
            }

            while (true)
            {
                Thread.Sleep(10);
                double distance = infraredSensor.Read();

                if (distance > 0.8)
                {
                    yellowLed.Write(false);
                    redLed.Write(false);
                    greenLed.Write(false);
                    yellowLed2.Write(false);
                    redLed2.Write(true);
                }
                else if (distance > 0.6)
                {
                    yellowLed.Write(false);
                    redLed.Write(false);
                    greenLed.Write(false);
                    yellowLed2.Write(true);
                    redLed2.Write(false);
                }
                else if (distance > 0.4)
                {
                    yellowLed.Write(false);
                    redLed.Write(false);
                    greenLed.Write(true);
                    yellowLed2.Write(false);
                    redLed2.Write(false);
                }
                else if (distance > 0.2)
                {
                    yellowLed.Write(false);
                    redLed.Write(true);
                    greenLed.Write(false);
                    yellowLed2.Write(false);
                    redLed2.Write(false);
                }
                else
                {
                    yellowLed.Write(true);
                    redLed.Write(false);
                    greenLed.Write(false);
                    yellowLed2.Write(false);
                    redLed2.Write(false);
                }
            }
        }
    }
}
