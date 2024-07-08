using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SagatFarm.Models;
using SagatFarm.Data;
using Microsoft.EntityFrameworkCore;

namespace SagatFarm.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ToDoController : ControllerBase
    {
        private readonly ApiContext _contextApi;
        public ToDoController(ApiContext contextApi)
        {
            _contextApi = contextApi;
        }

        // Crear task
        [HttpPost]
        public JsonResult CrearTarea(ToDo todo)
        {
            _contextApi.ToDos.Add(todo);
            _contextApi.SaveChanges();
            return new JsonResult(Ok(todo));

        }

        // obtener task especifica
        [HttpGet]
        public JsonResult ObtenerTarea(int id)
        {
            var result = _contextApi.ToDos.Find(id);

            if (result == null)
                return new JsonResult("Task no encontrada");

            return new JsonResult(Ok(result));
        }

        // obtener todas las tareas
        [HttpGet("/Obtener todas las tareas")]
        public JsonResult ObtenerTareas()
        {
            var result = _contextApi.ToDos.ToList();
            if (result != null)
                return new JsonResult(Ok(result));
            else
                return new JsonResult(BadRequest("Task no encontrada"));

        }

        // Borrar task
        [HttpDelete]
        public IActionResult Borrar(int id)
        {
            var result = _contextApi.ToDos.Find(id);
            if (result == null) 
                return BadRequest("Task no encontrada");

            _contextApi.ToDos.Remove(result);
            _contextApi.SaveChanges();

            return Ok("Task eliminada!");
        }

        // Task completada
        [HttpPut]
        public IActionResult MarcarTareaCompletada(int id)
        {
            var result = _contextApi.ToDos.Find(id);
            if (result == null)
                return BadRequest("Task no encontrada");

            result.MarcarTareaCompletada();
            _contextApi.ToDos.Update(result);
            _contextApi.SaveChanges();
            return Ok("Tarea completada!");
        }

        // Actualizar task
        [HttpPut]
        public JsonResult Update(int id, ToDo todo)
        {
            var ToDoInDB = _contextApi.ToDos.Find(id);
            if (ToDoInDB == null)
                return new JsonResult(BadRequest("Task no encontrada"));

            ToDoInDB.Nombre = todo.Nombre;
            ToDoInDB.Descripcion = todo.Descripcion;

            _contextApi.ToDos.Update(ToDoInDB);
            _contextApi.SaveChanges();

            return new JsonResult(Ok(todo));
        }

        // Agregar un comentario a task
        [HttpPost]
        public JsonResult AddComment(int id, string comentario)
        {
            var todo = _contextApi.ToDos.Find(id);
            if (todo == null)
                return new JsonResult(BadRequest("Task no encontrada"));

            todo.Comentar(comentario);
            _contextApi.ToDos.Update(todo);

            _contextApi.SaveChanges();

            return new JsonResult(Ok("Comentario agregado!"));
        }

        // Responder un comentario a task
        [HttpPost]
        public JsonResult RespondToComment(int id, string respuesta)
        {
            var todo = _contextApi.ToDos.Find(id);
            if (todo == null)
                return new JsonResult(BadRequest("Task no encontrada"));

            todo.Responder(respuesta);
            _contextApi.ToDos.Update(todo);
            _contextApi.SaveChanges();

            return new JsonResult(Ok("Respuesta agregada!"));
        }

        // Obtener los comentarios de una tarea por su id
        [HttpGet]
        public JsonResult VerComentarios(int id)
        {
            var todo = _contextApi.ToDos.Find(id);
            if (todo == null)
                return new JsonResult(BadRequest("Task no encontrada"));

            return new JsonResult(Ok(new { Comentario = todo.Comentario, Response = todo.Respuesta }));
        }

        // Modificar comentario
        [HttpPut]
        public JsonResult ModificarComentario(int id, string comentario)
        {
            var todo = _contextApi.ToDos.Find(id);
            if (todo == null)
                return new JsonResult(BadRequest("Task no encontrada"));

            todo.Comentar(comentario);
            _contextApi.ToDos.Update(todo);
            _contextApi.SaveChanges();

            return new JsonResult(Ok("Comentario modificado!"));
        }

        // Eliminar comentario
        [HttpDelete]
        public JsonResult BorrarComentario(int id)
        {
            var todo = _contextApi.ToDos.Find(id);
            if (todo == null)
                return new JsonResult(BadRequest("Task no encontrada"));

            todo.Comentar(String.Empty);
            _contextApi.ToDos.Update(todo);
            _contextApi.SaveChanges();

            return new JsonResult(Ok("Comentario eliminado!"));
        }

    }
}
