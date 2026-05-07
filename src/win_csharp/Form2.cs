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
            label1.Text = "Thank you for using the tool.\r\n"
                + "Always receive bug reports.\r\n"
                + "If possible, please let me know on the Issues tab at \r\n"
                + "https://github.com/ImageCompressor and I could solve it quickly.\r\n\r\n"
                + "Unfortunately, I do not accept requests for functional improvement, \r\n"
                + "but I will consider it when there are more users.\r\n";
            label1.Text += "I admire all developers who purely code in this day and age. \r\nThanks a lot.";
            textBox1.Text = "https://github.com/Noksek2/ImageCompressor";
        }

    }
}
