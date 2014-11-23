using System;
using Microsoft.SPOT;

namespace RobotControl
{
    public class TurnRightBehaviour : Behaviours
    {
        public TurnRightBehaviour(Motor[] motors)
            :base(motors)
        {
            
            this.Motors[0].SetSpeed(25);
            this.Motors[1].SetSpeed(-25);
            this.Motors[2].SetSpeed(100);
            this.Motors[3].SetSpeed(-100);
        }
    }
}
