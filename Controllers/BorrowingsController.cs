using APBD_cw8_s29640.Mappers;
using APBD_cw8_s29640.Services;
using APBD_cw8_s29640.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace APBD_cw8_s29640.Controllers
{

    public class BorrowingsController : Controller
    {
        private readonly IBorrowingService _borrowingService;
        private readonly IBookService _bookService;

        public BorrowingsController(
            IBorrowingService borrowingService,
            IBookService bookService)
        {
            _borrowingService = borrowingService;
            _bookService = bookService;
        }

        public async Task<IActionResult> Create(int? bookId)
        {
            await LoadBooksAsync();

            var borrowing = new CreateBorrowingViewModel
            {
                BookId = bookId ?? 0,
                BorrowedAt = DateTime.Now
            };

            return View(borrowing);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateBorrowingViewModel borrowing)
        {
            if (!ModelState.IsValid)
            {
                await LoadBooksAsync();
                return View(borrowing);
            }

            try
            {
                await _borrowingService.CreateBorrowingAsync(BorrowingMapper.ToEntity(borrowing));
                return RedirectToAction("Details", "Books", new { id = borrowing.BookId });
            }
            catch (InvalidOperationException ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
                await LoadBooksAsync();
                return View(borrowing);
            }
        }

        private async Task LoadBooksAsync()
        {
            var books = await _bookService.GetAllBooksAsync();

            ViewBag.BookId = new SelectList(
                books,
                "Id",
                "Title"
            );
        }
    }
}