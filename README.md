
# Proyecto ToDo API
## Docs
[Documentacion en swagger](https://localhost:7233/swagger/index.html)

## Descripción

El proyecto ToDo API es una aplicación basada en ASP.NET Core diseñada para gestionar una lista de tareas (ToDo). Proporciona endpoints para crear, obtener, actualizar, eliminar tareas y gestionar comentarios en las mismas.

## Requisitos Previos

- .NET Core SDK 3.1 o superior
- Visual Studio 2019 o superior
- SQL Server (o cualquier base de datos compatible con Entity Framework Core)

## Configuración del Proyecto

### Clonar el Repositorio

Clona el repositorio desde GitHub:

```bash
git clone https://github.com/juanProano44/SagatFarmProject
cd ToDoApi
```

### Migraciones de Entity Framework

Aplica las migraciones para crear la base de datos y las tablas necesarias:

```bash
dotnet ef migrations add InitialCreate
dotnet ef database update
```

## Ejecución del Proyecto

Para ejecutar el proyecto, usa el siguiente comando:

```bash
dotnet run
```

Esto iniciará el servidor en `https://localhost:5001` por defecto.

## Endpoints Disponibles

### Crear una Tarea

```http
POST /api/ToDo/CrearTarea
```

**Cuerpo de la solicitud:**

```json
{
  "Nombre": "Nombre de la tarea",
  "Descripcion": "Descripción de la tarea"
}
```

### Obtener una Tarea por ID

```http
GET /api/ToDo/ObtenerTarea/{id}
```

### Obtener Todas las Tareas

```http
GET /api/Obtener todas las tareas
```

### Eliminar una Tarea

```http
DELETE /api/ToDo/Borrar/{id}
```

### Marcar una Tarea como Completada

```http
PUT /api/ToDo/MarcarTareaCompletada/{id}
```

### Actualizar una Tarea

```http
PUT /api/ToDo/Update/{id}
```

**Cuerpo de la solicitud:**

```json
{
  "ID": 1,
  "Nombre": "Nombre de la tarea actualizado",
  "Descripcion": "Descripción de la tarea actualizada"
}
```

### Agregar un Comentario a una Tarea

```http
POST /api/ToDo/AddComment/{id}
```

**Cuerpo de la solicitud:**

```json
{
  "comentario": "Este es un comentario"
}
```

### Responder a un Comentario

```http
POST /api/ToDo/RespondToComment/{id}
```

**Cuerpo de la solicitud:**

```json
{
  "respuesta": "Esta es una respuesta al comentario"
}
```

### Ver Comentarios de una Tarea

```http
GET /api/ToDo/VerComentarios/{id}
```

### Modificar Comentario

```http
PUT /api/ToDo/ModificarComentario/{id}
```

**Cuerpo de la solicitud:**

```json
{
  "comentario": "Este es un comentario modificado"
}
```

### Eliminar Comentario

```http
DELETE /api/ToDo/BorrarComentario/{id}
```

## Contribución

Si deseas contribuir a este proyecto, por favor sigue estos pasos:

1. Haz un fork del repositorio.
2. Crea una rama para tu característica (`git checkout -b feature/nueva-caracteristica`).
3. Realiza tus cambios y haz commit (`git commit -am 'Añadir nueva característica'`).
4. Empuja tu rama (`git push origin feature/nueva-caracteristica`).
5. Abre un Pull Request.

## Licencia

Este proyecto está licenciado bajo la Licencia MIT. Consulta el archivo `LICENSE` para obtener más detalles.
