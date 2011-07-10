using System.Collections.Generic;
using System.Web.Mvc;
using Inspections.Models;

namespace Inspections.Controllers
{
    public class InspectionController : Controller
    {
        public ViewResult Index()
        {
            var dto = DependencyResolver.Current.GetService<IInspectionQuery>().RetrieveInspections();
            return base.View(dto);
        }
    }

    public interface IInspectionQuery
    {
        InspectionListingDto RetrieveInspections();
    }

    public class InspectionQuery : IInspectionQuery
    {
        public InspectionListingDto RetrieveInspections()
        {
            return new InspectionListingDto
                          {Inspections = new List<InspectionDto>
                                             {
                                                 new InspectionDto {Name = "AMTA"},
                                                 new InspectionDto {Name = "ENFORM"},
                                                 new InspectionDto {Name = "AASP"}
                                             }};

        }

    }
}