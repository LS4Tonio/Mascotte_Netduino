using System;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using Microsoft.SPOT;
using Microsoft.SPOT.Hardware;
using SecretLabs.NETMF.Hardware;
using SecretLabs.NETMF.Hardware.Netduino;

namespace RGB
{
    public class Program
    {
        public static void blinkLed(OutputPort led, Int32 onTime, Int32 offTime)
        {
            led.Write(true);
            Thread.Sleep(onTime);
            led.Write(false);
            Thread.Sleep(offTime);
        }

        public static void Main()
        {
            OutputPort onBoardLed = new OutputPort(Pins.ONBOARD_LED, false);
            AnalogInput redInput = new AnalogInput(Cpu.AnalogChannel.ANALOG_0);
            AnalogInput greenInput = new AnalogInput(Cpu.AnalogChannel.ANALOG_1);
            AnalogInput blueInput = new AnalogInput(Cpu.AnalogChannel.ANALOG_2);
            OutputPort redLed = new OutputPort(Pins.GPIO_PIN_D0, false);
            OutputPort greenLed = new OutputPort(Pins.GPIO_PIN_D1, false);
            OutputPort blueLed = new OutputPort(Pins.GPIO_PIN_D2, false);

            for (int i = 0; i < 3; i++)
            {
                blinkLed(onBoardLed, 250, 100);
            }

            while (true)
            {
                double redValue = redInput.Read();
                double greenValue = greenInput.Read();
                double blueValue = blueInput.Read();

                if (redValue > 0.2)
                {
                    redLed.Write(true);
                    greenLed.Write(false);
                    blueLed.Write(false);
                }
                Thread.Sleep(1000);
                if (greenValue > 0.2)
                {
                    redLed.Write(false);
                    greenLed.Write(true);
                    blueLed.Write(false);
                }
                Thread.Sleep(1000);
                if (blueValue > 0.2)
                {
                    redLed.Write(false);
                    greenLed.Write(false);
                    blueLed.Write(true);
                }
                //else
                //{
                //    redLed.Write(false);
                //    greenLed.Write(false);
                //    blueLed.Write(false);
                //}
                Thread.Sleep(1000);
            }
        }
    }
}
