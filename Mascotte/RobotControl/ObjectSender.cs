using System;
using Microsoft.SPOT;

namespace RobotControl
{
    public class ObjectSender
    {
        byte[][] _actualGrid;
        public ObjectSender(byte[][] actualGrid)
        {
            _actualGrid = actualGrid;
        }
        public void Send(Object o) { }
        public Object Receive()
        {
            return null;
        }
        public void PositionSend(int[] positions)
        {
            Send(positions);
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
