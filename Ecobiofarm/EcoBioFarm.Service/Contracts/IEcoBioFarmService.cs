using EcoBioFarm.Service.Models;
using System.Collections.Generic;

namespace EcoBioFarm.Service.Contracts
{
    public interface IEcoBioFarmService
    {
        void CreateProduct(ProductViewModel model);

        void EditProduct(ProductViewModel model);

        IEnumerable<ProductViewModel> GetProducts();

        ProductViewModel GetProduct(long id);

        void DeleteProduct(long id);

    }
}
