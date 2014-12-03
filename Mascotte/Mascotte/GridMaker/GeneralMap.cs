using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mascotte.GridMaker
{
    public class GeneralMap
    {
        MiniGrid minimap;
        protected const int GENERAL_MAP_SIZE = 200;
        public GeneralMap()
        {
            byte[][] datas = new byte[8][];

            for (int i = 0; i < datas.Length; i++)
                datas[i] = new byte[8];

            minimap = new MiniGrid(datas, this.GridContent);
        }

        public byte[][] GridContent { get; set; }

        /// <summary>
        /// Merge present Minigrid with parentMap 
        /// The last bit is a flag made for indicating provisory or not
        /// 1 : true , 0 : false
        /// </summary>
        public void Synchronize()
        {
            for (int i = 0; i < minimap.DatasInMiniMap.Length; i++)
            {
                for (int j = 0; j < minimap.DatasInMiniMap[i].Length; i++)
                {
                    if (GridContent[i + minimap.MapPosY][j + minimap.MapPosX] < 63)
                    {
                        GridContent[i + minimap.MapPosY][j + minimap.MapPosX] += minimap.DatasInMiniMap[i][j];
                        // When adding is done, scan new value
                        if (GridContent[i + minimap.MapPosY][j + minimap.MapPosX] >= 63)
                            GridContent[i + minimap.MapPosY][j + minimap.MapPosX] += 1 << 7;
                    }
                    else if(GridContent[i + minimap.MapPosY][j + minimap.MapPosX] > 63 && GridContent[i + minimap.MapPosY][j + minimap.MapPosX] > minimap.DatasInMiniMap[i][j])
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
        }
        /// <summary>
        /// Show a validation Form in interface 
        /// </summary>
        /// <param name="posX"></param>
        /// <param name="posY"></param>
        private void ValidateObject(int posX, int posY) { } // Not sure this func will
        private enum CaseState
        {
            Moving = 0 << 7,
            Stable = 1 << 7,
            Validated = 1 << 8,
            OnValidating = 0 << 8
        }
    }
}
