using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using BusinessAndDataLogic;
using CMSSchedules;
using CMSTopics;

namespace churchmanagementsystem 
{
    internal class Program
    {
        static BusinessAndDataLogic.CMSProcess cmsProcess = new CMSProcess();
        static void Main(string[] args)
        {
            DisplayDashboard();
        }
        static void DisplayDashboard()
        {
            //UI Logic
            Console.Clear();
            Console.WriteLine("\nWELCOME TO ADELINA CHRISTIAN CHURCH");
            DisplayLine();
            Console.WriteLine("[1] Register");
            Console.WriteLine("[2] Log in");
            Console.WriteLine("[3] Log in as an Admin (Leader)");
            Console.WriteLine("[4] Exit");

            int userChoice;
            do
            {
                userChoice = UserChoice();
                if (userChoice == 1)
                {
                    RegisterUser();
                }
                else if (userChoice == 2)
                {
                    DisplayLine();
                    SignInUser(false);
                    break;
                }
                else if (userChoice == 3)
                {
                    DisplayLine();
                    SignInUser(true);
                    break;
                }
                else if (userChoice == 4)
                {
                    Console.Write("Closing the program...");
                    Thread.Sleep(3000);
                    Environment.Exit(0);
                    break;
                }
                else
                {
                    Console.WriteLine("Error: User Input exceed 1-3 Options");
                }
            } while (userChoice > 3 || userChoice < 1);

        }      
        static void DisplayLine()
        {
            Console.WriteLine("------------------------------------");
        }
        static void RegisterUser()
        {
            //UI
            Console.WriteLine("\nREGISTRATION");
            DisplayLine();

            string firstName = NoNullOrEmptyInput("First Name: ");
            string lastName = NoNullOrEmptyInput("Last Name: ");
            Console.Write("Age: ");
            int age = Convert.ToInt16(Console.ReadLine());
            string emailAddress = NoNullOrEmptyInput("Email Address: ");

            Console.WriteLine("Are you an Officer/Admin? [1]Yes [2]No: ");
            int positionChoice = UserChoice();
           
            string username = CreateUsername();
            string password = CreatePassword();
            bool isAdmin = positionChoice == 1; // means the user is admin
            if (isAdmin)
            {
                string ministryName = NoNullOrEmptyInput("Ministry Name: ");
                string position = NoNullOrEmptyInput("Your Position: ");
                cmsProcess.RegisteringAdminAccounts(firstName, lastName, age, emailAddress, ministryName, position, username, password);
                
            } else
            {
                cmsProcess.RegisteringRegularAccounts(firstName, lastName, age, emailAddress, username, password);
            }

            Console.WriteLine("Registration Complete");
            DisplayDashboard();
        }
        
        static string CreateUsername()
        {
            string username = NoNullOrEmptyInput("Create Username: ");
            return username;
        }
        static string CreatePassword()
        {
            while (true)
            {
                string password = NoNullOrEmptyInput("Create Password: ");
                string re_Enter_Password = NoNullOrEmptyInput("Re-Enter Password: ");

                if (CMSProcess.CheckPasswordMatch(password, re_Enter_Password))
                {
                    return password;
                }
                Console.WriteLine("Password do not Match. Try again.");

            }
        }
        static void SignInUser(bool isAdmin)
        {
            int attempt = 0;
            int maxAttempt = 3;

            while (attempt < maxAttempt)
            {
                string username = NoNullOrEmptyInput("Username: ");
                string password = NoNullOrEmptyInput("Password: ");

                string role = cmsProcess.ValidatingUserRole(username, password);
              
                switch (isAdmin)
                {
                    case true:
                        if (role == "Admin")
                        {
                            Console.WriteLine("Login Successful!");
                            string ministryName = cmsProcess.ValidatingAdminMinistry(username, password);
                            Console.Clear();
                            DisplayAdminOptions(ministryName);
                            return;
                        }else
                        {
                            Console.WriteLine("Error Admin Login");
                        }
                        break;
                    case false:
                        if (role == "User")
                        {
                            Console.WriteLine("Login Successful!");
                            Console.Clear();
                    
                            return;
                        }else
                        {
                            Console.WriteLine("Error User Login");
                        }
                        break;
                    default:
                        throw new Exception ("account does not exist");
                    }
   

                    attempt++;
                Console.WriteLine($"Wrong Username or Password. Attempts left: {maxAttempt - attempt}");
            }
            Console.Write("Maximum attempts reached. Try again later.");
            Thread.Sleep(2000);
            DisplayDashboard();
        }

