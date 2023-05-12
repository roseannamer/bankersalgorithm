using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OSassignment
{
    public partial class Form1 : Form
    {
        private int numResources;
        private int numProcesses;
       // private TextBox txtNumResources;
        //private TextBox txtNumProcesses;
        public Form1()
        {
            InitializeComponent();
        }

       /* public int numResources;
        public int numProcesses;
        public int[,] maximumNeed;
        public int[,] currentAllocation;
        public int[] availableResources;
        public int[] dtTotalResources; */

        private void button1_Click(object sender, EventArgs e)
        {
           
            numResources = int.Parse(textBox1.Text);
            numProcesses = int.Parse(textBox2.Text);

            if (int.TryParse(textBox1.Text, out numResources) && int.TryParse(textBox2.Text, out numProcesses))
            {
                if (numResources < 0 || numProcesses < 0)
                {
                    MessageBox.Show("Number of resources and processes must be greater than zero.", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    // Open the next form and pass the number of resources and processes as parameters
                    Form2 bankersalgorithm = new Form2(numResources, numProcesses);
                    bankersalgorithm.Show();
                    this.Hide();
                }
            }
            else
            {
                MessageBox.Show("Please enter valid numbers for the number of resources and processes.");
            }

        }
           
        

        public void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("Please enter number", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (textBox1.Text == "")
            {
                Console.Write("Enter the number of resource types: ");
                int numResources = int.Parse(Console.ReadLine());
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (textBox2.Text == "")
            {
                MessageBox.Show("Please enter number", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (textBox2.Text == "")
            {
                Console.Write("Enter the number of processes: ");
                int numProcesses = int.Parse(Console.ReadLine());
            }
        }

        private void label_color(object sender, EventArgs e)
        {
            (sender as Label).ForeColor = Color.Red;
        }

        private void MouseLeave_color(object sender, EventArgs e)
        {
            (sender as Label).ForeColor = Color.Black;
        }
    }
    
}
