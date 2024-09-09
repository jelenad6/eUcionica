using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Http;
using eUcionica.EntityLib;
using eUcionica.DBContext;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace eUcionica.Pages.Studenti
{
    public class AddTestModel : PageModel
    {
        private readonly SchoolContext _context;

        public AddTestModel(SchoolContext context)
        {
            _context = context;
        }

        [BindProperty]
        public int SelectedPredmetId { get; set; }
        [BindProperty]
        public int SelectedOblastId { get; set; }
        [BindProperty]
        public int NivoTezine { get; set; }
        [BindProperty]
        public IFormFile UploadedFile { get; set; }

        public IList<Predmet> Predmeti { get; set; }
        public IList<Oblast> Oblasti { get; set; }

        public async Task OnGetAsync()
        {
            Predmeti = await _context.Predmet.ToListAsync();
            Oblasti = await _context.Oblast.ToListAsync();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (UploadedFile != null && UploadedFile.Length > 0)
            {
                using (var reader = new StreamReader(UploadedFile.OpenReadStream()))
                {
                    var lines = await reader.ReadToEndAsync();
                    var questions = lines.Split('\n');

                    foreach (var question in questions)
                    {
                        if (!string.IsNullOrWhiteSpace(question))
                        {
                            var zadatak = new Zadatak
                            {
                                OblastId = SelectedOblastId,
                                NivoTezine = NivoTezine,
                                SadrzajZadatka = question.Trim()
                            };
                            _context.Zadatak.Add(zadatak);
                        }
                    }

                    await _context.SaveChangesAsync();
                }
            }

            return RedirectToPage("/Studenti/Student");
        }
    }
}
