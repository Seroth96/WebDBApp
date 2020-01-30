//using WebDBApp.ViewModels;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Net;
//using System.Net.Mail;
//using System.Web;
//using WebDBApp.Interfaces;
//using WebDBApp.Models;
//using WebDBApp.Enum;

//namespace WebDBApp.Helpers
//{
//    public class TestTemplate
//    {
//        public int ID { get; set; }
//        public string Name { get; set; }
//    }

//    public static class TestsHelper
//    {
//        public static List<TestTemplate> GetAvailableTests()
//        {
//            var list = new List<TestTemplate>();

//            list.Add(new TestTemplate
//            {
//                ID = 0,
//                Name = "Zmodyfikowana próba Burpee'go"
//            });
//            list.Add(new TestTemplate
//            {
//                ID = 1,
//                Name = "Test Progresywny Balke'a"
//            });
//            list.Add(new TestTemplate
//            {
//                ID = 2,
//                Name = "Test pływacki"
//            });
//            list.Add(new TestTemplate
//            {
//                ID = 3,
//                Name = "Test Coopera dla nietrenujących"
//            });
//            list.Add(new TestTemplate
//            {
//                ID = 4,
//                Name = "Wyskok Dosiężny"
//            });
//            list.Add(new TestTemplate
//            {
//                ID = 5,
//                Name = "Próba Liana"
//            });
//            list.Add(new TestTemplate
//            {
//                ID = 6,
//                Name = "Step test według Canadian Public Health Association"
//            });

//            list.Add(new TestTemplate
//            {
//                ID = 7,
//                Name = "Test brzuszków wg IFA"
//            });

//            list.Add(new TestTemplate
//            {
//                ID = 8,
//                Name = "Test pompkowy wg IFA"
//            });




//            return list;

//        }

//        public static string GetResult(IUnitOfWork _unitOfWork, int id, double value, double age, bool sex)
//        {
//            switch (id)
//            {
//                case 0:
//                    return ZmodyfikowanaBurpeego(_unitOfWork, value, age, sex);
//                case 1:
//                    return ProgresywnyBalke(_unitOfWork, value, age, sex);
//                case 2:
//                    return Swimming(_unitOfWork, value, age, sex);
//                case 3:
//                    return TestCoopera(_unitOfWork, value, age, sex);
//                case 4:
//                    return WyskokDosiezny(_unitOfWork, value, age, sex);
//                case 5:
//                    return Lian(_unitOfWork, value, age, sex);
//                case 6:
//                    return StepTest(_unitOfWork, value, age, sex);
//                case 7:
//                    return TestBrzuszkow(_unitOfWork, value, age, sex);
//                case 8:
//                    return TestPompkowy(_unitOfWork, value, age, sex);

//                default:
//                    return null;
//            }
//        }
//        private static string CreateTestForUser(IUnitOfWork _unitOfWork,double value, string name, string result)
//        {
//            var login = SessionHelper.GetElement<string>(SessionElement.Login);
//            var user = _unitOfWork.UserRepository.Find(login);
//            var test = new Test
//            {
//                Value = value,
//                Name = name,
//                Result = result,
//                User = user,
//                DateOfTest = DateTime.Now
//            };
//            _unitOfWork.TestRepository.Add(test);
//            _unitOfWork.SaveChanges();

//            return test.Wynik;
//        }

//        private static string ZmodyfikowanaBurpeego(IUnitOfWork _unitOfWork, double value, double age, bool sex)
//        {
//            if (age > 19 && age < 30)
//            {
//                if (sex ==false)
//                {
//                    if (value < 40)
//                    {
//                        return CreateTestForUser(_unitOfWork, value, @"Zmodyfikowana próba Burpee'go", "Bardzo dobry");
//                    }
//                    else if (value < 45)
//                    {
//                        return CreateTestForUser(_unitOfWork, value, @"Zmodyfikowana próba Burpee'go", "dobry");
//                    }
//                    else if (value < 55)
//                    {
//                        return CreateTestForUser(_unitOfWork, value, @"Zmodyfikowana próba Burpee'go", "Dostateczny");
//                    }
//                    else if (value < 60)
//                    {
//                        return CreateTestForUser(_unitOfWork, value, @"Zmodyfikowana próba Burpee'go", "Słaby");
//                    }
//                    else if (value >= 60)
//                    {
//                        return CreateTestForUser(_unitOfWork, value, @"Zmodyfikowana próba Burpee'go", "Bardzo słaby");
//                    }
//                }
//                else
//                {
//                    if (value < 35)
//                    {
//                        return CreateTestForUser(_unitOfWork, value, @"Zmodyfikowana próba Burpee'go", "Bardzo dobry");
//                    }
//                    else if (value < 40)
//                    {
//                        return CreateTestForUser(_unitOfWork, value, @"Zmodyfikowana próba Burpee'go", "dobry");
//                    }
//                    else if (value < 50)
//                    {
//                        return CreateTestForUser(_unitOfWork, value, @"Zmodyfikowana próba Burpee'go", "Dostateczny");
//                    }
//                    else if (value < 55)
//                    {
//                        return CreateTestForUser(_unitOfWork, value, @"Zmodyfikowana próba Burpee'go", "Słaby");
//                    }
//                    else if (value >= 55)
//                    {
//                        return CreateTestForUser(_unitOfWork, value, @"Zmodyfikowana próba Burpee'go", "Bardzo słaby");
//                    }
//                }               
//            }
//            else if (age > 29 && age < 40)
//            {
//                if (sex == false)
//                {
//                    if (value < 45)
//                    {
//                        return CreateTestForUser(_unitOfWork, value, @"Zmodyfikowana próba Burpee'go", "Bardzo dobry");
//                    }
//                    else if (value < 50)
//                    {
//                        return CreateTestForUser(_unitOfWork, value, @"Zmodyfikowana próba Burpee'go", "dobry");
//                    }
//                    else if (value < 60)
//                    {
//                        return CreateTestForUser(_unitOfWork, value, @"Zmodyfikowana próba Burpee'go", "Dostateczny");
//                    }
//                    else if (value < 65)
//                    {
//                        return CreateTestForUser(_unitOfWork, value, @"Zmodyfikowana próba Burpee'go", "Słaby");
//                    }
//                    else if (value >= 65)
//                    {
//                        return CreateTestForUser(_unitOfWork, value, @"Zmodyfikowana próba Burpee'go", "Bardzo słaby");
//                    }
//                }
//                else
//                {
//                    if (value < 40)
//                    {
//                        return CreateTestForUser(_unitOfWork, value, @"Zmodyfikowana próba Burpee'go", "Bardzo dobry");
//                    }
//                    else if (value < 45)
//                    {
//                        return CreateTestForUser(_unitOfWork, value, @"Zmodyfikowana próba Burpee'go", "dobry");
//                    }
//                    else if (value < 55)
//                    {
//                        return CreateTestForUser(_unitOfWork, value, @"Zmodyfikowana próba Burpee'go", "Dostateczny");
//                    }
//                    else if (value < 60)
//                    {
//                        return CreateTestForUser(_unitOfWork, value, @"Zmodyfikowana próba Burpee'go", "Słaby");
//                    }
//                    else if (value >= 60)
//                    {
//                        return CreateTestForUser(_unitOfWork, value, @"Zmodyfikowana próba Burpee'go", "Bardzo słaby");
//                    }
//                }
//            }
//            else if (age > 39 && age < 50)
//            {
//                if (sex == false)
//                {
//                    if (value < 50)
//                    {
//                        return CreateTestForUser(_unitOfWork, value, @"Zmodyfikowana próba Burpee'go", "Bardzo dobry");
//                    }
//                    else if (value < 55)
//                    {
//                        return CreateTestForUser(_unitOfWork, value, @"Zmodyfikowana próba Burpee'go", "dobry");
//                    }
//                    else if (value < 65)
//                    {
//                        return CreateTestForUser(_unitOfWork, value, @"Zmodyfikowana próba Burpee'go", "Dostateczny");
//                    }
//                    else if (value < 70)
//                    {
//                        return CreateTestForUser(_unitOfWork, value, @"Zmodyfikowana próba Burpee'go", "Słaby");
//                    }
//                    else if (value >= 70)
//                    {
//                        return CreateTestForUser(_unitOfWork, value, @"Zmodyfikowana próba Burpee'go", "Bardzo słaby");
//                    }
//                }
//                else
//                {
//                    if (value < 45)
//                    {
//                        return CreateTestForUser(_unitOfWork, value, @"Zmodyfikowana próba Burpee'go", "Bardzo dobry");
//                    }
//                    else if (value < 50)
//                    {
//                        return CreateTestForUser(_unitOfWork, value, @"Zmodyfikowana próba Burpee'go", "dobry");
//                    }
//                    else if (value < 60)
//                    {
//                        return CreateTestForUser(_unitOfWork, value, @"Zmodyfikowana próba Burpee'go", "Dostateczny");
//                    }
//                    else if (value < 65)
//                    {
//                        return CreateTestForUser(_unitOfWork, value, @"Zmodyfikowana próba Burpee'go", "Słaby");
//                    }
//                    else if (value >= 65)
//                    {
//                        return CreateTestForUser(_unitOfWork, value, @"Zmodyfikowana próba Burpee'go", "Bardzo słaby");
//                    }
//                }
//            }
//            else if (age > 49 && age < 60)
//            {
//                if (sex == false)
//                {
//                    if (value < 55)
//                    {
//                        return CreateTestForUser(_unitOfWork, value, @"Zmodyfikowana próba Burpee'go", "Bardzo dobry");
//                    }
//                    else if (value < 60)
//                    {
//                        return CreateTestForUser(_unitOfWork, value, @"Zmodyfikowana próba Burpee'go", "dobry");
//                    }
//                    else if (value < 70)
//                    {
//                        return CreateTestForUser(_unitOfWork, value, @"Zmodyfikowana próba Burpee'go", "Dostateczny");
//                    }
//                    else if (value < 75)
//                    {
//                        return CreateTestForUser(_unitOfWork, value, @"Zmodyfikowana próba Burpee'go", "Słaby");
//                    }
//                    else if (value >= 75)
//                    {
//                        return CreateTestForUser(_unitOfWork, value, @"Zmodyfikowana próba Burpee'go", "Bardzo słaby");
//                    }
//                }
//                else
//                {
//                    if (value < 50)
//                    {
//                        return CreateTestForUser(_unitOfWork, value, @"Zmodyfikowana próba Burpee'go", "Bardzo dobry");
//                    }
//                    else if (value < 55)
//                    {
//                        return CreateTestForUser(_unitOfWork, value, @"Zmodyfikowana próba Burpee'go", "dobry");
//                    }
//                    else if (value < 65)
//                    {
//                        return CreateTestForUser(_unitOfWork, value, @"Zmodyfikowana próba Burpee'go", "Dostateczny");
//                    }
//                    else if (value < 70)
//                    {
//                        return CreateTestForUser(_unitOfWork, value, @"Zmodyfikowana próba Burpee'go", "Słaby");
//                    }
//                    else if (value >= 70)
//                    {
//                        return CreateTestForUser(_unitOfWork, value, @"Zmodyfikowana próba Burpee'go", "Bardzo słaby");
//                    }
//                }
//            }
//            else if (age > 59 && age < 70)
//            {
//                if (sex == false)
//                {
//                    if (value < 65)
//                    {
//                        return CreateTestForUser(_unitOfWork, value, @"Zmodyfikowana próba Burpee'go", "Bardzo dobry");
//                    }
//                    else if (value < 70)
//                    {
//                        return CreateTestForUser(_unitOfWork, value, @"Zmodyfikowana próba Burpee'go", "dobry");
//                    }
//                    else if (value < 80)
//                    {
//                        return CreateTestForUser(_unitOfWork, value, @"Zmodyfikowana próba Burpee'go", "Dostateczny");
//                    }
//                    else if (value < 85)
//                    {
//                        return CreateTestForUser(_unitOfWork, value, @"Zmodyfikowana próba Burpee'go", "Słaby");
//                    }
//                    else if (value >= 85)
//                    {
//                        return CreateTestForUser(_unitOfWork, value, @"Zmodyfikowana próba Burpee'go", "Bardzo słaby");
//                    }
//                }
//                else
//                {
//                    if (value < 60)
//                    {
//                        return CreateTestForUser(_unitOfWork, value, @"Zmodyfikowana próba Burpee'go", "Bardzo dobry");
//                    }
//                    else if (value < 65)
//                    {
//                        return CreateTestForUser(_unitOfWork, value, @"Zmodyfikowana próba Burpee'go", "dobry");
//                    }
//                    else if (value < 75)
//                    {
//                        return CreateTestForUser(_unitOfWork, value, @"Zmodyfikowana próba Burpee'go", "Dostateczny");
//                    }
//                    else if (value < 80)
//                    {
//                        return CreateTestForUser(_unitOfWork, value, @"Zmodyfikowana próba Burpee'go", "Słaby");
//                    }
//                    else if (value >= 80)
//                    {
//                        return CreateTestForUser(_unitOfWork, value, @"Zmodyfikowana próba Burpee'go", "Bardzo słaby");
//                    }
//                }
//            }
//            return "Nie zostały podane odpowiednie dane do obliczenia wyniku testu";
//        }

