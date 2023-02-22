using BusinessObject;
using DataAccess.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class ProductDAO
    {
        private Asm1PRNContext _Context;

        public ProductDAO()
        {
            _Context = DataProvider.Ins.DB;
        }

        public List<Product> getAll()
        {
            return _Context.Products.ToList();
        }

        public List<Product> getAllKey(string key)
        {
            return _Context.Products.Where(x=> x.ProductName.Contains(key)).ToList();
        }
        public int countProduct(string productName)
        {
            return _Context.Products.Where(x => x.ProductName == productName).Count();
        }

        public void addNew(Product product)
        {
            try
            {
                _Context.Products.Add(product);
                _Context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void update(int productId, Product product)
        {
            try
            {
                var pro = _Context.Products.Where(x => x.ProductId == productId).SingleOrDefault();
                if (pro == null)
                {
                    throw new Exception("Can not read selected Product!");
                }
                pro.ProductName = product.ProductName;
                pro.CategoryId = product.CategoryId;
                pro.Weight = product.Weight;
                pro.UnitStock = product.UnitStock;
                pro.UnitPrice = product.UnitPrice;
                _Context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void delete(int productId)
        {
            try
            {
                var pro = _Context.Products.Where(x => x.ProductId == productId).SingleOrDefault();
                if (pro == null)
                {
                    throw new Exception("Can not read selected Product!");
                }
                _Context.Products.Remove(pro);
                _Context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
