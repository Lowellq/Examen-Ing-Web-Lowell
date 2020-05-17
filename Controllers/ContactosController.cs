//git commit -m "paso 1:hacerte wei"
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Examen_Ing_Web_Lowell.Models;


namespace Examen_Ing_Web_Lowell.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactosController : ControllerBase
    {
        ContactosRepositorio repositorio;
        public ContactosController()
        {
            repositorio = new ContactosRepositorio();
        }

        // GET: api/Contacto
        [HttpGet]
        public ActionResult<List<Contacto>> Get()
        {
            var todos = repositorio.LeerTodos();
            return todos;
        }

        // GET: api/Contacto/5
        [HttpGet("{id}", Name = "Get")]
        public ActionResult<Contacto> Get(int id)
        {
            var Conctacto = repositorio.LeerPorId(id);
            if (Conctacto == null)
            {
                return NotFound();
            }
            return Conctacto;

        }

        // POST: api/Contacto
        [HttpPost]
        public IActionResult Post([FromBody] Contacto model)
        {
            repositorio.Crear(model);

            return Ok();

        }

        // PUT: api/Contacto/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Contacto model)
        {
            var Contacto = repositorio.LeerPorId(model.id);
            if (Contacto == null)
            {
                return NotFound();
            }

            repositorio.Actualizar(model);
            return Ok();
        }


        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var Conctacto = repositorio.LeerPorId(id);
            if (Conctacto == null)
            {
                return NotFound();
            }
            repositorio.Borrar(id);
            return Ok();
        }

    }
}