using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ServerFront
{
    /// <summary>
    /// Interaction logic for MainGrid.xaml
    /// </summary>
    public partial class MainGrid : UserControl
    {
        public MainGrid()
        {
            InitializeComponent();
            MainGrid1.Opacity = 1;
            MainGrid1.Width = 500;
            MainGrid1.Height = 500;
        }
        public void SizeBigGrid(int columns, int lines)
        {
            if( columns < 1 || lines < 1 )
                throw new ArgumentException();

            MainGrid1.Background = Brushes.Coral;

            ColumnDefinition column;
            for( int i=0; i < columns; i++ )
            {
                column = new ColumnDefinition();
                column.Width = new GridLength (MainGrid1.Width / columns);
                MainGrid1.ColumnDefinitions.Add( column );
            }
            RowDefinition row;
            for( int i=0; i < lines; i++ )
            {
                row = new RowDefinition();
                row.Height = new GridLength( MainGrid1.Height / lines );
                MainGrid1.RowDefinitions.Add(row );
            }
        }
    }
}
