using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mascotte
{
    public class MiniGrid : Grid
    {
        byte[][] _datas;
        public MiniGrid(byte[][] datas)
            : base(datas)
        {
            _datas = datas;
        }
        /// <summary>
        /// Grid content
        /// </summary>
        public byte[][] DatasInMiniMap {
            get { return _datas; }
            set { value =_datas ; } 
        }
        public int MapPosX { get; set; }
        public int MapPosY { get; set; }
        public byte MapConfidenceIndice { get; set; }

        public void AddAPoint()
        {
            
        }
    }
}
