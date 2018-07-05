using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab3
{
    public partial class OrderForm : Form
    {
        #region Constructor

        public OrderForm()
        {
            InitializeComponent();
        }

        #endregion

        #region AddIteam Button

        private void btnAddItem_Click(object sender, EventArgs e)
        {
            var item = new ReceiptItem(); // instantiate new ReceiptItem for the order

            // determine which drink was selected

            if (rdFruit.Checked)
            {
                item.Name = "J Fruit";
            }

            else if (rdVeg.Checked)
            {
                item.Name = "J Vegetable";
            }

            else if (rdPom.Checked)
            {
                item.Name = "S Pomegranate";
            }

            else if (rdStraw.Checked)
            {
                item.Name = "S Strw Banana";
            }

            else if (rdWheat.Checked)
            {
                item.Name = "S Wheat Berry";
            }

            else
            { // no drink selected
                MessageBox.Show("Please Select a Type of Drink");
                return; // cancel method
            }

            #region Additives

            // determine what additives are part of the order

            if (chkEnergyBoost.Checked)
            {
                item.AddAdditive(Additives.EnergyBoost);
            }

            if (chkVitaminPack.Checked)
            {
                item.AddAdditive(Additives.Vitamin);
            }

            if (chkCoolDown.Checked)
            {
                item.AddAdditive(Additives.CoolDownRemedy);
            }

            #endregion

            // determine what size was selected

            if (rd12.Checked)
            {
                item.Price = 3;
            }

            else if (rd16.Checked)
            {
                item.Price = 3.5;
            }

            else if (rd20.Checked)
            {
                item.Price = 4;
            }

            else
            {
                MessageBox.Show("Must select drink size.");
                return;
            }

            if (numericUpDown.Value < 1)
            { // no quantity selected
                MessageBox.Show("Must have a quantity of 1 or higher!");
                return; // exit method
            }

            item.Quantity = (int)numericUpDown.Value; // add quantity to item

            sourceItems.Add(item); // add item to BindingSource for ListBox to display

            CalculateTotal(); // re-calculate order total
            btnReset_Click(sender, e);
        }

        #endregion

        #region Event Handlers

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            // reset drink
            rdFruit.Checked = rdPom.Checked = rdVeg.Checked = rdStraw.Checked = rdWheat.Checked = false;

            // reset additives
            chkCoolDown.Checked = chkEnergyBoost.Checked = chkVitaminPack.Checked = false;

            // reset size to medium as it is the most often bought size and serves as a default. 
            rd16.Checked = true; 

            // reset quantity
            numericUpDown.Value = 1;
        }
        
        private void btnClearOrder_Click(object sender, EventArgs e)
        {
            sourceItems.Clear();
            CalculateTotal();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This program is for ordering juice and/or smoothies.", "Juice Bar");
        }

        /// <summary>
        /// Changes font for title.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timesNewRomanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            lblTitle.Font = new Font("Times New Roman", 48,FontStyle.Bold);
        }

        private void comicSansToolStripMenuItem_Click(object sender, EventArgs e)
        {
            lblTitle.Font = new Font("Comic Sans", 48, FontStyle.Bold);
        }

        private void arialToolStripMenuItem_Click(object sender, EventArgs e)
        {
            lblTitle.Font = new Font("Arial", 48, FontStyle.Bold);
        }

        private void broadwayToolStripMenuItem_Click(object sender, EventArgs e)
        {
            lblTitle.Font = new Font("Broadway", 48, FontStyle.Bold);
        }

        /// <summary>
        /// Changes the color for title. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void greyToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            lblTitle.ForeColor = System.Drawing.Color.WhiteSmoke;
        }

        private void blueToolStripMenuItem_Click(object sender, EventArgs e)
        {
            lblTitle.ForeColor = System.Drawing.Color.Blue;
        }

        private void blackToolStripMenuItem_Click(object sender, EventArgs e)
        {
            lblTitle.ForeColor = System.Drawing.Color.Black;
        }

        private void greenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            lblTitle.ForeColor = System.Drawing.Color.Green;
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Calculates the order total using the previously added items.
        /// </summary>
        private void CalculateTotal()
        {
            double total = 0;

            foreach (ReceiptItem item in sourceItems)
            { // iterate over the BindingSource items and add total.
                total += item.Total;
            }

            lblTotal.Text = total.ToString("c"); // format total as currency for label
        }

        #endregion

    }
}
