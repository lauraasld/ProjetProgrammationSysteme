using System;
using System.Collections.Generic;
using Model.Kitchen.BLL;
using Model.Kitchen.DAL;
namespace Model.Kitchen {
	public class ProductStorageFacade {
        StorageService storageService;
        ProductService productService;
        CategoryService categoryService;
        public ProductStorageFacade()
        {
            storageService = new StorageService();
            productService = new ProductService();
            categoryService = new CategoryService();
        }
        public void StoreProduct(Product product) {
            StorageBusiness storage = new StorageBusiness();
            storage.ArrivalDate = product.ArrivalDate;
            storage.Product.Name = product.Name;
            storage.Product.Category.Name = product.Category;
            storage.Amount += 1;
            storageService.Add(storage);
        }
		public void StoreProducts(List<Product> products) {
			throw new System.Exception("Not implemented");
		}
		public Product RetreiveProduct(string name) {
            StorageBusiness storage;
            if (storageService.GetByName(name)[0] != null)
            {
                storage = storageService.GetByName(name)[0];
                storage.Amount -= 1;
                if (storage.Amount == 0)
                {
                    storageService.Delete(storage.Id);
                }
                else
                {
                    storageService.Update(storage);
                }
            }
            return null;
        }
		public List<Product> RetreiveProducts(string name, int amount) {
            List<StorageBusiness> storageList;
            if (storageService.GetByName(name) != null)
            {
                storageList = storageService.GetByName(name);
                for (int i = 0; i < storageList.Count; i++)
                {
                    if (storageList[i].Amount > amount)
                    {
                        storageList[i].Amount -= amount;
                        storageService.Update(storageList[i]);
                    }
                    else if(storageList[i].Amount == amount)
                    {
                        storageService.Delete(storageList[i].Id);
                    }
                    else
                    {
                        i++;
                    }
                }
            }
            return null;
        }

	}

}
