using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using eUcionica.DBContext;
using eUcionica.EntityLib;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace eUcionica.Pages.Studenti

{
    public class AddTaskModel : PageModel
    {
        private readonly SchoolContext _context;

        public AddTaskModel(SchoolContext context)
        {
            _context = context;
        }

        public IList<Predmet> Predmeti { get; set; }
        public IList<Oblast> Oblasti { get; set; }

        [BindProperty]
        public int? SelectedPredmetId { get; set; }

        [BindProperty]
        public int? SelectedOblastId { get; set; }

        [BindProperty]
        public int? NivoTezine { get; set; }

        [BindProperty]
        public string SadrzajZadatka { get; set; }

        public async Task OnGetAsync()
        {
            Predmeti = await _context.Predmet.ToListAsync();
            Oblasti = await _context.Oblast.ToListAsync();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var zadatak = new Zadatak
            {
                OblastId = SelectedOblastId.GetValueOrDefault(),
                SadrzajZadatka = SadrzajZadatka,
                NivoTezine = NivoTezine.GetValueOrDefault()
            };

            _context.Zadatak.Add(zadatak);
            await _context.SaveChangesAsync();

            return RedirectToPage(); 
        }
    }
}
