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
            Moving = 0 << 6,
            Stable = 1 << 6,
            OnValidating = 0 << 7,
            Validated = 1 << 7

        }

        MiniGrid _minimap;
        byte[][] _gridContent;
        protected const int GENERAL_MAP_SIZE = 200; 
        protected const int DELTA_MARGIN = 1; //Error margin scale
        
        public GeneralMap()
        {
            int size2 = 8;

            byte[][] datas = new byte[size2][];
            for (int i = 0; i < datas.Length; i++)
                datas[i] = new byte[size2];

            _gridContent = new byte[GENERAL_MAP_SIZE][];
            for (int i = 0; i < _gridContent.Length; i++)
            {
                _gridContent[i] = new byte[GENERAL_MAP_SIZE];
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
        /// The last bit is a flag used for indicating Validated or not
        /// 1 : true , 0 : false
        /// The 7th it is a flag used for indicating moving or not
        /// 1 : true , 0 : false
        /// For each case synchronization value 1 increments surety of a detected object, value 0 decrements it
        /// </summary>
        public void Synchronize()
        {
            for (int i = 0; i < _minimap.DatasInMiniMap.Length; i++)
            {
                for (int j = 0; j < _minimap.DatasInMiniMap[i].Length; j++)
                {
                    if (GridContent[i + _minimap.MapPosY][j + _minimap.MapPosX] < 63
                        && _minimap.DatasInMiniMap[i][j] > 0)
                    {
                        GridContent[i + _minimap.MapPosY][j + _minimap.MapPosX]++;

                        // When adding is done, scan new value
                        if (GridContent[i + _minimap.MapPosY][j + _minimap.MapPosX] >= 63
                            && GridContent[i + _minimap.MapPosY][j + _minimap.MapPosX] < 128)
                        {
                            GridContent[i + _minimap.MapPosY][j + _minimap.MapPosX] += 1 << 7;
                            ThrowMessage("Nouvel objet Fixe identifié");
                        }
                    }
                    else if (GridContent[i + _minimap.MapPosY][j + _minimap.MapPosX] <= 127
                             && _minimap.DatasInMiniMap[i][j] == 0
                             && 0 < GridContent[i + _minimap.MapPosY][j + _minimap.MapPosX])
                    {
                        GridContent[i + _minimap.MapPosY][j + _minimap.MapPosX]--;
                    }
                    else if (GridContent[i + _minimap.MapPosY][j + _minimap.MapPosX] > 254
                             && _minimap.DatasInMiniMap[i][j] == 0)
                    {
                        GridContent[i + _minimap.MapPosY][j + _minimap.MapPosX] -= 1 << 7;
                        ThrowMessage("L'Objet anciennement validé semble avoir bougé");
                    }
                    else if (GridContent[i + _minimap.MapPosY][j + _minimap.MapPosX] == 63
                             || GridContent[i + _minimap.MapPosY][j + _minimap.MapPosX] >= 63
                             && GridContent[i + _minimap.MapPosY][j + _minimap.MapPosX] < 128
                             && _minimap.DatasInMiniMap[i][j] > 0)
                    {
                        GridContent[i + _minimap.MapPosY][j + _minimap.MapPosX] = 64;
                        GridContent[i + _minimap.MapPosY][j + _minimap.MapPosX] += 1 << 7;
                        ThrowMessage("Nouvel objet Fixe identifié");
                    }
                    else
                        ThrowMessage("Cas non identifié");
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

    }
}
