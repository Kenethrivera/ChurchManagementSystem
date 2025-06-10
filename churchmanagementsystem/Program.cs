using BusinessAndDataLogic;
using System;
using static System.Collections.Specialized.BitVector32;


namespace churchmanagementsystem 
{
    internal class Program
    {
        static BusinessAndDataLogic.CMSProcess cmsProcess = new CMSProcess();
        static readonly Dictionary<string, Ministry> MinistryMap = new()
        {
            {"Discipleship Ministry", Ministry.Discipleship },
            {"Prayer Ministry", Ministry.Prayer },
            {"Worship Ministry", Ministry.Worship },
            {"Christian Education", Ministry.ChristianEducation }
        };
        static void Main(string[] args)
        {
            DisplayDashboard();
        }
        static void DisplayDashboard()
        {
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
                    Console.Clear();
                    RegisterUser();
                }
                else if (userChoice == 2)
                {
                    Console.Clear();
                    SignInUser(false);
                    break;
                }
                else if (userChoice == 3)
                {
                    Console.Clear();
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
                bool added = cmsProcess.RegisteringAdminAccounts(firstName, lastName, age, emailAddress, ministryName, position, username, password);
                Console.WriteLine(added ? "Registration Completed" : "Failed to Register Account");
            } else
            {
                bool added = cmsProcess.RegisteringRegularAccounts(firstName, lastName, age, emailAddress, username, password);
                Console.WriteLine(added ? "Registration Completed" : "Failed to Register Account");
            }

            Thread.Sleep(1500);
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
                Console.WriteLine("Sign In");
                DisplayLine();
                string username = NoNullOrEmptyInput("Username: ");
                string password = NoNullOrEmptyInput("Password: ");

                string role = cmsProcess.ValidatingUserRole(username, password);
              
                switch (isAdmin)
                {
                    case true:
                        if (role == "Admin")
                        {
                            Console.WriteLine("");
                            Console.WriteLine("Login Successful!");
                            string ministry = cmsProcess.ValidatingAdminMinistry(username, password);
                            Console.Clear();
                            if (MinistryMap.TryGetValue(ministry, out Ministry ministryName))
                            {
                                DisplayAdminOptions(ministryName);
                            }
                            return;
                        }else
                        {
                            Console.WriteLine("");
                            Console.WriteLine("Error: Credentials Does not match to any Accounts");
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
                Thread.Sleep(1500);
                Console.Clear();
            }
            Console.Write("Maximum attempts reached. Try again later.");
            Thread.Sleep(1500);
            DisplayDashboard();
        }    
        static void DisplayAdminOptions(Ministry ministryName)
        {
            switch (ministryName)
            {
                case Ministry.Discipleship:
                    DiscipleshipAdminDashboard("Discipleship Ministry");
                    break;
                case Ministry.Prayer:
                    PrayerAdminDashboard("Prayer Ministry");
                    break;
                case Ministry.Worship:
                    WorshipAdminDashboard("Worship Ministry");
                    break;
                case Ministry.ChristianEducation:
                    ChristianEdAdminDashboard("Christian Education");
                    break;
            }

        }

