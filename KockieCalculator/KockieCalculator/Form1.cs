using System;
using System.Drawing;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Timers;

namespace KockieCalculator
{
    public partial class Form1 : Form
    {
        int type;
        decimal value1, value2;
        decimal result;
        private bool mouseDown;
        private Point lastLocation;

        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn
        (
            int nLeftRect,    
            int nTopRect,     
            int nRightRect,   
            int nBottomRect,  
            int nWidthEllipse,
            int nHeightEllipse
        );
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }
        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDown = true;
            lastLocation = e.Location;
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown)
            {
                this.Location = new Point(
                    (this.Location.X - lastLocation.X) + e.X, (this.Location.Y - lastLocation.Y) + e.Y);

                this.Update();
            }
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
        }

        private void especialButton1_Click(object sender, EventArgs e)
        {
            txtVisor.Text += 1;
        }
        private void especialButton2_Click(object sender, EventArgs e)
        {
            txtVisor.Text += 2;
        }

        private void especialButton3_Click(object sender, EventArgs e)
        {
            txtVisor.Text += 3;
        }

        private void especialButton4_Click(object sender, EventArgs e)
        {
            txtVisor.Text += 4;
        }

        private void especialButton5_Click(object sender, EventArgs e)
        {
            txtVisor.Text += 5;
        }

        private void especialButton6_Click(object sender, EventArgs e)
        {
            txtVisor.Text += 6;
        }

        private void especialButton7_Click(object sender, EventArgs e)
        {
            txtVisor.Text += 7;
        }

        private void especialButton8_Click(object sender, EventArgs e)
        {
            txtVisor.Text += 8;
        }

        private void especialButton9_Click(object sender, EventArgs e)
        {
            txtVisor.Text += 9;
        }

        private void especialButton0_Click(object sender, EventArgs e)
        {
            txtVisor.Text += 0;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnMaximize_Click(object sender, EventArgs e)
        {
            
        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            try
            {
                if (type == 1)
                {
                    value2 = decimal.Parse(txtVisor.Text);
                    result = value1 + value2;
                    txtVisor.Text = ($"{result}");
                }
                else if (type == 2)
                {
                    value2 = decimal.Parse(txtVisor.Text);
                    result = value1 - value2;
                    txtVisor.Text = ($"{result}");
                }
                else if (type == 3)
                {
                    value2 = decimal.Parse(txtVisor.Text);
                    result = value1 * value2;
                    txtVisor.Text = ($"{result}");
                }
            }
            catch (FormatException x)
            {
                type = 0;
                txtVisor.Clear();
                value1 = 0;
                value2 = 0;
                MessageBox.Show($"Nenhum caracter detectado para executar uma operação{x}", "Erro");
            }

        }

        private void btnMultiplication_Click(object sender, EventArgs e)
        {
            try
            {
                type = 3;
                value1 = decimal.Parse(txtVisor.Text);
                txtVisor.Clear();
            }
            catch (FormatException x)
            {
                MessageBox.Show($"Nenhum valor identificado: {x}", "Erro");
                txtVisor.Clear();
            }
        }

        private void btnSubtraction_Click(object sender, EventArgs e)
        {
            try
            {
                type = 2;
                value1 = decimal.Parse(txtVisor.Text);
                txtVisor.Clear();
            }
            catch (FormatException x)
            {
                MessageBox.Show($"Nenhum valor identificado: {x}", "Erro");
                txtVisor.Clear();
            }
        }

        private void btnAddition_Click(object sender, EventArgs e)
        {
            try
            {
                type = 1;
                value1 = decimal.Parse(txtVisor.Text);
                txtVisor.Clear();
            }
            catch (FormatException x)
            {
                MessageBox.Show($"Nenhum valor identificado: {x}", "Erro");
                txtVisor.Clear();
            }
        }

        private void txtVisor_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((Char.IsLetter(e.KeyChar)) || (Char.IsWhiteSpace(e.KeyChar)))
                e.Handled = true;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtVisor.Clear();
        }
    }
}
