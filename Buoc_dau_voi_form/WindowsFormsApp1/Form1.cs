using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            // tao doi tuong form 2
            Form Form2 = new Form();
            // thieets lap tieu de 
            Form2.Text = "Giao dien Form 2 ";
            // thiet lap vi tri form 
            Form2.StartPosition = FormStartPosition.CenterScreen;
            // thiet lap mau nen ho form 
            Form2.BackColor = Color.CadetBlue;
            // hien thi form 2 maf khong tac dong duoc den form 1
            Form2.ShowDialog();
            // hien thi form  2 tac dong duc den form 1
            //Form2.Show();
            // an form 1
         //   this.Visible = false;
         if(Form2.ShowDialog() == DialogResult.Cancel)
            { this.Close(); }
        }

    }
    
}
