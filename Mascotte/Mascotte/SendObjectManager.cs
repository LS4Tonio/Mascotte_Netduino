using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mascotte
{
    public class SendObjectManager
    {
        Object _workingObject;
        MiniGrid _minigrid;

        private SendObjectManager(MiniGrid miniGrid)
        {
            _minigrid = miniGrid;
        }
        public void Send(byte[] row) { }
        public void Receive() { }
        
        /// <summary>
        /// Move the robot on the Server's map and send new miniMap
        /// </summary>
        public void RefreshGrid()
        {
            if (_workingObject.GetType().IsEnum) // TODO : verify that the type is an int between 0 and 3 
            {
                Send(_minigrid.MoveGrid((int)_workingObject));
            }
        }

    }
}
