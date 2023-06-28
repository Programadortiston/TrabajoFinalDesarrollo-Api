using Microsoft.AspNetCore.Mvc;
using WebApiLibreria.Models;
using WebApiLibreria.Services;

namespace WebApiLibreria.Controllers
{
    [Route("Api/[Controller]")]
    [ApiController]
    public class LibroController : Controller
    {
        private readonly ILibro _libro;
        public LibroController(ILibro libro)
        {
            _libro = libro;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return Ok(_libro.GetAllLibro());
        }
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var obj = _libro.GetLibro(id);
            if (obj == null)
            {
                return NotFound("El libro(" + id.ToString() + ") no existe");
            }
            else
            {
                return Ok(obj);
            }
        }
        [HttpPost("agregar")]
        public IActionResult add(TbLibro libro)
        {
            _libro.add(libro);
            return CreatedAtAction(nameof(add), libro);
        }
        [HttpDelete("eliminar/{id}")]
        public IActionResult delete(int id)
        {
            _libro.delete(id);
            return NoContent();
        }
        [HttpPut("modificar")]
        public IActionResult modificar(TbLibro libro)
        {
            _libro.editDetails(libro);
            return CreatedAtAction(nameof(modificar), libro);
        }
    }
}