//        private static string ProgresywnyBalke(IUnitOfWork _unitOfWork, double value, double age, bool sex)
//        {
//            value = value / 60;
//            var Mvomax = (value * 1.444) + 14.99;
//            var Fvomax = (value * 38) + 5.22;
//            if (sex == false)
//            {
//                if (age < 30)
//                {
//                    if (Fvomax < 28)
//                    {
//                        return CreateTestForUser(_unitOfWork, Fvomax, @"Test progresywny Balke'a", "małe");
//                    }
//                    else if (Fvomax < 35)
//                    {
//                        return CreateTestForUser(_unitOfWork, Fvomax, @"Test progresywny Balke'a", "średnie");
//                    }
//                    else if (Fvomax < 44)
//                    {
//                        return CreateTestForUser(_unitOfWork, Fvomax, @"Test progresywny Balke'a", "przeciętne");
//                    }
//                    else if (Fvomax < 49)
//                    {
//                        return CreateTestForUser(_unitOfWork, Fvomax, @"Test progresywny Balke'a", "duże");
//                    }
//                    else if (Fvomax >= 49)
//                    {
//                        return CreateTestForUser(_unitOfWork, Fvomax, @"Test progresywny Balke'a", "bardzo duże");
//                    }
//                }
//                else if (age < 40)
//                {
//                    if (Fvomax < 27)
//                    {
//                        return CreateTestForUser(_unitOfWork, Fvomax, @"Test progresywny Balke'a", "małe");
//                    }
//                    else if (Fvomax < 34)
//                    {
//                        return CreateTestForUser(_unitOfWork, Fvomax, @"Test progresywny Balke'a", "średnie");
//                    }
//                    else if (Fvomax < 42)
//                    {
//                        return CreateTestForUser(_unitOfWork, Fvomax, @"Test progresywny Balke'a", "przeciętne");
//                    }
//                    else if (Fvomax < 48)
//                    {
//                        return CreateTestForUser(_unitOfWork, Fvomax, @"Test progresywny Balke'a", "duże");
//                    }
//                    else if (Fvomax >= 48)
//                    {
//                        return CreateTestForUser(_unitOfWork, Fvomax, @"Test progresywny Balke'a", "bardzo duże");
//                    }
//                }
//                else if (age < 50)
//                {
//                    if (Fvomax < 25)
//                    {
//                        return CreateTestForUser(_unitOfWork, Fvomax, @"Test progresywny Balke'a", "małe");
//                    }
//                    else if (Fvomax < 32)
//                    {
//                        return CreateTestForUser(_unitOfWork, Fvomax, @"Test progresywny Balke'a", "średnie");
//                    }
//                    else if (Fvomax < 41)
//                    {
//                        return CreateTestForUser(_unitOfWork, Fvomax, @"Test progresywny Balke'a", "przeciętne");
//                    }
//                    else if (Fvomax < 46)
//                    {
//                        return CreateTestForUser(_unitOfWork, Fvomax, @"Test progresywny Balke'a", "duże");
//                    }
//                    else if (Fvomax >= 46)
//                    {
//                        return CreateTestForUser(_unitOfWork, Fvomax, @"Test progresywny Balke'a", "bardzo duże");
//                    }
//                }
//                else if (age < 66)
//                {
//                    if (Fvomax < 21)
//                    {
//                        return CreateTestForUser(_unitOfWork, Fvomax, @"Test progresywny Balke'a", "małe");
//                    }
//                    else if (Fvomax < 29)
//                    {
//                        return CreateTestForUser(_unitOfWork, Fvomax, @"Test progresywny Balke'a", "średnie");
//                    }
//                    else if (Fvomax < 37)
//                    {
//                        return CreateTestForUser(_unitOfWork, Fvomax, @"Test progresywny Balke'a", "przeciętne");
//                    }
//                    else if (Fvomax < 42)
//                    {
//                        return CreateTestForUser(_unitOfWork, Fvomax, @"Test progresywny Balke'a", "duże");
//                    }
//                    else if (Fvomax >= 42)
//                    {
//                        return CreateTestForUser(_unitOfWork, Fvomax, @"Test progresywny Balke'a", "bardzo duże");
//                    }
//                }
//            }
//            else
//            {
//                if (age < 30)
//                {
//                    if (Mvomax < 38)
//                    {
//                        return CreateTestForUser(_unitOfWork, Mvomax, @"Test progresywny Balke'a", "małe");
//                    }
//                    else if (Mvomax < 44)
//                    {
//                        return CreateTestForUser(_unitOfWork, Mvomax, @"Test progresywny Balke'a", "średnie");
//                    }
//                    else if (Mvomax < 52)
//                    {
//                        return CreateTestForUser(_unitOfWork, Mvomax, @"Test progresywny Balke'a", "przeciętne");
//                    }
//                    else if (Mvomax < 57)
//                    {
//                        return CreateTestForUser(_unitOfWork, Mvomax, @"Test progresywny Balke'a", "duże");
//                    }
//                    else if (Mvomax >= 57)
//                    {
//                        return CreateTestForUser(_unitOfWork, Mvomax, @"Test progresywny Balke'a", "bardzo duże");
//                    }
//                }
//                else if (age < 40)
//                {
//                    if (Mvomax < 34)
//                    {
//                        return CreateTestForUser(_unitOfWork, Mvomax, @"Test progresywny Balke'a", "małe");
//                    }
//                    else if (Mvomax < 40)
//                    {
//                        return CreateTestForUser(_unitOfWork, Mvomax, @"Test progresywny Balke'a", "średnie");
//                    }
//                    else if (Mvomax < 48)
//                    {
//                        return CreateTestForUser(_unitOfWork, Mvomax, @"Test progresywny Balke'a", "przeciętne");
//                    }
//                    else if (Mvomax < 52)
//                    {
//                        return CreateTestForUser(_unitOfWork, Mvomax, @"Test progresywny Balke'a", "duże");
//                    }
//                    else if (Mvomax >= 52)
//                    {
//                        return CreateTestForUser(_unitOfWork, Mvomax, @"Test progresywny Balke'a", "bardzo duże");
//                    }
//                }
//                else if (age < 50)
//                {
//                    if (Mvomax < 30)
//                    {
//                        return CreateTestForUser(_unitOfWork, Mvomax, @"Test progresywny Balke'a", "małe");
//                    }
//                    else if (Mvomax < 36)
//                    {
//                        return CreateTestForUser(_unitOfWork, Mvomax, @"Test progresywny Balke'a", "średnie");
//                    }
//                    else if (Mvomax < 44)
//                    {
//                        return CreateTestForUser(_unitOfWork, Mvomax, @"Test progresywny Balke'a", "przeciętne");
//                    }
//                    else if (Mvomax < 48)
//                    {
//                        return CreateTestForUser(_unitOfWork, Mvomax, @"Test progresywny Balke'a", "duże");
//                    }
//                    else if (Mvomax >= 48)
//                    {
//                        return CreateTestForUser(_unitOfWork, Mvomax, @"Test progresywny Balke'a", "bardzo duże");
//                    }
//                }
//                else if (age < 70)
//                {
//                    if (Mvomax < 21)
//                    {
//                        return CreateTestForUser(_unitOfWork, Mvomax, @"Test progresywny Balke'a", "małe");
//                    }
//                    else if (Mvomax < 27)
//                    {
//                        return CreateTestForUser(_unitOfWork, Mvomax, @"Test progresywny Balke'a", "średnie");
//                    }
//                    else if (Mvomax < 36)
//                    {
//                        return CreateTestForUser(_unitOfWork, Mvomax, @"Test progresywny Balke'a", "przeciętne");
//                    }
//                    else if (Mvomax < 40)
//                    {
//                        return CreateTestForUser(_unitOfWork, Mvomax, @"Test progresywny Balke'a", "duże");
//                    }
//                    else if (Mvomax >= 40)
//                    {
//                        return CreateTestForUser(_unitOfWork, Mvomax, @"Test progresywny Balke'a", "bardzo duże");
//                    }
//                }

