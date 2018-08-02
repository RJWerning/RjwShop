using RjwShop.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
using System.Text;
using System.Threading.Tasks;

namespace RjwShop.DataAccess.InMemory {
    public class ProduceCategoryRepository {
        ObjectCache cache = MemoryCache.Default;
        List<ProductCategory> productCategories;

        public ProduceCategoryRepository() {
            productCategories = cache["productCategories"] as List<ProductCategory>;
            if (productCategories == null) {
                productCategories = new List<ProductCategory>();
            }
        }

        public void Commit() {
            cache["productCategories"] = productCategories;
        }

        public void Insert(ProductCategory P) {
            productCategories.Add(P);
        }

        public void Update(ProductCategory productCategory) {
            ProductCategory productToUpdate = productCategories.Find(p => p.Id == productCategory.Id);

            if (productToUpdate != null) {
                productToUpdate = productCategory;
            } else {
                throw new Exception("Product Category not found");
            }
        }

        public ProductCategory Find(string Id) {
            ProductCategory product = productCategories.Find(p => p.Id == Id);

            if (product != null) {
                return product;
            } else {
                throw new Exception("Product Category not found");
            }
        }

        public IQueryable<ProductCategory> Collection() {
            return productCategories.AsQueryable();
        }

        public void Delete(string Id) {
            ProductCategory product = productCategories.Find(p => p.Id == Id);

            if (product != null) {
                productCategories.Remove(product);
            } else {
                throw new Exception("Product Category not found");
            }
        }
    }
}