        //UI
        static void DisplayAdminOptions(string ministryName)
        {
            
            if(ministryName == "Discipleship Ministry")
            {
                DiscipleshipAdminDashboard(ministryName);
            } else if (ministryName == "Prayer Ministry")
            {
                PrayerAdminDashboard(ministryName);
            } else if (ministryName == "Worship Ministry")
            {
                WorshipAdminDashboard(ministryName);
            } else if (ministryName == "Christian Education")
            {
                ChristianEdAdminDashboard(ministryName);
            } else
            {
                Console.WriteLine("Invalid Ministry Name");
            }

        }

        //Disicipleship Ministry UI
        static void DiscipleshipAdminDashboard(string ministryName)
        {
            Console.WriteLine($"WELCOME TO {ministryName}");

            Console.WriteLine("[1] Schedule Training [2] Log Out");
            int userChoice = UserChoice();

            if (userChoice == 1)
            {
                var action = CRUDOptions();
                if (action == 1)
                {
                    Console.WriteLine("----------------------------------");
                    DiscipleshipViewSchedule(ministryName);
                } else if (action == 2)
                {
                    Console.WriteLine("----------------------------------");
                    DiscipleshipAddSchedule(ministryName);
                } else if (action == 3)
                {
                    Console.WriteLine("----------------------------------");
                    DiscipleshipRemoveSchedule(ministryName);
                } else
                {
                    Console.WriteLine("invalid input");
                }
            } else if (userChoice == 2)
            {
                Console.Clear();
                DisplayDashboard();
            } else
            {
                Console.WriteLine("Invalid Input");
            }
        }
        static void DiscipleshipViewSchedule(string ministryName)
        {
            Console.Clear();
            Console.WriteLine("Discipleship Training Schedule");

            foreach(var sched in cmsProcess.ViewDiscipleshipSchedule())
            {
                Console.WriteLine($"Date: {sched.Date}");
                Console.WriteLine($"Speaker: {sched.Speaker}");
                Console.WriteLine($"Description: {sched.Description}");
                Console.WriteLine($"Note/Reminder: {sched.Note}");
            }
            Console.WriteLine("----------------------------------");
            DiscipleshipAdminDashboard(ministryName);
        }
        static void DiscipleshipAddSchedule(string ministryName)
        {
            Console.Clear();
            Console.WriteLine("Provide the Need Details!!!");
            string date = NoNullOrEmptyInput("Date: ");
            string speaker = NoNullOrEmptyInput("Speaker: ");
            string description = NoNullOrEmptyInput("Description: ");
            string note = NoNullOrEmptyInput("Note/Reminder: ");

            bool isAdded = cmsProcess.AddDicipleshipSched(date, speaker, description, note);
            Console.WriteLine(isAdded ? "Added Successfully" : "Failed to Add Schedule");

            Console.WriteLine("----------------------------------");
            DiscipleshipAdminDashboard(ministryName);
        }
        static void DiscipleshipRemoveSchedule(string ministryName)
        {
            Console.Clear();
            Console.WriteLine("Enter Schedule Date");
            Console.WriteLine("MM-DD-YYYY");
            string date = Console.ReadLine();

            bool isDeleted = cmsProcess.RemoveDiscipleSched(date);
            Console.WriteLine(isDeleted ? "Schedule Deleted Successfully" : "Failed to Delete Schedule");

            Console.WriteLine("----------------------------------");
            DiscipleshipAdminDashboard(ministryName);
        }

