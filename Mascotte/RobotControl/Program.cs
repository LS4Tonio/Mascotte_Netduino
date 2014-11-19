﻿using System;
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
        static private InputPort buttonOnOff;
        static private bool _haveToContinue;

        public static void Main()
        {

            OutputPort onBoard_led = new OutputPort(Pins.ONBOARD_LED, false);
            

           buttonOnOff = new InputPort(Pins.ONBOARD_BTN, false, Port.ResistorMode.Disabled);
           _haveToContinue = false;
            //RangeSensorTest();
            // IT WORKS !!!!
           // blinkTest();
           onBoard_led.Write(true);
           Thread.Sleep(1000);
           onBoard_led.Write(false);
           Thread.Sleep(1000); 
            onBoard_led.Write(true);
           Thread.Sleep(1000);
           onBoard_led.Write(false);
           Thread.Sleep(1000); 
            onBoard_led.Write(true);
           Thread.Sleep(1000);
           onBoard_led.Write(false);
           Thread.Sleep(1000);
           roverTest();
            
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
                rover.Move();
                Thread.Sleep(100);
        }
        public static void roverTestEvoluted()
        {
            Rover rover = new Rover();
            //rover.Turn();
            rover.CalibrateMotors();
        }
        public static void RangeSensorTest()
        {
            OutputPort led = new OutputPort(Pins.ONBOARD_LED, false);
            RangeSensor rs = new RangeSensor(AnalogChannels.ANALOG_PIN_A0);
            while (true)
            {
                if (rs.Read() == 100)
                    led.Write(true);
                else
                    led.Write(false);
            }
        }

    }
}
