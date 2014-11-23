using System;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using Microsoft.SPOT;
using Microsoft.SPOT.Hardware;
using SecretLabs.NETMF.Hardware;
using SecretLabs.NETMF.Hardware.Netduino;

namespace RobotControl
{
    class RangeSensor
    {
        private AnalogInput _analogInput;

        public RangeSensor(Cpu.AnalogChannel channel, string name)
        {
            _analogInput = new AnalogInput(channel);
        }

        // Returns approximate distance in cm
        public int Read()
        {
            double sensorReading = _analogInput.Read();

            // Very crude conversion to cm
            double distanceInCm = (1000 - sensorReading) * 0.1;

            // Ensure answer is sensible
            if (distanceInCm > 0 && distanceInCm < 100)
                return (int)distanceInCm;
            else
                return 100; // default
        }
        public string Name
        {
            get;
            set;
        }

    }
}