        //prayer ministry UI
        static void PrayerAdminDashboard(string ministryName)
        {
            Console.WriteLine($"WELCOME TO {ministryName}");

            Console.WriteLine("[1] Schedule Prayer Meeting [2] Set Prayer Item [3] Log out");
            int userChoice = UserChoice();

            if (userChoice == 1)
            {
                var action = CRUDOptions();
                if (action == 1)
                {
                    Console.WriteLine("----------------------------------");
                    PrayerViewSchedule(ministryName);
                }
                else if (action == 2)
                {
                    Console.WriteLine("----------------------------------");
                    PrayerAddSchedule(ministryName);
                }
                else if (action == 3)
                {
                    Console.WriteLine("----------------------------------");
                    PrayerRemoveSchedule(ministryName);
                }
                else
                {
                    Console.WriteLine("invalid input");
                }

            } else if (userChoice == 2)
            {
                var action = CRUDOptions();
                if(action == 1)
                {

                }
                else if(action == 2)
                {
                    Console.WriteLine("----------------------------------");
                    SetPrayerItem(ministryName);
                }else if (action == 3)
                {

                } else
                {
                    Console.WriteLine("Invalid Input");
                }
            }
            else if (userChoice == 3)
            {
                Console.Clear();
                DisplayDashboard();
            }
            else
            {
                Console.WriteLine("Invalid Input");
            }
        }
        static void PrayerViewSchedule(string ministryName)
        {
            Console.Clear();
            Console.WriteLine("Prayer Meeting Schedule");

            foreach (var sched in cmsProcess.ViewPrayerSched())
            {
                Console.WriteLine($"Date: {sched.Date}");
                Console.WriteLine($"Song Leader: {sched.SongLeader}");
                Console.WriteLine($"Presider: {sched.Presider}");
                Console.WriteLine($"Speaker: {sched.Speaker}");
                Console.WriteLine("----------------------------------");
            }
            Thread.Sleep(1000);
            Console.WriteLine("----------------------------------");
            PrayerAdminDashboard(ministryName);
        }
        static void PrayerAddSchedule(string ministryName)
        {
            Console.Clear();
            Console.WriteLine("Provide the Need Details!!!");
            string date = NoNullOrEmptyInput("Date: ");
            string songLeader = NoNullOrEmptyInput("Song Leader: ");
            string presider = NoNullOrEmptyInput("Presider: ");
            string speaker = NoNullOrEmptyInput("Speaker: ");
            
            bool isAdded = cmsProcess.AddPrayerSched(date, songLeader, presider, speaker);
            Console.WriteLine(isAdded ? "Added Successfully" : "Failed to Add Schedule");

            Console.WriteLine("----------------------------------");
            PrayerAdminDashboard(ministryName);
        }
        static void PrayerRemoveSchedule(string ministryName)
        {
            Console.Clear();
            Console.WriteLine("Enter Schedule Date");
            Console.WriteLine("MM-DD-YYYY");
            string date = Console.ReadLine();

            bool isDeleted = cmsProcess.RemovePrayerSched(date);
            Console.WriteLine(isDeleted ? "Schedule Deleted Successfully" : "Failed to Delete Schedule");

            Console.WriteLine("----------------------------------");
            PrayerAdminDashboard(ministryName);
        }
        static void SetPrayerItem(string ministryName)
        {
            Console.Clear();
            string date = NoNullOrEmptyInput("Enter Date: ");
            string prayerItem = NoNullOrEmptyInput("Prayer Item: ");

            bool isSet = cmsProcess.SetPrayerItem(date, prayerItem);
            Console.WriteLine(isSet ? "Prayer Item Successfully Set" : "Failed to Set Prayer Item");

            Console.WriteLine("----------------------------------");
            PrayerAdminDashboard(ministryName);
        }

