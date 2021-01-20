using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MaPremiereFenetre
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            string[] maSource = { "choix1", "choix2", "choix3" };
            InitializeComponent();
            dataGridView1.DataSource = maSource;
        }

       
    }
}
