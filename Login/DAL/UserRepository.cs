using WebDBApp.Database;
using WebDBApp.Enum;
using WebDBApp.Extensions;
using WebDBApp.Helpers;
using WebDBApp.Interfaces;
using WebDBApp.Models;
using WebDBApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Data.Entity;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using NLog;

namespace WebDBApp.DAL
{
    public class UserRepository : Repository<User, string>
    {

        private static Logger logger = LogManager.GetCurrentClassLogger();
        public UserRepository(AppDbContext context, IHashHelper hashHelper)
            : base(context)
        {
            _hashHelper = hashHelper;
        }

        private IHashHelper _hashHelper;

        public UserRepository(AppDbContext context)
            : base(context)
        {

        }

        public override List<User> All()
        {
            var x = Context.Users.Include(sad => sad.Role)
                .ToList();

            return x;
        }


        public override User Find(string id)
        {
            return Context.Users.Include(sad => sad.Role).Single(user => user.Login == id);
        }

        public void Add(RegisterAccountViewModel viewModel, Role role)
        {
            if (Context.Users.Any(usr => usr.Login.ToLower() == viewModel.Login))
            {
                throw new Exception("Istnieje użytkownik o podanym loginie");
            }
            if (Context.Users.Any(user => user.Email == viewModel.Email))
            {
                throw new Exception("Istnieje użytkownik o podanym mailu");
            }

            var salt = _hashHelper.GetSalt();
            Add(new User()
            {
                Login = viewModel.Login, //string.Format("{0}.{1}", viewModel.FirstName.ToLower(), viewModel.LastName.ToLower()),
                Password = _hashHelper.Compute(viewModel.Password, salt),
                Salt = salt,
                PasswordCreated = DateTime.Now,
                Created = DateTime.Now,
                Email = viewModel.Email,
                FirstName = viewModel.FirstName,
                LastName = viewModel.LastName,
                Role = role
            });
            try
            {
               // Context.SaveChanges();
            }
            catch (DbEntityValidationException e)
            {
                logger.Error(e, e.Message);
            }
        }

      

        public void Update(string login, bool isFrozen)
        {
            Find(login).IsFrozen = isFrozen;
        }

        private string GetRandomPassword(int minLen)
        {
            int length = new Random().Next(minLen, 14);
            int complexity = 4;
            RNGCryptoServiceProvider csp = new RNGCryptoServiceProvider();
            char[][] classes =
            {
                @"abcdefghijklmnopqrstuvwxyz".ToCharArray(),
                @"ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray(),
                @"0123456789".ToCharArray(),
                @"!""#$%&'()*+,./:;<>?@[\]^_{|}~".ToCharArray(),
            };
            char[] allchars = classes.Take(complexity).SelectMany(x => x).ToArray();
            byte[] bytes = new byte[allchars.Length];
            csp.GetBytes(bytes);
            for (int i = 0; i < allchars.Length; i++)
            {
                char tmp = allchars[i];
                allchars[i] = allchars[bytes[i] % allchars.Length];
                allchars[bytes[i] % allchars.Length] = tmp;
            }
            Array.Resize(ref bytes, length);
            char[] result = new char[length];

            while (true)
            {
                csp.GetBytes(bytes);
                // Obtain the character of the class for each random byte
                for (int i = 0; i < length; i++)
                    result[i] = allchars[bytes[i] % allchars.Length];

                // Verify that it does not start or end with whitespace
                if (Char.IsWhiteSpace(result[0]) || Char.IsWhiteSpace(result[(length - 1) % length]))
                    continue;

                string testResult = new string(result);
                // Verify that all character classes are represented
                if (0 != classes.Take(complexity).Count(c => testResult.IndexOfAny(c) < 0))
                    continue;

                return testResult;
            }
        }

        public void ResetPassword(ResetPasswordRequestViewModel request)
        {
            //var username = string.Format("{0}.{1}", request.FirstName, request.LastName);
            var usr = Context.Users.FirstOrDefault(user => user.Email == request.Email);
            if (usr == null)
                throw new Exception("Nie istnieje użytkownik o podanym mailu.");
            var pwdString = GetRandomPassword(8);
            usr.Salt = _hashHelper.GetSalt();
            usr.Password = _hashHelper.Compute(pwdString, usr.Salt);
            usr.PasswordCreated = DateTime.Now;
            EmailHelper.SendEmail(new EmailAccount
            {
                Email = usr.Email,
                Subject = "Generacja nowego hasła",
                Request = string.Format("Witam, <br/><br/> " +
                "Na prośbę <b>{0} {1}</b> wygenerowano nowe hasło do aplikacji. <br/>" +
                "Login: <b>{2}</b> <br/>" +
                "Hasło: <b>{3}</b> <br/>" +
                "Jeśli nie składałeś prośby o nowe hasło proszę zignoruj tę wiadomość.<br/><br/>" +
                "Pozdrawiam, <br/>" +
                "Administrator aplikacji \"MTAB\" <br/><br/>" +
                "Odpowiedź wygenerowano automatycznie, proszę na nią nie odpowiadać.",
                usr.FirstName, usr.LastName, usr.Login, pwdString)
            });

        }

        public User GetLoggedUser()
        {
            return Find(SessionHelper.GetElement<string>(SessionElement.Login));
        }

        public int GetAccounts(bool isFrozen)
        {
            return All().Count(user => user.IsFrozen == isFrozen);
        }
    }
}