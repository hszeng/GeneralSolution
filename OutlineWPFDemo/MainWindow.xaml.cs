using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Introduction2Algorithms.Outline;
using Microsoft.Win32;

namespace Introduction2Algorithms.OutlineWPFDemo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private const int Coordinates_X_OFFSET = 40;
        private const int Coordinates_Y_OFFSET = 30;
        private double MaxDataX = 600;
        private double MaxDataY = 280;
        private Building<int>[] blds;
        private List<UIElement> CooridatesPaths = new List<UIElement>();

        public MainWindow()
        {
            InitializeComponent();
            drawCoordinates();
        }

        private void btn_GRB_Click(object sender, RoutedEventArgs e)
        {
            canvas.Children.Clear();
            drawCoordinates();
            blds = initBuildings(50, 40, 200, 1000);
            drawBuilds();
        }
        public static Building<int>[] initBuildings(int buildCount, int leftLimitInclusive, int maxHeightLimitInclusive, int rightLimitInclusive)
        {
            Building<int>[] buildings = new Building<int>[buildCount];
            Random rndRange = new Random(DateTime.Now.Millisecond);
            Random rndHeight = new Random(DateTime.Now.Millisecond);
            for (int i = 0; i < buildCount; i++)
            {
                int l = rndRange.Next(leftLimitInclusive, rightLimitInclusive);
                int r = rndRange.Next(l + 1, rightLimitInclusive + 1);
                int h = rndHeight.Next(1, maxHeightLimitInclusive + 1);
                Building<int> bld = new Building<int>(l, h, r);
                buildings[i] = bld;
            }
            return buildings;
        }
        private void drawBuilds()
        {
            if (blds == null) return;
            for (int i = 0; i < blds.Length; i++)
            {
                System.Windows.Point p1 = new System.Windows.Point(blds[i][0], 0);
                System.Windows.Point p2 = new System.Windows.Point(blds[i][0], blds[i][1]);
                System.Windows.Point p3 = new System.Windows.Point(blds[i][2], blds[i][1]);
                System.Windows.Point p4 = new System.Windows.Point(blds[i][2], 0);
                drawingLine(p1, p2, Colors.Black);
                drawingLine(p2, p3, Colors.Black);
                drawingLine(p3, p4, Colors.Black);

                if (MaxDataX <= (p4.X + Coordinates_X_OFFSET))
                {
                    MaxDataX = p4.X + Coordinates_X_OFFSET;
                }
                if (MaxDataY <= (p3.Y + Coordinates_Y_OFFSET))
                {
                    MaxDataY = p3.Y + Coordinates_Y_OFFSET;
                }
            }
            resizeCanvas();
        }
        private void drawOutlines(Building<int> result)
        {
            if (result == null) return;
            int c = result.Data.Count;
            for (int i = 0; i < c - 2; i = i + 2)
            {
                if (i == 0)
                {
                    System.Windows.Point p1 = new System.Windows.Point(result[i], 0);
                    System.Windows.Point p2 = new System.Windows.Point(result[i], result[i + 1]);
                    System.Windows.Point p3 = new System.Windows.Point(result[i + 2], result[i + 1]);
                    drawingLine(p1, p2, Colors.Red, true);
                    drawingLine(p2, p3, Colors.Red, true);
                }
                else
                {
                    System.Windows.Point p1 = new System.Windows.Point(result[i], result[i - 1]);
                    System.Windows.Point p2 = new System.Windows.Point(result[i], result[i + 1]);
                    System.Windows.Point p3 = new System.Windows.Point(result[i + 2], result[i + 1]);
                    drawingLine(p1, p2, Colors.Red, true);
                    drawingLine(p2, p3, Colors.Red, true);
                }
            }
            if (c > 0)
            {
                System.Windows.Point p1 = new System.Windows.Point(result[c - 2], result[c - 3]);
                System.Windows.Point p2 = new System.Windows.Point(result[c - 2], 0);
                drawingLine(p1, p2, Colors.Red, true);
            }
        }
        private void btn_CO_Click(object sender, RoutedEventArgs e)
        {
            if (blds == null || blds.Length == 0)
            {
                MessageBox.Show("Please generate data first!", "Warnning", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else
            {
                Building<int> result = OutLineUtility.MergeBuildings<int>(blds, 0, blds.Length - 1);
                drawOutlines(result);
            }
        }
        private void btn_HS_Click(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < canvas.Children.Count; i++)
            {
                if (canvas.Children[i] is Path)
                {
                    if ((canvas.Children[i] as Path).Tag != null)
                    {
                        if ((canvas.Children[i] as Path).Visibility == Visibility.Visible)
                        {
                            (canvas.Children[i] as Path).Visibility = Visibility.Hidden;
                        }
                        else if ((canvas.Children[i] as Path).Visibility == Visibility.Hidden)
                        {
                            (canvas.Children[i] as Path).Visibility = Visibility.Visible;
                        }
                    }
                }
            }
        }
        private void btn_clr_Click(object sender, RoutedEventArgs e)
        {
            canvas.Children.Clear();
            drawCoordinates();
        }
        private void drawingLine(System.Windows.Point startPt, System.Windows.Point endPt, Color clr, bool isOutline = false)
        {
            startPt.Y = startPt.Y + Coordinates_Y_OFFSET;
            endPt.Y = endPt.Y + Coordinates_Y_OFFSET;
            startPt.X = startPt.X + Coordinates_X_OFFSET;
            endPt.X = endPt.X + Coordinates_X_OFFSET;

            LineGeometry myLineGeometry = new LineGeometry();
            myLineGeometry.StartPoint = startPt;
            myLineGeometry.EndPoint = endPt;
            Path myPath = new Path();
            myPath.Stroke = new SolidColorBrush(clr);
            myPath.StrokeThickness = 1;
            myPath.Data = myLineGeometry;
            canvas.Children.Add(myPath);
            if (isOutline)
            {
                myPath.Tag = 1;
            }
        }
        private void resizeCanvas()
        {
            if (MaxDataX == 600 && MaxDataY == 280)
            {
                canvas.Width = MaxDataX;
                canvas.Height = MaxDataY;
            }
            canvas.Width = MaxDataX + 20;
            canvas.Height = MaxDataY + 20;
            MaxDataX = 600;
            MaxDataY = 280;
        }
        private void drawCoordinates()
        {
            //原点
            System.Windows.Point Origin = new System.Windows.Point(Coordinates_X_OFFSET, Coordinates_Y_OFFSET);
            //Y轴顶点
            System.Windows.Point pYAxis = new System.Windows.Point(Coordinates_X_OFFSET, canvas.ActualHeight - 5);
            //X轴顶点
            System.Windows.Point pXAxis = new System.Windows.Point(canvas.ActualWidth - 5, Coordinates_Y_OFFSET);

            //x轴
            LineGeometry myLineGeometry = new LineGeometry();
            myLineGeometry.StartPoint = Origin;
            myLineGeometry.EndPoint = pXAxis;
            Path myPath = new Path();
            myPath.Stroke = Brushes.Black;
            myPath.StrokeThickness = 1;
            myPath.Data = myLineGeometry;
            canvas.Children.Add(myPath);
            CooridatesPaths.Add(myPath);
            //Y轴
            myLineGeometry = new LineGeometry();
            myLineGeometry.StartPoint = Origin;
            myLineGeometry.EndPoint = pYAxis;
            myPath = new Path();
            myPath.Stroke = Brushes.Black;
            myPath.StrokeThickness = 1;
            myPath.Data = myLineGeometry;
            canvas.Children.Add(myPath);
            CooridatesPaths.Add(myPath);

            //
            drawAnnotations();
        }
        private void drawAnnotations()
        {
            int X_origin = Coordinates_X_OFFSET;
            int Y_origin = Coordinates_Y_OFFSET;
            double X_Axis_Max = canvas.ActualWidth;
            double Y_Axis_Max = canvas.ActualHeight;

            int h1 = Coordinates_Y_OFFSET - 2;
            int h2 = Coordinates_Y_OFFSET - 10;
            for (int i = X_origin; i < X_Axis_Max - 20; i = i + 10)
            {
                LineGeometry myLineGeometry = new LineGeometry();
                myLineGeometry.StartPoint = new System.Windows.Point(i, h1);
                myLineGeometry.EndPoint = new System.Windows.Point(i, h2);
                if ((i - Coordinates_X_OFFSET) % 50 == 0)
                {
                    myLineGeometry.EndPoint = new System.Windows.Point(i, h2 - 8);

                    TextBlock tb = new TextBlock() { Text = (i - Coordinates_X_OFFSET).ToString() };
                    tb.FontSize = 8;
                    Canvas.SetTop(tb, h2 - 8);
                    Canvas.SetLeft(tb, i - 3);
                    canvas.Children.Add(tb);
                    CooridatesPaths.Add(tb);
                    TransformGroup tfg = new TransformGroup();
                    ScaleTransform stf = new ScaleTransform() { ScaleY = -1 };
                    tfg.Children.Add(stf);
                    tb.RenderTransform = tfg;
                }
                Path myPath = new Path();
                myPath.Stroke = Brushes.Black;
                myPath.StrokeThickness = 1;
                myPath.Data = myLineGeometry;
                canvas.Children.Add(myPath);
                CooridatesPaths.Add(myPath);
            }
            int x1 = Coordinates_X_OFFSET - 2;
            int x2 = Coordinates_X_OFFSET - 10;
            for (int i = Y_origin; i < Y_Axis_Max - 20; i = i + 10)
            {
                LineGeometry myLineGeometry = new LineGeometry();
                myLineGeometry.StartPoint = new System.Windows.Point(x1, i);
                myLineGeometry.EndPoint = new System.Windows.Point(x2, i);
                if ((i - Coordinates_Y_OFFSET) % 50 == 0)
                {
                    myLineGeometry.EndPoint = new System.Windows.Point(x2 - 8, i);

                    TextBlock tb = new TextBlock() { Text = (i - Coordinates_Y_OFFSET).ToString() };
                    tb.FontSize = 8;
                    Canvas.SetTop(tb, i + 6);
                    Canvas.SetLeft(tb, x2 - 23);
                    canvas.Children.Add(tb);
                    CooridatesPaths.Add(tb);
                    TransformGroup tfg = new TransformGroup();
                    ScaleTransform stf = new ScaleTransform() { ScaleY = -1 };
                    tfg.Children.Add(stf);
                    tb.RenderTransform = tfg;
                }
                Path myPath = new Path();
                myPath.Stroke = Brushes.Black;
                myPath.StrokeThickness = 1;
                myPath.Data = myLineGeometry;
                canvas.Children.Add(myPath);
                CooridatesPaths.Add(myPath);
            }
        }
        private void canvas_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            for (int i = 0; i < CooridatesPaths.Count; i++)
            {
                if (canvas.Children.Contains(CooridatesPaths[i]))
                {
                    canvas.Children.Remove(CooridatesPaths[i]);
                }
            }
            CooridatesPaths.Clear();
            drawCoordinates();
        }
        private void btn_LoadBuildings_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "文本文件(*.txt)|*.txt|所有文件(*.*)|*.*";
            ofd.ShowDialog();
            String txtPath = ofd.FileName;
            if (System.IO.File.Exists(txtPath))
            {
                blds = parseBuildings(txtPath);
                drawBuilds();
            }
        }

        private void btn_LoadOutLines_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "文本文件(*.txt)|*.txt|所有文件(*.*)|*.*";
            ofd.ShowDialog();
            String txtPath = ofd.FileName;
            if (System.IO.File.Exists(txtPath))
            {
                var outlines = parseOutLines(txtPath);
                drawOutlines(outlines);
            }
        }

        private Building<int>[] parseBuildings(string data)
        {
            string buildingString = null;
            using (System.IO.StreamReader myStream = new System.IO.StreamReader(data))
            {
                string stringLine = myStream.ReadLine();
                while (stringLine != null)
                {
                    buildingString += stringLine.Trim() + ",";
                    stringLine = myStream.ReadLine();
                }
            }
            var blds = buildingString.Split(',');
            Building<int>[] Buildings = new Building<int>[blds.Count() - 1];

            for (int i = 0; i < blds.Length - 1; i++)
            {
                string str1 = blds[i];
                var strs = str1.Split(' ');
                int l, h, r;
                try
                {
                    l = int.Parse(strs[0]);
                    h = int.Parse(strs[1]);
                    r = int.Parse(strs[2]);
                    Buildings[i] = new Building<int>(l, h, r);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Parse the building failed:" + ex.Message, "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                }

            }
            return Buildings;
        }
        private Building<int> parseOutLines(string data)
        {
            string OutlinesString = null;
            using (System.IO.StreamReader myStream = new System.IO.StreamReader(data))
            {
                string stringLine = myStream.ReadLine();
                while (stringLine != null)
                {
                    OutlinesString += stringLine.Trim();
                    stringLine = myStream.ReadLine();
                }
            }
            var strs = OutlinesString.Split(' ');
            Building<int> Outlines = new Building<int>();
            try
            {
                for (int i = 0; i < strs.Length; i++)
                {
                    int x1 = int.Parse(strs[i]);
                    Outlines.Data.Add(x1);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Parse the building failed:" + ex.Message, "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            return Outlines;
        }

    }
}

