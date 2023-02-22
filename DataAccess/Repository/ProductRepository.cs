using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{

    public class ProductRepository : IProductRepository
    {
        private ProductDAO _ProductDAO;

        public ProductRepository()
        {
            _ProductDAO = new ProductDAO();
        }

        public void Create(Product product)
        {
            _ProductDAO.addNew(product);
        }

        public int ProductCount(string productName)
        {
            return _ProductDAO.countProduct(productName);
        }

        public List<Product> ReadAll()
        {
            return _ProductDAO.getAll();
        }

        public void Update(int productId, Product product)
        {
            _ProductDAO.update(productId, product);
        }
        public void Remove(int productId)
        {
           _ProductDAO.delete(productId);
        }

        public List<Product> ReadKey(string key)
        {
            return _ProductDAO.getAllKey(key);
        }
    }
}