        //worship ministry dashboard
        static void WorshipAdminDashboard(string ministryName)
        {
            Console.Clear();
            Console.WriteLine($"WELCOME TO {ministryName}");

            Console.WriteLine("[1] Praise and Worship [2] Sunday Worship Service [3] Devotion [4] Log out");
            int userChoice = UserChoice();

            switch (userChoice)
            {
                case 1:
                    PraiseAndWorshipDashboard(ministryName);
                    break;
                case 2:
                    SundayWorshipServiceDashboard(ministryName);
                    break;
                case 3:
                    DevotionDashboard(ministryName);
                    break;
                case 4:
                    DisplayDashboard();
                    break;
                default:
                    Console.WriteLine("Invalid Input");
                    break;
            }

        }
        //worship - praise and worship
        static void PraiseAndWorshipDashboard(string ministryName)
        {
            Console.WriteLine("Praise and Worship Dashboard");
            
            int option = CRUDOptions();
            if (option == 1)
            {
                DisplayPraiseAndWorshipSchedule(ministryName);
            }
            else if (option == 2)
            {
                SchedulePraiseAndWorship(ministryName);
            }
            else if (option == 3)
            {
                RemovePraiseAndWorshipSchedule(ministryName);
            }
            else if (option == 4)
            {
                WorshipAdminDashboard(ministryName);
            }
            else
            {
                Console.WriteLine("Invalid Input");
            }

        }
        static void DisplayPraiseAndWorshipSchedule(string ministryName)
        {
            Console.Clear();
            Console.WriteLine("Praise and Worship Schedules");
            foreach (var sched in cmsProcess.ViewPraiseAndWorshipSched())
            {
                Console.WriteLine($"Date: {sched.Date}");
                Console.WriteLine($"Song Leader: {sched.SongLeader}");
                Console.WriteLine($"Instrumentalist: {sched.Instrumentalist}");
                Console.WriteLine("----------------------------------");
            }

            Console.WriteLine("----------------------------------");
            Thread.Sleep(1000);
            PraiseAndWorshipDashboard(ministryName);
        }
        static void SchedulePraiseAndWorship(string ministryName)
        {
            Console.Clear();
            Console.WriteLine("Praise and Worship Schedule");
            string date = NoNullOrEmptyInput("Date: ");
            string songLeader = NoNullOrEmptyInput("Song Leader: ");
            string instrumentalist = NoNullOrEmptyInput("Instrumentalist: ");

            bool isAdded = cmsProcess.AddPraiseAndWorshipSched(date, songLeader, instrumentalist);
            Console.WriteLine(isAdded ? "Schedule Added Successfully" : "Schedule Failed to Add");

            Console.WriteLine("----------------------------------");
            PraiseAndWorshipDashboard(ministryName);
        }
        static void RemovePraiseAndWorshipSchedule(string ministryName)
        {
            Console.Clear();
            string date = NoNullOrEmptyInput("Enter Date (MM-DD-YYYY): ");

            bool isDeleted = cmsProcess.RemovePraiseAndWorshipSched(date);
            Console.WriteLine(isDeleted ? "Schedule Deleted Successfully" : "Failed to Delete Schedule");

            Console.WriteLine("----------------------------------");
            PraiseAndWorshipDashboard(ministryName);
        }

