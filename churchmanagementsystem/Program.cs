using BusinessAndDataLogic;
using CMSAccounts;
using CMSSchedules;
using System;
using System.Data;
using System.Runtime.CompilerServices;
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
                try
                {
                    EmailService emailService = new();
                    emailService.SendWelcomeEmail(emailAddress, firstName, ministryName);
                    Console.WriteLine($"📨 A welcome email has been sent to {emailAddress}");
                }
                catch
                {
                    Console.WriteLine($"⚠️ Failed to send email");
                }
            }
            else
            {
                string ministryName = NoNullOrEmptyInput("Ministry Name: ");
                Console.WriteLine("Position: Member");
                string position = "Member";
                bool added = cmsProcess.RegisteringRegularAccounts(firstName, lastName, age, emailAddress, ministryName, position, username, password);
                Console.WriteLine(added ? "Registration Completed" : "Failed to Register Account");
                
                try
                {
                    EmailService emailService = new();
                    emailService.SendWelcomeEmail(emailAddress, firstName, ministryName);
                    Console.WriteLine($"A welcome email has been sent to {emailAddress}");
                }
                catch
                {
                    Console.WriteLine($"Failed to send email");
                }
            }
           

            Thread.Sleep(1500);
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
                Console.WriteLine(isAdmin ? "Admin Sign In" : "User Sign In");
                DisplayLine();
                string username = NoNullOrEmptyInput("Username: ");
                string password = NoNullOrEmptyInput("Password: ");
                
                UserAccounts user = cmsProcess.ValidatingUserRole(isAdmin, username, password);

                if (user != null)
                {
                    Console.WriteLine("");
                    Console.WriteLine("Login Successful!");
                    Console.Clear();

                    string ministryName = user.MinistryName;
                    if (MinistryMap.ContainsKey(ministryName))
                    {
                        if (isAdmin)
                        {
                            DisplayAdminMainDashboard(ministryName, user, isAdmin);
                        } else
                        {
                            UserMainDashboard(ministryName, user, isAdmin);
                        }
                            
                    }
                    else
                    {
                        Console.WriteLine("Error: Credentials do not match any ministry.");
                    }
                    return;
                }
                    
                else
                {
                    attempt++;
                    Console.WriteLine("Wrong Username or Password or Role mismatch.");
                    Console.WriteLine($"Attempts left: {maxAttempt - attempt}");
                    Thread.Sleep(1500);
                    Console.Clear();
                }
            }

            Console.WriteLine("Too many failed attempts. Returning to main menu...");
            DisplayDashboard();
        }
        
        //Admin Main Dashboard
        static void DisplayAdminMainDashboard(string ministryName, UserAccounts user, bool isAdmin)
        {
            if (MinistryMap.TryGetValue(ministryName, out Ministry ministryEnum))
            {
                switch (ministryEnum)
                {
                    case Ministry.Discipleship:
                        DiscipleshipAdminDashboard("Discipleship Ministry", user);
                        break;
                    case Ministry.Prayer:
                        PrayerAdminDashboard("Prayer Ministry", user);
                        break;
                    case Ministry.Worship:
                        WorshipDashboard("Worship Ministry", user, isAdmin);
                        break;
                    case Ministry.ChristianEducation:
                        ChristianEdDashboard("Christian Education", user, isAdmin);
                        break;
                    default:
                        Console.WriteLine("Unknown ministry type.");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Invalid ministry name.");
            }


        }
        //Discipleship Ministry dashboard --- admin
        static void DiscipleshipAdminDashboard(string ministryName, UserAccounts signInAccount)
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
                switch (action)
                {
                    case CRUDAction.View:
                        DiscipleshipViewSchedule(ministryName, signInAccount, true);
                        break;
                    case CRUDAction.Add:
                        DiscipleshipAddSchedule(ministryName, signInAccount);
                        break;
                    case CRUDAction.Update:
                        DiscipleshipUpdateSchedule(ministryName, signInAccount);
                        break;
                    case CRUDAction.Delete:
                        DiscipleshipRemoveSchedule(ministryName, signInAccount);
                        break;
                    default:
                        Console.WriteLine("invalid input");
                        break;
                }
            }
            else if (userChoice == 2)
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
        static void DiscipleshipViewSchedule(string ministryName, UserAccounts user, bool isAdmin)
        {
            Console.Clear();
            Console.WriteLine("Discipleship Training Schedule");
            DisplayLine();
            foreach (var sched in cmsProcess.ViewDiscipleshipSchedule())
            {

                Console.WriteLine($"Date: {sched.Date:MM-dd-yyyy}");
                Console.WriteLine($"Speaker: {sched.Speaker} - {sched.Status}");
                Console.WriteLine($"Description: {sched.Description}");
                Console.WriteLine($"Note/Reminder: {sched.Note}");
                DisplayLine();
            }

            Console.WriteLine("Press any key to return");
            Console.ReadKey();
            Console.Clear();
            if (isAdmin)
            {
                DiscipleshipAdminDashboard(ministryName, user);
            }
            else
            {
                DiscipleshipUserDashboard(ministryName, user);
            }
            

        }
        static void DiscipleshipAddSchedule(string ministryName, UserAccounts signInAccount)
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
            string speaker = GetValidUserFromMinistries("speaker", ministryName);
            string description = NoNullOrEmptyInput("Description: ");
            string note = NoNullOrEmptyInput("Note/Reminder: ");

            bool isAdded = cmsProcess.AddDiscipleshipSched(date, speaker, description, note);
            Console.WriteLine(isAdded ? "SCHEDULE ADDED SUCCESSFULLY" : "FAILED TO ADD SCHEDULE");

            Thread.Sleep(1500);
            Console.WriteLine("");
            Console.WriteLine("");
            DiscipleshipAdminDashboard(ministryName, signInAccount);
        }
        static void DiscipleshipUpdateSchedule(string ministryName, UserAccounts signInAccount)
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
                DiscipleshipAdminDashboard(ministryName, signInAccount);
                return;
            }
            string speaker = GetValidUserFromMinistries("Speaker", ministryName);
            string speakerStatus = NoNullOrEmptyInput("Speaker Status: ");
            string description = NoNullOrEmptyInput("New Description: ");
            string note = NoNullOrEmptyInput("New Note: ");

            bool isUpdate = cmsProcess.UpdateDiscipleshipSched(date, speaker, speakerStatus, description, note);
            Console.WriteLine(isUpdate ? "Schedule Updated Successfully" : "Failed to Update Schedule");

            Thread.Sleep(1500);
            Console.WriteLine("");
            Console.WriteLine("");
            DiscipleshipAdminDashboard(ministryName, signInAccount);
        }
        static void DiscipleshipRemoveSchedule(string ministryName, UserAccounts signInAccount)
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
            DiscipleshipAdminDashboard(ministryName, signInAccount);
        }

        //prayer ministry dashboard --- admin
        static void PrayerAdminDashboard(string ministryName, UserAccounts user)
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
                        PrayerViewSchedule(ministryName, user, true);
                        break;
                    case CRUDAction.Add:
                        PrayerAddSchedule(ministryName, user);
                        break;
                    case CRUDAction.Update:
                        PrayerUpdateSchedule(ministryName, user);
                        break;
                    case CRUDAction.Delete:
                        PrayerRemoveSchedule(ministryName, user);
                        break;
                    default:
                        Console.WriteLine("invalid input");
                        break;
                }
            }
            else if (userChoice == 2)
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
        static void PrayerViewSchedule(string ministryName, UserAccounts user, bool isAdmin)
        {
            Console.Clear();
            Console.WriteLine("Prayer Meeting Schedule");
            DisplayLine();

            foreach (var sched in cmsProcess.ViewPrayerSched())
            {
                Console.WriteLine($"Date: {sched.Date:MM-dd-yyyy}");
                Console.WriteLine($"Song Leader: {sched.SongLeader} -- {sched.SongLeaderStatus}");
                Console.WriteLine($"Presider: {sched.Presider} -- {sched.PresiderStatus}");
                Console.WriteLine($"Speaker: {sched.Speaker} -- {sched.SpeakerStatus}");
                Console.WriteLine($"Prayer Item: {sched.PrayerItem}");
                Console.WriteLine("----------------------------------");
            }

            Console.WriteLine("Press any key to return");
            Console.ReadKey();
            Console.Clear();
            if (isAdmin)
            {
                PrayerAdminDashboard(ministryName, user);
            }
            else
            {
                UserMainDashboard(ministryName, user, false);
            }
            
        }
        static void PrayerAddSchedule(string ministryName, UserAccounts user)
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
            string songLeader = GetValidUserFromMinistries("Song Leader", "Worship Ministry");
            string presider = GetValidUserFromMinistries("Presider", ministryName);
            string speaker = GetValidUserFromMinistries("Speaker", ministryName);
            string prayerItem = NoNullOrEmptyInput("Prayer Item: ");

            bool isAdded = cmsProcess.AddPrayerSched(date, songLeader, presider, speaker, prayerItem);
            Console.WriteLine(isAdded ? "SCHEDULE ADDED SUCCESSFULLY" : "FAILED TO ADD SCHEDULE");

            Thread.Sleep(1500);
            Console.WriteLine("");
            Console.WriteLine("");
            PrayerAdminDashboard(ministryName, user);
        }
        static void PrayerUpdateSchedule(string ministryName, UserAccounts user)
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
                PrayerAdminDashboard(ministryName, user);
                return;
            }
            string songLeader = GetValidUserFromMinistries("Song Leader", "Worship Ministry");
            string songLeaderStatus = NoNullOrEmptyInput("Song Leader Status: ");
            string presider = GetValidUserFromMinistries("Presider", ministryName);
            string presiderStatus = NoNullOrEmptyInput("Presider Status: ");
            string speaker = GetValidUserFromMinistries("Speaker", ministryName);
            string speakerStatus = NoNullOrEmptyInput("Speaker Status: ");
            string prayerItem = NoNullOrEmptyInput("New Prayer Item: ");

            bool isUpdated = cmsProcess.UpdatePrayerSched(date, songLeader, songLeaderStatus, presider, presiderStatus, speaker, speakerStatus, prayerItem);
            Console.WriteLine(isUpdated ? "Schedule Updated Successfully" : "Failed to Update Schedule");

            Thread.Sleep(1500);
            Console.WriteLine("");
            Console.WriteLine("");
            PrayerAdminDashboard(ministryName, user);
        }
        static void PrayerRemoveSchedule(string ministryName, UserAccounts user)
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
            PrayerAdminDashboard(ministryName, user);
        }


        //worship ministry dashboard --- admin
        static void WorshipDashboard(string ministryName, UserAccounts user, bool isAdmin)
        {
            Console.Clear();
            Console.WriteLine($"WELCOME TO {ministryName}");
            DisplayLine();
            Console.WriteLine("[1] Praise and Worship [2] Sunday Worship Service [3] Devotion [4] Log out");
            int choice = UserChoice();
           
            Worship userChoice = (Worship)choice;
            
            if (isAdmin)
            {
                switch (userChoice)
                {
                    case Worship.PraiseAndWorship:
                        PraiseAndWorshipAdminDashboard(ministryName, user, isAdmin);
                        break;
                    case Worship.SundayWorship:
                        SundayWorshipServiceAdminDashboard(ministryName, user, isAdmin);
                        break;
                    case Worship.Devotion:
                        DevotionAdminDashboard(ministryName, user, isAdmin);
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
            } else
            {
                switch (userChoice)
                {
                    case Worship.PraiseAndWorship:
                        PraiseAndWorshipUserDashboard(ministryName, user, isAdmin);
                        break;
                    case Worship.SundayWorship:
                        SundayWorshipUserDashboard(ministryName, user, isAdmin);
                        break;
                    case Worship.Devotion:
                        DevotionUserDashboard(ministryName, user, isAdmin);
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

            
            

        }
        //worship - praise and worship --- admin
        static void PraiseAndWorshipAdminDashboard(string ministryName, UserAccounts user, bool isAdmin)
        {
            Console.Clear();
            Console.WriteLine("Praise and Worship Dashboard");
            Console.WriteLine($"Welcome {user.FirstName} {user.LastName}");
            DisplayLine();

            CRUDAction action = CRUDOptions();
            switch (action)
            {
                case CRUDAction.View:
                    DisplayPraiseAndWorshipSchedule(ministryName, user, isAdmin);
                    break;
                case CRUDAction.Add:
                    SchedulePraiseAndWorship(ministryName, user, isAdmin);
                    break;
                case CRUDAction.Update:
                    UpdatePraiseAndWorshipSchedule(ministryName, user, isAdmin);
                    break;
                case CRUDAction.Delete:
                    RemovePraiseAndWorshipSchedule(ministryName, user, isAdmin);
                    break;
                case CRUDAction.Back:
                    WorshipDashboard(ministryName, user, isAdmin);
                    break;
                default:
                    Console.WriteLine("invalid input");
                    break;
            }
        }
        static void DisplayPraiseAndWorshipSchedule(string ministryName, UserAccounts user, bool isAdmin)
        {
            Console.Clear();
            Console.WriteLine("Praise and Worship Schedules");
            Console.WriteLine($" test {user.FirstName} {user.LastName}");
            DisplayLine();

            foreach (var sched in cmsProcess.ViewPraiseAndWorshipSched())
            {
                Console.WriteLine($"Date: {sched.Date: MM-dd-yyyy}");
                Console.WriteLine($"Song Leader: {sched.SongLeader} -- {sched.SongLeaderStatus}");
                Console.WriteLine($"Instrumentalist: {sched.Instrumentalist}");
                Console.WriteLine("----------------------------------");
            }

            Console.WriteLine("Press any key to return");
            Console.ReadKey();
            Console.Clear();
            if (isAdmin)
            {
                PraiseAndWorshipAdminDashboard(ministryName, user, isAdmin);
            }
            else
            {
                PraiseAndWorshipUserDashboard(ministryName, user, isAdmin);
            }
        }
        static void SchedulePraiseAndWorship(string ministryName, UserAccounts user, bool isAdmin)
        {
            Console.Clear();
            Console.WriteLine("Praise and Worship Schedule");
            Console.WriteLine($"Welcome {user.FirstName} {user.LastName}");
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
            string songLeader = GetValidUserFromMinistries("Song Leader", "Worship Ministry");
            string instrumentalist = GetValidUserFromMinistries("Instrumentalist", "Worship Ministry");

            bool isAdded = cmsProcess.AddPraiseAndWorshipSched(date, songLeader, instrumentalist);
            Console.WriteLine(isAdded ? "SCHEDULE ADDED SUCCESSFULLY" : "FAILED TO ADD SCHEDULE");

            Thread.Sleep(2500);
            PraiseAndWorshipAdminDashboard(ministryName, user, isAdmin);
        }
        static void UpdatePraiseAndWorshipSchedule(string ministryName, UserAccounts user, bool isAdmin)
        {
            Console.Clear();
            Console.WriteLine("Update Praise and Worship Schedule");
            Console.WriteLine($"Welcome {user.FirstName} {user.LastName}");
            DisplayLine();

            DateTime date = DateTimeValidator();
            if (!cmsProcess.PraiseAndWorshipScheduleExist(date))
            {
                Console.WriteLine("Date does not Exist");
                Thread.Sleep(1500);
                Console.Clear();
                PraiseAndWorshipAdminDashboard(ministryName, user, isAdmin);
                return;
            }

            string songLeader = GetValidUserFromMinistries("Song Leader", ministryName);
            string songLeaderStatus = NoNullOrEmptyInput("Song Leader Status: ");

            bool isUpdated = cmsProcess.UpdatePraiseAndWorshipSched(date, songLeader, songLeaderStatus);
            Console.WriteLine(isUpdated ? "Schedule Updated Successfully" : "Failed to Update Schedule");

            Thread.Sleep(1500);
            Console.WriteLine("");
            Console.WriteLine("");
            PraiseAndWorshipAdminDashboard(ministryName, user, isAdmin);
        }
        static void RemovePraiseAndWorshipSchedule(string ministryName, UserAccounts user, bool isAdmin)
        {
            Console.Clear();
            Console.WriteLine("Remove Praise and Worship Schedule");
            Console.WriteLine($"Welcome {user.FirstName} {user.LastName}");
            DisplayLine();

            DateTime date = DateTimeValidator();
            bool isDeleted = cmsProcess.RemovePraiseAndWorshipSched(date);
            Console.WriteLine(isDeleted ? "SCHEDULE DELETED SUCCESSFULLY" : "FAILED TO DELETE SCHEDULE");

            Thread.Sleep(2500);
            PraiseAndWorshipAdminDashboard(ministryName, user, isAdmin);
        }

        //worship - sunday worship service  --- admin
        static void SundayWorshipServiceAdminDashboard(string ministryName, UserAccounts user, bool isAdmin)
        {
            Console.Clear();
            Console.WriteLine("Sunday Worship Service Dashboard");
            DisplayLine();

            CRUDAction action = CRUDOptions();
            switch (action)
            {
                case CRUDAction.View:
                    DisplaySundayWorshipSchedule(ministryName, user, isAdmin);
                    break;
                case CRUDAction.Add:
                    ScheduleSundayWorshipService(ministryName, user, isAdmin);
                    break;
                case CRUDAction.Update:
                    UpdateSundayWorshipSchedule(ministryName, user, isAdmin);
                    break;
                case CRUDAction.Delete:
                    RemoveSundayWorshipSched(ministryName,  user, isAdmin);
                    break;
                case CRUDAction.Back:
                    WorshipDashboard(ministryName, user, isAdmin);
                    break;
                default:
                    Console.WriteLine("invalid input");
                    break;
            }
        }
        static void DisplaySundayWorshipSchedule(string ministryName, UserAccounts user, bool isAdmin)
        {
            Console.Clear();
            Console.WriteLine("Sunday Worship Schedules");
            DisplayLine();

            foreach (var sched in cmsProcess.ViewSundayWorshipSched())
            {
                Console.WriteLine($"Date: {sched.Date:MM-dd-yyyy}");
                Console.WriteLine($"Presider: {sched.Presider} -- {sched.PresiderStatus}");
                Console.WriteLine($"Speaker: {sched.Speaker} -- {sched.SpeakerStatus}");
                Console.WriteLine($"Flowers: {sched.Flowers} -- {sched.FlowersStatus}");
                Console.WriteLine($"Ushers: {sched.Ushers} -- {sched.UshersStatus}");
                DisplayLine();
            }
            Console.WriteLine("Press any key to return");
            Console.ReadKey();
            Console.Clear();

            if (isAdmin)
            {
                SundayWorshipServiceAdminDashboard(ministryName, user, isAdmin);
            }else
            {
                SundayWorshipUserDashboard(ministryName, user, isAdmin);
            }
        }
        static void ScheduleSundayWorshipService(string ministryName, UserAccounts user, bool isAdmin)
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

            string presider = GetValidUserFromMinistries("Presider", ministryName);
            string speaker = GetValidUserFromMinistries("Speaker", ministryName);
            string flowers = GetValidUserFromMinistries("FLowers", ministryName);
            string ushers = GetValidUserFromMinistries("Ushers & Usherettes", ministryName);
            //note: also need to get the scheduled song leader and band of praise and worship


            bool isAdded = cmsProcess.AddSundayWorshipServiceSched(date, presider, speaker, flowers, ushers);
            Console.WriteLine(isAdded ? "SCHEDULE ADDED SUCCESSFULLY" : "FAILED TO ADD SCHEDULE");

            Thread.Sleep(2500);
            SundayWorshipServiceAdminDashboard(ministryName, user, isAdmin);
        }
        static void UpdateSundayWorshipSchedule(string ministryName, UserAccounts user, bool isAdmin)
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
                SundayWorshipServiceAdminDashboard(ministryName, user, isAdmin);
                return;
            }
            string presider = GetValidUserFromMinistries("Presider", ministryName);
            string presiderStatus = NoNullOrEmptyInput("Presider Status: ");
            string speaker = GetValidUserFromMinistries("Speaker", ministryName);
            string speakerStatus = NoNullOrEmptyInput("Speaker Status: ");
            string flowers = GetValidUserFromMinistries("FLowers", ministryName);
            string flowersStatus = NoNullOrEmptyInput("Flowers Status: ");
            string ushers = GetValidUserFromMinistries("Ushers & Usherettes", ministryName);
            string ushersStatus = NoNullOrEmptyInput("New Ushers Status: ");

            bool isUpdated = cmsProcess.UpdateSundayWorshipServiceSched(date, presider, presiderStatus, speaker, speakerStatus, flowers, flowersStatus, ushers, ushersStatus);
            Console.WriteLine(isUpdated ? "Schedule Updated Successfully" : "Failed to Update Schedule");

            Thread.Sleep(1500);
            Console.WriteLine("");
            Console.WriteLine("");
            SundayWorshipServiceAdminDashboard(ministryName, user, isAdmin);
        }
        static void RemoveSundayWorshipSched(string ministryName, UserAccounts user, bool isAdmin)
        {
            Console.Clear();
            Console.WriteLine("Remove Sunday Worship Service Schedule");
            DisplayLine();

            DateTime date = DateTimeValidator();

            bool isDeleted = cmsProcess.RemoveSundayWorshipSched(date);
            Console.WriteLine(isDeleted ? "SCHEDULE REMOVE SUCCESSFULLY" : "FAILED TO REMOVE SCHEDULE");

            Thread.Sleep(2500);
            SundayWorshipServiceAdminDashboard(ministryName, user, isAdmin);
        }
        //worship - devotion --- admin
        static void DevotionAdminDashboard(string ministryName, UserAccounts user, bool isAdmin)
        {
            Console.Clear();
            Console.WriteLine("Devotion Dashboard");
            DisplayLine();

            CRUDAction action = CRUDOptions();
            switch (action)
            {
                case CRUDAction.View:
                    DisplayDevotionSched(ministryName, user, isAdmin);
                    break;
                case CRUDAction.Add:
                    AddDevotionSchedule(ministryName, user, isAdmin);
                    break;
                case CRUDAction.Update:
                    UpdateDevotionSchedule(ministryName, user, isAdmin);
                    break;
                case CRUDAction.Delete:
                    RemoveDevotionSched(ministryName, user, isAdmin);
                    break;
                case CRUDAction.Back:
                    WorshipDashboard(ministryName, user, isAdmin);
                    break;
                default:
                    Console.WriteLine("invalid input");
                    break;
            }
        }
        static void DisplayDevotionSched(string ministryName, UserAccounts user, bool isAdmin)
        {
            Console.Clear();
            Console.WriteLine("Devotion Schedules");
            DisplayLine();

            foreach (var sched in cmsProcess.ViewDevotionSched())
            {
                Console.WriteLine($"Date: {sched.Date:MM-dd-yyyy}");
                Console.WriteLine($"Song Leader: {sched.SongLeader} -- {sched.SongLeaderStatus}");
                Console.WriteLine($"Presider: {sched.Presider} -- {sched.PresiderStatus}");
                Console.WriteLine($"Speaker: {sched.Speaker} -- {sched.SpeakerStatus}");
                DisplayLine();
            }

            Console.WriteLine("Press any key to return");
            Console.ReadKey();
            Console.Clear();
            if (isAdmin)
            {
                DevotionAdminDashboard(ministryName, user, isAdmin);
            }else
            {
                DevotionUserDashboard(ministryName, user, isAdmin);
            }
        }
        static void AddDevotionSchedule(string ministryName, UserAccounts user, bool isAdmin)
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
            string songLeader = GetValidUserFromMinistries("Song Leader", ministryName);
            string presider = GetValidUserFromMinistries("Presider", ministryName);
            string speaker = GetValidUserFromMinistries("Speaker", ministryName);

            bool isAdded = cmsProcess.AddDevotionSched(date, songLeader, presider, speaker);
            Console.WriteLine(isAdded ? "SCHEDULE ADDED SUCCESSFULLY" : "FAILED TO ADD SCHEDULE");

            Thread.Sleep(2500);
            DevotionAdminDashboard(ministryName, user, isAdmin);
        }
        static void UpdateDevotionSchedule(string ministryName, UserAccounts user, bool isAdmin)
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
                DevotionAdminDashboard(ministryName, user, isAdmin);
                return;
            }
            string songLeader = GetValidUserFromMinistries("Song Leader", ministryName);
            string songLeaderStatus = NoNullOrEmptyInput("Song Leader Status: ");
            string presider = GetValidUserFromMinistries("Presider", ministryName);
            string presiderStatus = NoNullOrEmptyInput("Presider Status: ");
            string speaker = GetValidUserFromMinistries("Speaker", ministryName);
            string speakerStatus = NoNullOrEmptyInput("Speaker Status: ");

            bool isUpdated = cmsProcess.UpdateDevotionSched(date, songLeader, songLeaderStatus, presider, presiderStatus, speaker, speakerStatus);
            Console.WriteLine(isUpdated ? "Schedule Updated Successfully" : "Failed to Update Schedule");

            Thread.Sleep(1500);
            Console.WriteLine("");
            Console.WriteLine("");
            DevotionAdminDashboard(ministryName, user, isAdmin);
        }
        static void RemoveDevotionSched(string ministryName, UserAccounts user, bool isAdmin)
        {
            Console.Clear();
            Console.WriteLine("Remove Devotion Schedule");
            DisplayLine();

            DateTime date = DateTimeValidator();

            bool isDeleted = cmsProcess.RemoveDevotionSched(date);
            Console.WriteLine(isDeleted ? "SCHEDULE REMOVE SUCCESSFULLY" : "FAILED TO ADD SCHEDULE");

            Thread.Sleep(2500);
            DevotionAdminDashboard(ministryName, user, isAdmin);
        }

        //Christian Education Ministry --- admin  
        static void ChristianEdDashboard(string ministryName, UserAccounts user, bool isAdmin)
        {
            Console.Clear();
            Console.WriteLine($"WELCOME TO {ministryName}");
            DisplayLine();

            Console.WriteLine("[1] Teacher's List [2] Topic [3] Log out");
            int userChoice = UserChoice();

            if (isAdmin)
            {
                switch (userChoice)
                {
                    case 1:
                        TeachersDashboard(ministryName, user, isAdmin);
                        break;
                    case 2:
                        TeachersLessonDashboard(ministryName, user, isAdmin);
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
            else
            {
                switch (userChoice)
                {
                    case 1:
                        TeachersUserDashboard(ministryName, user, isAdmin);
                        break;
                    case 2:
                        LessonsUserDashboard(ministryName, user, isAdmin);
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
            
        }
        //teachers dashboard --- admin
        static void TeachersDashboard(string ministryName, UserAccounts user, bool isAdmin)
        {
            Console.Clear();
            Console.WriteLine("Teacher's Dashboard");
            DisplayLine();

            CRUDAction action = CRUDOptions();
            switch (action)
            {
                case CRUDAction.View:
                    ViewTeachersList(ministryName, user, true);
                    break;
                case CRUDAction.Add:
                    AddTeacher(ministryName, user, isAdmin);
                    break;
                case CRUDAction.Update:
                    UpdateTeacher(ministryName, user, isAdmin);
                    break;
                case CRUDAction.Delete:
                    RemoveTeacher(ministryName, user, isAdmin);
                    break;
                case CRUDAction.Back:
                    ChristianEdDashboard(ministryName, user, isAdmin);
                    break;
                default:
                    Console.WriteLine("invalid input");
                    break;
            }
        }
        static void ViewTeachersList(string ministryName, UserAccounts user, bool isAdmin)
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


            Console.WriteLine("Press any key to return");
            Console.ReadKey();
            Console.Clear();
            if (isAdmin)
            {
                TeachersDashboard(ministryName, user, isAdmin);
            }else
            {
                TeachersUserDashboard(ministryName, user, isAdmin);
            }
        }
        static void AddTeacher(string ministryName, UserAccounts user, bool isAdmin)
        {
            Console.Clear();
            Console.WriteLine("Add New Teacher");
            DisplayLine();

            string name = NoNullOrEmptyInput("Name: ");
            string designation = NoNullOrEmptyInput("Designation: ");

            bool isAdded = cmsProcess.AddTeachers(name, designation);
            Console.WriteLine(isAdded ? "TEACHER ADDED SUCCESSFULLY" : "FAILED TO ADD TEACHER");

            Thread.Sleep(2000);
            TeachersDashboard(ministryName, user, isAdmin);
        }
        static void UpdateTeacher(string ministryName, UserAccounts user, bool isAdmin)
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
                TeachersDashboard(ministryName, user, isAdmin);
                return;
            }

            string designation = NoNullOrEmptyInput("New Designation: ");

            bool isUpdated = cmsProcess.UpdateTeachers(name, designation);
            Console.WriteLine(isUpdated ? "Updated Successfully" : "Failed to Update");

            Thread.Sleep(1500);
            Console.WriteLine("");
            Console.WriteLine("");
            TeachersDashboard(ministryName, user, isAdmin);
        }
        static void RemoveTeacher(string ministryName, UserAccounts user, bool isAdmin)
        {
            Console.Clear();
            Console.WriteLine("Remove a Teacher");
            DisplayLine();

            string name = NoNullOrEmptyInput("Enter Teacher's Name: ");

            bool isDeleted = cmsProcess.RemoveTeacher(name);
            Console.WriteLine(isDeleted ? "TEACHER REMOVED SUCCESSFULLY" : "FAILED TO REMOVE");

            Thread.Sleep(2000);
            TeachersDashboard(ministryName, user, isAdmin);
        }
        //lesson dashboard --- admin
        static void TeachersLessonDashboard(string ministryName, UserAccounts user, bool isAdmin)
        {
            Console.Clear();
            Console.WriteLine("Teachers' Lesson Dashboard");
            DisplayLine();

            CRUDAction action = CRUDOptions();
            switch (action)
            {
                case CRUDAction.View:
                    ViewLesson(ministryName, user, isAdmin);
                    break;
                case CRUDAction.Add:
                    AddLesson(ministryName, user, isAdmin);
                    break;
                case CRUDAction.Update:
                    UpdateLesson(ministryName, user, isAdmin);
                    break;
                case CRUDAction.Delete:
                    RemoveLesson(ministryName, user, isAdmin);
                    break;
                case CRUDAction.Back:
                    ChristianEdDashboard(ministryName, user, isAdmin);
                    break;
                default:
                    Console.WriteLine("invalid input");
                    break;
            }
        }
        static void ViewLesson(string ministryName, UserAccounts user, bool isAdmin)
        {
            Console.Clear();
            Console.WriteLine("Lesson's List");
            DisplayLine();

            foreach (var lessons in cmsProcess.GetLessons())
            {
                Console.WriteLine($"Date: {lessons.Date:MM-dd-yyyy}");
                Console.WriteLine($"Lesson: {lessons.Lessson}");
                Console.WriteLine($"Materials: {lessons.Materials}");
                DisplayLine();
            }

            Console.WriteLine("Press any key to return");
            Console.ReadKey();
            Console.Clear();
            if (isAdmin)
            {
                TeachersLessonDashboard(ministryName, user, isAdmin);
            }
            else
            {
                TeachersUserDashboard(ministryName, user, isAdmin);
            }
            
        }
        static void AddLesson(string ministryName, UserAccounts user, bool isAdmin)
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
            TeachersLessonDashboard(ministryName, user, isAdmin);
        }
        static void UpdateLesson(string ministryName, UserAccounts user, bool isAdmin)
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
                TeachersLessonDashboard(ministryName, user, isAdmin);
                return;
            }

            string lesson = NoNullOrEmptyInput("New Lesson: ");
            string materials = NoNullOrEmptyInput("New Materials: ");

            bool isUpdated = cmsProcess.UpdateLesson(date, lesson, materials);
            Console.WriteLine(isUpdated ? "Schedule Updated Successfully" : "Failed to Update Schedule");

            Thread.Sleep(1500);
            Console.WriteLine("");
            Console.WriteLine("");
            TeachersLessonDashboard(ministryName, user, isAdmin);
        }
        static void RemoveLesson(string ministryName, UserAccounts user, bool isAdmin)
        {
            Console.Clear();
            Console.WriteLine("Remove a Lesson");
            DisplayLine();

            DateTime date = DateTimeValidator();
            bool isDeleted = cmsProcess.RemoveLesson(date);
            Console.WriteLine(isDeleted ? "LESSON REMOVED" : "FAILED TO REMOVED LESSON");

            Thread.Sleep(2500);
            TeachersLessonDashboard(ministryName, user, isAdmin);
        }

        //USER PATH
        static void UserMainDashboard(string ministryName, UserAccounts user, bool isAdmin)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine($"Welcome {user.FirstName}!".ToUpper());
                DisplayLine();

                if(ministryName == "Discipleship Ministry" || ministryName == "Prayer Ministry" || ministryName == "Worship Ministry")
                {
                    Console.WriteLine("Your Ministry: ");
                    Console.WriteLine($"- [1] {ministryName} ");
                    Console.WriteLine("[2] Your Pending Schedule");
                    Console.WriteLine("[3] Your Confirmed Schedule");
                    Console.WriteLine("[4] Log out");

                    int userChoice = UserChoice();
                    switch (userChoice)
                    {
                        case 1:
                            DisplayUserOptions(ministryName, user, isAdmin);
                            break;
                        case 2:
                            UserResponseToSched(user);
                            break;
                        case 3:
                            ViewConfirmedSchedules(user);
                            break;
                        case 4:
                            DisplayLine();
                            Console.WriteLine("Logging out. Please Wait...");
                            Thread.Sleep(1500);
                            DisplayDashboard();
                            break;
                        default:
                            Console.WriteLine("Error: Invalid Input");
                            break;
                    }
                } else
                {
                    DisplayUserOptions(ministryName, user, false);
                }
                

            }
        }
        //USER MINISTRIES
        static void DisplayUserOptions(string ministryName, UserAccounts user, bool isAdmin)
        {
            if (MinistryMap.TryGetValue(ministryName, out Ministry ministryEnum))
            {
                switch (ministryEnum)
                {
                    case Ministry.Discipleship:
                        DiscipleshipUserDashboard("Discipleship Ministry", user);
                        break;
                    case Ministry.Prayer:
                        PrayerUserDashboard("Prayer Ministry", user);
                        break;
                    case Ministry.Worship:
                        WorshipDashboard("Worship Ministry", user, false);
                        break;
                    case Ministry.ChristianEducation:
                        ChristianEdDashboard("Christian Education", user, false);
                        break;
                    default:
                        Console.WriteLine("Unknown ministry type.");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Invalid ministry name.");
            }
        }
        static void DiscipleshipUserDashboard(string ministryName, UserAccounts user)
        {
            Console.Clear();
            Console.WriteLine($"WELCOME TO {ministryName}");
            Console.WriteLine($"TEST IF CORRECT ACCOUNT: {user.FirstName} {user.LastName}");
            DisplayLine();

            Console.WriteLine("[1] View Schedule [2] Back");
            int userChoice = UserChoice();

            switch (userChoice)
            {
                case 1: // view
                    DiscipleshipViewSchedule(ministryName, user, false);
                    break;
                case 2: // back
                    UserMainDashboard(ministryName, user, false);
                    break;
                default: // error
                    Console.WriteLine("ERROR: Input does not match any options");
                    break;
            }
        }
        static void PrayerUserDashboard(string ministryName, UserAccounts user)
        {
            Console.Clear();
            Console.WriteLine($"WELCOME TO {ministryName}");
            Console.WriteLine($"TEST IF CORRECT ACCOUNT: {user.FirstName} {user.LastName}");
            DisplayLine();

            Console.WriteLine("[1] View Schedule [2] Back");
            int userChoice = UserChoice();

            switch (userChoice)
            {
                case 1: // view
                    PrayerViewSchedule(ministryName, user,false);
                    break;
                case 2: // back
                    UserMainDashboard(ministryName, user, false);
                    break;
                default: // error
                    Console.WriteLine("ERROR: Input does not match any options");
                    break;

            }
        }
        static void PraiseAndWorshipUserDashboard(string ministryName, UserAccounts user, bool isAdmin)
        {
            Console.Clear();
            Console.WriteLine($"WELCOME TO Praise and Worship Dashboard");
            Console.WriteLine($"TEST IF CORRECT ACCOUNT: {user.FirstName} {user.LastName}");
            DisplayLine();

            Console.WriteLine("[1] View Schedule [2] Back");
            int userChoice = UserChoice();

            switch (userChoice)
            {
                case 1: // view
                    DisplayPraiseAndWorshipSchedule(ministryName, user, isAdmin);
                    break;
                case 2: // back
                    UserMainDashboard(ministryName, user, false);
                    break;
                default: // error
                    Console.WriteLine("ERROR: Input does not match any options");
                    break;

            }
        }
        static void SundayWorshipUserDashboard(string ministryName, UserAccounts user, bool isAdmin)
        {
            Console.Clear();
            Console.WriteLine($"WELCOME TO Sunday Worship Dashboard");
            Console.WriteLine($"TEST IF CORRECT ACCOUNT: {user.FirstName} {user.LastName}");
            DisplayLine();

            Console.WriteLine("[1] View Schedule [2] Back");
            int userChoice = UserChoice();

            switch (userChoice)
            {
                case 1: // view
                    DisplaySundayWorshipSchedule(ministryName, user, isAdmin);
                    break;
                case 2: // back
                    UserMainDashboard(ministryName, user, false);
                    break;
                default: // error
                    Console.WriteLine("ERROR: Input does not match any options");
                    break;

            }
        }
        static void DevotionUserDashboard(string ministryName,UserAccounts user, bool isAdmin)
        {
            Console.Clear();
            Console.WriteLine($"WELCOME TO Devotion Dashboard");
            Console.WriteLine($"TEST IF CORRECT ACCOUNT: {user.FirstName} {user.LastName}");
            DisplayLine();

            Console.WriteLine("[1] View Schedule [2] Back");
            int userChoice = UserChoice();

            switch (userChoice)
            {
                case 1: // view
                    DisplayDevotionSched(ministryName, user, isAdmin);
                    break;
                case 2: // back
                    UserMainDashboard(ministryName, user, false);
                    break;
                default: // error
                    Console.WriteLine("ERROR: Input does not match any options");
                    break;

            }
        }
        static void TeachersUserDashboard(string ministryName, UserAccounts user, bool isAdmin)
        {
            Console.Clear();
            Console.WriteLine($"WELCOME TO Teachers List Board");
            Console.WriteLine($"TEST IF CORRECT ACCOUNT: {user.FirstName} {user.LastName}");
            DisplayLine();

            Console.WriteLine("[1] View Teacher's List [3] Back");
            int userChoice = UserChoice();

            switch (userChoice)
            {
                case 1: // view
                    ViewTeachersList(ministryName, user, isAdmin);
                    break;
                case 2: // back
                    UserMainDashboard(ministryName, user, false);
                    break;
                default: // error
                    Console.WriteLine("ERROR: Input does not match any options");
                    break;

            }
        }
        static void LessonsUserDashboard(string ministryName, UserAccounts user, bool isAdmin)
        {
            Console.Clear();
            Console.WriteLine($"WELCOME TO Teachers Lesson Board");
            Console.WriteLine($"TEST IF CORRECT ACCOUNT: {user.FirstName} {user.LastName}");
            DisplayLine();

            Console.WriteLine("[1] View Lessons [2] Back");
            int userChoice = UserChoice();

            switch (userChoice)
            {
                case 1: // view
                    ViewLesson(ministryName, user, isAdmin);
                    break;
                case 2: // back
                    UserMainDashboard(ministryName, user, false);
                    break;
                default: // error
                    Console.WriteLine("ERROR: Input does not match any options");
                    break;
            }
        }

        // di applicable si bitwise operator OR dito kasi need i-update yung list or storage
        // need nya i address or i-path kung san pupunta which is the handleMinistry...
        static void UserResponseToSched(UserAccounts user)
        {
            Console.Clear();
            Console.WriteLine("Your Assigned Schedules");

            string fullName = $"{user.FirstName} {user.LastName}";

            bool ifHasAssignedSchedule = false;

            if (HandleDiscipleshipResponse(fullName))
            {
                ifHasAssignedSchedule = true;
            }
            if (HandlePrayerResponse(fullName))
            {
                ifHasAssignedSchedule = true;
            }
            if (HandlePraiseAndWorshipResponse(fullName))
            {
                ifHasAssignedSchedule = true;
            }
            if (HandleSundayWorshipResponse(fullName))
            {
                ifHasAssignedSchedule = true;
            }
            if (HandleDevotionResponse(fullName))
            {
                ifHasAssignedSchedule = true;
            }            
            if (ifHasAssignedSchedule)
            {
                Console.WriteLine("All of your responses have been processed. Thank you and GOD bless.");
            }
            else
            {
                Console.WriteLine("You don't have any assigned schedules at the moment.");
            }

            Thread.Sleep(1500);

        }           
        static bool HandleDiscipleshipResponse(string fullName)
        {
            bool ifHasAssignedSchedule = false;
            //discipleship ministry
            foreach (var sched in cmsProcess.ViewDiscipleshipSchedule())
            {
                if (cmsProcess.CheckIfStatusIsPending(fullName, sched.Speaker, sched.Status))
                {
                    string speakerStatus = sched.Status;
                    string response = GetResponseFromUser("Speaker", sched.Status, "Discipleship Training", sched.Date);
                    if (response == "Confirmed" || response == "Request to be Changed")
                    {
                        bool updated = cmsProcess.ProcessUserResponseDiscipleship(sched.Date, response);
                        Console.WriteLine(updated ? "Your Response is Sent." : "Failed to update your response.");
                        ifHasAssignedSchedule = true;
                    }

                }
            }
            return ifHasAssignedSchedule;
        }
        static bool HandlePrayerResponse(string fullName)
        {
            bool ifHasAssignedSchedule = false;
            foreach (var sched in cmsProcess.ViewPrayerSched())
            {
                bool hasAssigned = false;
                string presiderStatus = sched.PresiderStatus;
                string speakerStatus = sched.SpeakerStatus;
                string songLeaderStatus = sched.SongLeaderStatus;

                if (cmsProcess.CheckIfStatusIsPending(fullName, sched.Speaker, sched.SpeakerStatus))
                {
                    string response = GetResponseFromUser("Speaker", sched.SpeakerStatus, "Prayer Meeting", sched.Date);
                    if (response == "Confirmed" || response == "Request to be Changed")
                    {
                        speakerStatus = response;
                        hasAssigned = true;
                    }
                }
                if (cmsProcess.CheckIfStatusIsPending(fullName, sched.SongLeader, sched.SongLeaderStatus))
                {
                    string response = GetResponseFromUser("Song Leader", sched.SongLeaderStatus, "Prayer Meeting", sched.Date);
                    if (response == "Confirmed" || response == "Request to be Changed")
                    {
                        songLeaderStatus = response;
                        hasAssigned = true;
                    }
                }
                if (cmsProcess.CheckIfStatusIsPending(fullName, sched.Presider, sched.PresiderStatus))
                {
                    string response = GetResponseFromUser("Presider", sched.PresiderStatus, "Prayer Meeting", sched.Date);
                    if (response == "Confirmed" || response == "Request to be Changed")
                    {
                        presiderStatus = response;
                        hasAssigned = true;
                    }
                }
                if (hasAssigned)
                {
                    bool updated = cmsProcess.ProcessUserResponsePrayer(sched.Date, presiderStatus, speakerStatus, songLeaderStatus);
                    Console.WriteLine(updated ? "Your response was saved." : "Failed to update your response.");
                    ifHasAssignedSchedule = true;
                }

            }
            return ifHasAssignedSchedule;
        }
        static bool HandlePraiseAndWorshipResponse(string fullName)
        {
            bool ifHasAssignedSchedule = false;
            //praise and worship ministry 
            foreach (var sched in cmsProcess.ViewPraiseAndWorshipSched())
            {
                if (cmsProcess.CheckIfStatusIsPending(fullName, sched.SongLeader, sched.SongLeaderStatus))
                {
                    string response = GetResponseFromUser("Song Leader", sched.SongLeaderStatus, "Sunday Worship Service", sched.Date);
                    if (response == "Confirmed" || response == "Request to be Changed")
                    {
                        bool updated = cmsProcess.ProcessUserResponsePW(sched.Date, response);
                        Console.WriteLine(updated ? "Your Response is Sent." : "Failed to update your response.");
                        ifHasAssignedSchedule = true;
                        Thread.Sleep(1000);
                    }
                }
            }
            return ifHasAssignedSchedule;
        }
        static bool HandleSundayWorshipResponse(string fullName)
        {
            bool ifHasAssignedSchedule = false;
            foreach (var sched in cmsProcess.ViewSundayWorshipSched())
            {
                bool hasAssigned = false;
                string presiderStatus = sched.PresiderStatus;
                string speakerStatus = sched.SpeakerStatus;
                string flowersStatus = sched.FlowersStatus;
                string ushersStatus = sched.UshersStatus;

                if (cmsProcess.CheckIfStatusIsPending(fullName, sched.Speaker, sched.SpeakerStatus))
                {
                    string response = GetResponseFromUser("Speaker", sched.SpeakerStatus, "Sunday Worship Service", sched.Date);
                    if (response == "Confirmed" || response == "Request to be Changed")
                    {
                        speakerStatus = response;
                        hasAssigned = true;
                    }
                }
                if (cmsProcess.CheckIfStatusIsPending(fullName, sched.Flowers, sched.FlowersStatus))
                {
                    string response = GetResponseFromUser("Flowers", sched.FlowersStatus, "Sunday Worship Service", sched.Date);
                    if (response == "Confirmed" || response == "Request to be Changed")
                    {
                        flowersStatus = response;
                        hasAssigned = true;
                    }
                }
                if (cmsProcess.CheckIfStatusIsPending(fullName, sched.Presider, sched.PresiderStatus))
                {
                    string response = GetResponseFromUser("Presider", sched.PresiderStatus, "Sunday Worship Service", sched.Date);
                    if (response == "Confirmed" || response == "Request to be Changed")
                    {
                        presiderStatus = response;
                        hasAssigned = true;
                    }
                }
                if (cmsProcess.CheckIfStatusIsPending(fullName, sched.Ushers, sched.UshersStatus))
                {
                    string response = GetResponseFromUser("Ushers", sched.UshersStatus, "Sunday Worship Service", sched.Date);
                    if (response == "Confirmed" || response == "Request to be Changed")
                    {
                        ushersStatus = response;
                        hasAssigned = true;
                    }
                }
                if (hasAssigned)
                {
                    bool updated = cmsProcess.ProcessUserResponseSundayWorship(sched.Date, presiderStatus, speakerStatus, flowersStatus, ushersStatus);
                    Console.WriteLine(updated ? "Your response was saved." : "Failed to update your response.");
                    ifHasAssignedSchedule = true;
                }

            }
            return ifHasAssignedSchedule;
        }
        static bool HandleDevotionResponse(string fullName)
        {
            bool ifHasAssignedSchedule = false;
            foreach (var sched in cmsProcess.ViewDevotionSched())
            {
                bool hasAssigned = false;
                string presiderStatus = sched.PresiderStatus;
                string speakerStatus = sched.SpeakerStatus;
                string songLeaderStatus = sched.SongLeaderStatus;

                if (cmsProcess.CheckIfStatusIsPending(fullName, sched.Speaker, sched.SpeakerStatus))
                {
                    string response = GetResponseFromUser("Speaker", sched.SpeakerStatus, "Praise and Worship Devotion", sched.Date);
                    if (response == "Confirmed" || response == "Request to be Changed")
                    {
                        speakerStatus = response;
                        hasAssigned = true;
                    }
                }
                if (cmsProcess.CheckIfStatusIsPending(fullName, sched.SongLeader, sched.SongLeaderStatus))
                {
                    string response = GetResponseFromUser("Song Leader", sched.SongLeaderStatus, "Praise and Worship Devotion", sched.Date);
                    if (response == "Confirmed" || response == "Request to be Changed")
                    {
                        songLeaderStatus = response;
                        hasAssigned = true;
                    }
                }
                if (cmsProcess.CheckIfStatusIsPending(fullName, sched.Presider, sched.PresiderStatus))
                {
                    string response = GetResponseFromUser("Presider", sched.PresiderStatus, "Praise And Worship Devotion", sched.Date);
                    if (response == "Confirmed" || response == "Request to be Changed")
                    {
                        presiderStatus = response;
                        hasAssigned = true;
                    }
                }                
                if (hasAssigned)
                {
                    bool updated = cmsProcess.ProcessUserResponseDevotion(sched.Date, presiderStatus, speakerStatus, songLeaderStatus);
                    Console.WriteLine(updated ? "Your response was saved." : "Failed to update your response.");
                    ifHasAssignedSchedule = true;
                }

            }
            return ifHasAssignedSchedule;
        }
        static string GetResponseFromUser(string userRole, string currentStatus, string ministryName, DateTime date)
        {
            DisplayLine();
            Console.WriteLine($"You are Assigned as: ");
            Console.WriteLine($"DATE: {date.Date:MM-dd-yyyy}");
            Console.WriteLine($"WHAT: {ministryName}");
            Console.WriteLine($"ROLE: {userRole}");
            DisplayLine();
            Console.WriteLine("[1] Confirm [2] Request to be Changed");
            DisplayLine();

            int choice = UserChoice();
            return cmsProcess.GetUserConfirmation(choice);
        }


        //  use bitwise OR operator cause it returns true kahit isa lang ang true which is needed to find every role na confirmed by user
        // similar sya sa num += num;  (a|=b is equal to a = a|b)
        // iterate through the list of each ministry then pass the parameters needed sa helper method (displayconfirmedrole) then yung method na 
        // yun ang mag chcheck if may confirm na si user or wala. which is the return true and return false.
        // the code in longer version means "bool hasConfirmed = hasConfirmed | DisplayConfirmedRole();"
        // since hasConfirmed ay declared false sa initialization, it becomes hasconfirmed = false | return false/true ng helper method.
        // and OR operator output is TRUE if one is TRUE
        // false or false = false | false  or true = true | true or false = true | etc.
        static void ViewConfirmedSchedules(UserAccounts user)
        {
            Console.Clear();
            Console.WriteLine("Your Confirmed Schedules");
            DisplayLine();

            string fullName = $"{user.FirstName} {user.LastName}";
            bool hasConfirmed = false;

            foreach (var sched in cmsProcess.ViewDiscipleshipSchedule())
            {
                hasConfirmed |= DisplayConfirmedRole(fullName, sched.Speaker, sched.Status, sched.Date, "Discipleship Training", "Speaker");
            }
            foreach (var sched in cmsProcess.ViewPrayerSched())
            {
                hasConfirmed |= DisplayConfirmedRole(fullName, sched.Speaker, sched.SpeakerStatus, sched.Date, "Prayer Meeting", "Speaker");
                hasConfirmed |= DisplayConfirmedRole(fullName, sched.SongLeader, sched.SongLeaderStatus, sched.Date, "Prayer Meeting", "Song Leader");
                hasConfirmed |= DisplayConfirmedRole(fullName, sched.Presider, sched.PresiderStatus, sched.Date, "Prayer Meeting", "Presider");
            }

            foreach (var sched in cmsProcess.ViewPraiseAndWorshipSched())
            {
                hasConfirmed |= DisplayConfirmedRole(fullName, sched.SongLeader, sched.SongLeaderStatus, sched.Date, "Praise and Worship", "Song Leader");
            }

            foreach (var sched in cmsProcess.ViewSundayWorshipSched())
            {
                hasConfirmed |= DisplayConfirmedRole(fullName, sched.Speaker, sched.SpeakerStatus, sched.Date, "Sunday Worship", "Speaker");
                hasConfirmed |= DisplayConfirmedRole(fullName, sched.Presider, sched.PresiderStatus, sched.Date, "Sunday Worship", "Presider");
                hasConfirmed |= DisplayConfirmedRole(fullName, sched.Flowers, sched.FlowersStatus, sched.Date, "Sunday Worship", "Flowers");
                hasConfirmed |= DisplayConfirmedRole(fullName, sched.Ushers, sched.UshersStatus, sched.Date, "Sunday Worship", "Ushers");
            }
            foreach (var sched in cmsProcess.ViewDevotionSched())
            {
                hasConfirmed |= DisplayConfirmedRole(fullName, sched.Speaker, sched.SpeakerStatus, sched.Date, "Devotion", "Speaker");
                hasConfirmed |= DisplayConfirmedRole(fullName, sched.Presider, sched.PresiderStatus, sched.Date, "Devotion", "Presider");
                hasConfirmed |= DisplayConfirmedRole(fullName, sched.SongLeader, sched.SongLeaderStatus, sched.Date, "Devotion", "Song Leader");
            }

            if (!hasConfirmed)
            {
                Console.WriteLine("You have no confirmed schedules at the moment.");
            }
            DisplayLine();
            Console.WriteLine("Press any key to return...");
            Console.ReadKey();
        }
        static bool DisplayConfirmedRole(string fullName, string assignedName, string status, DateTime date, string ministry, string role)
        {
            if (assignedName.Equals(fullName, StringComparison.OrdinalIgnoreCase) && status.Equals("Confirmed", StringComparison.OrdinalIgnoreCase))
            {
                DisplayLine();
                Console.WriteLine($"DATE: {date:MM-dd-yyyy}");
                Console.WriteLine($"WHAT: {ministry}");
                Console.WriteLine($"ROLE: {role}");              
                return true;
            }
            return false;
        }
       
        // helper method.
        
        static string GetValidUserFromMinistries(string role, string ministryName)
        {
            //List<string> ministries = new List<string>();
            //ministries.Add(ministryName);
            List<string> users = cmsProcess.GetAllUsersPerMinistry(ministryName);

            Console.WriteLine("");
            DisplayLine();
            Console.WriteLine($"Available {role}");
            DisplayLine();
            foreach (var user in users)
            {
                Console.WriteLine($"- {user}");
            }
            DisplayLine();

            string inputName = "";
            bool isNameValid = false;

            while (!isNameValid)
            {
                inputName = NoNullOrEmptyInput($"Enter {role} Name: ").Trim();
                foreach(var user in users)
                {
                    if(string.Equals(user, inputName, StringComparison.OrdinalIgnoreCase))
                    {
                        inputName = user;
                        isNameValid = true;
                        break;
                    }
                }
                if (!isNameValid)
                {
                    Console.WriteLine($"ERROR: Invalid {role} Name");
                }
            }
            return inputName;
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
