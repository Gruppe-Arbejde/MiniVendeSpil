﻿using System;
using System.Threading;
using System.Windows.Forms;

namespace MiniVendeSpil
{
    public partial class MiniVendeSpil : Form
    {
        private bool firstButtonPressed = false;
        Button firstButton;
        string[] backSide = { "A", "A", "B", "B" };



        public MiniVendeSpil()
        {
            InitializeComponent();
            button1.Text = "";
            button2.Text = "";
            button3.Text = "";
            button4.Text = "";


        }

        private void ButtonCommon(object sender, EventArgs e)
        {

            Button b = (Button)sender;

            if (firstButtonPressed == false)
            {
                firstButton = b;
                int nummer = GetNumber(firstButton.Name);
                if (nummer > 0)
                {
                    firstButton.Text = backSide[nummer - 1]; // -1 due to 0 index in array
                }
                firstButton.Enabled = false; // Disables the button when pressed, so you can't double press and get a match.
                firstButtonPressed = true;
            }
            else
            {
                int nummer = GetNumber(b.Name);
                if (nummer > 0)
                {
                    b.Text = backSide[nummer - 1]; // -1 due to 0 index in array
                }
                if (0 == string.Compare(b.Text, firstButton.Text))
                {
                    MessageBox.Show("There was a match");
                    b.Click -= (ButtonCommon);
                    firstButton.Click -= (ButtonCommon); // Disables the button without greying it out.
                    firstButton.Enabled = true; // re-enables the disabled button if you choose the wrong button.
                }
                else
                {
                    this.Refresh();
                    Thread.Sleep(1500);
                    firstButton.Text = "";
                    b.Text = "";
                    firstButton.Enabled = true; // re-enables the disabled button if you choose the wrong button.
                }
                firstButtonPressed = false;
            }

        }

        private int GetNumber(string buttonName)
        {
            string num = "";
            int res = -1;
            // Search whole string lenght
            for (int i = 0; i < buttonName.Length; i++)
            {
                // If the present char is a number then add to num string
                if (char.IsDigit(buttonName[i]))
                    num += buttonName[i];
            }
            // If a number is located
            if (num.Length > 0)
            {
                res = int.Parse(num);
            }
            return res;
        }
    }
}
