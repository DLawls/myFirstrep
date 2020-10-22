//*******************************************************************
// Programmer: David Lawler
// Date:       24/09/2020
// Software:   Microsoft Visual Studio 2019 Community Edition
// Platform:   Microsoft Windows 10 Professional 64­bit Version 1803
// Purpose:    Reading from a text file to a 2D array - Assignment 1c
//*******************************************************************
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Assignment_1c___David_Lawler
{
    public partial class frmMain : Form
    {
        private StreamReader fileReader;
        public frmMain()
        {
            InitializeComponent();
        }

        // Form­wide variables
        string fileName;

        const int ROWS = 4;
        const int COLUMNS = 2;

        int[,] finesArray = new int[ROWS, COLUMNS];

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            string inputRow;
            string[] inputFines;
            dlgOpen.Filter = "Text files (*.txt)|*.txt";

            if (dlgOpen.ShowDialog() != DialogResult.Cancel)
                fileName = dlgOpen.FileName;

            FileStream input = new FileStream(fileName, FileMode.Open, FileAccess.Read);

            fileReader = new StreamReader(input);

            for (int row = 0; row < 4; row++)
            {
                inputRow = fileReader.ReadLine(); // Read a record from the file
                inputFines = inputRow.Split(','); // Store the 2 columns in the string array 

                for (int col = 0; col < 2; col++)
                {
                    finesArray[row, col] = Convert.ToInt32(inputFines[col]);
                }
                    
            }

            MessageBox.Show("File was read successfully", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            btnOpen.Enabled = false;
        }

        private void btnAverage_Click(object sender, EventArgs e)
        {
            int totalEvening = 0;
            
            for (int row = 0; row < 4; row++) //Navigates row 2 only
                totalEvening += finesArray[row, 1]; //Accumulator
            lblAverage.Text = "Average Evening Fines = " + Convert.ToString(totalEvening / ROWS);
            btnAverage.Enabled = false; // Disable button to prevent selection
        }

        private void btnTotal_Click(object sender, EventArgs e)
        {
            int totalAll = 0;
            for (int row = 0; row < 4; row++)
                for (int col = 0; col < 2; col++)
                    totalAll += finesArray[row, col];
            lblTotal.Text = "Total fines = " + Convert.ToString(totalAll);
            btnTotal.Enabled = false;
        }

        private void frmMain_Load(object sender, EventArgs e)
        {

        }
    }
}
