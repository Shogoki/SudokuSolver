using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Sudoku_Solver;


namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {

        private System.Windows.Forms.TextBox[,] textBoxes;       
        public Form1()
        {
            
            InitializeComponent();
            this.textBoxes = new System.Windows.Forms.TextBox[9,9];
            for (int i = 0; i < 9; i++)
            {
                for (int a = 0; a < 9; a++)
                {
                    this.textBoxes[i, a] = new TextBox();
                    this.textBoxes[i, a].Location = new System.Drawing.Point((i*25 +25),(a *25 +25 ));
                    this.textBoxes[i, a].Name = "textBox" +i.ToString() + a.ToString();
                    this.textBoxes[i, a].Size = new System.Drawing.Size(25, 25);
                    this.textBoxes[i, a].Multiline = true;
                    this.textBoxes[i, a].Font = new System.Drawing.Font("Arial", 10,FontStyle.Bold);
                    this.textBoxes[i, a].TextAlign = HorizontalAlignment.Center;
                    this.textBoxes[i, a].MaxLength = 1;
                   // this.textBoxes[i, a].Text = i.ToString() + a.ToString();
                    this.textBoxes[i, a].TextChanged += new System.EventHandler(this.textBoxes_TextChanged);
                    this.Controls.Add(this.textBoxes[i, a]);
                }
            }

            /*
            this.textBoxes[0,0].Location = new System.Drawing.Point(20, 20);
            this.textBoxes[0,0].Name = "textBox00";
            this.textBoxes[0,0].Size = new System.Drawing.Size(25, 25);
        */
             }

        private int[,] field = new int[10, 10];

       private void textBoxes_TextChanged(object sender, EventArgs e)
        {
            //check if the value is a number
            int value;
            TextBox box = (TextBox)sender;
            if (!Int32.TryParse(box.Text, out value))
                box.Text = "";

           
        }

       private void button1_Click(object sender, EventArgs e)
       {
           Sudoku su = new Sudoku(new SudokuField(textBoxes));
           su.solve();
           su.GetField(ref textBoxes);

       }

       private void button2_Click(object sender, EventArgs e)
       {
           Sudoku su = new Sudoku(new SudokuField(textBoxes));
           MessageBox.Show(su.GetField().IsValid().ToString());

       }
        



    }
}