//            }

//            return "Nie zostały podane odpowiednie dane do obliczenia wyniku testu";
//        }

//        private static string Swimming(IUnitOfWork _unitOfWork, double value, double age, bool sex)
//        {
//            if (value < 150)
//            {
//                return CreateTestForUser(_unitOfWork, value, @"Test pływacki", "bardzo mała");
//            }
//            else if (value < 201)
//            {
//                return CreateTestForUser(_unitOfWork, value, @"Test pływacki", "mała");
//            }
//            else if (value < 251)
//            {
//                return CreateTestForUser(_unitOfWork, value, @"Test pływacki", "średnia");
//            }
//            else if (value < 300)
//            {
//                return CreateTestForUser(_unitOfWork, value, @"Test pływacki", "duża");
//            }
//            else if (value >= 300)
//            {
//                return CreateTestForUser(_unitOfWork, value, @"Test pływacki", "bardzo duża");
//            }
//            return "Nie zostały podane odpowiednie dane do obliczenia wyniku testu";
//        }

//        private static string TestCoopera(IUnitOfWork _unitOfWork, double value, double age, bool sex)
//        {
//            if (sex == false)
//            {
//                if (age < 20)
//                {
//                    if (value < 2100)
//                    {
//                        return CreateTestForUser(_unitOfWork, value, "Test Coopera dla nietrenujących", "słaby");
//                    }
//                    else if (value < 2300)
//                    {
//                        return CreateTestForUser(_unitOfWork, value, "Test Coopera dla nietrenujących", "zadowalający");
//                    }
//                    else if (value < 2400)
//                    {
//                        return CreateTestForUser(_unitOfWork, value, "Test Coopera dla nietrenujących", "dobry");
//                    }
//                    else if (value >= 2400)
//                    {
//                        return CreateTestForUser(_unitOfWork, value, "Test Coopera dla nietrenujących", "bardzo dobry");
//                    }
//                }
//                else if (age < 30)
//                {
//                    if (value < 1900)
//                    {
//                        return CreateTestForUser(_unitOfWork, value, "Test Coopera dla nietrenujących", "słaby");
//                    }
//                    else if (value < 2100)
//                    {
//                        return CreateTestForUser(_unitOfWork, value, "Test Coopera dla nietrenujących", "zadowalający");
//                    }
//                    else if (value < 2300)
//                    {
//                        return CreateTestForUser(_unitOfWork, value, "Test Coopera dla nietrenujących", "dobry");
//                    }
//                    else if (value >= 2400)
//                    {
//                        return CreateTestForUser(_unitOfWork, value, "Test Coopera dla nietrenujących", "bardzo dobry");
//                    }
//                }
//                else if (age < 40)
//                {
//                    if (value < 1900)
//                    {
//                        return CreateTestForUser(_unitOfWork, value, "Test Coopera dla nietrenujących", "słaby");
//                    }
//                    else if (value < 2000)
//                    {
//                        return CreateTestForUser(_unitOfWork, value, "Test Coopera dla nietrenujących", "zadowalający");
//                    }
//                    else if (value < 2200)
//                    {
//                        return CreateTestForUser(_unitOfWork, value, "Test Coopera dla nietrenujących", "dobry");
//                    }
//                    else if (value >= 2200)
//                    {
//                        return CreateTestForUser(_unitOfWork, value, "Test Coopera dla nietrenujących", "bardzo dobry");
//                    }
//                }
//                else if (age < 50)
//                {
//                    if (value < 1800)
//                    {
//                        return CreateTestForUser(_unitOfWork, value, "Test Coopera dla nietrenujących", "słaby");
//                    }
//                    else if (value < 2000)
//                    {
//                        return CreateTestForUser(_unitOfWork, value, "Test Coopera dla nietrenujących", "zadowalający");
//                    }
//                    else if (value < 2100)
//                    {
//                        return CreateTestForUser(_unitOfWork, value, "Test Coopera dla nietrenujących", "dobry");
//                    }
//                    else if (value >= 2100)
//                    {
//                        return CreateTestForUser(_unitOfWork, value, "Test Coopera dla nietrenujących", "bardzo dobry");
//                    }
//                }
//                else if (age < 60)
//                {
//                    if (value < 1700)
//                    {
//                        return CreateTestForUser(_unitOfWork, value, "Test Coopera dla nietrenujących", "słaby");
//                    }
//                    else if (value < 1900)
//                    {
//                        return CreateTestForUser(_unitOfWork, value, "Test Coopera dla nietrenujących", "zadowalający");
//                    }
//                    else if (value < 2000)
//                    {
//                        return CreateTestForUser(_unitOfWork, value, "Test Coopera dla nietrenujących", "dobry");
//                    }
//                    else if (value >= 2000)
//                    {
//                        return CreateTestForUser(_unitOfWork, value, "Test Coopera dla nietrenujących", "bardzo dobry");
//                    }
//                }
//                else if (age >= 60)
//                {
//                    if (value < 1550)
//                    {
//                        return CreateTestForUser(_unitOfWork, value, "Test Coopera dla nietrenujących", "słaby");
//                    }
//                    else if (value < 1700)
//                    {
//                        return CreateTestForUser(_unitOfWork, value, "Test Coopera dla nietrenujących", "zadowalający");
//                    }
//                    else if (value < 1900)
//                    {
//                        return CreateTestForUser(_unitOfWork, value, "Test Coopera dla nietrenujących", "dobry");
//                    }
//                    else if (value >= 1900)
//                    {
//                        return CreateTestForUser(_unitOfWork, value, "Test Coopera dla nietrenujących", "bardzo dobry");
//                    }
//                }
//            }
//            else
//            {
//                if (age < 20)
//                {
//                    if (value < 2500)
//                    {
//                        return CreateTestForUser(_unitOfWork, value, "Test Coopera dla nietrenujących", "słaby");
//                    }
//                    else if (value < 2750)
//                    {
//                        return CreateTestForUser(_unitOfWork, value, "Test Coopera dla nietrenujących", "zadowalający");
//                    }
//                    else if (value < 3000)
//                    {
//                        return CreateTestForUser(_unitOfWork, value, "Test Coopera dla nietrenujących", "dobry");
//                    }
//                    else if (value >= 3000)
//                    {
//                        return CreateTestForUser(_unitOfWork, value, "Test Coopera dla nietrenujących", "bardzo dobry");
//                    }
//                }
//                else if (age < 30)
//                {
//                    if (value < 2400)
//                    {
//                        return CreateTestForUser(_unitOfWork, value, "Test Coopera dla nietrenujących", "słaby");
//                    }
//                    else if (value < 2600)
//                    {
//                        return CreateTestForUser(_unitOfWork, value, "Test Coopera dla nietrenujących", "zadowalający");
//                    }
//                    else if (value < 2800)
//                    {
//                        return CreateTestForUser(_unitOfWork, value, "Test Coopera dla nietrenujących", "dobry");
//                    }
//                    else if (value >= 2800)
//                    {
//                        return CreateTestForUser(_unitOfWork, value, "Test Coopera dla nietrenujących", "bardzo dobry");
//                    }
//                }
//                else if (age < 40)
//                {
//                    if (value < 2300)
//                    {
//                        return CreateTestForUser(_unitOfWork, value, "Test Coopera dla nietrenujących", "słaby");
//                    }
//                    else if (value < 2500)
//                    {
//                        return CreateTestForUser(_unitOfWork, value, "Test Coopera dla nietrenujących", "zadowalający");
//                    }
//                    else if (value < 2700)
//                    {
//                        return CreateTestForUser(_unitOfWork, value, "Test Coopera dla nietrenujących", "dobry");
//                    }
//                    else if (value >= 2700)
//                    {
//                        return CreateTestForUser(_unitOfWork, value, "Test Coopera dla nietrenujących", "bardzo dobry");
//                    }
//                }
//                else if (age < 50)
//                {
//                    if (value < 2200)
//                    {
//                        return CreateTestForUser(_unitOfWork, value, "Test Coopera dla nietrenujących", "słaby");
//                    }
//                    else if (value < 2450)
//                    {
//                        return CreateTestForUser(_unitOfWork, value, "Test Coopera dla nietrenujących", "zadowalający");
//                    }
//                    else if (value < 2600)
//                    {
//                        return CreateTestForUser(_unitOfWork, value, "Test Coopera dla nietrenujących", "dobry");
//                    }
//                    else if (value >= 2600)
//                    {
//                        return CreateTestForUser(_unitOfWork, value, "Test Coopera dla nietrenujących", "bardzo dobry");
//                    }
//                }
//                else if (age < 60)
//                {
//                    if (value < 2100)
//                    {
//                        return CreateTestForUser(_unitOfWork, value, "Test Coopera dla nietrenujących", "słaby");
//                    }
//                    else if (value < 2300)
//                    {
//                        return CreateTestForUser(_unitOfWork, value, "Test Coopera dla nietrenujących", "zadowalający");
//                    }
//                    else if (value < 2500)
//                    {
//                        return CreateTestForUser(_unitOfWork, value, "Test Coopera dla nietrenujących", "dobry");
//                    }
//                    else if (value >= 2500)
//                    {
//                        return CreateTestForUser(_unitOfWork, value, "Test Coopera dla nietrenujących", "bardzo dobry");
//                    }
//                }
//                else if (age >= 60)
//                {
//                    if (value < 1900)
//                    {
//                        return CreateTestForUser(_unitOfWork, value, "Test Coopera dla nietrenujących", "słaby");
//                    }
//                    else if (value < 2100)
//                    {
//                        return CreateTestForUser(_unitOfWork, value, "Test Coopera dla nietrenujących", "zadowalający");
//                    }
//                    else if (value < 2400)
//                    {
//                        return CreateTestForUser(_unitOfWork, value, "Test Coopera dla nietrenujących", "dobry");
//                    }
//                    else if (value >= 2400)
//                    {
//                        return CreateTestForUser(_unitOfWork, value, "Test Coopera dla nietrenujących", "bardzo dobry");
//                    }
//                }

