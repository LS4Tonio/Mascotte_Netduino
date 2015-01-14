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
using Mascotte.GridMaker;
using Mascotte;

namespace ServerFront
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : RibbonWindow
    {
        Server server = new Server();
        MainWindowViewModel _vm;
        MainGrid maingrid;
        protected const int MARGIN_ACCEPTABLE = 1; // TODO : no inspiration, change this name
        public List<Test> a;
        
        public MainWindow()
        {
            _vm = new MainWindowViewModel();
            a = new List<Test>();
            a.Add(new Test());
            a.Add(new Test());
            test2 = "coucou";
            InitializeComponent();
            Fluent.TextBox textbox1 = new Fluent.TextBox();
            textbox1.Text = "HELLO WORLD";
            textbox1.FontSize = 20;
            //textbox1.Height = Double.NaN;
            textbox1.Height = 21;
            Canvas.SetTop(textbox1, 50);
            Canvas.SetLeft(textbox1, 50);
            this.Canvas1.Children.Add(textbox1);
            this.Show();

            Mascotte.GridMaker.GeneralMap map1 = new Mascotte.GridMaker.GeneralMap();
            double coef = Canvas1.ActualHeight / map1.GridContent.Count();

            PathSegmentCollection segs = new PathSegmentCollection();
            LineSegment seg = new LineSegment();
            seg.Point = new Point(250, 250);
            segs.Add(seg);
            seg = new LineSegment();
            seg.Point = new Point(250, 251);
            segs.Add(seg);
            //PathFigureCollection collec= new PathFigureCollection();
            //collec.Add(new PathFigure(new Point(1,0),segs,false));
            PathGeometry pgeo = new PathGeometry();
            pgeo.Figures.Add(new PathFigure(new Point(1, 0), segs, false));
            Path p = new Path();
            p.Data = pgeo;
            //p.StrokeThickness = coef;

            /*if (Canvas1.Children[0] is Path)
                p.Stroke = ((Path) Canvas1.Children[0]).Stroke;*/

            p.Stroke = Brushes.Black;

            this.Canvas1.Children.Add(p);

            //var grid1 = new MainGrid();
            //grid1.SizeBigGrid(5,3);
            //this.Canvas1.Children.Add( grid1 );
            maingrid = new MainGrid();
            Grid.SetColumn(maingrid, 0);
            this.backgroundGrid.Children.Add(maingrid);
            maingrid.SizeBigGrid(200, 200);
            maingrid.Name = "MainGrid1";
            Refresh();
            //InitializeComponent();
            /*Grid grid=new Grid();
            this.AddChild( grid );
            grid.ColumnDefinitions.Add( new ColumnDefinition() );
            grid.RowDefinitions.Add( new RowDefinition() );*/
        }

        public string test2 { get; set; }

        public void Refresh()
        {
            for (int i = 0; i < server.GeneralMap.GridContent.Length; i++)
            {
                for (int j = 0; j < server.GeneralMap.GridContent[i].Length; j++)
                {
                    server.GeneralMap.GridContent[i][j] = 42;
                    var background = new Image();

                    var logo = new BitmapImage();
                    logo.BeginInit();
                    logo.UriSource = new Uri("pack://ServerFront:,,,/ResourceFile.xaml", UriKind.Absolute);
                    logo.EndInit();
                    background.Source = logo;

                    //if (server.GeneralMap.GridContent[i][j] < 63)
                    //    background.Opacity = (server.GeneralMap.GridContent[i][j] / 100);

                    Grid.SetColumn(background, i);
                    Grid.SetRow(background, j);
                    maingrid.MainGrid1.Children.Add(background);
                }
            }
        }
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
            for (int i = 0; i < arrayOfArrays.Length; i++)
                arrayOfArrays[i] = new byte[10];
        }
        //map1.GridContent
    }
    //load file: canvas OR grid.
    //implement a grid to canvas and a canvas to grid
    //save file
}
