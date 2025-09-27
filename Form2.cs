using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ImageCompressor
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            label1.Text = "1. Select an extension and set quality of the result images.\n2. Click the button and choose a path to save. \n3. Wait until the conversion is complete";
            label1.Text += "\n\n The quality of the images is recommended to be 85~95. "
                +"\nQuality : \n※55~64: You can use it but not to be recommended.\n"
                +"65~74 : Low quality and small size.\n75~84 : Midium quality & suitable size."
                +"\n85~95 : High quality and suitable size. \n95~: High Quality but too much size. ";
            label2.Text += "\nhttps://blog.naver.com/noksek0615";
        }
    }
}
