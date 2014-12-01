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
            byte[][] datas = new byte[GENERAL_MAP_SIZE][];
            minimap = new MiniGrid(datas, this.GridContent);
        }

        public byte[][] GridContent { get; set; }

        /// <summary>
        /// Merge present Minigrid with parentMap 
        /// </summary>
        public void Synchronize()
        {
            for (int i = 0; i < minimap.DatasInMiniMap.Length; i++)
            {
                for (int j = 0; j < minimap.DatasInMiniMap[i].Length; i++)
                    GridContent[i + minimap.MapPosY][j + minimap.MapPosX] += minimap.DatasInMiniMap[i][j];
            }
        }

        
    }
}