        //worship - sunday worship service
        static void SundayWorshipServiceDashboard(string ministryName)
        {
            Console.WriteLine("Sunday Worship Service Dashboard");

            int option = CRUDOptions();
            if (option == 1)
            {
                DisplaySundayWorshipSchedule(ministryName);
            }
            else if (option == 2)
            {
                ScheduleSundayWorshipService(ministryName);
            }
            else if (option == 3)
            {
                RemoveSundayWorshipSched(ministryName);
            }
            else if (option == 4)
            {
                WorshipAdminDashboard(ministryName);
            }
            else
            {
                Console.WriteLine("Invalid Input");
            }
        }
        static void DisplaySundayWorshipSchedule(string ministryName)
        {
            Console.Clear();
            Console.WriteLine("Sunday Worship Schedules");
            foreach (var sched in cmsProcess.ViewSundayWorshipSched())
            {
                Console.WriteLine($"Date: {sched.Date}");
                Console.WriteLine($"Presider: {sched.Presider}");
                Console.WriteLine($"Speaker: {sched.Speaker}");
                Console.WriteLine($"Flowers: {sched.Flowers}");
                Console.WriteLine($"Ushers: {sched.Ushers}");
            }
            Thread.Sleep(1000);
            Console.WriteLine("----------------------------------");

            SundayWorshipServiceDashboard(ministryName);
        }
        static void ScheduleSundayWorshipService(string ministryName)
        {
            Console.Clear();
            string date = NoNullOrEmptyInput("Enter Date: ");
            string presider = NoNullOrEmptyInput("Presider: ");
            string speaker = NoNullOrEmptyInput("Speaker: ");
            string flowers = NoNullOrEmptyInput("Flowers for the Lord: ");
            string ushers = NoNullOrEmptyInput("Ushers: ");
            //note: also need to get the scheduled song leader and band of praise and worship

            bool isAdded = cmsProcess.AddSundayWorshipServiceSched(date, presider, speaker, flowers, ushers);
            Console.WriteLine(isAdded ? "Added Successfully" : "Failed to Add Schedule");

            Console.WriteLine("----------------------------------");
            SundayWorshipServiceDashboard(ministryName);
        }
        static void RemoveSundayWorshipSched(string ministryName)
        {
            Console.Clear();
            string date = NoNullOrEmptyInput("Enter Exact Date: ");

            bool isDeleted = cmsProcess.RemoveSundayWorshipSched(date);
            Console.WriteLine(isDeleted ? "Schedule Deleted Successfully" : "Failed to Delete Schedule");

            Console.WriteLine("----------------------------------");
            SundayWorshipServiceDashboard(ministryName);
        }
        //worship - devotion
        static void DevotionDashboard(string ministryName)
        {
            Console.WriteLine("Devotion Dashboard");

            int option = CRUDOptions();
            if (option == 1)
            {
                //view
                DisplayDevotionSched(ministryName);
            }
            else if (option == 2)
            {
                //schedule
                AddDevotionSchedule(ministryName);
            }
            else if (option == 3)
            {
                //remove
                RemoveDevotionSched(ministryName);
            }
            else if (option == 4)
            {
                WorshipAdminDashboard(ministryName);
            }
            else
            {
                Console.WriteLine("Invalid Input");
            }

        }
        static void DisplayDevotionSched(string ministryName)
        {
            Console.Clear();
            Console.WriteLine("Devotion Schedules");
            foreach (var sched in cmsProcess.ViewDevotionSched())
            {
                Console.WriteLine($"Date: {sched.Date}");
                Console.WriteLine($"Song Leader: {sched.SongLeader}");
                Console.WriteLine($"Presider: {sched.Presider}");
                Console.WriteLine($"Speaker: {sched.Speaker}");
            }
            Thread.Sleep(1000);
            Console.WriteLine("----------------------------------");
            DevotionDashboard(ministryName);
        }
        static void AddDevotionSchedule(string ministryName)
        {
            Console.Clear();
            string date = NoNullOrEmptyInput("Enter Date: ");
            string songLeader = NoNullOrEmptyInput("Song Leader: ");
            string presider = NoNullOrEmptyInput("Presider: ");
            string speaker = NoNullOrEmptyInput("Speaker: ");

            bool isAdded = cmsProcess.AddDevotionSched(date, songLeader, presider, speaker);
            Console.WriteLine(isAdded ? "Schedule Added Successfully" : "Failed to Add Schedule");

            Console.WriteLine("----------------------------------");
            DevotionDashboard(ministryName);
        }
        static void RemoveDevotionSched(string ministryName)
        {
            Console.Clear();
            string date = NoNullOrEmptyInput("Enter Date (MM-DD-YYY): ");

            bool isDeleted = cmsProcess.RemoveDevotionSched(date);
            Console.WriteLine(isDeleted ? "Schedule Remove Successfully" : "Failed to Remove Schedule");

            Console.WriteLine("----------------------------------");
            DevotionDashboard(ministryName);
        }



             
        static void ChristianEdAdminDashboard(string ministryName)
        {
            Console.Clear();
            Console.WriteLine($"WELCOME TO {ministryName}");

            Console.WriteLine("[1] Teacher's List [2] Topic [3] Log out");
            int userChoice = UserChoice();

            switch (userChoice)
            {
                case 1:
                    TeachersDashboard(ministryName);
                    break;
                case 2:
                    TeachersLessonDashboard(ministryName);
                    break;
                case 3:
                    DisplayDashboard();
                    break;
                default:
                    Console.WriteLine("Invalid Input");
                    break;
            }
        }
        static void TeachersDashboard(string ministryName)
        {
            Console.WriteLine("Teacher's Dashboard");

            int option = CRUDOptions();
            if (option == 1)
            {
                //view
                ViewTeachersList(ministryName);
            }
            else if (option == 2)
            {
                //schedule
                AddTeacher(ministryName);
            }
            else if (option == 3)
            {
                //remove
                RemoveTeacher(ministryName);
            }
            else if (option == 4)
            {
                ChristianEdAdminDashboard(ministryName);
            }
            else
            {
                Console.WriteLine("Invalid Input");
            }
        }
        static void ViewTeachersList(string ministryName)
        {
            Console.Clear();
            Console.WriteLine("Teacher's List: ");
            foreach (var sched in cmsProcess.GetTeachers())
            {
                Console.WriteLine($"Name: {sched.TeachersName}");
                Console.WriteLine($"Designation: {sched.Assignment}");
                Console.WriteLine("");
            }

            Thread.Sleep(1000);
            Console.WriteLine("-----------------------------------");
            TeachersDashboard(ministryName);
        }
        static void AddTeacher(string ministryName)
        {
            Console.Clear();
            Console.WriteLine("Add New Teacher");
            string name = NoNullOrEmptyInput("Name: ");
            string designation = NoNullOrEmptyInput("Designation: ");

            bool isAdded = cmsProcess.AddTeachers(name, designation);
            Console.WriteLine(isAdded ? "Teacher Added Successfully" : "Failed to Add Teacher");

            TeachersDashboard(ministryName);
        }
        static void RemoveTeacher(string ministryName)
        {
            Console.Clear();
            string name = NoNullOrEmptyInput("Enter Teacher's Name: ");

            bool isDeleted = cmsProcess.RemoveTeacher(name);
            Console.WriteLine(isDeleted ? "Teacher Removed" : "Failed to Remove");

            TeachersDashboard(ministryName);
        }