//            }
//            return "Nie zostały podane odpowiednie dane do obliczenia wyniku testu";
//        }

//        private static string WyskokDosiezny(IUnitOfWork _unitOfWork, double value, double age, bool sex)
//        {
//            if (sex == false)
//            {
//                if (value < 11)
//                {
//                   return CreateTestForUser(_unitOfWork, value, @"Wyskok dosiężny", "bardzo słaby");
//                }
//                else if (value < 21)
//                {
//                    return CreateTestForUser(_unitOfWork, value, @"Wyskok dosiężny", "słaby");
//                }
//                else if (value < 31)
//                {
//                    return CreateTestForUser(_unitOfWork, value, @"Wyskok dosiężny", "poniżej średniego");
//                }
//                else if (value < 41)
//                {
//                    return CreateTestForUser(_unitOfWork, value, @"Wyskok dosiężny", "średni");
//                }
//                else if (value < 51)
//                {
//                    return CreateTestForUser(_unitOfWork, value, @"Wyskok dosiężny", "powyżej średniego");

//                }
//                else if (value < 61)
//                {
//                    return CreateTestForUser(_unitOfWork, value, @"Wyskok dosiężny", "bardzo dobry");
//                }
//                else if (value >= 61)
//                {
//                    return CreateTestForUser(_unitOfWork, value, @"Wyskok dosiężny", "doskonały");
//                }
//            }
//            else
//            {
//                if (value < 21)
//                {
//                    return CreateTestForUser(_unitOfWork, value, @"Wyskok dosiężny", "bardzo słaby");
//                }
//                else if (value < 31)
//                {
//                    return CreateTestForUser(_unitOfWork, value, @"Wyskok dosiężny", "słaby");
//                }
//                else if (value < 41)
//                {
//                    return CreateTestForUser(_unitOfWork, value, @"Wyskok dosiężny", "poniżej średniego");
//                }
//                else if (value < 51)
//                {
//                    return CreateTestForUser(_unitOfWork, value, @"Wyskok dosiężny", "średni");
//                }
//                else if (value < 61)
//                {
//                    return CreateTestForUser(_unitOfWork, value, @"Wyskok dosiężny", "powyżej średniego");
//                }
//                else if (value < 71)
//                {
//                    return CreateTestForUser(_unitOfWork, value, @"Wyskok dosiężny", "bardzo dobry");
//                }
//                else if (value >= 71)
//                {
//                    return CreateTestForUser(_unitOfWork, value, @"Wyskok dosiężny", "doskonały");
//                }

//            }
//            return "Nie zostały podane odpowiednie dane do obliczenia wyniku testu"; ;
//        }

//        private static string Lian(IUnitOfWork _unitOfWork, double value, double age, bool sex)
//        {
//            if (value < 100)
//            {
//                return CreateTestForUser(_unitOfWork, value, "Próba Liana", "Powrót do stanu wyjściowego w ciągu 3 min restytucji świadczy o prawidłowej reakcji układu krążenia i dobre kondycji");
//            }
//            else
//            {
//                return CreateTestForUser(_unitOfWork, value, "Próba Liana", "Powrót do stanu wyjściowego trwający 6 min bądź dłużej świadczy o małej wydolności.");
//            }
//            return "Nie zostały podane odpowiednie dane do obliczenia wyniku testu";
//        }

