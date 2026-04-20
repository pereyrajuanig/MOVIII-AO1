using MoviiiAo1.Api.Models;

namespace MoviiiAo1.Api.Services;

public sealed class ContactoService
{
    private readonly List<Contacto> _contactos = new()
    {
        new Contacto { Id = 1, Nombre = "Ana", Apellido = "Pérez", Telefono = "1111-1111", Email = "ana.perez@example.com" },
        new Contacto { Id = 2, Nombre = "Bruno", Apellido = "Gómez", Telefono = "2222-2222", Email = "bruno.gomez@example.com" },
    };

    private int _nextId = 3;

    public List<Contacto> ObtenerTodos() => _contactos.ToList();

    public Contacto? ObtenerPorId(int id) => _contactos.FirstOrDefault(c => c.Id == id);

    public Contacto Crear(Contacto contacto)
    {
        contacto.Id = _nextId++;
        _contactos.Add(contacto);
        return contacto;
    }

    public bool Editar(int id, Contacto contacto)
    {
        var existente = ObtenerPorId(id);
        if (existente is null) return false;

        existente.Nombre = contacto.Nombre;
        existente.Apellido = contacto.Apellido;
        existente.Telefono = contacto.Telefono;
        existente.Email = contacto.Email;
        return true;
    }

    public bool Eliminar(int id)
    {
        var existente = ObtenerPorId(id);
        if (existente is null) return false;
        _contactos.Remove(existente);
        return true;
    }
}

