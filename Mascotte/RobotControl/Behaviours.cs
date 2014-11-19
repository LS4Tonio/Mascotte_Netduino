using System;
using Microsoft.SPOT;

namespace RobotControl
{
    public abstract class Behaviours
    {
        Motor[] _motors;
        public Behaviours(Motor[] motors)
        {
            _motors = motors;
            _motors[0].SetSpeed(50);
            _motors[1].SetSpeed(-50);
            _motors[2].SetSpeed(50);
            _motors[3].SetSpeed(-50);
        }
        public void Execute()
        {
            for (int i = 0; i < 4; i++)
            {
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
