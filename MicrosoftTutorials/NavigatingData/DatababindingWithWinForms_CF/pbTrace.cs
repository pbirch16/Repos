using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DatababindingWithWinForms_CF
{
    class pbTrace
    {
        BindingSource _bsCategory;
        BindingSource _bsProduct;
        DataGridView _dgvCategory;
        DataGridView _dgvProduct;

        public pbTrace
                (
                    BindingSource bsCategory, BindingSource bsProduct,
                    DataGridView dgvCategory, DataGridView dgvProduct
                )
        {
            _bsCategory = bsCategory;
            _bsProduct = bsProduct;
            _dgvCategory = dgvCategory;
            _dgvProduct = dgvProduct;
        }

        public void TraceThruBindingSources()
        {
            int catCount = _bsCategory.Count;
            var catCurrent = _bsCategory.Current;
            int catPosition = _bsCategory.Position;

            Console.WriteLine("catCount = {0}  catPosition = {1}", catCount.ToString(), catPosition.ToString());

            for (int i = 0; i < catCount; i++)
            {
                Category ct = (Category)_bsCategory.List[i];
                Console.WriteLine("\tCategoryId = {0}  Name = {1} ", ct.CategoryId.ToString(), ct.Name);
                foreach (Product p in ct.Products)
                {
                    Console.WriteLine("\t\tcategoryProductId = {0}  categoryProductName = {1}", p.ProductId, p.Name);
                }
            }

            Console.WriteLine();
            Console.WriteLine();

            Category c = (Category)catCurrent;
            int currentIid = c.CategoryId;

            int prodCount = _bsProduct.Count;
            var prodCurrent = _bsProduct.Current;
            int prodPosition = _bsProduct.Position;

            Console.WriteLine("prodCount = {0}  prodPosition = {1}", prodCount, prodPosition);

            Product product = (Product)prodCurrent;
            int productId = product.ProductId;
            int pcid = product.CategoryId;
            Category productCategory = product.Category;

            for (int i = 0; i < prodCount; i++)
            {
                Product pr = (Product)_bsProduct.List[i];
                Console.WriteLine("\tProductId = {0}   Product Name = {1}  productCategoryId = {2} ",
                    pr.ProductId.ToString(), pr.Name, pr.CategoryId);
            }
        }        
    }
}