//        private static string StepTest(IUnitOfWork _unitOfWork, double value, double age, bool sex)
//        {
//            if (sex == false)
//            {
//                if (age < 26)
//                {
//                    if (value < 85)
//                    {
//                        return CreateTestForUser(_unitOfWork, value, "Step Test wg CPHA", "doskonały");
//                    }
//                    else if (value < 99)
//                    {
//                        return CreateTestForUser(_unitOfWork, value, "Step Test wg CPHA", "dobry");
//                    }
//                    else if (value < 109)
//                    {
//                        return CreateTestForUser(_unitOfWork, value, "Step Test wg CPHA", "powyżej średniej");
//                    }
//                    else if (value < 118)
//                    {
//                        return CreateTestForUser(_unitOfWork, value, "Step Test wg CPHA", "średni");
//                    }
//                    else if (value < 127)
//                    {
//                        return CreateTestForUser(_unitOfWork, value, "Step Test wg CPHA", "poniżej średniej");
//                    }
//                    else if (value < 141)
//                    {
//                        return CreateTestForUser(_unitOfWork, value, "Step Test wg CPHA", "słaby");
//                    }
//                    else if (value >= 141)
//                    {
//                        return CreateTestForUser(_unitOfWork, value, "Step Test wg CPHA", "bardzo słaby");
//                    }
//                }
//                else if (age < 36)
//                {
//                    if (value < 88)
//                    {
//                        return CreateTestForUser(_unitOfWork, value, "Step Test wg CPHA", "doskonały");
//                    }
//                    else if (value < 100)
//                    {
//                        return CreateTestForUser(_unitOfWork, value, "Step Test wg CPHA", "dobry");
//                    }
//                    else if (value < 112)
//                    {
//                        return CreateTestForUser(_unitOfWork, value, "Step Test wg CPHA", "powyżej średniej");
//                    }
//                    else if (value < 120)
//                    {
//                        return CreateTestForUser(_unitOfWork, value, "Step Test wg CPHA", "średni");
//                    }
//                    else if (value < 127)
//                    {
//                        return CreateTestForUser(_unitOfWork, value, "Step Test wg CPHA", "poniżej średniej");
//                    }
//                    else if (value < 139)
//                    {
//                        return CreateTestForUser(_unitOfWork, value, "Step Test wg CPHA", "słaby");
//                    }
//                    else if (value >= 139)
//                    {
//                        return CreateTestForUser(_unitOfWork, value, "Step Test wg CPHA", "bardzo słaby");
//                    }
//                }
//                else if (age < 46)
//                {
//                    if (value < 90)
//                    {
//                        return CreateTestForUser(_unitOfWork, value, "Step Test wg CPHA", "doskonały");
//                    }
//                    else if (value < 103)
//                    {
//                        return CreateTestForUser(_unitOfWork, value, "Step Test wg CPHA", "dobry");
//                    }
//                    else if (value < 111)
//                    {
//                        return CreateTestForUser(_unitOfWork, value, "Step Test wg CPHA", "powyżej średniej");
//                    }
//                    else if (value < 119)
//                    {
//                        return CreateTestForUser(_unitOfWork, value, "Step Test wg CPHA", "średni");
//                    }
//                    else if (value < 129)
//                    {
//                        return CreateTestForUser(_unitOfWork, value, "Step Test wg CPHA", "poniżej średniej");
//                    }
//                    else if (value < 141)
//                    {
//                        return CreateTestForUser(_unitOfWork, value, "Step Test wg CPHA", "słaby");
//                    }
//                    else if (value >= 141)
//                    {
//                        return CreateTestForUser(_unitOfWork, value, "Step Test wg CPHA", "bardzo słaby");
//                    }
//                }
//                else if (age < 56)
//                {
//                    if (value < 95)
//                    {
//                        return CreateTestForUser(_unitOfWork, value, "Step Test wg CPHA", "doskonały");
//                    }
//                    else if (value < 105)
//                    {
//                        return CreateTestForUser(_unitOfWork, value, "Step Test wg CPHA", "dobry");
//                    }
//                    else if (value < 116)
//                    {
//                        return CreateTestForUser(_unitOfWork, value, "Step Test wg CPHA", "powyżej średniej");
//                    }
//                    else if (value < 121)
//                    {
//                        return CreateTestForUser(_unitOfWork, value, "Step Test wg CPHA", "średni");
//                    }
//                    else if (value < 130)
//                    {
//                        return CreateTestForUser(_unitOfWork, value, "Step Test wg CPHA", "poniżej średniej");
//                    }
//                    else if (value < 136)
//                    {
//                        return CreateTestForUser(_unitOfWork, value, "Step Test wg CPHA", "słaby");
//                    }
//                    else if (value >= 136)
//                    {
//                        return CreateTestForUser(_unitOfWork, value, "Step Test wg CPHA", "bardzo słaby");
//                    }
//                }
//                else if (age < 66)
//                {
//                    if (value < 96)
//                    {
//                        return CreateTestForUser(_unitOfWork, value, "Step Test wg CPHA", "doskonały");
//                    }
//                    else if (value < 105)
//                    {
//                        return CreateTestForUser(_unitOfWork, value, "Step Test wg CPHA", "dobry");
//                    }
//                    else if (value < 116)
//                    {
//                        return CreateTestForUser(_unitOfWork, value, "Step Test wg CPHA", "powyżej średniej");
//                    }
//                    else if (value < 121)
//                    {
//                        return CreateTestForUser(_unitOfWork, value, "Step Test wg CPHA", "średni");
//                    }
//                    else if (value < 130)
//                    {
//                        return CreateTestForUser(_unitOfWork, value, "Step Test wg CPHA", "poniżej średniej");
//                    }
//                    else if (value < 136)
//                    {
//                        return CreateTestForUser(_unitOfWork, value, "Step Test wg CPHA", "słaby");
//                    }
//                    else if (value >= 136)
//                    {
//                        return CreateTestForUser(_unitOfWork, value, "Step Test wg CPHA", "bardzo słaby");
//                    }
//                }
//                else if (age >= 66)
//                {
//                    if (value < 30)
//                    {
//                        return CreateTestForUser(_unitOfWork, value, "Step Test wg CPHA", "doskonały");
//                    }
//                    else if (value < 103)
//                    {
//                        return CreateTestForUser(_unitOfWork, value, "Step Test wg CPHA", "dobry");
//                    }
//                    else if (value < 116)
//                    {
//                        return CreateTestForUser(_unitOfWork, value, "Step Test wg CPHA", "powyżej średniej");
//                    }
//                    else if (value < 123)
//                    {
//                        return CreateTestForUser(_unitOfWork, value, "Step Test wg CPHA", "średni");
//                    }
//                    else if (value < 129)
//                    {
//                        return CreateTestForUser(_unitOfWork, value, "Step Test wg CPHA", "poniżej średniej");
//                    }
//                    else if (value < 135)
//                    {
//                        return CreateTestForUser(_unitOfWork, value, "Step Test wg CPHA", "słaby");
//                    }
//                    else if (value >= 135)
//                    {
//                        return CreateTestForUser(_unitOfWork, value, "Step Test wg CPHA", "bardzo słaby");
//                    }
//                }
//            }
//            else
//            {
//                if (age < 26)
//                {
//                    if (value < 80)
//                    {
//                        return CreateTestForUser(_unitOfWork, value, "Step Test wg CPHA", "doskonały");
//                    }
//                    else if (value < 90)
//                    {
//                        return CreateTestForUser(_unitOfWork, value, "Step Test wg CPHA", "dobry");
//                    }
//                    else if (value < 100)
//                    {
//                        return CreateTestForUser(_unitOfWork, value, "Step Test wg CPHA", "powyżej średniej");
//                    }
//                    else if (value < 106)
//                    {
//                        return CreateTestForUser(_unitOfWork, value, "Step Test wg CPHA", "średni");
//                    }
//                    else if (value < 117)
//                    {
//                        return CreateTestForUser(_unitOfWork, value, "Step Test wg CPHA", "poniżej średniej");
//                    }
//                    else if (value < 129)
//                    {
//                        return CreateTestForUser(_unitOfWork, value, "Step Test wg CPHA", "słaby");
//                    }
//                    else if (value >= 129)
//                    {
//                        return CreateTestForUser(_unitOfWork, value, "Step Test wg CPHA", "bardzo słaby");
//                    }
//                }
//                else if (age < 36)
//                {
//                    if (value < 82)
//                    {
//                        return CreateTestForUser(_unitOfWork, value, "Step Test wg CPHA", "doskonały");
//                    }
//                    else if (value < 90)
//                    {
//                        return CreateTestForUser(_unitOfWork, value, "Step Test wg CPHA", "dobry");
//                    }
//                    else if (value < 100)
//                    {
//                        return CreateTestForUser(_unitOfWork, value, "Step Test wg CPHA", "powyżej średniej");
//                    }
//                    else if (value < 108)
//                    {
//                        return CreateTestForUser(_unitOfWork, value, "Step Test wg CPHA", "średni");
//                    }
//                    else if (value < 118)
//                    {
//                        return CreateTestForUser(_unitOfWork, value, "Step Test wg CPHA", "poniżej średniej");
//                    }
//                    else if (value < 129)
//                    {
//                        return CreateTestForUser(_unitOfWork, value, "Step Test wg CPHA", "słaby");
//                    }
//                    else if (value >= 129)
//                    {
//                        return CreateTestForUser(_unitOfWork, value, "Step Test wg CPHA", "bardzo słaby");
//                    }
//                }
//                else if (age < 46)
//                {
//                    if (value < 83)
//                    {
//                        return CreateTestForUser(_unitOfWork, value, "Step Test wg CPHA", "doskonały");
//                    }
//                    else if (value < 97)
//                    {
//                        return CreateTestForUser(_unitOfWork, value, "Step Test wg CPHA", "dobry");
//                    }
//                    else if (value < 104)
//                    {
//                        return CreateTestForUser(_unitOfWork, value, "Step Test wg CPHA", "powyżej średniej");
//                    }
//                    else if (value < 113)
//                    {
//                        return CreateTestForUser(_unitOfWork, value, "Step Test wg CPHA", "średni");
//                    }
//                    else if (value < 120)
//                    {
//                        return CreateTestForUser(_unitOfWork, value, "Step Test wg CPHA", "poniżej średniej");
//                    }
//                    else if (value < 131)
//                    {
//                        return CreateTestForUser(_unitOfWork, value, "Step Test wg CPHA", "słaby");
//                    }
//                    else if (value >= 131)
//                    {
//                        return CreateTestForUser(_unitOfWork, value, "Step Test wg CPHA", "bardzo słaby");
//                    }
//                }
//                else if (age < 56)
//                {
//                    if (value < 87)
//                    {
//                        return CreateTestForUser(_unitOfWork, value, "Step Test wg CPHA", "doskonały");
//                    }
//                    else if (value < 98)
//                    {
//                        return CreateTestForUser(_unitOfWork, value, "Step Test wg CPHA", "dobry");
//                    }
//                    else if (value < 106)
//                    {
//                        return CreateTestForUser(_unitOfWork, value, "Step Test wg CPHA", "powyżej średniej");
//                    }
//                    else if (value < 117)
//                    {
//                        return CreateTestForUser(_unitOfWork, value, "Step Test wg CPHA", "średni");
//                    }
//                    else if (value < 123)
//                    {
//                        return CreateTestForUser(_unitOfWork, value, "Step Test wg CPHA", "poniżej średniej");
//                    }
//                    else if (value < 133)
//                    {
//                        return CreateTestForUser(_unitOfWork, value, "Step Test wg CPHA", "słaby");
//                    }
//                    else if (value >= 133)
//                    {
//                        return CreateTestForUser(_unitOfWork, value, "Step Test wg CPHA", "bardzo słaby");
//                    }
//                }
//                else if (age < 66)
//                {
//                    if (value < 86)
//                    {
//                        return CreateTestForUser(_unitOfWork, value, "Step Test wg CPHA", "doskonały");
//                    }
//                    else if (value < 98)
//                    {
//                        return CreateTestForUser(_unitOfWork, value, "Step Test wg CPHA", "dobry");
//                    }
//                    else if (value < 103)
//                    {
//                        return CreateTestForUser(_unitOfWork, value, "Step Test wg CPHA", "powyżej średniej");
//                    }
//                    else if (value < 113)
//                    {
//                        return CreateTestForUser(_unitOfWork, value, "Step Test wg CPHA", "średni");
//                    }
//                    else if (value < 121)
//                    {
//                        return CreateTestForUser(_unitOfWork, value, "Step Test wg CPHA", "poniżej średniej");
//                    }
//                    else if (value < 130)
//                    {
//                        return CreateTestForUser(_unitOfWork, value, "Step Test wg CPHA", "słaby");
//                    }
//                    else if (value >= 130)
//                    {
//                        return CreateTestForUser(_unitOfWork, value, "Step Test wg CPHA", "bardzo słaby");
//                    }
//                }
//                else if (age >= 66)
//                {
//                    if (value < 88)
//                    {
//                        return CreateTestForUser(_unitOfWork, value, "Step Test wg CPHA", "doskonały");
//                    }
//                    else if (value < 97)
//                    {
//                        return CreateTestForUser(_unitOfWork, value, "Step Test wg CPHA", "dobry");
//                    }
//                    else if (value < 104)
//                    {
//                        return CreateTestForUser(_unitOfWork, value, "Step Test wg CPHA", "powyżej średniej");
//                    }
//                    else if (value < 114)
//                    {
//                        return CreateTestForUser(_unitOfWork, value, "Step Test wg CPHA", "średni");
//                    }
//                    else if (value < 121)
//                    {
//                        return CreateTestForUser(_unitOfWork, value, "Step Test wg CPHA", "poniżej średniej");
//                    }
//                    else if (value < 131)
//                    {
//                        return CreateTestForUser(_unitOfWork, value, "Step Test wg CPHA", "słaby");
//                    }
//                    else if (value >= 131)
//                    {
//                        return CreateTestForUser(_unitOfWork, value, "Step Test wg CPHA", "bardzo słaby");
//                    }
//                }
//            }
//            return "Nie zostały podane odpowiednie dane do obliczenia wyniku testu";
//        }

