using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace Traversal_Core_Project.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CommentController : Controller
    {
        ICommentService _commentService;

        public CommentController(ICommentService commentService)
        {
            _commentService = commentService;
        }

        public IActionResult Index()
        {
            var values = _commentService.TGetCommentsWithDestination();
            return View(values);
        }

        public IActionResult DeleteComment(int id)
        {
            var value = _commentService.TGetByID(id);
            _commentService.TDelete(value);
            return RedirectToAction("Comment", "Admin", "Index");
        }
    }
}
