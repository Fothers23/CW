using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CW.Data;
using CW.Models;
using Microsoft.AspNetCore.Authorization;

/* This class provides the functionality for altering the Statuses and Comments tables
 * in the database and redirecting to the correct views */
namespace CW.Controllers
{
    [Authorize]
    public class StatusController : Controller
    {
        private readonly ApplicationDbContext _context;

        // Constructor that provides access to the database.
        public StatusController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Status
        // Method to list all statuses.
        public async Task<IActionResult> Index()
        {
            return View(await _context.Statuses.ToListAsync());
        }

        // GET: Status/Details/5
        /* Method to direct users to a page where both a specific status
         * and its comments can be viewed. */
        [HttpGet]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Status status = await _context.Statuses
                .SingleOrDefaultAsync(m => m.StatusID == id);
            if (status == null)
            {
                return NotFound();
            }
            StatusDetailsViewModel viewModel = await GetViewModelFromStatus(status);

            return View(viewModel); // Returns the details view with the added comment.
        }

        // Method to allow customers to add comments to a specific status.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Customer")]
        public async Task<IActionResult> Details([Bind("StatusID, Remark,UserID")] StatusDetailsViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                Comment comment = new Comment();
                comment.Remark = viewModel.Remark;

                Status status = await _context.Statuses
                    .SingleOrDefaultAsync(m => m.StatusID == viewModel.StatusID);

                if (status == null)
                {
                    return NotFound();
                }

                comment.MyStatus = status;
                _context.Comments.Add(comment);
                await _context.SaveChangesAsync();

                viewModel = await GetViewModelFromStatus(status);
            }
            return View(viewModel);
        }

        // Method to list comments for a specific status.
        private async Task<StatusDetailsViewModel> GetViewModelFromStatus(Status status)
        {
            StatusDetailsViewModel viewModel = new StatusDetailsViewModel();

            viewModel.Status = status;

            List<Comment> comments = await _context.Comments
                .Where(x => x.MyStatus == status).ToListAsync();

            viewModel.Comments = comments;
            return viewModel;
        }

        // GET: Status/Create
        // Method to direct the admin to a form page to add a status.
        [Authorize(Roles = "Admin")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Status/Create
        // Method to allow admin to create new statuses.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create([Bind("Post,UserID")] Status status)
        {
            if (ModelState.IsValid)
            {
                _context.Add(status);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(status);
        }

        // GET: Status/Edit/5
        // Method to allow admin access to a page to edit a status.
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var status = await _context.Statuses.FindAsync(id);
            if (status == null)
            {
                return NotFound();
            }
            return View(status);
        }

        // POST: Status/Edit/5
        // Method to allow admin to edit a specific status.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(int id, [Bind("StatusID,Post,UserID")] Status status)
        {
            if (id != status.StatusID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(status); 
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StatusExists(status.StatusID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(status);
        }

        // GET: Status/Delete/5
        // Method to direct admin to a delete confirmation page for statuses.
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var status = await _context.Statuses
                .FirstOrDefaultAsync(m => m.StatusID == id);
            if (status == null)
            {
                return NotFound();
            }

            return View(status);
        }

        // POST: Status/Delete/5
        // Method to remove a status from the database.
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var status = await _context.Statuses.FindAsync(id);
            _context.Statuses.Remove(status);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // Method to check that a status exists in the database.
        private bool StatusExists(int id)
        {
            return _context.Statuses.Any(e => e.StatusID == id);
        }

        // Method to direct the customer to a page to edit a specific comment.
        [Authorize(Roles = "Customer")]
        public async Task<IActionResult> EditComment(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var comment = await _context.Comments.FindAsync(id);
            if (comment == null)
            {
                return NotFound();
            }
            return View(comment);
        }

        // Method to edit a comment.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Customer")]
        public async Task<IActionResult> EditComment(int id, [Bind("CommentId,Remark,UserID")] Comment comment)
        {
            if (id != comment.CommentId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(comment);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CommentExists(comment.CommentId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(comment);
        }
        
        // Method to direct the customer to a delete confirmation page for comments.
        [Authorize(Roles = "Customer")]
        public async Task<IActionResult> DeleteComment(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var status = await _context.Comments
                .FirstOrDefaultAsync(m => m.CommentId == id);
            if (status == null)
            {
                return NotFound();
            }

            return View(status);
        }

        // Method to remove comments from the database.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Customer")]
        public async Task<IActionResult> DeleteComment(int id)
        {
            var comment = await _context.Comments.FindAsync(id);
            _context.Comments.Remove(comment);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // Method to check that a comment exists in the database.
        private bool CommentExists(int id)
        {
            return _context.Comments.Any(e => e.CommentId == id);
        }
    }
}
