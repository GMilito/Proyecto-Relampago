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


        [BindProperty]
        public int IdArea { get; set; }

        [BindProperty]
        public string NombreArea { get; set; }
        [BindProperty]
        public int IdAreaB { get; set; }

        [BindProperty]
        public string NombreAreaB { get; set; }



        public AreasModel(ILogger<IndexModel> logger, Conexion conexion)
        {
            _logger = logger;
            _conexion = conexion;
        }


        public void OnGet()
        {
            //Obtiene todas las areas para mostrar en la tabla
            Areas = _conexion.ObtenerAreas();

        }

        //Metodo Post para agregar Areas
        public IActionResult OnPost()
        {
            
            // Crear el objeto Area y usar la conexi�n para agregarlo
            var nuevaArea = new Area
            {
                IdArea = IdArea,
                NombreArea = NombreArea
            };

            try
            {
                _conexion.AddArea(nuevaArea);
                TempData["SuccessMessage"] = "�rea agregada correctamente.";
                return RedirectToPage("/Areas");
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = $"Error al agregar el �rea: {ex.Message}";
                return Page();
            }

        }


        //Metodo Post para Editar Areas
        public IActionResult OnPostEdit()
        {
            

            // Crear el objeto Area con los datos actualizados
            var areaActualizada = new Area
            {
                IdArea = IdArea,
                NombreArea = NombreArea
            };

            try
            {
                _conexion.UpdateArea(areaActualizada);
                TempData["SuccessMessage"] = "�rea actualizada correctamente.";
                return RedirectToPage("/Areas");
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = $"Error al actualizar el �rea: {ex.Message}";
                return Page();
            }
        }


        //Metodo Post para Eliminar Areas
        public IActionResult OnPostDelete()
        {
            if (IdAreaB <= 0)
            {
                TempData["ErrorMessage"] = "ID de �rea inv�lido.";
                return Page();
            }

            try
            {
                _conexion.DeleteArea(IdAreaB);
                TempData["SuccessMessage"] = "�rea eliminada correctamente.";
                return RedirectToPage("/Areas");
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = $"Error al eliminar el �rea: {ex.Message}";
                return Page();
            }
        }


    }
}