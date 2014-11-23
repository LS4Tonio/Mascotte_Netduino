using System;
using Microsoft.SPOT;

namespace RobotControl
{
    public abstract class Behaviours
    {
        Motor[] _motors;
        private const double UnityPerTenPercent = 0.65;
        public Behaviours(Motor[] motors)
        {
            _motors = motors;

        }
        public Motor[] Motors
        {
            get{ return _motors; }
        }
        public void Execute()
        {
            for (int i = 0; i < 4; i++)
            {
                _motors[i].Stop();
                _motors[i].Start();
            }

        }
        public void Stop()
        {
            for (int i = 0; i < 4; i++)
            {
                _motors[i].Stop();
            }
        }
    }
}
