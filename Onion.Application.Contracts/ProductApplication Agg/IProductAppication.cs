

namespace Onion.Application.Contracts.ProductApplication_Agg
{
    public interface IProductAppication
    {
        EditProductCommand GetBy(int id);
        List<ProductViewModel> GetAll();
        bool Activate(int id, out string Error);
        bool DeActivate(int id, out string Error);
        bool Edit(EditProductCommand Command, out string Error);
        bool Create(CreateProductCommand Command, out string Error);


    }
}
