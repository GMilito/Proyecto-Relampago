using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using DataAccess;

namespace SitioRelampago.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly Conexion _conexion;
        public List<Area> Areas { get; set; }

        public IndexModel(ILogger<IndexModel> logger, Conexion conexion)
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