//        private static string TestBrzuszkow(IUnitOfWork _unitOfWork, double value, double age, bool sex)
//        {
//            if (sex == false)
//            {
//                if (age < 20)
//                {
//                    if (value < 20)
//                    {
//                        return CreateTestForUser(_unitOfWork, value, "Test brzuszków wg IFA", "bardzo słaby");
//                    }
//                    else if (value < 28)
//                    {
//                        return CreateTestForUser(_unitOfWork, value, "Test brzuszków wg IFA", "słaby");

//                    }
//                    else if (value < 32)
//                    {
//                        return CreateTestForUser(_unitOfWork, value, "Test brzuszków wg IFA", "średni");
//                    }
//                    else if (value < 42)
//                    {
//                        return CreateTestForUser(_unitOfWork, value, "Test brzuszków wg IFA", "dobry");
//                    }
//                    else if (value >= 42)
//                    {
//                        return CreateTestForUser(_unitOfWork, value, "Test brzuszków wg IFA", "bardzo dobry");
//                    }

//                }
//                else if (age < 30)
//                {
//                    if (value < 17)
//                    {
//                        return CreateTestForUser(_unitOfWork, value, "Test brzuszków wg IFA", "bardzo słaby");
//                    }
//                    else if (value < 25)
//                    {
//                        return CreateTestForUser(_unitOfWork, value, "Test brzuszków wg IFA", "słaby");

//                    }
//                    else if (value < 28)
//                    {
//                        return CreateTestForUser(_unitOfWork, value, "Test brzuszków wg IFA", "średni");
//                    }
//                    else if (value < 37)
//                    {
//                        return CreateTestForUser(_unitOfWork, value, "Test brzuszków wg IFA", "dobry");
//                    }
//                    else if (value >= 37)
//                    {
//                        return CreateTestForUser(_unitOfWork, value, "Test brzuszków wg IFA", "bardzo dobry");
//                    }
//                }
//                else if (age < 40)
//                {
//                    if (value < 12)
//                    {
//                        return CreateTestForUser(_unitOfWork, value, "Test brzuszków wg IFA", "bardzo słaby");
//                    }
//                    else if (value < 19)
//                    {
//                        return CreateTestForUser(_unitOfWork, value, "Test brzuszków wg IFA", "słaby");

//                    }
//                    else if (value < 22)
//                    {
//                        return CreateTestForUser(_unitOfWork, value, "Test brzuszków wg IFA", "średni");
//                    }
//                    else if (value < 31)
//                    {
//                        return CreateTestForUser(_unitOfWork, value, "Test brzuszków wg IFA", "dobry");
//                    }
//                    else if (value >= 31)
//                    {
//                        return CreateTestForUser(_unitOfWork, value, "Test brzuszków wg IFA", "bardzo dobry");
//                    }
//                }
//                else if (age < 50)
//                {
//                    if (value < 8)
//                    {
//                        return CreateTestForUser(_unitOfWork, value, "Test brzuszków wg IFA", "bardzo słaby");
//                    }
//                    else if (value < 15)
//                    {
//                        return CreateTestForUser(_unitOfWork, value, "Test brzuszków wg IFA", "słaby");

//                    }
//                    else if (value < 18)
//                    {
//                        return CreateTestForUser(_unitOfWork, value, "Test brzuszków wg IFA", "średni");
//                    }
//                    else if (value < 27)
//                    {
//                        return CreateTestForUser(_unitOfWork, value, "Test brzuszków wg IFA", "dobry");
//                    }
//                    else if (value >= 27)
//                    {
//                        return CreateTestForUser(_unitOfWork, value, "Test brzuszków wg IFA", "bardzo dobry");
//                    }
//                }
//                else if (age < 60)
//                {
//                    if (value < 5)
//                    {
//                        return CreateTestForUser(_unitOfWork, value, "Test brzuszków wg IFA", "bardzo słaby");
//                    }
//                    else if (value < 11)
//                    {
//                        return CreateTestForUser(_unitOfWork, value, "Test brzuszków wg IFA", "słaby");

