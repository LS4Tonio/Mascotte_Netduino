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
            double speed = 5000;

            for (int i = 0; i < 4; i++)
            {
                if (i % 2 == 0)
                {
                    this.Motors[i].SetSpeed(speed);
                }
                else
                {
                    this.Motors[i].SetSpeed(-speed);
                }
            }
        }

        public void AdvanceForFiveSec()
        {
            this.Execute();
            Thread.Sleep(5000);
            this.Stop();
           
        }
        public void MoveStraight(int distance)
        {
            this.Execute();
        }
    }
}