        //Discipleship Ministry dashboard --- admin
        static void DiscipleshipAdminDashboard(string ministryName)
        {
            Console.WriteLine($"WELCOME TO {ministryName}");
            DisplayLine();

            Console.WriteLine("[1] Schedule Training [2] Log Out");
            int userChoice = UserChoice();

            if (userChoice == 1)
            {
                Console.Clear();
                Console.WriteLine("Discipleship Schedule");
                DisplayLine();

                CRUDAction action = CRUDOptions();
                switch(action){
                    case CRUDAction.View:
                        DiscipleshipViewSchedule(ministryName);
                        break;
                    case CRUDAction.Add:
                        DiscipleshipAddSchedule(ministryName);
                        break;
                    case CRUDAction.Update:
                        DiscipleshipUpdateSchedule(ministryName);
                        break;
                    case CRUDAction.Delete:
                        DiscipleshipRemoveSchedule(ministryName);
                        break;
                    default:
                        Console.WriteLine("invalid input");
                        break;
                }
            } else if (userChoice == 2)
            {
                Console.WriteLine("Logging Out...");
                Thread.Sleep(2000);
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
            DisplayLine();
            foreach(var sched in cmsProcess.ViewDiscipleshipSchedule())
            {
                
                Console.WriteLine($"Date: {sched.Date:MM-dd-yyyy}");
                Console.WriteLine($"Speaker: {sched.Speaker}");
                Console.WriteLine($"Description: {sched.Description}");
                Console.WriteLine($"Note/Reminder: {sched.Note}");
                DisplayLine();
            }

            Thread.Sleep(1500);
            Console.WriteLine("");
            Console.WriteLine("");
            DiscipleshipAdminDashboard(ministryName);

        }
        static void DiscipleshipAddSchedule(string ministryName)
        {
            Console.Clear();
            Console.WriteLine("Add Discipleship Training Schedule");
            DisplayLine();

            DateTime date;
            while (true)
            {
                date = DateTimeValidator();
                if (cmsProcess.ValidateSundayDate(date) && cmsProcess.DateIsPast(date) && !cmsProcess.DiscipleshipScheduleExist(date))
                {
                    break;
                }
                Console.WriteLine("Date is not Sunday/Past/Already Used");
            }
            string speaker = NoNullOrEmptyInput("Speaker: ");
            string description = NoNullOrEmptyInput("Description: ");
            string note = NoNullOrEmptyInput("Note/Reminder: ");

            bool isAdded = cmsProcess.AddDiscipleshipSched(date, speaker, description, note);
            Console.WriteLine(isAdded ? "SCHEDULE ADDED SUCCESSFULLY" : "FAILED TO ADD SCHEDULE");
            
            Thread.Sleep(1500);
            Console.WriteLine("");
            Console.WriteLine("");
            DiscipleshipAdminDashboard(ministryName);
        }
        static void DiscipleshipUpdateSchedule(string ministryName)
        {
            Console.Clear();
            Console.WriteLine("Update Discipleship Schedule");
            DisplayLine();

            DateTime date = DateTimeValidator();
            if (!cmsProcess.DiscipleshipScheduleExist(date))
            {
                Console.WriteLine("Date does not Exist");
                Thread.Sleep(1500);
                Console.Clear();
                DiscipleshipAdminDashboard(ministryName);
                return;
            }
            string speaker = NoNullOrEmptyInput("New Speaker: ");
            string description = NoNullOrEmptyInput("New Description: ");
            string note = NoNullOrEmptyInput("New Note: ");

            bool isUpdate = cmsProcess.UpdateDiscipleshipSched(date, speaker, description, note);
            Console.WriteLine(isUpdate ? "Schedule Updated Successfully" : "Failed to Update Schedule");
            
            Thread.Sleep(1500);
            Console.WriteLine("");
            Console.WriteLine("");
            DiscipleshipAdminDashboard(ministryName);
        }
        static void DiscipleshipRemoveSchedule(string ministryName)
        {
            Console.Clear();
            Console.WriteLine("Remove Discipleship Schedule");
            DisplayLine();

            DateTime date = DateTimeValidator();

            bool isDeleted = cmsProcess.RemoveDiscipleSched(date);
            Console.WriteLine(isDeleted ? "SCHEDULE REMOVED" : "FAILED TO REMOVE SCHEDULE");

            Thread.Sleep(1500);
            Console.WriteLine("");
            Console.WriteLine("");
            DiscipleshipAdminDashboard(ministryName);
        }

        //prayer ministry dashboard --- admin
        static void PrayerAdminDashboard(string ministryName)
        {
            Console.WriteLine($"WELCOME TO {ministryName}");
            DisplayLine();

            Console.WriteLine("[1] Schedule Prayer Meeting [2] Log out");
            int userChoice = UserChoice();

            if (userChoice == 1)
            {
                Console.Clear();
                Console.WriteLine("Prayer Meeting Schedule");
                DisplayLine();

                CRUDAction action = CRUDOptions();
                switch (action)
                {
                    case CRUDAction.View:
                        PrayerViewSchedule(ministryName);
                        break;
                    case CRUDAction.Add:
                        PrayerAddSchedule(ministryName);
                        break;
                    case CRUDAction.Update:
                        PrayerUpdateSchedule(ministryName);
                        break;
                    case CRUDAction.Delete:
                        PrayerRemoveSchedule(ministryName);
                        break;
                    default:
                        Console.WriteLine("invalid input");
                        break;
                }
            } else if (userChoice == 2)
            {
                Console.WriteLine("Logging Out...");
                Thread.Sleep(2000);
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
            DisplayLine();

            foreach (var sched in cmsProcess.ViewPrayerSched())
            {
                Console.WriteLine($"Date: {sched.Date:MM-dd-yyyy}");
                Console.WriteLine($"Song Leader: {sched.SongLeader}");
                Console.WriteLine($"Presider: {sched.Presider}");
                Console.WriteLine($"Speaker: {sched.Speaker}");
                Console.WriteLine($"Prayer Item: {sched.PrayerItem}");
                Console.WriteLine("----------------------------------");
            }
            Thread.Sleep(1500);
            Console.WriteLine(" ");
            Console.WriteLine("");
            PrayerAdminDashboard(ministryName);
        }
        static void PrayerAddSchedule(string ministryName)
        {
            Console.Clear();
            Console.WriteLine("Add Prayer Meeting Schedule");
            DisplayLine();

            DateTime date;
            while (true)
            {
                date = DateTimeValidator();
                if (cmsProcess.ValidateThursdayDate(date) && cmsProcess.DateIsPast(date) && !cmsProcess.PrayerScheduleExist(date))
                {
                    break;
                }
                Console.WriteLine("Date is not Thursday/Past/Already Used");
            }
            string songLeader = NoNullOrEmptyInput("Song Leader: ");
            string presider = NoNullOrEmptyInput("Presider: ");
            string speaker = NoNullOrEmptyInput("Speaker: ");
            string prayerItem = NoNullOrEmptyInput("Prayer Item: ");
            
            bool isAdded = cmsProcess.AddPrayerSched(date, songLeader, presider, speaker, prayerItem);
            Console.WriteLine(isAdded ? "SCHEDULE ADDED SUCCESSFULLY" : "FAILED TO ADD SCHEDULE");

            Thread.Sleep(1500);
            Console.WriteLine("");
            Console.WriteLine("");
            PrayerAdminDashboard(ministryName);
        }
        static void PrayerUpdateSchedule(string ministryName)
        {
            Console.Clear();
            Console.WriteLine("Update Prayer Meeting Schedule");
            DisplayLine();

            DateTime date = DateTimeValidator();
            if (!cmsProcess.PrayerScheduleExist(date))
            {
                Console.WriteLine("Date does not Exist");
                Thread.Sleep(1500);
                Console.Clear();
                PrayerAdminDashboard(ministryName);
                return;
            }
            string songLeader = NoNullOrEmptyInput("New Song Leader: ");
            string presider = NoNullOrEmptyInput("New Presider: ");
            string speaker = NoNullOrEmptyInput("New Speaker: ");
            string prayerItem = NoNullOrEmptyInput("New Prayer Item: ");

            bool isUpdated = cmsProcess.UpdatePrayerSched(date, songLeader, presider, speaker, prayerItem);
            Console.WriteLine(isUpdated ? "Schedule Updated Successfully" : "Failed to Update Schedule");

            Thread.Sleep(1500);
            Console.WriteLine("");
            Console.WriteLine("");
            PrayerAdminDashboard(ministryName);
        }
        static void PrayerRemoveSchedule(string ministryName)
        {
            Console.Clear();
            Console.WriteLine("Remove Prayer Meeting Schedule");
            DisplayLine();

            DateTime date = DateTimeValidator();

            bool isDeleted = cmsProcess.RemovePrayerSched(date);
            Console.WriteLine(isDeleted ? "Schedule Deleted Successfully" : "Failed to Delete Schedule");

            Thread.Sleep(1500);
            Console.WriteLine("");
            Console.WriteLine("");
            PrayerAdminDashboard(ministryName);
        }


        //worship ministry dashboard --- admin
        static void WorshipAdminDashboard(string ministryName)
        {
            Console.Clear();
            Console.WriteLine($"WELCOME TO {ministryName}");
            DisplayLine();

            Console.WriteLine("[1] Praise and Worship [2] Sunday Worship Service [3] Devotion [4] Log out");
            int choice = UserChoice();

            Worship userChoice = (Worship)choice;
            switch (userChoice)
            {
                case Worship.PraiseAndWorship:
                    PraiseAndWorshipDashboard(ministryName);
                    break;
                case Worship.SundayWorship:
                    SundayWorshipServiceDashboard(ministryName);
                    break;
                case Worship.Devotion:
                    DevotionDashboard(ministryName);
                    break;
                case Worship.Logout:
                    Console.WriteLine("Logging out...");
                    Thread.Sleep(2000);
                    DisplayDashboard();
                    break;
                default:
                    Console.WriteLine("Invalid Input");
                    break;
            }

        }
        //worship - praise and worship --- admin
        static void PraiseAndWorshipDashboard(string ministryName)
        {
            Console.Clear();
            Console.WriteLine("Praise and Worship Dashboard");
            DisplayLine();
            
            CRUDAction action = CRUDOptions();
            switch (action)
            {
                case CRUDAction.View:
                    DisplayPraiseAndWorshipSchedule(ministryName);
                    break;
                case CRUDAction.Add:
                    SchedulePraiseAndWorship(ministryName);
                    break;
                case CRUDAction.Update:
                    UpdatePraiseAndWorshipSchedule(ministryName);
                    break;
                case CRUDAction.Delete:
                    RemovePraiseAndWorshipSchedule(ministryName);
                    break;
                case CRUDAction.Back:
                    WorshipAdminDashboard(ministryName);
                    break;
                default:
                    Console.WriteLine("invalid input");
                    break;
            }
        }
        static void DisplayPraiseAndWorshipSchedule(string ministryName)
        {
            Console.Clear();
            Console.WriteLine("Praise and Worship Schedules");
            DisplayLine();

            foreach (var sched in cmsProcess.ViewPraiseAndWorshipSched())
            {
                Console.WriteLine($"Date: {sched.Date: MM-dd-yyyy}");
                Console.WriteLine($"Song Leader: {sched.SongLeader}");
                Console.WriteLine($"Instrumentalist: {sched.Instrumentalist}");
                Console.WriteLine("----------------------------------");
            }

            Thread.Sleep(2500);
            PraiseAndWorshipDashboard(ministryName);
        }
        static void SchedulePraiseAndWorship(string ministryName)
        {
            Console.Clear();
            Console.WriteLine("Praise and Worship Schedule");
            DisplayLine();

            DateTime date;
            while (true)
            {
                date = DateTimeValidator();
                if (cmsProcess.ValidateSundayDate(date) && cmsProcess.DateIsPast(date) && !cmsProcess.PraiseAndWorshipScheduleExist(date))
                {
                    break;
                }
                Console.WriteLine("Date is not Sunday/Past/Already Used");
            }
            string songLeader = NoNullOrEmptyInput("Song Leader: ");
            string instrumentalist = NoNullOrEmptyInput("Instrumentalist: ");

            bool isAdded = cmsProcess.AddPraiseAndWorshipSched(date, songLeader, instrumentalist);
            Console.WriteLine(isAdded ? "SCHEDULE ADDED SUCCESSFULLY" : "FAILED TO ADD SCHEDULE");

            Thread.Sleep(2500);
            PraiseAndWorshipDashboard(ministryName);
        }
        static void UpdatePraiseAndWorshipSchedule(string ministryName)
        {
            Console.Clear();
            Console.WriteLine("Update Praise and Worship Schedule");
            DisplayLine();

            DateTime date = DateTimeValidator();
            if (!cmsProcess.PraiseAndWorshipScheduleExist(date))
            {
                Console.WriteLine("Date does not Exist");
                Thread.Sleep(1500);
                Console.Clear();
                PraiseAndWorshipDashboard(ministryName);
                return;
            }
            string songLeader = NoNullOrEmptyInput("New Song Leader: ");

            bool isUpdated = cmsProcess.UpdatePraiseAndWorshipSched(date, songLeader);
            Console.WriteLine(isUpdated ? "Schedule Updated Successfully" : "Failed to Update Schedule");

            Thread.Sleep(1500);
            Console.WriteLine("");
            Console.WriteLine("");
            PraiseAndWorshipDashboard(ministryName);
        }
        static void RemovePraiseAndWorshipSchedule(string ministryName)
        {
            Console.Clear();
            Console.WriteLine("Remove Praise and Worship Schedule");
            DisplayLine();

            DateTime date = DateTimeValidator();
            bool isDeleted = cmsProcess.RemovePraiseAndWorshipSched(date);
            Console.WriteLine(isDeleted ? "SCHEDULE DELETED SUCCESSFULLY" : "FAILED TO DELETE SCHEDULE");

            Thread.Sleep(2500);
            PraiseAndWorshipDashboard(ministryName);
        }

        //worship - sunday worship service  --- admin
        static void SundayWorshipServiceDashboard(string ministryName)
        {
            Console.Clear();
            Console.WriteLine("Sunday Worship Service Dashboard");
            DisplayLine();

            CRUDAction action = CRUDOptions();
            switch (action)
            {
                case CRUDAction.View:
                    DisplaySundayWorshipSchedule(ministryName);
                    break;
                case CRUDAction.Add:
                    ScheduleSundayWorshipService(ministryName);
                    break;
                case CRUDAction.Update:
                    UpdateSundayWorshipSchedule(ministryName);
                    break;
                case CRUDAction.Delete:
                    RemoveSundayWorshipSched(ministryName);
                    break;
                case CRUDAction.Back:
                    WorshipAdminDashboard(ministryName);
                    break;
                default:
                    Console.WriteLine("invalid input");
                    break;
            }
        }
        static void DisplaySundayWorshipSchedule(string ministryName)
        {
            Console.Clear();
            Console.WriteLine("Sunday Worship Schedules");
            DisplayLine();

            foreach (var sched in cmsProcess.ViewSundayWorshipSched())
            {
                Console.WriteLine($"Date: {sched.Date:MM-dd-yyyy}");
                Console.WriteLine($"Presider: {sched.Presider}");
                Console.WriteLine($"Speaker: {sched.Speaker}");
                Console.WriteLine($"Flowers: {sched.Flowers}");
                Console.WriteLine($"Ushers: {sched.Ushers}");
                DisplayLine();
            }
            Thread.Sleep(2500);
            SundayWorshipServiceDashboard(ministryName);
        }
        static void ScheduleSundayWorshipService(string ministryName)
        {
            Console.Clear();
            Console.WriteLine("Add Sunday Worship Service Schedule");
            DisplayLine();
            
            DateTime date;
            while (true)
            {
                date = DateTimeValidator();
                if (cmsProcess.ValidateSundayDate(date) && cmsProcess.DateIsPast(date) && !cmsProcess.SundayWorshipScheduleExist(date))
                {
                    break;
                }
                Console.WriteLine("Date is not Sunday/Past/Already Used");
            }
           
            string presider = NoNullOrEmptyInput("Presider: ");
            string speaker = NoNullOrEmptyInput("Speaker: ");
            string flowers = NoNullOrEmptyInput("Flowers for the Lord: ");
            string ushers = NoNullOrEmptyInput("Ushers: ");
            //note: also need to get the scheduled song leader and band of praise and worship


            bool isAdded = cmsProcess.AddSundayWorshipServiceSched(date, presider, speaker, flowers, ushers);
            Console.WriteLine(isAdded ? "SCHEDULE ADDED SUCCESSFULLY" : "FAILED TO ADD SCHEDULE");

            Thread.Sleep(2500);
            SundayWorshipServiceDashboard(ministryName);
        }
        static void UpdateSundayWorshipSchedule(string ministryName)
        {
            Console.Clear();
            Console.WriteLine("Update Sunday Worship Schedule");
            DisplayLine();

            DateTime date = DateTimeValidator();
            if (!cmsProcess.SundayWorshipScheduleExist(date))
            {
                Console.WriteLine("Date does not Exist");
                Thread.Sleep(1500);
                Console.Clear();
                SundayWorshipServiceDashboard(ministryName);
                return;
            }
            string presider = NoNullOrEmptyInput("New Presider: ");
            string speaker = NoNullOrEmptyInput("New Speaker: ");
            string flowers = NoNullOrEmptyInput("New Flowers: ");
            string ushers = NoNullOrEmptyInput("New Ushers: ");

            bool isUpdated = cmsProcess.UpdateSundayWorshipServiceSched(date, presider, speaker, flowers, ushers);
            Console.WriteLine(isUpdated ? "Schedule Updated Successfully" : "Failed to Update Schedule");

            Thread.Sleep(1500);
            Console.WriteLine("");
            Console.WriteLine("");
            SundayWorshipServiceDashboard(ministryName);
        }
        static void RemoveSundayWorshipSched(string ministryName)
        {
            Console.Clear();
            Console.WriteLine("Remove Sunday Worship Service Schedule");
            DisplayLine();

            DateTime date = DateTimeValidator();

            bool isDeleted = cmsProcess.RemoveSundayWorshipSched(date);
            Console.WriteLine(isDeleted ? "SCHEDULE REMOVE SUCCESSFULLY" : "FAILED TO REMOVE SCHEDULE");

            Thread.Sleep(2500);
            SundayWorshipServiceDashboard(ministryName);
        }
        //worship - devotion --- admin
        static void DevotionDashboard(string ministryName)
        {
            Console.Clear();
            Console.WriteLine("Devotion Dashboard");
            DisplayLine();

            CRUDAction action = CRUDOptions();
            switch (action)
            {
                case CRUDAction.View:
                    DisplayDevotionSched(ministryName);
                    break;
                case CRUDAction.Add:
                    AddDevotionSchedule(ministryName);
                    break;
                case CRUDAction.Update:
                    UpdateDevotionSchedule(ministryName);
                    break;
                case CRUDAction.Delete:
                    RemoveDevotionSched(ministryName);
                    break;
                case CRUDAction.Back:
                    WorshipAdminDashboard(ministryName);
                    break;
                default:
                    Console.WriteLine("invalid input");
                    break;
            }
        }
        static void DisplayDevotionSched(string ministryName)
        {
            Console.Clear();
            Console.WriteLine("Devotion Schedules");
            DisplayLine();

            foreach (var sched in cmsProcess.ViewDevotionSched())
            {
                Console.WriteLine($"Date: {sched.Date:MM-dd-yyyy}");
                Console.WriteLine($"Song Leader: {sched.SongLeader}");
                Console.WriteLine($"Presider: {sched.Presider}");
                Console.WriteLine($"Speaker: {sched.Speaker}");
                DisplayLine();
            }
            Thread.Sleep(2500);
            DevotionDashboard(ministryName);
        }
        static void AddDevotionSchedule(string ministryName)
        {
            Console.Clear();
            Console.WriteLine("Add Devotion Schedule");
            DisplayLine();

            DateTime date;
            while (true)
            {
                date = DateTimeValidator();
                if (cmsProcess.ValidateFridayDate(date) && cmsProcess.DateIsPast(date) && !cmsProcess.DevotionScheduleExist(date))
                {
                    break;
                }
                Console.WriteLine("Date is not Friday/Past/Already Used");
            }
            string songLeader = NoNullOrEmptyInput("Song Leader: ");
            string presider = NoNullOrEmptyInput("Presider: ");
            string speaker = NoNullOrEmptyInput("Speaker: ");

            bool isAdded = cmsProcess.AddDevotionSched(date, songLeader, presider, speaker);
            Console.WriteLine(isAdded ? "SCHEDULE ADDED SUCCESSFULLY" : "FAILED TO ADD SCHEDULE");

            Thread.Sleep(2500);
            DevotionDashboard(ministryName);
        }
        static void UpdateDevotionSchedule(string ministryName)
        {
            Console.Clear();
            Console.WriteLine("Update Devotion Schedule");
            DisplayLine();

            DateTime date = DateTimeValidator();
            if (!cmsProcess.DevotionScheduleExist(date))
            {
                Console.WriteLine("Date does not Exist");
                Thread.Sleep(1500);
                Console.Clear();
                DevotionDashboard(ministryName);
                return;
            }
            string songLeader = NoNullOrEmptyInput("New Song Leader: ");
            string presider = NoNullOrEmptyInput("New Presider: ");
            string speaker = NoNullOrEmptyInput("New Speaker: ");

            bool isUpdated = cmsProcess.UpdateDevotionSched(date, songLeader, presider, speaker);
            Console.WriteLine(isUpdated ? "Schedule Updated Successfully" : "Failed to Update Schedule");

            Thread.Sleep(1500);
            Console.WriteLine("");
            Console.WriteLine("");
            DevotionDashboard(ministryName);
        }
        static void RemoveDevotionSched(string ministryName)
        {
            Console.Clear();
            Console.WriteLine("Remove Devotion Schedule");
            DisplayLine();

            DateTime date = DateTimeValidator();

            bool isDeleted = cmsProcess.RemoveDevotionSched(date);
            Console.WriteLine(isDeleted ? "SCHEDULE REMOVE SUCCESSFULLY" : "FAILED TO ADD SCHEDULE");

            Thread.Sleep(2500);
            DevotionDashboard(ministryName);
        }
        //Christian Education Ministry --- admin  
        
        static void ChristianEdAdminDashboard(string ministryName)
        {
            Console.Clear();
            Console.WriteLine($"WELCOME TO {ministryName}");
            DisplayLine();

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
                    Console.WriteLine("Logging out...");
                    Thread.Sleep(2000);
                    DisplayDashboard();
                    break;
                default:
                    Console.WriteLine("Invalid Input");
                    break;
            }
        }
        //teachers dashboard --- admin
        static void TeachersDashboard(string ministryName)
        {
            Console.Clear();
            Console.WriteLine("Teacher's Dashboard");
            DisplayLine();

            CRUDAction action = CRUDOptions();
            switch (action)
            {
                case CRUDAction.View:
                    ViewTeachersList(ministryName);
                    break;
                case CRUDAction.Add:
                    AddTeacher(ministryName);
                    break;
                case CRUDAction.Update:
                    UpdateTeacher(ministryName);
                    break;
                case CRUDAction.Delete:
                    RemoveTeacher(ministryName);
                    break;
                case CRUDAction.Back:
                    ChristianEdAdminDashboard(ministryName);
                    break;
                default:
                    Console.WriteLine("invalid input");
                    break;
            }
        }
        static void ViewTeachersList(string ministryName)
        {
            Console.Clear();
            Console.WriteLine("Teacher's List: ");
            DisplayLine();

            foreach (var sched in cmsProcess.GetTeachers())
            {
                Console.WriteLine($"Name: {sched.TeachersName}");
                Console.WriteLine($"Designation: {sched.Assignment}");
                DisplayLine();
            }

            Thread.Sleep(2500);
            TeachersDashboard(ministryName);
        }
        static void AddTeacher(string ministryName)
        {
            Console.Clear();
            Console.WriteLine("Add New Teacher");
            DisplayLine();

            string name = NoNullOrEmptyInput("Name: ");
            string designation = NoNullOrEmptyInput("Designation: ");

            bool isAdded = cmsProcess.AddTeachers(name, designation);
            Console.WriteLine(isAdded ? "TEACHER ADDED SUCCESSFULLY" : "FAILED TO ADD TEACHER");

            Thread.Sleep(2000);
            TeachersDashboard(ministryName);
        }
        static void UpdateTeacher(string ministryName)
        {
            Console.Clear();
            Console.WriteLine("Update Teacher");
            DisplayLine();

            string name = NoNullOrEmptyInput("Teacher's Name: ");
            if (!cmsProcess.TeacherNameExist(name))
            {
                Console.WriteLine("Teacher's Name does not Exist");
                Thread.Sleep(1500);
                Console.Clear();
                TeachersDashboard(ministryName);
                return;
            }

            string designation = NoNullOrEmptyInput("New Designation: ");

            bool isUpdated = cmsProcess.UpdateTeachers(name, designation);
            Console.WriteLine(isUpdated ? "Updated Successfully" : "Failed to Update");

            Thread.Sleep(1500);
            Console.WriteLine("");
            Console.WriteLine("");
            TeachersDashboard(ministryName);
        }
        static void RemoveTeacher(string ministryName)
        {
            Console.Clear();
            Console.WriteLine("Remove a Teacher");
            DisplayLine();

            string name = NoNullOrEmptyInput("Enter Teacher's Name: ");

            bool isDeleted = cmsProcess.RemoveTeacher(name);
            Console.WriteLine(isDeleted ? "TEACHER REMOVED SUCCESSFULLY" : "FAILED TO REMOVE");

            Thread.Sleep(2000);
            TeachersDashboard(ministryName);
        }
        //lesson dashboard --- admin
        static void TeachersLessonDashboard(string ministryName)
        {
            Console.Clear();
            Console.WriteLine("Teachers' Lesson Dashboard");
            DisplayLine();

            CRUDAction action = CRUDOptions();
            switch (action)
            {
                case CRUDAction.View:
                    ViewLesson(ministryName);
                    break;
                case CRUDAction.Add:
                    AddLesson(ministryName);
                    break;
                case CRUDAction.Update:
                    UpdateLesson(ministryName);
                    break;
                case CRUDAction.Delete:
                    RemoveLesson(ministryName);
                    break;
                case CRUDAction.Back:
                    ChristianEdAdminDashboard(ministryName);
                    break;
                default:
                    Console.WriteLine("invalid input");
                    break;
            }
        }
        static void ViewLesson(string ministryName)
        {
            Console.Clear();
            Console.WriteLine("Lesson's List");
            DisplayLine();

            foreach(var lessons in cmsProcess.GetLessons())
            {
                Console.WriteLine($"Date: {lessons.Date:MM-dd-yyyy}");
                Console.WriteLine($"Lesson: {lessons.Lessson}");
                Console.WriteLine($"Materials: {lessons.Materials}");
                DisplayLine();
            }
            Thread.Sleep(2500);
            TeachersLessonDashboard(ministryName);
        }
        static void AddLesson(string ministryName)
        {
            Console.Clear();
            Console.WriteLine("Add Lesson");
            DisplayLine();

            DateTime date;
            while (true)
            {
                date = DateTimeValidator();
                if (cmsProcess.ValidateSundayDate(date) && cmsProcess.DateIsPast(date) && !cmsProcess.LessonExist(date))
                {
                    break;
                }
                Console.WriteLine("Date is not Sunday/Past/Already Used");
            }
            string lesson = NoNullOrEmptyInput("Lesson Title: ");
            string materials = NoNullOrEmptyInput("Materials Needed: ");
            bool isAdded = cmsProcess.AddLesson(date, lesson, materials);
            Console.WriteLine(isAdded ? "LESSON ADDED" : "FAILED TO ADD LESSON");

            Thread.Sleep(2500);
            TeachersLessonDashboard(ministryName);
        }
        static void UpdateLesson(string ministryName)
        {
            Console.Clear();
            Console.WriteLine("Update Lesson");
            DisplayLine();

            DateTime date = DateTimeValidator();
            if (!cmsProcess.LessonExist(date))
            {
                Console.WriteLine("Date does not Exist");
                Thread.Sleep(1500);
                Console.Clear();
                TeachersLessonDashboard(ministryName);
                return;
            }
           
            string lesson = NoNullOrEmptyInput("New Lesson: ");
            string materials = NoNullOrEmptyInput("New Materials: ");

            bool isUpdated = cmsProcess.UpdateLesson(date, lesson, materials);
            Console.WriteLine(isUpdated ? "Schedule Updated Successfully" : "Failed to Update Schedule");

            Thread.Sleep(1500);
            Console.WriteLine("");
            Console.WriteLine("");
            TeachersLessonDashboard(ministryName);
        }

        static void RemoveLesson(string ministryName)
        {
            Console.Clear();
            Console.WriteLine("Remove a Lesson");
            DisplayLine();

            DateTime date = DateTimeValidator();
            bool isDeleted = cmsProcess.RemoveLesson(date);
            Console.WriteLine(isDeleted ? "LESSON REMOVED" : "FAILED TO REMOVED LESSON");

            Thread.Sleep(2500);
            TeachersLessonDashboard(ministryName);
        }
        static CRUDAction CRUDOptions()
        {
            Console.WriteLine("[1] View [2] Add [3] Update [4] Delete [5] Back");
            int userChoice = UserChoice();

            return (CRUDAction)userChoice;
        }
        static DateTime DateTimeValidator()
        {
            DateTime date;

            while (true)
            {
                string dateInput = NoNullOrEmptyInput("Enter Date (MM-DD-YYYY): ");

                if (DateTime.TryParseExact(dateInput, "MM-dd-yyyy", null, System.Globalization.DateTimeStyles.None, out date))
                    return date;

                Console.WriteLine("Invalid Date Format. Please use MM-dd-yyyy");
            }
        }
        /*
             code for user path
        */


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
        static string NoNullOrEmptyInput(string prompt)
        {
            string userInput;
            do
            {
                Console.Write(prompt);
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
