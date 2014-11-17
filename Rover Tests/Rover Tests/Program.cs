using System;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using Microsoft.SPOT;
using Microsoft.SPOT.Hardware;
using SecretLabs.NETMF.Hardware;
using SecretLabs.NETMF.Hardware.Netduino;

namespace Rover_Tests
{
    public class Program
    {
        public static void blinkLed(OutputPort pin, int nb)
        {
            for (int i = 0; i < nb; i++)
            {
                pin.Write(true);
                Thread.Sleep(500);
                pin.Write(false);
                Thread.Sleep(500);
            }
        }

        public static void Main()
        {
            OutputPort pwm = new OutputPort(Pins.GPIO_PIN_D0, false);
            OutputPort dir = new OutputPort(Pins.GPIO_PIN_D1, false);
            OutputPort current = new OutputPort(Pins.GPIO_PIN_A0, false);
            OutputPort onBoardLed = new OutputPort(Pins.ONBOARD_LED, false);

            while (true)
            {
                blinkLed(onBoardLed, 5);
                //pwm.Write(true);
            }
        }
    }
}
