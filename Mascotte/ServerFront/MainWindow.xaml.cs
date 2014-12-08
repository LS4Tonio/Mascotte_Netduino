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
using Fluent;

namespace ServerFront
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : RibbonWindow
    {
        public MainWindow()
        {
            a = new List<Test>();
            a.Add( new Test() );
            a.Add( new Test() );
            test2 = "coucou";
            InitializeComponent();
            Fluent.TextBox textbox1= new Fluent.TextBox();
            textbox1.Text = "HELLO WORLD";
            textbox1.FontSize = 20;
            //textbox1.Height = Double.NaN;
            textbox1.Height = 21;
            Canvas.SetTop( textbox1, 50 );
            Canvas.SetLeft( textbox1, 50 );
            this.Canvas1.Children.Add( textbox1 );
            this.Show();
            //InitializeComponent();
            /*Grid grid=new Grid();
            this.AddChild( grid );
            grid.ColumnDefinitions.Add( new ColumnDefinition() );
            grid.RowDefinitions.Add( new RowDefinition() );*/
        }
        public string test2 { get; set; }
        public List<Test> a;
    }
    public class Test
    {
        public Test()
        {
            Un = "un";
        }
        public String Un { get; set; }

        public void truc()
        {
            byte[,] multiDimensionalArray = new byte[4, 10];
            byte[][] arrayOfArrays = new byte[4][];
            for( int i=0; i < arrayOfArrays.Length; i++ )
            {
                arrayOfArrays[i] = new byte[10];
            }
        }
    }
}