        static void TeachersLessonDashboard(string ministryName)
        {
            Console.WriteLine("Teachers' Lesson Dashboard");

            int option = CRUDOptions();
            if (option == 1)
            {
                //view
                ViewLesson(ministryName);
            }
            else if (option == 2)
            {
                //schedule
                AddLesson(ministryName);
            }
            else if (option == 3)
            {
                //remove
                RemoveLesson(ministryName);
            }
            else if (option == 4)
            {
                ChristianEdAdminDashboard(ministryName);
            }
            else
            {
                Console.WriteLine("Invalid Input");
            }
        }
        static void ViewLesson(string ministryName)
        {
            Console.Clear();
            Console.WriteLine("Lesson's List");
            foreach(var lessons in cmsProcess.GetLessons())
            {
                Console.WriteLine($"Date: {lessons.Date}");
                Console.WriteLine($"Lesson: {lessons.Lessson}");
                Console.WriteLine($"Materials: {lessons.Materials}");
            }
            Thread.Sleep(1000);
            Console.WriteLine("--------------------------------");
            TeachersLessonDashboard(ministryName);
        }
        static void AddLesson(string ministryName)
        {
            Console.Clear();
            string date = NoNullOrEmptyInput("Date: ");
            string lesson = NoNullOrEmptyInput("Lesson Title: ");
            string materials = NoNullOrEmptyInput("Materials Needed: ");
            bool isAdded = cmsProcess.AddLesson(date, lesson, materials);
            Console.WriteLine(isAdded ? "Lesson Added" : "Failed to Add lesson");

            Console.WriteLine("--------------------------------");
            TeachersLessonDashboard(ministryName);
        }
        static void RemoveLesson(string ministryName)
        {
            Console.Clear();
            string date = NoNullOrEmptyInput("Enter Date (MM-DD-YYYY): ");
            bool isDeleted = cmsProcess.RemoveLesson(date);
            Console.WriteLine(isDeleted ? "Lesson Removed" : "Failed to Remove");

            Console.WriteLine("--------------------------------");
            TeachersLessonDashboard(ministryName);
        }




        static int CRUDOptions()
        {
            Console.WriteLine("[1] View [2] Add [3] Delete [4] Back");
            int userChoice = UserChoice();

            return userChoice;
        }

        // code for user path

        static int UserChoice()
        {
            int userChoice;
            do
            {
                Console.Write("Enter Choice: ");
                if (!int.TryParse(Console.ReadLine(), out userChoice) || userChoice <= 0)
                {
                    Console.WriteLine("Please Input a Valid Integer");
                }
            } while (userChoice <= 0);

            return userChoice;
        }
        static string NoNullOrEmptyInput(string input)
        {
            string userInput;
            do
            {
                Console.Write(input);
                userInput = Console.ReadLine() ?? string.Empty;

                if (string.IsNullOrWhiteSpace(userInput))
                {
                    Console.WriteLine("Please Enter Valid Strings to proceed.");
                }

            } while (string.IsNullOrWhiteSpace(userInput));
            return userInput;
        }
    }
    }
