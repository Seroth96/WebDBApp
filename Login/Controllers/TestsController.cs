//using NLog;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Net;
//using System.Web;
//using System.Web.Mvc;
//using WebDBApp.Enum;
//using WebDBApp.Helpers;
//using WebDBApp.Interfaces;
//using WebDBApp.Service_References.Annotation;
//using WebDBApp.ViewModels;

//namespace Login.Controllers
//{
//    [SessionExpireFilter]
//    public class TestsController : Controller
//    {

//        private static Logger logger = LogManager.GetCurrentClassLogger();
//        private readonly IUnitOfWork _unitOfWork;

//        public TestsController(IUnitOfWork unitOfWork)
//        {
//            _unitOfWork = unitOfWork;
//        }

//        public ActionResult Index()
//        {
//            var viewModel = new TestsViewModel();


//            var x = TestsHelper.GetAvailableTests().Select(r => new SelectListItem
//            {
//                Text = r.Name,
//                Value = r.ID.ToString()
//            });
//            viewModel.choices.AddRange(x);

//            return View(viewModel);
//        }

//        public ActionResult ShowTest(int id)
//        {
//            var viewModel = new TestDataViewModel();
//            viewModel.ID = id;
//            switch (id)
//            {
//                case 0:
//                    return PartialView("~/Views/Tests/ZmodyfikowanaBurpeego.cshtml", viewModel);
//                case 1:
//                    return PartialView("~/Views/Tests/ProgresywnyBalke.cshtml", viewModel);
//                case 2:
//                    return PartialView("~/Views/Tests/Swimming.cshtml", viewModel);
//                case 3:
//                    return PartialView("~/Views/Tests/TestCoopera.cshtml", viewModel);
//                case 4:
//                    return PartialView("~/Views/Tests/WyskokDosiezny.cshtml", viewModel);
//                case 5:
//                    return PartialView("~/Views/Tests/Lian.cshtml", viewModel);
//                case 6:
//                    return PartialView("~/Views/Tests/StepTest.cshtml", viewModel);
//                case 7:
//                    return PartialView("~/Views/Tests/TestBrzuszkow.cshtml", viewModel);
//                case 8:
//                    return PartialView("~/Views/Tests/TestPompkowy.cshtml", viewModel);

//                default:
//                    Response.StatusCode = (int)HttpStatusCode.BadRequest;
//                    return PartialView("~/Views/PartialViews/Error.cshtml", "Nie ma takiego testu.");
//            }
//        }

//        public ActionResult GetResult(TestDataViewModel viewModel)
//        {
//            var login = SessionHelper.GetElement<string>(SessionElement.Login);
//            var user = _unitOfWork.UserRepository.Find(login);
//            var result = TestsHelper.GetResult(_unitOfWork, viewModel.ID, viewModel.Result, viewModel.Age, user.Sex);

//            return Json(result, JsonRequestBehavior.AllowGet);

//        }


//    }
//}