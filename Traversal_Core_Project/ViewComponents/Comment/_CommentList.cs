using BusinessLayer.Abstract;
using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace Traversal_Core_Project.ViewComponents.Comment
{
    public class _CommentList : ViewComponent
    {
        ICommentService _commentService;

        public _CommentList(ICommentService commentService)
        {
            _commentService = commentService;
        }

        public IViewComponentResult Invoke(int id)
        {
            using var c = new Context();
            ViewBag.CommentCount = c.Comments.Where(x=>x.DestinationId == id).Count();
            var values = _commentService.GetCommentsById(id);
            return View(values);
        }
    }
}

