using APBD_cw8_s29640.ViewModels;
using APBD_cw8_s29640.Models;
using APBD_cw8_s29640.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using APBD_cw8_s29640.Mappers;

namespace APBD_cw8_s29640.Controllers
{

    public class BooksController : Controller
    {
        private readonly IBookService _bookService;
        private readonly IAuthorService _authorService;

        public BooksController(IBookService bookService, IAuthorService authorService)
        {
            _bookService = bookService;
            _authorService = authorService;
        }

        public async Task<IActionResult> Index()
        {
            var books = await _bookService.GetAllBooksAsync();
            return View(books);
        }

        public async Task<IActionResult> Details(int id)
        {
            var book = await _bookService.GetBookDetailsAsync(id);

            if (book is null)
                return NotFound();

            return View(book);
        }

        public async Task<IActionResult> Create()
        {
            await LoadAuthorsAsync();
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateBookViewModel book)
        {
            if (!ModelState.IsValid)
            {
                await LoadAuthorsAsync();
                return View(book);
            }

            try
            {
                await _bookService.CreateBookAsync(BookMapper.ToEntity(book));
                return RedirectToAction(nameof(Index));
            }
            catch (InvalidOperationException ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
                await LoadAuthorsAsync();
                return View(book);
            }
        }

        private async Task LoadAuthorsAsync()
        {
            var authors = await _authorService.GetAllAuthorsAsync();

            ViewBag.AuthorId = new SelectList(
                authors.Select(a => new
                {
                    a.Id,
                    FullName = $"{a.FirstName} {a.LastName}"
                }),
                "Id",
                "FullName"
            );
        }
    }
}