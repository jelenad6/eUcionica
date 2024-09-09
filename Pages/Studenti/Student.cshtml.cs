using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using eUcionica.DBContext;
using eUcionica.EntityLib;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;


namespace eUcionica.Pages.Studenti
{
    public class StudentModel : PageModel
    {
        private readonly SchoolContext _context;

        public StudentModel(SchoolContext context)
        {
            _context = context;
        }

        public IList<Predmet> Predmeti { get; set; }
        public IList<Oblast> Oblasti { get; set; }
        public IList<Zadatak> GenerisaniZadaci { get; set; }

        [BindProperty]
        public int? SelectedPredmetId { get; set; }

        [BindProperty]
        public int? SelectedOblastId { get; set; }

        [BindProperty]
        public int? SelectedNivoTezine { get; set; }

        public async Task OnGetAsync()
        {
            
            Predmeti = await _context.Predmet.ToListAsync();
            Oblasti = await _context.Oblast.ToListAsync();

            
            if (Request.Query.TryGetValue("SelectedPredmetId", out var predmetId))
            {
                if (int.TryParse(predmetId, out int id))
                {
                    SelectedPredmetId = id;
                }
            }

            if (Request.Query.TryGetValue("SelectedOblastId", out var oblastId))
            {
                if (int.TryParse(oblastId, out int id))
                {
                    SelectedOblastId = id;
                }
            }

            if (Request.Query.TryGetValue("SelectedNivoTezine", out var nivoTezine))
            {
                if (int.TryParse(nivoTezine, out int nivo))
                {
                    SelectedNivoTezine = nivo;
                }
            }

           
            if (SelectedPredmetId.HasValue && SelectedOblastId.HasValue && SelectedNivoTezine.HasValue)
            {
                GenerisaniZadaci = await _context.Zadatak
                    .Where(z => z.OblastId == SelectedOblastId && z.NivoTezine == SelectedNivoTezine)
                    .ToListAsync();
            }
        }

    }
}