//                    }
//                    else if (value < 14)
//                    {
//                        return CreateTestForUser(_unitOfWork, value, "Test brzuszków wg IFA", "średni");
//                    }
//                    else if (value < 21)
//                    {
//                        return CreateTestForUser(_unitOfWork, value, "Test brzuszków wg IFA", "dobry");
//                    }
//                    else if (value >= 21)
//                    {
//                        return CreateTestForUser(_unitOfWork, value, "Test brzuszków wg IFA", "bardzo dobry");
//                    }
//                }
//                else if (age >= 60)
//                {
//                    if (value < 4)
//                    {
//                        return CreateTestForUser(_unitOfWork, value, "Test brzuszków wg IFA", "bardzo słaby");
//                    }
//                    else if (value < 10)
//                    {
//                        return CreateTestForUser(_unitOfWork, value, "Test brzuszków wg IFA", "słaby");

//                    }
//                    else if (value < 13)
//                    {
//                        return CreateTestForUser(_unitOfWork, value, "Test brzuszków wg IFA", "średni");
//                    }
//                    else if (value < 20)
//                    {
//                        return CreateTestForUser(_unitOfWork, value, "Test brzuszków wg IFA", "dobry");
//                    }
//                    else if (value >= 20)
//                    {
//                        return CreateTestForUser(_unitOfWork, value, "Test brzuszków wg IFA", "bardzo dobry");
//                    }
//                }

//            }
//            else
//            {
//                if (age < 20)
//                {

//                    if (value < 31)
//                    {
//                        return CreateTestForUser(_unitOfWork, value, "Test brzuszków wg IFA", "bardzo słaby");
//                    }
//                    else if (value < 38)
//                    {
//                        return CreateTestForUser(_unitOfWork, value, "Test brzuszków wg IFA", "słaby");

//                    }
//                    else if (value < 41)
//                    {
//                        return CreateTestForUser(_unitOfWork, value, "Test brzuszków wg IFA", "średni");
//                    }
//                    else if (value < 51)
//                    {
//                        return CreateTestForUser(_unitOfWork, value, "Test brzuszków wg IFA", "dobry");
//                    }
//                    else if (value >= 51)
//                    {
//                        return CreateTestForUser(_unitOfWork, value, "Test brzuszków wg IFA", "bardzo dobry");
//                    }
//                }
//                else if (age < 30)
//                {
//                    if (value < 26)
//                    {
//                        return CreateTestForUser(_unitOfWork, value, "Test brzuszków wg IFA", "bardzo słaby");
//                    }
//                    else if (value < 34)
//                    {
//                        return CreateTestForUser(_unitOfWork, value, "Test brzuszków wg IFA", "słaby");

//                    }
//                    else if (value < 37)
//                    {
//                        return CreateTestForUser(_unitOfWork, value, "Test brzuszków wg IFA", "średni");
//                    }
//                    else if (value < 47)
//                    {
//                        return CreateTestForUser(_unitOfWork, value, "Test brzuszków wg IFA", "dobry");
//                    }
//                    else if (value >= 47)
//                    {
//                        return CreateTestForUser(_unitOfWork, value, "Test brzuszków wg IFA", "bardzo dobry");
//                    }
//                }
//                else if (age < 40)
//                {
//                    if (value < 21)
//                    {
//                        return CreateTestForUser(_unitOfWork, value, "Test brzuszków wg IFA", "bardzo słaby");
//                    }
//                    else if (value < 28)
//                    {
//                        return CreateTestForUser(_unitOfWork, value, "Test brzuszków wg IFA", "słaby");

//                    }
//                    else if (value < 31)
//                    {
//                        return CreateTestForUser(_unitOfWork, value, "Test brzuszków wg IFA", "średni");
//                    }
//                    else if (value < 40)
//                    {
//                        return CreateTestForUser(_unitOfWork, value, "Test brzuszków wg IFA", "dobry");
//                    }
//                    else if (value >= 40)
//                    {
//                        return CreateTestForUser(_unitOfWork, value, "Test brzuszków wg IFA", "bardzo dobry");
//                    }
//                }
//                else if (age < 50)
//                {
//                    if (value < 17)
//                    {
//                        return CreateTestForUser(_unitOfWork, value, "Test brzuszków wg IFA", "bardzo słaby");
//                    }
//                    else if (value < 24)
//                    {
//                        return CreateTestForUser(_unitOfWork, value, "Test brzuszków wg IFA", "słaby");

//                    }
//                    else if (value < 26)
//                    {
//                        return CreateTestForUser(_unitOfWork, value, "Test brzuszków wg IFA", "średni");
//                    }
//                    else if (value < 35)
//                    {
//                        return CreateTestForUser(_unitOfWork, value, "Test brzuszków wg IFA", "dobry");
//                    }
//                    else if (value >= 25)
//                    {
//                        return CreateTestForUser(_unitOfWork, value, "Test brzuszków wg IFA", "bardzo dobry");
//                    }
//                }
//                else if (age < 60)
//                {
//                    if (value < 12)
//                    {
//                        return CreateTestForUser(_unitOfWork, value, "Test brzuszków wg IFA", "bardzo słaby");
//                    }
//                    else if (value < 19)
//                    {
//                        return CreateTestForUser(_unitOfWork, value, "Test brzuszków wg IFA", "słaby");

//                    }
//                    else if (value < 22)
//                    {
//                        return CreateTestForUser(_unitOfWork, value, "Test brzuszków wg IFA", "średni");
//                    }
//                    else if (value < 30)
//                    {
//                        return CreateTestForUser(_unitOfWork, value, "Test brzuszków wg IFA", "dobry");
//                    }
//                    else if (value >= 30)
//                    {
//                        return CreateTestForUser(_unitOfWork, value, "Test brzuszków wg IFA", "bardzo dobry");
//                    }
//                }
//                else if (age >= 60)
//                {
//                    if (value < 10)
//                    {
//                        return CreateTestForUser(_unitOfWork, value, "Test brzuszków wg IFA", "bardzo słaby");
//                    }
//                    else if (value < 17)
//                    {
//                        return CreateTestForUser(_unitOfWork, value, "Test brzuszków wg IFA", "słaby");

//                    }
//                    else if (value < 20)
//                    {
//                        return CreateTestForUser(_unitOfWork, value, "Test brzuszków wg IFA", "średni");
//                    }
//                    else if (value < 29)
//                    {
//                        return CreateTestForUser(_unitOfWork, value, "Test brzuszków wg IFA", "dobry");
//                    }
//                    else if (value >= 29)
//                    {
//                        return CreateTestForUser(_unitOfWork, value, "Test brzuszków wg IFA", "bardzo dobry");
//                    }
//                }

//            }
//            return "Nie zostały podane odpowiednie dane do obliczenia wyniku testu";
//        }

//        private static string TestPompkowy(IUnitOfWork _unitOfWork, double value, double age, bool sex)
//        {

//            if (sex == false)
//            {
//                if (age < 20)
//                {
//                    if (value < 9)
//                    {
//                        return CreateTestForUser(_unitOfWork, value, "Test pompkowy wg IFA", "bardzo słaby");
//                    }
//                    else if (value < 17)
//                    {
//                        return CreateTestForUser(_unitOfWork, value, "Test pompkowy wg IFA", "słaby");

//                    }
//                    else if (value < 21)
//                    {
//                        return CreateTestForUser(_unitOfWork, value, "Test pompkowy wg IFA", "średni");
//                    }
//                    else if (value < 31)
//                    {
//                        return CreateTestForUser(_unitOfWork, value, "Test pompkowy wg IFA", "dobry");
//                    }
//                    else if (value >= 31)
//                    {
//                        return CreateTestForUser(_unitOfWork, value, "Test pompkowy wg IFA", "bardzo dobry");
//                    }

//                }
//                else if (age < 30)
//                {
//                    if (value < 8)
//                    {
//                        return CreateTestForUser(_unitOfWork, value, "Test pompkowy wg IFA", "bardzo słaby");
//                    }
//                    else if (value < 16)
//                    {
//                        return CreateTestForUser(_unitOfWork, value, "Test pompkowy wg IFA", "słaby");

//                    }
//                    else if (value < 19)
//                    {
//                        return CreateTestForUser(_unitOfWork, value, "Test pompkowy wg IFA", "średni");
//                    }
//                    else if (value < 30)
//                    {
//                        return CreateTestForUser(_unitOfWork, value, "Test pompkowy wg IFA", "dobry");
//                    }
//                    else if (value >= 30)
//                    {
//                        return CreateTestForUser(_unitOfWork, value, "Test pompkowy wg IFA", "bardzo dobry");
//                    }
//                }
//                else if (age < 40)
//                {
//                    if (value < 5)
//                    {
//                        return CreateTestForUser(_unitOfWork, value, "Test pompkowy wg IFA", "bardzo słaby");
//                    }
//                    else if (value < 14)
//                    {
//                        return CreateTestForUser(_unitOfWork, value, "Test pompkowy wg IFA", "słaby");

