using System;
using Microsoft.SPOT;

namespace RobotControl
{
    public class TurnRightBehaviour : Behaviours
    {
        Motor[] _motors;
        public TurnRightBehaviour(Motor[] motors)
            :base(motors)
        {
            _motors = motors;
            motors[0].SetSpeed(25);
            motors[1].SetSpeed(-25);
            motors[2].SetSpeed(75);
            motors[3].SetSpeed(-75);
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
