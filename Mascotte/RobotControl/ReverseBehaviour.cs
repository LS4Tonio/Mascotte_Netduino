using System;
using Microsoft.SPOT;

namespace RobotControl
{
    public class ReverseBehaviour : Behaviours
    {
        Motor[] _motors;

        public ReverseBehaviour(Motor[] motors)
            :base(motors)
        {
            _motors = motors;
            motors[0].SetSpeed(50);
            motors[1].SetSpeed(-50);
            motors[2].SetSpeed(50);
            motors[3].SetSpeed(-50);
        }


    }
}
