using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Web;
using System.Web.Mvc;
using WebDBApp.Interfaces;
using WebDBApp.Models;
using WebDBApp.ViewModels;
using WebDBApp.Service_References.Annotation;

namespace Login.Controllers
{
    [SessionExpireFilter]
    public class UsersController : Controller
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();
        private readonly IUnitOfWork _unitOfWork;
        private IHashHelper _hashHelper;

        public UsersController(IUnitOfWork unitOfWork, IHashHelper hashHelper)
        {
            _hashHelper = hashHelper;
            _unitOfWork = unitOfWork;
        }
        [HttpGet]
        public ActionResult Index()
        {
            var viewModel = new ManageUsersViewModel(_unitOfWork);
            viewModel.SetUsers();
            return View(viewModel);
        }

        [HttpGet]
        public ActionResult GetFrozenUsers()
        {
            var viewModel = new ManageUsersViewModel(_unitOfWork);
            viewModel.SetUsers();
            return View();
        }
        [HttpPost]
        public ActionResult Edit(EditUserViewModel viewModel)
        {
            try
            {                
                var user = _unitOfWork.UserRepository.Find(viewModel.Login);
                    if (user.Password != _hashHelper.Compute(viewModel.Password, user.Salt))
                    {
                        var salt = _hashHelper.GetSalt();
                        user.Password = _hashHelper.Compute(viewModel.Password, salt);
                        user.PasswordCreated = DateTime.Now;
                        user.Salt = salt;
                    }
                    if (user.Email != viewModel.Email)
                    {
                        user.Email = viewModel.Email;
                    }
                    if (user.FirstName != viewModel.FirstName || user.LastName != viewModel.LastName)
                    {
                        user.FirstName = viewModel.FirstName;
                        user.LastName = viewModel.LastName;
                    }
                    if (user.Role.ID != viewModel.SelectedRole)
                    {
                        user.Role = _unitOfWork.RoleRepository.Find((int)viewModel.SelectedRole);
                    }
                    _unitOfWork.SaveChanges();                
                
            }
            catch (Exception e)
            {
                logger.Error(e, e.Message);
                throw e;
            }                       

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(string id)
        {
            var user = _unitOfWork.UserRepository.Find(id);
            var viewModel = new EditUserViewModel(user);
            viewModel.Roles = _unitOfWork.RoleRepository.All();
            var x = viewModel.Roles.Select(r => new SelectListItem
            {
                Text = r.Name,
                Value = r.ID.ToString()
            });
            viewModel.choices.AddRange(x);
            return View(viewModel);
        }
        [HttpGet]
        public ActionResult Freeze(string id)
        {
            var user = _unitOfWork.UserRepository.Find(id);
            user.IsFrozen = true;
            _unitOfWork.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Defreeze(string id)
        {
            var user = _unitOfWork.UserRepository.Find(id);
            user.IsFrozen = false;
            _unitOfWork.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}