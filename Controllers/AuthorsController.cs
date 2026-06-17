using APBD_cw8_s29640.Services;
using Microsoft.AspNetCore.Mvc;

namespace APBD_cw8_s29640.Controllers
{
    public class AuthorsController : Controller
    {
        private readonly IAuthorService _authorService;

        public AuthorsController(IAuthorService authorService)
        {
            _authorService = authorService;
        }

        public async Task<IActionResult> Index()
        {
            var authors = await _authorService.GetAllAuthorsAsync();
            return View(authors);
        }
    }
}