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
        byte[][] _parentGrid;
        public MiniGrid(byte[][] datas, byte[][] parentGrid)
            : base(datas, parentGrid)
        {
            _datas = datas;
            _parentGrid = parentGrid;
        }
        /// <summary>
        /// Grid content
        /// </summary>
        public byte[][] DatasInMiniMap
        {
            get { return _datas; }
        }
        public int MapPosX { get; set; }
        public int MapPosY { get; set; }
        public byte MapConfidenceIndice { get; set; }

        public void AddAPoint()
        {
            
        }
        public override void Synchronize()
        {
            
        }
        public byte[] MoveGrid(int direction)
        {
            byte[] tmp = new byte[_datas[0].Length];
            switch (direction)
            {
                case 1:
                    MapPosY--;
                    for (int i = _datas.Length; i > 0; i-- )
                    {
                        _datas[i] = _datas[i - 1];
                    }
                    _datas[0] = _parentGrid[MapPosY];
                    return _datas[0];
                case 2 :
                    MapPosY++;
                    for (int i = 0; i < _datas.Length -1; i++ )
                    {
                        _datas[i] = _datas[i + 1];
                    }
                    _datas[_datas.Length] = _parentGrid[MapPosY + _datas.Length];
                    return _datas[_datas.Length];
                case 3 : 
                     MapPosX--;
                     for (int i = 0; i < _datas.Length; i++)
                    {
                        for( int j = _datas[i].Length; j > 0; j--)
                        {
                            _datas[i][j] = _datas[i][j - 1];
                        }
                            _datas[i][0] = _parentGrid[i][MapPosX];
                            tmp[i] = _datas[i][0];
                    }
                     return tmp;
                case 4 :
                    MapPosX++;
                    for (int i = 0; i < _datas.Length; i++)
                    {
                        for (int j = 0; j < _datas[i].Length - 1; j++)
                        {
                            _datas[i][j] = _datas[i][j + 1];
                        }
                            _datas[i][_datas[i].Length] = _parentGrid[i][MapPosX + _datas[i].Length];
                            tmp[i] = _datas[i][_datas[i].Length];
                    }
                     return tmp;
                default :
                    throw new ArgumentException();

            }
        }
    }
}
