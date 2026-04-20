using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MoviiiAo1.Api.Models;
using MoviiiAo1.Api.Services;

namespace MoviiiAo1.Api.Controllers;

[ApiController]
[Route("api/contacto")]
[Authorize(Roles = Roles.ADMIN)]
public sealed class ContactosController(ContactoService contactoService) : ControllerBase
{
    [HttpGet("{id:int}")]
    public ActionResult<Contacto> GetById(int id) =>
        contactoService.ObtenerPorId(id) is Contacto c ? Ok(c) : NotFound();

    [HttpPost("add")]
    public ActionResult<Contacto> Add([FromBody] Contacto contacto)
    {
        var creado = contactoService.Crear(contacto);
        return CreatedAtAction(nameof(GetById), new { id = creado.Id }, creado);
    }

    [HttpPut("edit/{id:int}")]
    public ActionResult Edit(int id, [FromBody] Contacto contacto) =>
        contactoService.Editar(id, contacto) ? NoContent() : NotFound();
}
