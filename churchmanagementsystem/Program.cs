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

                if (cmsProcess.ValidatingUsernameAndPassword(username, password, isAdmin))
                {
                    Console.WriteLine("Login Successful!");
                    DisplayMinistryOptions();
                    return;
                }

                attempt++;
                Console.WriteLine($"Wrong Username or Password. Attempts left: {maxAttempt - attempt}");
            }
            Console.Write("Maximum attempts reached. Try again later.");
            Thread.Sleep(2000);
            DisplayDashboard();
        }

        //UI
        static void DisplayMinistryOptions()
        {
            Console.WriteLine("\nWelcome to Adelina Christian Church");
            Console.WriteLine("Ministry: ");

            string[] ministryName = cmsProcess.MinistryNamesList();
            foreach (string ministry in ministryName)
            {
                Console.WriteLine(ministry);
            }

            int userChoice = UserChoice();
            if (userChoice == 5)
            {
                DisplayDashboard();
            }
            else if (userChoice >= 1 && userChoice <= ministryName.Length)
            {
                DisplayMinistryDashboard(ministryName[userChoice - 1]);
            }
            else
            {
                Console.WriteLine("Invalid Input.");
                DisplayMinistryOptions();
            }
        }

        //UI
        static void DisplayMinistryDashboard(string ministryName)
        {
            Console.WriteLine($"\n{ministryName}");
            DisplayLine();
            while (true)
            {
                DisplayMinistryContents(ministryName);
            }
        }
        //UI
        static void DisplayMinistryContents(string ministryName)
        {
            Console.WriteLine("Select an option:");
            if (ministryName == "[1] Discipleship Ministry")
            {
                Console.WriteLine("[1] Schedule \n[2] Topics \n[3] Exit");
            }
            else if (ministryName == "[2] Prayer Ministry")
            {
                Console.WriteLine("[1] Schedule \n[2] Prayer Request \n[3] Exit");
            }
            else if (ministryName == "[3] Worship Ministry")
            {
                Console.WriteLine("[1] Schedule \n[2] Repertoire \n[3] Exit");
            }
            else if (ministryName == "[4] Christian Education")
            {
                Console.WriteLine("[1] Teacher's List  \n[2] Topic \n[3] Exit");
            }
            else
            {
                Console.WriteLine("Invalid Input \n");
            }

            int userChoice = UserChoice();
            ProcessMinistryOptionsChoice(ministryName, userChoice);

        }
        static void ProcessMinistryOptionsChoice(string ministryName, int userChoice)
        {
            switch (userChoice)
            {
                case 1:
                    ManageSchedule(ministryName);
                    break;
                case 2:
                    int choice = ViewAddDeleteOption();
                    ManageListForTopics(ministryName, choice);
                    break;
                case 3:
                    DisplayMinistryOptions();
                    break;
                default:
                    Console.WriteLine("ERROR: Exceeds 1-3 input");
                    DisplayMinistryContents(ministryName);
                    break;
            }
        }
        //BL
        static void ManageSchedule(string ministryName)
        {
            int userChoice;
            while (true)
            {
                Console.WriteLine(" ");
                Console.WriteLine("[1]View [2]Add [3]Remove [4]Exit");
                userChoice = UserChoice();

                switch (userChoice)
                {
                    case 1://view
                        if(ministryName == "[3] Worship Ministry")
                        {
                            int worshipViewType = WorshipViewingSchedule();
                            if (worshipViewType == 1)
                            {
                                Console.WriteLine("Current List: ");
                                Console.WriteLine(cmsProcess.ViewSchedules(ministryName));
                            }
                            else if (worshipViewType == 2)
                            {
                                Console.WriteLine("Current List: ");
                                Console.WriteLine(cmsProcess.ViewPraiseAndWorshipSchedule());
                            }
                            else if (worshipViewType == 3)
                            {
                                Console.WriteLine("Current List: ");
                                Console.WriteLine(cmsProcess.ViewDevotionSchedule());
                            }
                            else
                            {
                                Console.WriteLine("Invalid Input");
                            }
                        } else
                        {
                            Console.WriteLine("Current List: ");
                            Console.WriteLine(cmsProcess.ViewSchedules(ministryName));
                        }
                            break;
                    case 2://add
                        SetTypeOfSchedule(ministryName);
                        break;
                    case 3://remove
                        RemoveFromSchedule(ministryName);
                        break;
                    case 4://back
                        return;
                    default:
                        Console.WriteLine("Input does not match with the options");
                        break;
                }
            }
        }
        public static int WorshipViewingSchedule()
        {
            DisplayLine();
            Console.WriteLine("Choose Schedule Type: ");
            Console.WriteLine("[1] Sunday Worship Service \n[2] Weekly P&W Practices\n[3] Weekly Team Devotion");
            int userChoice = UserChoice();
            return userChoice;
        }
        public static void RemoveFromSchedule(string ministryName)
        {
            int index;
            if(ministryName == "[3] Worship Ministry")
            {
                int choice = WorshipViewingSchedule();
                if (choice == 1)
                {
                    Console.Write("Enter index: ");
                    index = Convert.ToInt32(Console.ReadLine());
                    bool success = cmsProcess.RemoveSchedule(ministryName, index - 1);
                    if (success)
                    {
                        Console.WriteLine("Remove Successfully");
                    }
                    else
                    {
                        Console.WriteLine("Removing Schedule Failed");
                    }
                }
                if (choice == 2)
                {
                    Console.Write("Enter index: ");
                    index = Convert.ToInt32(Console.ReadLine());
                    bool success = cmsProcess.RemovePraiseAndWorshipSchedule(index - 1);
                    if (success)
                    {
                        Console.WriteLine("Remove Successfully");
                    }
                    else
                    {
                        Console.WriteLine("Removing Schedule Failed");
                    }
                }else if (choice == 3)
                {
                    Console.Write("Enter index: ");
                    index = Convert.ToInt32(Console.ReadLine());
                    bool success = cmsProcess.RemoveDevotionSchedule(index - 1);
                    if (success)
                    {
                        Console.WriteLine("Remove Successfully");
                    }
                    else
                    {
                        Console.WriteLine("Removing Schedule Failed");
                    }
                } else
                {
                    Console.WriteLine("Error: No Schedule type match");
                }
            }
                
        }
        public static void SetTypeOfSchedule(string ministryName)
        {
            int typeofSchedule = cmsProcess.SetTypeOfScheduling(ministryName);
            switch (typeofSchedule)
            {
                case 1:
                    SchedulingType1(ministryName);
                    break;
                case 2:
                    SchedulingType2(ministryName);
                    break;
                case 3:
                    ManageTeachersList();
                    break;
                case 4:
                    ManageSchedule(ministryName);
                    break;
                default:
                    Console.WriteLine("Error: Input does not Match the Choices");
                    break;
            }
        }
        //first type of scheduling
        //generalType -- for Discipleship, prayer, and worship service
        static void SchedulingType1(string ministryName)
        {
            Console.WriteLine("   ");
            Console.WriteLine("APRIL 2025");

            int[] availableDates = CMSProcess.GetAvailableDates(ministryName);
            foreach (int day in availableDates)
            {
                Console.WriteLine($"April {day}, 2025");
            }

            int userChoice = UserChoice();

            if (availableDates.Contains(userChoice))
            {
                string speaker = GetSpeaker();
                string presider = GetPresider();
                string description = GetDescription();

                bool addedSchedule = cmsProcess.AddMinistrySchedule(ministryName, userChoice, speaker, presider, description);
                if (addedSchedule == true)
                {
                    Console.WriteLine("Added Successfully");
                } else
                {
                    Console.WriteLine("Error: Schedule Cannot be Added. Try Again");
                }
            }
            else
            {
                Console.WriteLine("ERROR: Date does not match the available dates");
            }
            DisplayMinistryDashboard(ministryName);
        }

        //scheduling type2 for Worship
        static void SchedulingType2(string ministryName)
        {
            //UI
            Console.WriteLine("What are you scheduling for?");
            Console.WriteLine("[1] Sunday Worship Service \n[2] Weekly P&W Practices \n[3] Weekly Team Devotion");
            int userChoice = UserChoice();

            if (userChoice == 1)
            {
                SchedulingType1(ministryName);
            }
            else if (userChoice == 2)
            {
                //UI
                string songLeader = NoNullOrEmptyInput("Song Leader: ");
                string firstRehearsalDate = GetDate();
                string firstRehearsalTime = GetTime();
                string finalRehearsalDate = GetDate();
                string finalRehearsalTime = GetTime();

                bool addedSchedule = cmsProcess.AddPraiseAndWorshipSchedule(songLeader, firstRehearsalDate, firstRehearsalTime, finalRehearsalDate, finalRehearsalTime);
                if (addedSchedule == true)
                {
                    Console.WriteLine("Added Successfully");
                }
                else
                {
                    Console.WriteLine("Error: Schedule Cannot be Added. Try Again");
                }
            }

            else if (userChoice == 3)
            {
                string speaker = GetSpeaker();
                string presider = GetPresider();
                string date = GetDate();
                string time = GetTime();

                bool addedSchedule = cmsProcess.AddDevotionSchedule(speaker, presider, date, time);
                if (addedSchedule == true)
                {
                    Console.WriteLine("Added Successfully");
                }
                else
                {
                    Console.WriteLine("Error: Schedule Cannot be Added. Try Again");
                }

            }

        }
        static void ManageTeachersList()
        {
            string teachersName = NoNullOrEmptyInput("Name: ");
            bool addedSchedule = cmsProcess.AddTeachersName(teachersName);
            if (addedSchedule == true)
            {
                Console.WriteLine("Added Successfully");
            }
            else
            {
                Console.WriteLine("Error: Schedule Cannot be Added. Try Again");
            }
        }

       static int ViewAddDeleteOption()
       {
            Console.WriteLine(" ");
            Console.WriteLine("[1]View [2]Add [3]Remove [4]Exit");
            int userChoice = UserChoice();
            return userChoice;
        }

        static void ManageListForTopics(string ministryName, int userChoice)
        {
            switch (userChoice)
            {
                case 1:
                    DisplayTopics(ministryName);
                    break;
                case 2:
                    switch (ministryName)
                    {
                        case "[1] Discipleship Ministry":
                            AddDiscipleshipTopicsDetails(ministryName); //add
                            break;
                        case "[2] Prayer Ministry":
                            AskPrayerRequest(ministryName); //add
                            break;
                        case "[3] Worship Ministry":
                            AskRepertoire(ministryName); //add
                            break;
                        case "[4] Christian Education":
                            AskLessons(ministryName); //add
                            break;
                        default:
                            Console.WriteLine("Error: ");
                            break;
                    }
                    break;
                case 3:
                    RemoveTopics(ministryName);
                    break;
                default:
                    Console.WriteLine("Invalid UserChoice");
                    break;

            }
        }
        //discipleship ministry
        static void AddDiscipleshipTopicsDetails(string ministryName)
        {
            string topic = NoNullOrEmptyInput("Enter Topic: ");
            string description = NoNullOrEmptyInput("Description of Topics: ");
            string materials = NoNullOrEmptyInput("Materials needed: ");
            string dateTime = NoNullOrEmptyInput("Date and Time: ");
            bool success = cmsProcess.AddMinistryTopics(ministryName, topic, description, materials, dateTime);
            if (success == true)
            {
                Console.WriteLine("Added successfully");
            }
            else
            {
                Console.WriteLine("Failed to Add");
            }
        }     
        //prayer ministry
        static void AskPrayerRequest(string ministryName)
        {
            string prayerRequest = NoNullOrEmptyInput("Enter your Prayer Request: ");
            bool success = cmsProcess.AddMinistryTopics(ministryName, prayerRequest);
            if (success == true)
            {
                Console.WriteLine("Your Prayer Request will be added to the list to pray for the upcoming Prayer Meeting.");
            }
            else
            {
                Console.WriteLine("Failed to Add");
            }
        }
        //worship ministry
        static void AskRepertoire(string ministryName)
        {
            Console.WriteLine("How many songs?");
            int songs = UserChoice();

            string repertoire = "";
            for(int i = 0; i < songs; i++)
            {
                string song = NoNullOrEmptyInput($"Enter Song {i + 1}:");
                repertoire += song + "\n";
            }

            bool success = cmsProcess.AddMinistryTopics(ministryName, repertoire);
            if (success == true)
            {
                Console.WriteLine("Added successfully");
            }
            else
            {
                Console.WriteLine("Failed to Add");
            }
        }
        // christian Education
        static void AskLessons(string ministryName)
        {
            string lesson = NoNullOrEmptyInput("Lesson: ");
            string teacher = NoNullOrEmptyInput("Assign Teacher: ");
            string materials = NoNullOrEmptyInput("Materials needed: ");
            bool success = cmsProcess.AddMinistryTopics(ministryName, lesson, teacher, materials);
            if (success == true)
            {
                Console.WriteLine("Added successfully");
            }
            else
            {
                Console.WriteLine("Failed to Add");
            }
        }
        static void DisplayTopics(string ministryName)
        {
            Console.WriteLine("Current List: ");
            Console.WriteLine(cmsProcess.ViewTopics(ministryName));
        }
        static void RemoveTopics(string ministryName)
        {
            Console.Write("Enter index: ");
            int index = Convert.ToInt32(Console.ReadLine());
            bool success = cmsProcess.RemoveTopics(ministryName, index - 1);
            if (success)
            {
                Console.WriteLine("Remove Successfully");
            }
            else
            {
                Console.WriteLine("Removing Schedule Failed");
            }
        }
        static string GetSpeaker()
        {
            string speaker = NoNullOrEmptyInput("Speaker: ");
            return speaker;
        }
        //BL
        static string GetPresider()
        {
            string presider = NoNullOrEmptyInput("Presider: ");
            return presider;
        }
        //BL
        static string GetDescription()
        {
            string description = NoNullOrEmptyInput("Description: ");
            return description;
        }

        //for worship
        //BL
        static string GetDate()
        {
            string date = NoNullOrEmptyInput("Enter Date: ");
            return date;
        }
        //BLs
        static string GetTime()
        {
            string time = NoNullOrEmptyInput("Enter Time: ");
            return time;
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
