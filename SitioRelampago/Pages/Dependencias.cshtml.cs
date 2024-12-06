using DataAccess;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace SitioRelampago.Pages
{
    public class DependenciasModel : PageModel
    {
        private readonly Conexion _conexion;
        public List<Dependencia> Dependencias { get; set; }

        [BindProperty]
        public int IdDependencia { get; set; }

        [BindProperty]
        public string NombreDependencia { get; set; }

        [BindProperty]
        public int IdDependenciaB { get; set; }

        [BindProperty]
        public string NombreDependenciaB { get; set; }

        public DependenciasModel(Conexion conexion)
        {
            _conexion = conexion;
        }

        public void OnGet()
        {
            Dependencias = _conexion.ObtenerDependencias();
        }

        public IActionResult OnPost()
        {
            try
            {
                _conexion.AddDependencia(new Dependencia
                {
                    IdDependencia = IdDependencia,
                    NombreDependencia = NombreDependencia
                });
                TempData["SuccessMessage"] = "Dependencia agregada correctamente.";
                return RedirectToPage("/Dependencias");
            }
            catch
            {
                TempData["ErrorMessage"] = "Error al agregar la dependencia.";
                return Page();
            }
        }

        public IActionResult OnPostEdit()
        {
            try
            {
                _conexion.UpdateDependencia(new Dependencia
                {
                    IdDependencia = IdDependencia,
                    NombreDependencia = NombreDependencia
                });
                TempData["SuccessMessage"] = "Dependencia actualizada correctamente.";
                return RedirectToPage("/Dependencias");
            }
            catch
            {
                TempData["ErrorMessage"] = "Error al editar la dependencia.";
                return Page();
            }
        }

        public IActionResult OnPostDelete()
        {
            try
            {
                _conexion.DeleteDependencia(IdDependenciaB);
                TempData["SuccessMessage"] = "Dependencia eliminada correctamente.";
                return RedirectToPage("/Dependencias");
            }
            catch
            {
                TempData["ErrorMessage"] = "Error al eliminar la dependencia.";
                return Page();
            }
        }
    }
}
