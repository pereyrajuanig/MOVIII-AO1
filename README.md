# MoviiiAo1.Api – Actividad obligatoria 1

## Video de demostración

<video src="./AO1-MOVIII-DEMO.mp4" controls width="100%">Tu navegador no reproduce el video embebido.</video>

[También puedes abrir o descargar el archivo en GitHub](./AO1-MOVIII-DEMO.mp4).

Hola, este es mi proyecto para **Programación de aplicaciones móviles III**. Es una Web API en **.NET** para gestionar contactos en memoria, con **Swagger**, un endpoint **minimal** y autenticación con **JWT**.

## Qué tiene

- CRUD de contactos por **controlador** (`api/contacto/...`) con respuestas tipo `Ok`, `NotFound`, `CreatedAtAction`, `NoContent`.
- Un **minimal API** que lista todos los contactos: `GET /minimal/contactos`.
- **Login** con usuario y contraseña en JSON y devuelve un token JWT.
- Los endpoints del controlador están protegidos con **JWT** y rol **ADMIN**.

## Requisitos

- Tener instalado el **SDK de .NET** (yo lo hice con .NET 10).

## Cómo lo corro

En una terminal, desde esta carpeta:

```bash
dotnet run
```

Después abro el navegador en la URL que me muestra la consola (en mi máquina suele ser algo como `http://localhost:5278/swagger`) y entro a **Swagger**.

## Credenciales de prueba

Para el login uso las que pide la consigna:

- **Usuario:** `admin`
- **Contraseña:** `1234`

## Swagger y el token

1. Ejecuto **POST** `/api/auth/login` con el JSON de usuario y contraseña.
2. Copio el **token** que me devuelve.
3. Arriba en Swagger aprieto **Authorize** y en el campo pongo el token en el formato que indica la descripción (tipo **Bearer** + espacio + el token).
4. Ahí ya puedo probar los **GET/POST/PUT** de `api/contacto`.

Los contactos de ejemplo tienen **id 1 y 2** para probar el GET por id.

## Sobre el servicio en memoria

Los contactos se guardan en una **lista en memoria**, así que si cierro la app se pierden los datos. El `ContactoService` lo registré como **Singleton** para que el minimal y el controlador usen la misma lista.

---

*Cualquier cosa me pueden escribir. Saludos.*
