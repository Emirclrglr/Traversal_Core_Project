using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Traversal_Core_Project.Controllers
{
    [AllowAnonymous]
    public class CommentController : Controller
    {
        ICommentService _commentService;

        public CommentController(ICommentService commentService)
        {
            _commentService = commentService;
        }

        [HttpGet]
        public PartialViewResult AddComment(int id)
        {
            ViewBag.id = id;
            return PartialView();
        }
        [HttpPost]
        public IActionResult AddComment(Comment p)
        {
            p.Status = true;
            p.Date = DateTime.Parse(DateTime.Now.ToString());
            _commentService.TInsert(p);
            return RedirectToAction("DestinationDetails","Destination", new {id = p.DestinationId});
        }
    }
}
