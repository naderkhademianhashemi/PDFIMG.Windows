using PDFIMG.Windows.Util;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PDFIMG.Windows
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        public string GetPath()
        {
            var path = string.Empty;
            var fdlg = new OpenFileDialog();
            fdlg.Title = "SelectFile";
            fdlg.InitialDirectory = @"c:\\";

            fdlg.FilterIndex = 1;
            fdlg.RestoreDirectory = true;
            if (fdlg.ShowDialog() == DialogResult.OK)
                path = fdlg.FileName;
            return path;
        }
        public static void CreateIMG(string txt)
        {
            using (Bitmap b = new Bitmap(5000, 5000))
            {
                Font drawFont = new Font("Arial", 16);
                SolidBrush drawBrush = new SolidBrush(Color.Black);
                PointF drawPoint = new PointF(70.0F, 70.0F);
                using (Graphics g = Graphics.FromImage(b))
                {
                    g.DrawString(txt, drawFont
                        , drawBrush
                        , drawPoint);
                }
                b.Save(@"D:\txt2.png");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var txt=Extens.pdfText(textBox1.Text);
            CreateIMG(txt);
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            textBox1.Text = GetPath();
        }
    }
}
