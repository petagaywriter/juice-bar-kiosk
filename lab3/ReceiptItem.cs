using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab3
{
    /// <summary>
    /// Represents an item that was ordered.
    /// </summary>
    public class ReceiptItem
    {
        private String _name = null;

        /// <summary>
        /// Get or set the item name.
        /// </summary>
        public String Name
        {
            get { return _name; }
            set
            {
                if (value == null)
                {
                    _name = "";
                }

                else
                {
                    _name = value;
                }
            }
        }

        private double _price;

        /// <summary>
        /// Get or set item price.
        /// </summary>
        public double Price
        {
            get { return _price; }
            set
            {
                if (value < 0)
                {
                    _price = 0;
                }

                else
                {
                    _price = value;
                }

                this.CalculateTotal(); // re-calculate total
            }
        }

        private int _quantity;

        /// <summary>
        /// Get or set item quantity.
        /// </summary>
        public int Quantity
        {
            get { return _quantity; }
            set
            {
                if (value < 0)
                {
                    _quantity = 0;
                }

                else
                {
                    _quantity = value;
                }

                this.CalculateTotal(); // re-calculate total
            }
        }

        private double _total;

        /// <summary>
        /// Get calculated item total.
        /// </summary>
        public double Total
        {
            get { return _total; }
        }

        /// <summary>
        /// Generates friendly display text for the item.
        /// </summary>
        /// <returns>Friendly display text.</returns>
        public override string ToString()
        {
            return String.Format("{0} ({1:c}) x{2} {3} - {4:c}", this.Name, this.Price, this.Quantity, this.AdditivesString(), this.Total);
        }

        private List<Additives> _additivies = new List<Additives>();

        /// <summary>
        /// Gets the additives as part of the item.
        /// </summary>
        public List<Additives> Additivites
        {
            get { return _additivies; }
        }

        /// <summary>
        /// Adds an additive onto the item.
        /// </summary>
        /// <param name="additivte">Additive to be added.</param>
        public void AddAdditive(Additives additivte)
        {
            _additivies.Add(additivte);
            CalculateTotal(); // re-calculate total
        }

        /// <summary>
        /// Private method that calculates the item total.
        /// </summary>
        private void CalculateTotal()
        {
            _total = _quantity * _price + _additivies.Count * 2.5;
        }

        /// <summary>
        /// Generates a string representing what (if any) additives are part of the item.
        /// String consists of first character of each additive.
        /// </summary>
        /// <returns>String representing additives.</returns>
        private String AdditivesString()
        {
            String str = "";

            foreach (var additive in this.Additivites)
            {
                str += additive.ToString()[0];
            }

            return str;
        }
    }

    /// <summary>
    /// Enumeration of possible additives that may be added to an order.
    /// </summary>
    public enum Additives
    {
        Vitamin, EnergyBoost, CoolDownRemedy
    }
}
