using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mascotte
{
    public abstract class Grid
    {
        public Grid(byte[][] grid)
        {
            
        }
        public Grid(byte[][] grid, byte[][] parentGrid)
        {
            
        }
        public abstract void Synchronize();
    }
}
