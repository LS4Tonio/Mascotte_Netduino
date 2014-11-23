using System;
using Microsoft.SPOT;
using System.Threading;

namespace RobotControl
{
    class ForwardBehaviour : Behaviours
    {

        public ForwardBehaviour(Motor[] motors)
            : base(motors)
        {
            this.Motors[0].SetSpeed(50);
            this.Motors[1].SetSpeed(-50);
            this.Motors[2].SetSpeed(50);
            this.Motors[3].SetSpeed(-50);
        }
        public void AdvanceForFiveSec()
        {
            this.Execute();
            Thread.Sleep(1000);
            this.Stop();
        }
        
        
        

    }
}
