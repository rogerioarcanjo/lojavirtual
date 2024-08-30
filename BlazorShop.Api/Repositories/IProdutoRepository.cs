using BlazorShop.Api.Entities;

namespace BlazorShop.Api.Repositories;

public interface IProdutoRepository
{
    Task<IEnumerable<Produto>> GetItens();
    Task<Produto> GetItem(int id);

    Task<IEnumerable<Produto>> GetItensPorCategoria(int id);
    Task<IEnumerable<Categoria>> GetCategorias();

    Task<Produto> UpdateItem(Produto produto);

    Task DeleteItem(int id);

   Task<Produto> AddItem(Produto produto); // Adicionado método para criar um novo produto


}
