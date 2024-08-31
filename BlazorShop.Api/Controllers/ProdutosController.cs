using BlazorShop.Api.Entities;
using BlazorShop.Api.Mappings;
using BlazorShop.Api.Repositories;
using BlazorShop.Models.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlazorShop.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProdutosController : ControllerBase
{
    private readonly IProdutoRepository _produtoRepository;

    public ProdutosController(IProdutoRepository produtoRepository)
    {
        _produtoRepository = produtoRepository;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<ProdutoDto>>> GetItems()
    {
        try
        {
            var produtos = await _produtoRepository.GetItens();
            if (produtos is null)
            {
                return NotFound();
            }
            else
            {
                var produtoDtos = produtos.ConverterProdutosParaDto();
                return Ok(produtoDtos);
            }
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError,
                "Erro ao acessar a base de dados");
        }
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<ProdutoDto>> GetItem(int id)
    {
        try
        {
            var produto = await _produtoRepository.GetItem(id);
            if (produto is null)
            {
                return NotFound("Produto não localizado");
            }
            else
            {
                var produtoDto = produto.ConverterProdutoParaDto();
                return Ok(produtoDto);
            }
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError,
                              "Erro ao acessar o banco de dados");
        }
    }

    [HttpGet]
    [Route("{categoriaId}/GetItensPorCategoria")]
    public async Task<ActionResult<IEnumerable<ProdutoDto>>> GetItensPorCategoria(int categoriaId)
    {
        try
        {
            var produtos = await _produtoRepository.GetItensPorCategoria(categoriaId);
            var produtosDto = produtos.ConverterProdutosParaDto();
            return Ok(produtosDto);
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError,
                            "Erro ao acessar o banco de dados");
        }
    }

    [HttpGet]
    [Route("GetCategorias")]
    public async Task<ActionResult<IEnumerable<CategoriaDto>>> GetCategorias()
    {
        try
        {
            var categorias = await _produtoRepository.GetCategorias();
            var categoriasDto = categorias.ConverterCategoriasParaDto();
            return Ok(categoriasDto);
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError,
                                       "Erro ao acessar o banco de dados");
        }
    }

    [HttpPut("{id:int}")]
    public async Task<ActionResult<ProdutoDto>> UpdateItem(int id, [FromBody] ProdutoDto produtoDto)
    {
        try
        {
            // Verifica se o ID do produto no DTO coincide com o ID na URL
            if (id != produtoDto.Id)
            {
                return BadRequest("ID do produto na URL não coincide com o ID no corpo da requisição");
            }

            // Verifica se o produto existe no repositório
            var produtoExistente = await _produtoRepository.GetItem(id);

            if (produtoExistente == null)
            {
                return NotFound("Produto não encontrado");
            }

            // Atualiza as propriedades do produto existente com as informações do DTO
            produtoExistente.Nome = produtoDto.Nome;
            produtoExistente.Descricao = produtoDto.Descricao;
            produtoExistente.ImagemUrl = produtoDto.ImagemUrl;
            produtoExistente.Preco = produtoDto.Preco;
            produtoExistente.Quantidade = produtoDto.Quantidade;
            produtoExistente.CategoriaId = produtoDto.CategoriaId;

            // Atualiza o produto no repositório
            var produtoAtualizado = await _produtoRepository.UpdateItem(produtoExistente);

            // Converte o produto atualizado para DTO
            var produtoAtualizadoDto = produtoAtualizado.ConverterProdutoParaDto();

            return Ok(produtoAtualizadoDto);
        }
        catch (Exception ex)
        {
            // Log a exception or use a more specific error message
            return StatusCode(StatusCodes.Status500InternalServerError,
                              "Erro ao atualizar o produto: " + ex.Message);
        }
    }


    // Novo método para excluir um produto
    [HttpDelete("{id:int}")]
    public async Task<ActionResult> DeleteItem(int id)
    {
        try
        {
            var produto = await _produtoRepository.GetItem(id);
            if (produto is null)
            {
                return NotFound("Produto não encontrado");
            }

            await _produtoRepository.DeleteItem(id);

            return Ok($"Produto com ID {id} foi excluído com sucesso.");
        }
        catch (Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError,
                              "Erro ao excluir o produto");
        }

    }

    [HttpPost]
    public async Task<ActionResult<ProdutoDto>> PostItem(ProdutoDto produtoDto)
    {
        try
        {
            // Verifica se o DTO é válido
            if (produtoDto == null)
            {
                return BadRequest("Produto não pode ser nulo");
            }

            // Converte o DTO para uma entidade Produto
            var produto = new Produto
            {
                Nome = produtoDto.Nome,
                Descricao = produtoDto.Descricao,
                ImagemUrl = produtoDto.ImagemUrl,
                Preco = produtoDto.Preco,
                Quantidade = produtoDto.Quantidade,
                CategoriaId = produtoDto.CategoriaId
            };

            // Adiciona o produto ao repositório
            var produtoCriado = await _produtoRepository.AddItem(produto);

            // Converte o produto criado para DTO
            var produtoCriadoDto = produtoCriado.ConverterProdutoParaDto();

            return CreatedAtAction(nameof(GetItem), new { id = produtoCriadoDto.Id }, produtoCriadoDto);
        }
        catch (Exception ex)
        {
            // Log a exception or use a more specific error message
            return StatusCode(StatusCodes.Status500InternalServerError,
                              "Erro ao criar o produto: " + ex.Message);
        }
    }



}
