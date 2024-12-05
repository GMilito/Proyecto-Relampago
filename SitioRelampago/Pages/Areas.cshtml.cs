using DataAccess;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace SitioRelampago.Pages
{
    public class AreasModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly Conexion _conexion;
        public List<Area> Areas { get; set; }

        public AreasModel(ILogger<IndexModel> logger, Conexion conexion)
        {
            _logger = logger;
            _conexion = conexion;
        }

        public void OnGet()
        {
            Areas = _conexion.ObtenerAreas();

        }
    }
}
