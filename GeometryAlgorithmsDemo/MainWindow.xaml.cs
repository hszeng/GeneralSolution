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
using Introduction2Algorithms.GeometryAlgorithms;

namespace Introduction2Algorithms.GeometryAlgorithmsDemo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public SimplePolygon simplePolygon { get; set; }
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btn_GRB_Click(object sender, RoutedEventArgs e)
        {
            simplePolygon = new SimplePolygon();
            simplePolygon.Initialize(10, 30, 570, 30, 370);
            drawPoints();
            drawingLine();
            drawingEmitLine();
            resizeCanvas();
        }

        private void btn_clr_Click(object sender, RoutedEventArgs e)
        {
            canvas.Children.Clear();
            tb.Text = null; ;
            drawCoordinates();
        }


        private const int Coordinates_X_OFFSET = 40;
        private const int Coordinates_Y_OFFSET = 30;
        private double MaxDataX = 600;
        private double MaxDataY = 400;
        private List<UIElement> CooridatesPaths = new List<UIElement>();



        private void drawPoints()
        {
            if (simplePolygon == null) return;
            StringBuilder s = new StringBuilder();
            for (int i = 0; i < simplePolygon.GeometryPoints.Length; i++)
            {
                Ellipse elps = new Ellipse();
                elps.Height = 3;
                elps.Width = 3;
                elps.Fill = Brushes.Black;
                elps.SetValue(Canvas.LeftProperty, simplePolygon.GeometryPoints[i].X + Coordinates_X_OFFSET);
                elps.SetValue(Canvas.TopProperty, simplePolygon.GeometryPoints[i].Y + Coordinates_Y_OFFSET);
                canvas.Children.Add(elps);
                s = s.AppendLine(simplePolygon.GeometryPoints[i].ToString());
            }
            tb.Text = s.ToString();
        }



        private void drawingLine()
        {
            if (simplePolygon == null) return;
            for (int i = 0; i < simplePolygon.GeometryPoints.Length - 1; i++)
            {
                Point startPt = new Point();
                Point endPt = new Point();

                startPt.Y = simplePolygon.GeometryPoints[i].Y + Coordinates_Y_OFFSET;
                endPt.Y = simplePolygon.GeometryPoints[i + 1].Y + Coordinates_Y_OFFSET;
                startPt.X = simplePolygon.GeometryPoints[i].X + Coordinates_X_OFFSET;
                endPt.X = simplePolygon.GeometryPoints[i + 1].X + Coordinates_X_OFFSET;

                LineGeometry myLineGeometry = new LineGeometry();
                myLineGeometry.StartPoint = startPt;
                myLineGeometry.EndPoint = endPt;
                Path myPath = new Path();
                myPath.Stroke = Brushes.Green;
                myPath.StrokeThickness = 1;
                myPath.Data = myLineGeometry;
                canvas.Children.Add(myPath);
                if (i == simplePolygon.GeometryPoints.Length - 2)
                {
                    int j = simplePolygon.GeometryPoints.Length - 1;
                    Point startPt1 = new Point();
                    Point endPt1 = new Point();
                    startPt1.Y = simplePolygon.GeometryPoints[j].Y + Coordinates_Y_OFFSET;
                    endPt1.Y = simplePolygon.GeometryPoints[0].Y + Coordinates_Y_OFFSET;
                    startPt1.X = simplePolygon.GeometryPoints[j].X + Coordinates_X_OFFSET;
                    endPt1.X = simplePolygon.GeometryPoints[0].X + Coordinates_X_OFFSET;

                    LineGeometry myLineGeometry1 = new LineGeometry();
                    myLineGeometry1.StartPoint = startPt1;
                    myLineGeometry1.EndPoint = endPt1;
                    Path myPath1 = new Path();
                    myPath1.Stroke = Brushes.Green;
                    myPath1.StrokeThickness = 1;
                    myPath1.Data = myLineGeometry1;
                    canvas.Children.Add(myPath1);
                }
            }

        }

        private void drawingEmitLine()
        {
            if (simplePolygon == null) return;
            int j = simplePolygon.GeometryPoints.Length - 1;
            for (int i = 0; i < simplePolygon.GeometryPoints.Length - 1; i++)
            {
                Point startPt = new Point();
                Point endPt = new Point();

                startPt.Y = simplePolygon.GeometryPoints[j].Y + Coordinates_Y_OFFSET;
                endPt.Y = simplePolygon.GeometryPoints[i].Y + Coordinates_Y_OFFSET;
                startPt.X = simplePolygon.GeometryPoints[j].X + Coordinates_X_OFFSET;
                endPt.X = simplePolygon.GeometryPoints[i].X + Coordinates_X_OFFSET;

                LineGeometry myLineGeometry = new LineGeometry();
                myLineGeometry.StartPoint = startPt;
                myLineGeometry.EndPoint = endPt;
                Path myPath = new Path();
                myPath.Stroke = Brushes.Red;
                myPath.StrokeThickness = 0.5;
                myPath.Data = myLineGeometry;
                canvas.Children.Add(myPath);
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

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            canvas.Children.Clear();
            drawCoordinates();
        }
    }
}
