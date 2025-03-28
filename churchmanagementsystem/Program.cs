using System;
using System.Collections.Generic;
using System.Diagnostics;
using BusinessAndDataLogic;

namespace churchmanagementsystem
{
    internal class Program
    {
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
        static int UserChoice()
        {
            Console.Write("Enter Choice: ");
            int userChoice = Convert.ToInt16(Console.ReadLine());
            return userChoice;
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

            Console.Write("First Name: ");
            string firstName = Console.ReadLine();
            Console.Write("Last Name: ");
            string lastName = Console.ReadLine();
            Console.Write("Age: ");
            int age = Convert.ToInt16(Console.ReadLine());
            Console.Write("Email Address: ");
            string emailAddress = Console.ReadLine();

            Console.WriteLine("Are you an Officer/Admin? [1]Yes [2]No: ");
            //BL
            int positionChoice = UserChoice();

            string username = CreateUsername();
            string password = CreatePassword();

            bool isAdmin = positionChoice == 1;
            if (isAdmin)
            {
                Console.Write("Enter Ministry: ");
                string ministryName = Console.ReadLine();
                Console.Write("Enter Position: ");
                string position = Console.ReadLine();
            }
            CMSProcess.RegisteredUsernameAndPassword(username, password, isAdmin);
            Console.WriteLine("Registration Complete");
            DisplayDashboard();
        }
        static string CreateUsername()
        {
            Console.Write("Create Username: ");
            string username = Console.ReadLine();
            return username;
        }
        static string CreatePassword()
        {
            while (true)
            {
                Console.Write("Create your Password: ");
                string password = Console.ReadLine();

                Console.Write("Re-Enter your Password: ");
                string re_Enter_Password = Console.ReadLine();

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
                Console.Write("Username: ");
                string username = Console.ReadLine();
                Console.Write("Password: ");
                string password = Console.ReadLine();

                if (CMSProcess.ValidatingUsernameAndPassword(username, password, isAdmin))
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
            Console.WriteLine("\n Welcome to Adelina Christian Church");
            Console.WriteLine("Ministry: ");

            string[] ministryName = CMSProcess.MinistryNamesList();
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
            //BL
            int userChoice = UserChoice();
            ProcessMinistryOptionsChoice(ministryName, userChoice);

        }
        //BL
        static void ProcessMinistryOptionsChoice(string ministryName, int userChoice)
        {
            switch (userChoice)
            {
                case 1:
                    ManageSchedule(ministryName);
                    break;
                case 2:
                    ManageListForTopics(ministryName);
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

                if (userChoice == 1)
                {
                    Console.WriteLine("Current List: ");
                    List<string> schedules = CMSProcess.ViewSchedule(ministryName);
                    foreach (string schedule in schedules)
                    {
                        Console.WriteLine(schedule);
                    }
                }
                //BL
                else if (userChoice == 2)
                {     
                    if(ministryName == "[4] Christian Education")
                    {
                        ManageTeachersList(ministryName);
                    }
                    SetTypeOfSchedule(ministryName);
                }
                else if (userChoice == 3)
                {
                    Console.Write("Enter something to remove? ");
                    string toRemove = Console.ReadLine();
                    if (CMSProcess.RemoveScheduleItem(ministryName,toRemove))
                    {
                        Console.WriteLine("Removed Successfully");
                    
                    } else
                    {
                        Console.WriteLine("No item to remove");
                    }
                }
                else if (userChoice == 4)
                {
                    return;
                }
                else
                {
                    Console.WriteLine("Error");
                }
            }
        }
        public static void SetTypeOfSchedule(string ministryName)
        {
            if (ministryName == "[1] Discipleship Ministry" || ministryName == "[2] Prayer Ministry")
            {
                SchedulingType1(ministryName);
            }
            else if (ministryName == "[3] Worship Ministry")
            {
                SchedulingType2(ministryName);
            }
            else if (ministryName == "[4] Christian Education")
            {
                ManageSchedule(ministryName);
            }
            else
            {
                Console.WriteLine("Unknown ministry. Cannot set scheduling type.");
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

                bool addedSchedule = CMSProcess.ProcessingType1Scheduling(ministryName, userChoice, speaker, presider, description);
                if(addedSchedule == true)
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

            //BL
            if (userChoice == 1)
            {
                SchedulingType1(ministryName);
            }
            else if (userChoice == 2)
            {
                //UI
                Console.Write("Song Leader: ");
                string songLeader = Console.ReadLine();

                Console.WriteLine("Date (First rehearsal)");
                string firstRehearsalDate = GetDate();

                Console.WriteLine("Time ");
                string firstRehearsalTime = GetTime();

                Console.WriteLine("Date (Final rehearsal)");
                string finalRehearsalDate = GetDate();

                Console.WriteLine("Time: ");
                string finalRehearsalTime = GetTime();

                bool addedSchedule = CMSProcess.ProcessingType2Scheduling(ministryName, userChoice, songLeader, firstRehearsalDate, firstRehearsalTime, finalRehearsalDate, finalRehearsalTime);
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

                bool addedSchedule = CMSProcess.ProcessingType2Scheduling(ministryName, userChoice, speaker, presider, date, time);
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

        static void ManageTeachersList(string ministryName)
        {
            if (ministryName == "[4] Christian Education")
            {
                Console.Write("Name: ");
                string teachersName = Console.ReadLine();

                bool addedSchedule = CMSProcess.ProcessingTeachersList(ministryName,teachersName);
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


        //code for OPTION NUMBER 2
        //view add remove function
        static void ManageListForTopics(string ministryName)
        {
            int userChoice;
            while (true)
            {
                Console.WriteLine(" ");
                Console.WriteLine("[1]View [2]Add [3]Remove [4]Exit");
                userChoice = UserChoice();

                if (userChoice == 1)
                {
                    Console.WriteLine("Current List: ");
                    List<string> topics = CMSProcess.ViewTopicList(ministryName);
                    foreach (string topic in topics)
                    {
                        Console.WriteLine(topic);
                    }  
                }
                else if (userChoice == 2)
                {
                    string details = GetTypesOfTopics(ministryName);
                    bool added = CMSProcess.ProcessingTopicTypes1(ministryName, details);
                    if (added == true)
                    {
                        Console.WriteLine("Added Successfully");
                    } else
                    {
                        Console.WriteLine("Topic Cannot be added");
                    }
                }
                else if (userChoice == 3)
                {
                    Console.Write("Enter something to remove? ");
                    string toRemove = Console.ReadLine();
                    if (CMSProcess.RemoveTopics(ministryName, toRemove))
                    {
                        Console.WriteLine("Removed Successfully");
                    }
                    else
                    {
                        Console.WriteLine("No item to remove");
                    }
                }
                else if (userChoice == 4)
                {
                    return;
                }
                else
                {
                    Console.WriteLine("Error");
                }
            }
        }
        //kung anong ministry mag ibaba ng path. sheeshshshsajdhajda
        static string GetTypesOfTopics(string ministryName)
        {
            if (ministryName == "[1] Discipleship Ministry" || ministryName == "[4] Christian Education")
            {
                string date = GetDate();
                string time = GetTime();
                Console.Write("Topics: ");
                string topics = Console.ReadLine();
                return ($"Details: \n{date} \n{time} \n{topics}");
            }
            else if (ministryName == "[3] Worship Ministry")
            {
                Console.Write("How many songs? ");
                int numberOfSongs = Convert.ToInt16(Console.ReadLine());

                List<string> repertoires = new List<string> ();
                for (int i = 0; i < numberOfSongs; i++)
                {
                    Console.Write("Enter your Repertoire: ");
                    string input = Console.ReadLine();
                    repertoires.Add(input);
                }
                string repertoire = "Repertoire:\n";

                foreach (string song in repertoires)
                {
                    repertoire += song + "\n";
                }
                return repertoire;
            }
            else if (ministryName == "[2] Prayer Ministry")
            {
                Console.Write("Enter your Prayer Request: ");
                string prayerRequest = Console.ReadLine();
                return prayerRequest;
            }
            else
            {
                return "Error: Ministry Name not Found";
            }
        }

        static string GetSpeaker()
        {
            Console.Write("Speaker: ");
            string speaker = Console.ReadLine();
            return speaker;
        }
        //BL
        static string GetPresider()
        {
            Console.Write("Presider: ");
            string presider = Console.ReadLine();
            return presider;
        }
        //BL
        static string GetDescription()
        {
            Console.Write("Description: ");
            string description = Console.ReadLine();
            return description;
        }
        //BL
        static string GetDate()
        {
            Console.Write("Enter Date: ");
            string date = Console.ReadLine();
            return date;
        }
        //BLs
        static string GetTime()
        {
            Console.Write("Enter Time: ");
            string time = Console.ReadLine();
            return time;
        }

    }
}
