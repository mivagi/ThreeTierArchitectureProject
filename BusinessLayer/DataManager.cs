using BusinessLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class DataManager
    {
        private readonly ICategories categories;
        private readonly IProducts products;

        public DataManager(ICategories categories, IProducts products)
        {
            this.categories = categories;
            this.products = products;
        }
        public ICategories Categories { get { return categories; } }
        public IProducts Products { get { return products; } }
    }
}
