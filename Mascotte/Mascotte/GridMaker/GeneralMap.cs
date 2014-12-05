using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mascotte.GridMaker
{
    public class GeneralMap
    {
        private enum CaseState
        {
            Moving = 0 << 7,
            Stable = 1 << 7,
            Validated = 1 << 8,
            OnValidating = 0 << 8
        }

        MiniGrid _minimap;
        byte[][] _gridContent;
        protected const int GENERAL_MAP_SIZE = 200;
        
        public GeneralMap()
        {
            int size = 1024;
            int size2 = 8;

            byte[][] datas = new byte[size2][];
            for (int i = 0; i < datas.Length; i++)
                datas[i] = new byte[size2];

            _gridContent = new byte[size][];
            for (int i = 0; i < _gridContent.Length; i++)
            {
                _gridContent[i] = new byte[size];
                for (int j = 0; j < _gridContent[i].Length; j++)
                {
                    _gridContent[i][j] = 0;
                }
            }

            _minimap = new MiniGrid(datas, this.GridContent);
        }

        /// <summary>
        /// Gets or set map content
        /// </summary>
        public byte[][] GridContent
        {
            get { return _gridContent; }
        }
        /// <summary>
        /// Gets minimap
        /// </summary>
        public MiniGrid Minimap
        {
            get { return _minimap; }
        }

        /// <summary>
        /// Merge present Minigrid with parentMap 
        /// The last bit is a flag made for indicating provisory or not
        /// 1 : true , 0 : false
        /// </summary>
        public void Synchronize()
        {
            for (int i = 0; i < _minimap.DatasInMiniMap.Length; i++)
            {
                for (int j = 0; j < _minimap.DatasInMiniMap[i].Length; i++)
                {
                    if (GridContent[i + _minimap.MapPosY][j + _minimap.MapPosX] < 63)
                    {
                        GridContent[i + _minimap.MapPosY][j + _minimap.MapPosX] += _minimap.DatasInMiniMap[i][j];
                        // When adding is done, scan new value
                        if (GridContent[i + _minimap.MapPosY][j + _minimap.MapPosX] >= 63)
                            GridContent[i + _minimap.MapPosY][j + _minimap.MapPosX] += 1 << 7;
                    }
                    else if(GridContent[i + _minimap.MapPosY][j + _minimap.MapPosX] > 63 && GridContent[i + _minimap.MapPosY][j + _minimap.MapPosX] > _minimap.DatasInMiniMap[i][j])
                        ThrowMessage("L'Objet anciennement validé semble avoir bougé");
                }
            }
        }
        /// <summary>
        /// Send a message to show in interface
        /// </summary>
        /// <param name="p"></param>
        private void ThrowMessage(string p)
        {
            //TO DO
        }
        /// <summary>
        /// Show a validation Form in interface 
        /// </summary>
        /// <param name="posX"></param>
        /// <param name="posY"></param>
        private void ValidateObject(int posX, int posY)
        {
            //TO DO
        } // Not sure this func will
    }
}