//                    }
//                    else if (value < 18)
//                    {
//                        return CreateTestForUser(_unitOfWork, value, "Test pompkowy wg IFA", "średni");
//                    }
//                    else if (value < 29)
//                    {
//                        return CreateTestForUser(_unitOfWork, value, "Test pompkowy wg IFA", "dobry");
//                    }
//                    else if (value >= 29)
//                    {
//                        return CreateTestForUser(_unitOfWork, value, "Test pompkowy wg IFA", "bardzo dobry");
//                    }
//                }
//                else if (age < 50)
//                {
//                    if (value < 4)
//                    {
//                        return CreateTestForUser(_unitOfWork, value, "Test pompkowy wg IFA", "bardzo słaby");
//                    }
//                    else if (value < 12)
//                    {
//                        return CreateTestForUser(_unitOfWork, value, "Test pompkowy wg IFA", "słaby");

//                    }
//                    else if (value < 15)
//                    {
//                        return CreateTestForUser(_unitOfWork, value, "Test pompkowy wg IFA", "średni");
//                    }
//                    else if (value < 24)
//                    {
//                        return CreateTestForUser(_unitOfWork, value, "Test pompkowy wg IFA", "dobry");
//                    }
//                    else if (value >= 24)
//                    {
//                        return CreateTestForUser(_unitOfWork, value, "Test pompkowy wg IFA", "bardzo dobry");
//                    }
//                }
//                else if (age < 60)
//                {
//                    if (value < 3)
//                    {
//                        return CreateTestForUser(_unitOfWork, value, "Test pompkowy wg IFA", "bardzo słaby");
//                    }
//                    else if (value < 10)
//                    {
//                        return CreateTestForUser(_unitOfWork, value, "Test pompkowy wg IFA", "słaby");

//                    }
//                    else if (value < 13)
//                    {
//                        return CreateTestForUser(_unitOfWork, value, "Test pompkowy wg IFA", "średni");
//                    }
//                    else if (value < 20)
//                    {
//                        return CreateTestForUser(_unitOfWork, value, "Test pompkowy wg IFA", "dobry");
//                    }
//                    else if (value >= 20)
//                    {
//                        return CreateTestForUser(_unitOfWork, value, "Test pompkowy wg IFA", "bardzo dobry");
//                    }
//                }
//                else if (age >= 60)
//                {
//                    if (value < 2)
//                    {
//                        return CreateTestForUser(_unitOfWork, value, "Test pompkowy wg IFA", "bardzo słaby");
//                    }
//                    else if (value < 8)
//                    {
//                        return CreateTestForUser(_unitOfWork, value, "Test pompkowy wg IFA", "słaby");

//                    }
//                    else if (value < 11)
//                    {
//                        return CreateTestForUser(_unitOfWork, value, "Test pompkowy wg IFA", "średni");
//                    }
//                    else if (value < 18)
//                    {
//                        return CreateTestForUser(_unitOfWork, value, "Test pompkowy wg IFA", "dobry");
//                    }
//                    else if (value >= 18)
//                    {
//                        return CreateTestForUser(_unitOfWork, value, "Test pompkowy wg IFA", "bardzo dobry");
//                    }
//                }

//            }
//            else
//            {
//                if (age < 20)
//                {

//                    if (value < 15)
//                    {
//                        return CreateTestForUser(_unitOfWork, value, "Test pompkowy wg IFA", "bardzo słaby");
//                    }
//                    else if (value < 25)
//                    {
//                        return CreateTestForUser(_unitOfWork, value, "Test pompkowy wg IFA", "słaby");

//                    }
//                    else if (value < 30)
//                    {
//                        return CreateTestForUser(_unitOfWork, value, "Test pompkowy wg IFA", "średni");
//                    }
//                    else if (value < 45)
//                    {
//                        return CreateTestForUser(_unitOfWork, value, "Test pompkowy wg IFA", "dobry");
//                    }
//                    else if (value >= 45)
//                    {
//                        return CreateTestForUser(_unitOfWork, value, "Test pompkowy wg IFA", "bardzo dobry");
//                    }
//                }
//                else if (age < 30)
//                {
//                    if (value < 12)
//                    {
//                        return CreateTestForUser(_unitOfWork, value, "Test pompkowy wg IFA", "bardzo słaby");
//                    }
//                    else if (value < 22)
//                    {
//                        return CreateTestForUser(_unitOfWork, value, "Test pompkowy wg IFA", "słaby");

//                    }
//                    else if (value < 26)
//                    {
//                        return CreateTestForUser(_unitOfWork, value, "Test pompkowy wg IFA", "średni");
//                    }
//                    else if (value < 39)
//                    {
//                        return CreateTestForUser(_unitOfWork, value, "Test pompkowy wg IFA", "dobry");
//                    }
//                    else if (value >= 39)
//                    {
//                        return CreateTestForUser(_unitOfWork, value, "Test pompkowy wg IFA", "bardzo dobry");
//                    }
//                }
//                else if (age < 40)
//                {
//                    if (value < 10)
//                    {
//                        return CreateTestForUser(_unitOfWork, value, "Test pompkowy wg IFA", "bardzo słaby");
//                    }
//                    else if (value < 18)
//                    {
//                        return CreateTestForUser(_unitOfWork, value, "Test pompkowy wg IFA", "słaby");

//                    }
//                    else if (value < 22)
//                    {
//                        return CreateTestForUser(_unitOfWork, value, "Test pompkowy wg IFA", "średni");
//                    }
//                    else if (value < 33)
//                    {
//                        return CreateTestForUser(_unitOfWork, value, "Test pompkowy wg IFA", "dobry");
//                    }
//                    else if (value >= 3)
//                    {
//                        return CreateTestForUser(_unitOfWork, value, "Test pompkowy wg IFA", "bardzo dobry");
//                    }
//                }
//                else if (age < 50)
//                {
//                    if (value < 7)
//                    {
//                        return CreateTestForUser(_unitOfWork, value, "Test pompkowy wg IFA", "bardzo słaby");
//                    }
//                    else if (value < 15)
//                    {
//                        return CreateTestForUser(_unitOfWork, value, "Test pompkowy wg IFA", "słaby");

//                    }
//                    else if (value < 18)
//                    {
//                        return CreateTestForUser(_unitOfWork, value, "Test pompkowy wg IFA", "średni");
//                    }
//                    else if (value < 26)
//                    {
//                        return CreateTestForUser(_unitOfWork, value, "Test pompkowy wg IFA", "dobry");
//                    }
//                    else if (value >= 26)
//                    {
//                        return CreateTestForUser(_unitOfWork, value, "Test pompkowy wg IFA", "bardzo dobry");
//                    }
//                }
//                else if (age < 60)
//                {
//                    if (value < 5)
//                    {
//                        return CreateTestForUser(_unitOfWork, value, "Test pompkowy wg IFA", "bardzo słaby");
//                    }
//                    else if (value < 12)
//                    {
//                        return CreateTestForUser(_unitOfWork, value, "Test pompkowy wg IFA", "słaby");

//                    }
//                    else if (value < 15)
//                    {
//                        return CreateTestForUser(_unitOfWork, value, "Test pompkowy wg IFA", "średni");
//                    }
//                    else if (value < 24)
//                    {
//                        return CreateTestForUser(_unitOfWork, value, "Test pompkowy wg IFA", "dobry");
//                    }
//                    else if (value >= 24)
//                    {
//                        return CreateTestForUser(_unitOfWork, value, "Test pompkowy wg IFA", "bardzo dobry");
//                    }
//                }
//                else if (age >= 60)
//                {
//                    if (value < 3)
//                    {
//                        return CreateTestForUser(_unitOfWork, value, "Test pompkowy wg IFA", "bardzo słaby");
//                    }
//                    else if (value < 10)
//                    {
//                        return CreateTestForUser(_unitOfWork, value, "Test pompkowy wg IFA", "słaby");

//                    }
//                    else if (value < 14)
//                    {
//                        return CreateTestForUser(_unitOfWork, value, "Test pompkowy wg IFA", "średni");
//                    }
//                    else if (value < 23)
//                    {
//                        return CreateTestForUser(_unitOfWork, value, "Test pompkowy wg IFA", "dobry");
//                    }
//                    else if (value >= 23)
//                    {
//                        return CreateTestForUser(_unitOfWork, value, "Test pompkowy wg IFA", "bardzo dobry");
//                    }
//                }

//            }
//            return "Nie zostały podane odpowiednie dane do obliczenia wyniku testu";
//        }
      




//    }
//}