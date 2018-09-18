using Acme.Common;
using static Acme.Common.LoggingService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acme.Biz
{
    /// <summary>
    /// Manages products carried in inventory.
    /// </summary>
    public class Product
    {
        #region Constructors
        public Product()
        {
            //var colourOptions = new string[4];
            //colourOptions[0] = "Red";
            //colourOptions[1] = "Brown";
            //colourOptions[2] = "White";
            //colourOptions[3] = "Blue";

            string[] colourOptions = {"Red", "Brown", "White", "Blue"};

            var brownIndex = Array.IndexOf(colourOptions, "Brown");
            colourOptions.SetValue("Navy", 3);

            for(int i = 0 ; i < colourOptions.Length ; i++) {
                colourOptions[i] = colourOptions[i].ToLower();
            }

            foreach(var colour in colourOptions) {
                Console.WriteLine($"The colour is {colour}");
            }
        }
        public Product(int productId,
                        string productName,
                        string description) : this()
        {
            this.ProductId = productId;
            this.ProductName = productName;
            this.Description = description;
        }
        #endregion

        #region Properties
        public DateTime? AvailabilityDate { get; set; }

        public decimal Cost { get; set; }

        public string Description { get; set; }

        public int ProductId { get; set; }

        private string productName;
        public string ProductName
        {
            get {
                var formattedValue = productName?.Trim();
                return formattedValue;
            }
            set
            {
                if (value.Length < 3)
                {
                    ValidationMessage = "Product Name must be at least 3 characters";
                }
                else if (value.Length > 20)
                {
                    ValidationMessage = "Product Name cannot be more than 20 characters";

                }
                else
                {
                    productName = value;

                }
            }
        }

        private Vendor productVendor;
        public Vendor ProductVendor
        {
            get {
                if (productVendor == null)
                {
                    productVendor = new Vendor();
                }
                return productVendor;
            }
            set { productVendor = value; }
        }

        public string ValidationMessage { get; private set; }

        #endregion

        /// <summary>
        /// Calculates the suggested retail price
        /// </summary>
        /// <param name="markupPercent">Percent used to mark up the cost.</param>
        /// <returns></returns>
        public OperationResultDecimal CalculateSuggestedPrice(decimal markupPercent)
        {
            var message = "";

            if(markupPercent <= 0m)
                message = "Invalid markup percentage";
            else if(markupPercent < 10)
                message = "Below recommended markup percentage";
            var value = this.Cost + (this.Cost * markupPercent / 100);

            var operationResult = new OperationResultDecimal(value, message);
            return operationResult;
        }

        public override string ToString()
        {
            return this.ProductName + " (" + this.ProductId + ")";
        }
    }
}
