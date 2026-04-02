using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/contacto")]
public class ContactosController : ControllerBase
{
    public readonly ContactoService _contactoService;

    public ContactosController(ContactoService contactoService)
    {
        _contactoService = contactoService;
    }

    [HttpGet("{id}")]
    public ActionResult<Contacto> ObtenerPorId(int id)
    {
        var contacto = _contactoService.ObtenerPorId(id);
        return contacto == null ? NotFound() : Ok(contacto);
    }

    [HttpPost("add")]
    public ActionResult<Contacto> Crear(Contacto contacto)
    {

        // Validamos que el modelo sea válido, o retornamos Bad Request y el detalle
        if(!ModelState.IsValid)
            return BadRequest(ModelState);

        var creado = _contactoService.Crear(contacto);
        return CreatedAtAction(nameof(ObtenerPorId), new { id = creado.Id }, creado);
    }

    [HttpPut("edit/{id}")]
    public ActionResult<Contacto> Crear(int id, Contacto contacto )
    {
        // Validamos que los datos coincidan
        if(id != contacto.Id)
        {
            return BadRequest();
        }

        // Validamos que el modelo sea válido, o retornamos Bad Request y el detalle        
        if(!ModelState.IsValid)
            return BadRequest(ModelState);
        
        bool result = _contactoService.Editar(id, contacto);

        if (!result) return NotFound();
        return Ok(contacto);

    }


    
}