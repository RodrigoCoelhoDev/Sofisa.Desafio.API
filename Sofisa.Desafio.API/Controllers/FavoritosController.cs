using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sofisa.Desafio.API.Models;

namespace Sofisa.Desafio.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class FavoritosController : ControllerBase
    {
        private readonly RepositorioContext _context;

        public FavoritosController(RepositorioContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Obter Lista De Favoritos
        /// </summary>        
        /// <returns>Retorna uma Lista com os Favoritos</returns>  
        [HttpGet]
        [Route("ObterListaDeFavoritos")]
        public async Task<ActionResult<List<Repositorio>>> ObterListaDeFavoritos()
        {
            return await _context.Repositorios.ToListAsync();
        }

        /// <summary>
        /// Obter Lista De Favoritos por ID
        /// </summary>        
        [HttpGet("ObterListaDeFavoritosPorID/{id}")]
        public async Task<ActionResult<Repositorio>> ObterListaDeFavoritosPorID(int id)
        {
            var favorito = await _context.Repositorios.FindAsync(id);

            if (favorito == null)
            {
                return NotFound();
            }

            return favorito;
        }

        /// <summary>
        /// Inserir um novo Favorito.
        /// </summary> 
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPost]
        [Route("Inserir")]
        public async Task<ActionResult<Repositorio>> PostFavorito(Repositorio favorito)
        {
            if (favorito.id != 0)
            {
                _context.Repositorios.Add(favorito);
                await _context.SaveChangesAsync();
            }

            return CreatedAtAction("PostFavorito", new { id = favorito.id }, favorito);
        }

        /// <summary>
        /// Excluir Favorito.
        /// </summary> 
        [HttpDelete("Excluir/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Repositorio>> DeleteFavorito(int id)
        {
            var favorito = await _context.Repositorios.FindAsync(id);
            if (favorito == null)
            {
                return NotFound();
            }

            _context.Repositorios.Remove(favorito);
            await _context.SaveChangesAsync();

            return favorito;
        }
    }
}
