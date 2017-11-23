using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prototype
{
    public class ProductModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public decimal Price { get; set; }
        public string ImagePath { get; set; }
        public string Description { get; set; }
        public int Type { get; set; }

        public override bool Equals(object obj)
        {
            ProductModel product = obj as ProductModel;
            return this.ID == product.ID;
        }


    }
}
