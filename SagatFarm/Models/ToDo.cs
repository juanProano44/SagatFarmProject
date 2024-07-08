using Microsoft.EntityFrameworkCore;    

namespace SagatFarm.Models
{
    public class ToDo
    {
        public int ID { get; private set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public bool estaCompletada { get; private set; }
        public void MarcarTareaCompletada()
        {
            estaCompletada = true;
        }
        public String Comentario { get; private set; } = String.Empty;
        public String Respuesta { get; private set; } = String.Empty;

        public void Comentar(string comment)
        {
            Comentario = comment;
        }

        public void Responder(string response)
        {
            Respuesta = response;
        }
    }
}
