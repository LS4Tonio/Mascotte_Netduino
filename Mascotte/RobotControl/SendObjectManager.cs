using System;
using Microsoft.SPOT;

namespace RobotControl
{
    public class SendObjectManager
    {
        byte[][] _actualGrid;
     
        public SendObjectManager(byte[][] actualGrid)
        {
            _actualGrid = actualGrid;
        }
      
        public void Send(byte[][] grid, double angleOfRobot) { }

        public void Send(Directions direction) { }

        public void Send(int direction,int posX, int posY) {
            byte[] informations = new byte[3] { (byte)direction, (byte)posX, (byte)posY };
        } 

        public void Receive()
        {

        }
      
        public void LoadRow(Directions direction)
        {
            Send(direction);
            //_actualGrid = Receive();
        }
        
        public enum Directions
        {
            NONE = 0,
            UP = 1,
            DOWN = 2,
            LEFT = 3,
            RIGHT = 4,
        }
    }
}
