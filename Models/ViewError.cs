using System.Text.Json.Nodes;

namespace crud.Models
{
    public class ViewResultado
    {
        public string mensaje { get; set; } = null!;
        public bool error { get; set; } = false!;
        public object resultado { get; set; } = null!;
    }
}
