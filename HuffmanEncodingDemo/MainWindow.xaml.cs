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
using Microsoft.Win32;
using Introduction2Algorithms.FileReader;
using Introduction2Algorithms.HuffmanEncoding;

namespace Introduction2Algorithms.HuffmanEncodingDemo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btn_load_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "英文文件(*.txt)|*.txt|所有文件(*.*)|*.*";
            ofd.ShowDialog();
            String txtPath = ofd.FileName;
            if (System.IO.File.Exists(txtPath))
            {
                FileReaderTool frt = new FileReaderTool();
                string str = frt.ReadFile(txtPath);
                this.tb_ori.Text = str;
                //assic
                byte[] byteArray;
                byteArray = System.Text.Encoding.ASCII.GetBytes(str);
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < byteArray.Length; i++)
                {
                    string s = Convert.ToString(byteArray[i], 2);
                    int len = s.Length;
                    if (len < 8)
                    {
                        for (int j = 0; j < 8 - len; j++)
                        {
                            s = "0" + s;
                        }
                    }
                    sb.Append(s);
                }
                this.tb_assic.Text = sb.ToString();
                this.tb_bitnumber.Text = "Bit Count:" + +sb.ToString().ToCharArray().Length;
            }
        }
        Huffman hm;
        private void btn_encode_Click(object sender, RoutedEventArgs e)
        {
            FrequencyCounter fc = new FrequencyCounter();
            var kvps = fc.MapReduce(this.tb_ori.Text);
            hm = new Huffman(kvps);
            StringBuilder sb = new StringBuilder();
            string ori = this.tb_ori.Text;
            char[] chararray = ori.ToCharArray();
            for (int i = 0; i < chararray.Length; i++)
            {
                sb.Append(hm.Encode(chararray[i]));
            }
            this.tb_encode.Text = sb.ToString();
            this.tb_hufbitnumber.Text = "Bit Count:" + sb.ToString().ToCharArray().Length;
        }

        private void btn_decode_Click(object sender, RoutedEventArgs e)
        {
            string bstr = this.tb_encode.Text;
            StringBuilder sb = new StringBuilder();
            char? outchar = null;
            string tmpStr = null;
            for (int i = 0; i < bstr.Length; i++)
            {
                tmpStr = tmpStr + bstr[i];
                if (hm.Decode(tmpStr, out outchar))
                {
                    tmpStr = null;
                    sb.Append(outchar);
                }
            }
            this.tb_decode.Text = sb.ToString();
        }
    }
}
