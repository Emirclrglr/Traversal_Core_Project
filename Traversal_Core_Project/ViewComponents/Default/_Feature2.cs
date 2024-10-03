using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace Traversal_Core_Project.ViewComponents.Default
{
    public class _Feature2:ViewComponent
    {
        IFeature2Service _feature2Service;

        public _Feature2(IFeature2Service feature2Service)
        {
            _feature2Service = feature2Service;
        }

        public IViewComponentResult Invoke()
        {
            var values = _feature2Service.TGetList();
            
            return View(values);
        }
    }
}
