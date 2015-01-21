using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace RobotServer.GridMaker
{
    [Serializable]
    public class GeneralMap
    {
        private enum CaseState
        {
            Moving = 0 << 6,
            Stable = 1 << 6,
            OnValidating = 0 << 7,
            Validated = 1 << 7
        }
        [NonSerialized]
        MiniGrid _minimap;
        byte[][] _gridContent;
        int _actualPosX;
        int _actualPosY;
        protected const int GENERAL_MAP_SIZE = 200;
        protected const int DELTA_MARGIN = 1; //Error margin scale
        public event PropertyChangedEventHandler PropertyChanged;

        public GeneralMap()
        {
            int size2 = 8;

            byte[][] datas = new byte[size2][];
            for (int i = 0; i < datas.Length; i++)
                datas[i] = new byte[size2];

            GridContent = new byte[GENERAL_MAP_SIZE][];
            for (int i = 0; i < GridContent.Length; i++)
            {
                GridContent[i] = new byte[GENERAL_MAP_SIZE];
                for (int j = 0; j < GridContent[i].Length; j++)
                {
                    GridContent[i][j] = 0;
                }
            }
            _minimap = new MiniGrid(datas, this.GridContent);

            //RandonessIsCool();
        }

        private void RandonessIsCool()
        {
            var r = new Random(14012015);
            for (int i = 0; i < this.GridContent.Length; i++)
            {
                for (int j = 0; j < this.GridContent[i].Length; j++)
                {
                    var nb = r.Next(0, 120);
                    var nb2 = r.Next(1, 2);
                    this.GridContent[i][j] = (byte)(nb * nb2);
        }

            }
        }
        /// <summary>
        /// Gets or set map content
        /// </summary>
        public byte[][] GridContent
        {
            get { return _gridContent; }
            private set
            {
                _gridContent = value;
                RaisePropertyChanged();
            }
        }
        public string ActualMessage { get; set; }
        /// <summary>
        /// Gets minimap
        /// </summary>
        public MiniGrid Minimap
        {
            get { return _minimap; }
        }
        public int ActualPosX
        {
            get
            {
                _actualPosX = this.Minimap.MapPosX;
                return _actualPosX;
            }
            private set
            {
                _actualPosX = value;
                RaisePropertyChanged();
            }
        }
        public int ActualPosY
        {
            get
            {
                _actualPosY = this.Minimap.MapPosY;
                return _actualPosY;
            }
            private set
            {
                _actualPosY = value;
                RaisePropertyChanged();
            }
        }
        /// <summary>
        /// Merge present Minigrid with parentMap 
        /// The last bit is a flag used for indicating Validated or not
        /// 1 : true , 0 : false
        /// The 7th it is a flag used for indicating moving or not
        /// 1 : true , 0 : false
        /// For each case synchronization value 1 increments confidence in the detected object, value 0 decrements it
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
            ActualMessage = p;
            RaisePropertyChanged();
        }


        public byte[][] MoveGrid(int direction, byte[] newLine)
        {
            byte[] tmpX = new byte[this.Minimap.DatasInMiniMap[0].Length];
            byte[] tmpY = new byte[this.Minimap.DatasInMiniMap.Length];
            switch (direction)
            {
                case 1:     // Up
                    if (this.ActualPosY > 0)
                    {
                        this.ActualPosY--;

                        // Save datas of the last line
                        tmpX = this.Minimap.DatasInMiniMap[this.Minimap.DatasInMiniMap.Length - 1];
                        // Move datas
                        for (int i = this.Minimap.DatasInMiniMap.Length - 1; i > 0; i--)
                        {
                            if (i == this.Minimap.DatasInMiniMap.Length)
                                MergePoints(tmpX, this.GridContent[this.ActualPosY]);
                            this.Minimap.DatasInMiniMap[i] = this.Minimap.DatasInMiniMap[i - 1];
                        }

                        // Get first line from parent
                        for (int i = 0; i < this.Minimap.DatasInMiniMap[0].Length; i++)
                        {
                            this.Minimap.DatasInMiniMap[0][i] = this.GridContent[this.ActualPosY][this.ActualPosX + i];
                        }
                    }
                    return this.GridContent;

                case 2:     // Down
                    var length = this.Minimap.DatasInMiniMap.Length - 1;

                    this.ActualPosY++;

                    //Save and merge old line 
                    tmpX = this.Minimap.DatasInMiniMap[0];
                    MergePoints(tmpX, this.GridContent[this.ActualPosY]);

                    // Move datas
                    for (int i = 0; i < length; i++)
                    {
                        this.Minimap.DatasInMiniMap[i] = this.Minimap.DatasInMiniMap[i + 1];
                    }

                    // Get last line from parent
                    for (int i = 0; i < this.Minimap.DatasInMiniMap[0].Length; i++)
                    {
                        this.Minimap.DatasInMiniMap[length][i] = this.GridContent[this.ActualPosY + length][i + this.ActualPosX];
                    }
                    return this.GridContent;

                case 3:     // Left
                    if (this.ActualPosX > 0)
                    {
                        this.ActualPosX--;
                        //Save dataline to rewrite
                        tmpY = new byte[1];
                        var data = new byte[1];
                        for (int i = 0; i < this.Minimap.DatasInMiniMap.Length; i++)
                        {
                            tmpY[0] = this.Minimap.DatasInMiniMap[i][0];
                            data[0] = this.GridContent[i][0];
                            MergePoints(tmpY, data);
                            // TODO rewriting
                        }


                        for (int i = 0; i < this.Minimap.DatasInMiniMap.Length; i++)
                        {
                            // Move datas
                            for (int j = this.Minimap.DatasInMiniMap[i].Length - 1; j > 1; j--)
                            {

                                this.Minimap.DatasInMiniMap[i][j] = this.Minimap.DatasInMiniMap[i][j - 1];
                            }

                            // Get first column from parent
                            this.Minimap.DatasInMiniMap[i][0] = this.GridContent[this.ActualPosY + i][this.ActualPosX];

                            tmpX[i] = this.Minimap.DatasInMiniMap[i][0];
                        }
                    }
                    return this.GridContent;

                case 4:     // Right
                    this.ActualPosX++;

                    for (int i = 0; i < this.Minimap.DatasInMiniMap.Length; i++)
                    {
                        // Move datas
                        for (int j = 0; j < this.Minimap.DatasInMiniMap[i].Length - 1; j++)
                        {
                            this.Minimap.DatasInMiniMap[i][j] = this.Minimap.DatasInMiniMap[i][j + 1];
                        }

                        // Get last column from parent 
                        this.Minimap.DatasInMiniMap[i][this.Minimap.DatasInMiniMap[i].Length - 1] = this.GridContent[i][this.ActualPosX + this.Minimap.DatasInMiniMap[i].Length - 1];

                        tmpY[i] = this.Minimap.DatasInMiniMap[i][this.Minimap.DatasInMiniMap[i].Length - 1];
                    }
                    return this.GridContent;

                default:
                    throw new ArgumentException();

            }
        }
        public void MergePoints(byte[] tabToMerge, byte[] parentTab)
        {
            for (int i = 0; i < tabToMerge.Length; i++)
            {
                if (parentTab[i] < 63
                            && tabToMerge[i] > 0)
                {
                    parentTab[i]++;

                    // When adding is done, scan new value
                    if (parentTab[i] >= 63
                        && parentTab[i] < 128)
                    {
                        parentTab[i] += 1 << 7;
                    }
                }
                else if (parentTab[i] <= 127
                         && tabToMerge[i] == 0
                         && 0 < parentTab[i])
                {
                    parentTab[i]--;
                }
                else if (parentTab[i] > 254
                         && tabToMerge[i] == 0)
                {
                    parentTab[i] -= 1 << 7;
                }
                else if (parentTab[i] == 63
                         || parentTab[i] >= 63
                         && parentTab[i] < 128
                         && tabToMerge[i] > 0)
                {
                    parentTab[i] = 64;
                    parentTab[i] += 1 << 7;
                }
                else
                    Console.WriteLine("Cas non identifié"); // TODO : remove that 
            }
        }
        private void RaisePropertyChanged([CallerMemberName] string propertyName = null)
        {
            var h = PropertyChanged;
            if (h != null) h(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
