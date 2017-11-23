using EcoBioFarm.Data.Contracts;
using EcoBioFarm.Data.Models;
using EcoBioFarm.Service.Contracts;
using EcoBioFarm.Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EcoBioFarm.Service
{
    public class EcoBioFarmService : IEcoBioFarmService
    {
        private readonly IRDBERepository<Product> productRepo;

        public EcoBioFarmService(IRDBERepository<Product> productRepo)
        {
            this.productRepo = productRepo ?? throw new ArgumentNullException("productRepo");
        }

        public void CreateProduct(ProductViewModel model)
        {
            var product = new Product()
            {
                Cuts = model.Cuts,
                Discount = model.Discount,
                Description = model.Description,
                Id = model.Id,
                Name = model.Name
            };

            this.productRepo.Add(product);
            this.productRepo.SaveChanges();
        }

        public void EditProduct(ProductViewModel model)
        {
            var item = this.productRepo.GetById(model.Id);

            item.Cuts = model.Cuts;
            item.Description = model.Description;
            item.Name = model.Name;
            item.Discount = model.Discount;

            this.productRepo.SaveChanges();
        }

        public IEnumerable<ProductViewModel> GetProducts()
        {
            return this.productRepo.AllReadOnly()
                .Select(t => new ProductViewModel()
                {
                    Id = t.Id,
                    Name = t.Name,
                    Description = t.Description,
                    Discount = t.Discount,
                    Cuts = t.Cuts
                });
        }

        public ProductViewModel GetProduct(long id)
        {
            var item = this.productRepo.GetById(id);

            return new ProductViewModel()
            {
                Id = item.Id,
                Name = item.Name,
                Description = item.Description,
                Cuts = item.Cuts,
                Discount = item.Discount
            };
        }

        public void DeleteProduct(long id)
        {
            this.productRepo.Delete(id);

            this.productRepo.SaveChanges();
        }
    }
}
