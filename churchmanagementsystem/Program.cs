using System;

namespace churchmanagementsystem
{
    internal class Program
    {
        static List<string> usernames = new List<string>();
        static List<string> passwords = new List<string>();
        static List<string> teachersList = new List<string>();
        static void Main(string[] args)
        {
            usernames.Add("ken");
            passwords.Add("123");
            DisplayDashboard();
        }
        static void DisplayDashboard()
        {
            
            Console.WriteLine("\nWELCOME TO ADELINA CHRISTIAN CHURCH");
            DisplayLine();
            Console.WriteLine("[1] Register");
            Console.WriteLine("[2] Log in");
            Console.WriteLine("[3] Log in as an Admin (Leader)");
            Console.WriteLine("[4] Exit");

            int userChoice;
            do { 
                userChoice = UserChoice();
                if (userChoice == 1)
                {
                    RegisterUser();
                }
                else if (userChoice == 2)
                {
                    SignInUser();
                }
                else if (userChoice == 3)
                {
                    SignInLeader();
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
        static void HandlingUserPosition()
        {
            Console.Write("Enter Ministry: ");
            string ministry = Console.ReadLine();
            Console.Write("Enter Position: ");
            string position = Console.ReadLine();
        }
        static void RegisterUser()
        {
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

            Console.Write("Are you an Officer/Admin? [1]Yes [2]No: ");
            int positionChoice = UserChoice();
            
            if (positionChoice == 1)
            {
                HandlingUserPosition();
            }
            else if (positionChoice == 2)
            {
                 
            }
            else
            {
                Console.WriteLine("Error: Input Exceeds Valid Range");
            }

            Console.Write("Create Username: ");
            string username = Console.ReadLine();

            while (true)
            {
                Console.Write("Create your Password: ");
                string password = Console.ReadLine();

                Console.Write("Re-Enter your Password: ");
                string re_Enter_Password = Console.ReadLine();

                if (password != re_Enter_Password)
                {
                    Console.WriteLine("Password does not Match. Try again");
                }
                else
                {
                    Console.WriteLine("Registration Complete!!");
                    usernames.Add(username);
                    passwords.Add(password);
                    DisplayDashboard();
                    return;

                }
            }
        }
        static void ValidatingUsernameAndPassword()
        {
            string loginUsername;
            string loginPassword;

            int attempt = 0;
            int maxAttempt = 5;

            while (attempt < maxAttempt)
            {
                Console.Write("Username: ");
                loginUsername = Console.ReadLine();
                Console.Write("Password: ");
                loginPassword = Console.ReadLine();

                int index = usernames.IndexOf(loginUsername);
                if (index != -1  && passwords[index] == loginPassword)
                {
                    Console.WriteLine("Login Successfully");
                    DisplayMinistryOptions();
                }

                attempt++;
                Console.WriteLine("No username or password found. Try Again");
                Console.WriteLine($"Attempt: {attempt} of {maxAttempt}\n");
            }
            Console.WriteLine("Oops!!! You Reached Maximum Attempt. Try Again Later");
            Thread.Sleep(10000);
            DisplayDashboard();
        }
        static void SignInUser()
        {
            Console.WriteLine("\nACC USER LOGIN");
            DisplayLine();
            ValidatingUsernameAndPassword();
        }
        static void SignInLeader()
        {
            Console.WriteLine("\nACC LEADERS LOGIN");
            DisplayLine();
            HandlingUserPosition();
            ValidatingUsernameAndPassword();
            
        }
        static void DisplayMinistryOptions()
        {
            Console.WriteLine("\n Welcome to Adelina Christian Church");

            string[] ministryName = MinistryName();

            int userChoice = UserChoice();
            
            if(userChoice == 5){
                DisplayDashboard();
            }
            else if(userChoice >= 1 || userChoice <= 4 )
            {
                DisplayMinistryDashboard(ministryName[userChoice - 1]);
            } else
            {
                Console.WriteLine("ERROR: Number exceeds the range");
                DisplayMinistryOptions();
            }
            
        }
        static string[] MinistryName()
        {
            Console.WriteLine("Ministry: ");

            string[] ministry = {"[1] Discipleship Ministry","[2] Prayer Ministry",
                    "[3] Worship Ministry", "[4] Christian Education", "[5] Exit"};

            foreach (string options in ministry)
            {
                Console.WriteLine(options);
            }
            return ministry;

        }
        static void DisplayMinistryDashboard(string ministryName)
        {

            Console.WriteLine($"\n{ministryName}");
            DisplayLine();

            if (ministryName == "[1] Discipleship Ministry")
            {
                DiscipleshipMinistryContents(ministryName);

            } else if (ministryName == "[2] Prayer Ministry")
            {
                PrayerMinistryContents(ministryName);

            } else if (ministryName == "[3] Worship Ministry")
            {
                WorshipMinistryContents(ministryName);

            } else if (ministryName == "[4] Christian Education")
            {
                ChristianEducationContents(ministryName);
            }
            
        }

        static void DiscipleshipMinistryContents(string ministryName)
        {
            string[] contents = {"[1]Schedule", "[2]Topics", "[3]Exit" };
            foreach (string content in contents)
            {
                Console.WriteLine(content);
            }

            int userChoice = UserChoice();

            if(userChoice == 1)
            {
                FunctionsOfOption1(ministryName);

            }
            else if (userChoice == 2)
            {
                FunctionsOfOption2(ministryName);
            }
            else if(userChoice == 3)
            {
                DisplayMinistryOptions();
            }
            else
            {
                Console.WriteLine("ERROR: Exceeds 1-2 input");
            }
        }

        static void PrayerMinistryContents(string ministryName)
        {
            string[] contents = { "[1]Schedule", "[2]Prayer Items","[3]Exit" };
            foreach (string content in contents)
            {
                Console.WriteLine(content);
            }

            int userChoice = UserChoice();
            if (userChoice == 1)
            {
                FunctionsOfOption1(ministryName);

            }
            else if (userChoice == 2)
            {
                FunctionsOfOption2(ministryName);

            } else if (userChoice == 3)
            {
                DisplayMinistryOptions();
            }
            else
            {
                Console.WriteLine("ERROR: Exceeds 1-2 input");
            }
        }

        static void WorshipMinistryContents(string ministryName)
        {
            string[] contents = { "[1]Schedule", "[2]Repertoire", "[3]Exit" };
            foreach (string content in contents)
            {
                Console.WriteLine(content);
            }
            int userChoice = UserChoice();
            if(userChoice == 1)
            {
                Console.WriteLine("What are you scheduling for? ");
                Console.WriteLine("[1]Sunday Worship Service [2]Weekly P&W Practices [3]Weekly Team Devotion");
                userChoice = UserChoice();
                if(userChoice == 1)
                {
                    FunctionsOfOption1(ministryName);
                } else if (userChoice == 2)
                {
                    //wag na gawing method since this function is only for Worship Ministry
                    //di na rin sya marere-use
                    Console.Write("Date: ");
                    string date = Console.ReadLine();
                    Console.Write("Time: ");
                    string time = Console.ReadLine();
                    Console.Write("Song Leader: ");
                    string songLeader = Console.ReadLine();

                    Console.WriteLine(" ");
                    Console.WriteLine("");
                    Console.WriteLine("Added Practice Schedule");
                    Console.WriteLine($"Date: {date}");
                    Console.WriteLine($"Time: {time}");
                    Console.WriteLine($"Song Leader: {songLeader}");
                } else if (userChoice == 3)
                {
                    Console.Write("Date: ");
                    string date = Console.ReadLine();
                    Console.Write("Time: ");
                    string time = Console.ReadLine();
                    string speaker = Speaker();
                    string presider = Presider();

                    Console.WriteLine("");
                    Console.WriteLine("Added Devotion Schedule: ");
                    Console.WriteLine($"Date: {date}");
                    Console.WriteLine($"Time: {time}");
                    Console.WriteLine($"Speaker: {speaker}");
                    Console.WriteLine($"Presider: {presider}");

                }
            } else if (userChoice == 2)
            {
                FunctionsOfOption2(ministryName);

            } else if (userChoice == 3)
            {
                DisplayMinistryOptions();
            } else
            {
                Console.WriteLine("ERROR: ");
            }

        }

        static void ChristianEducationContents(string ministryName)
        {
           
            string[] contents = { "[1]Lessons", "[2]Teacher's List", "[3]Exit"};
            foreach (string content in contents)
            {
                Console.WriteLine(content);
            }
            int userChoice = UserChoice();
            if (userChoice == 1)
            {
                FunctionsOfOption2(ministryName);

            } else if (userChoice == 2)
            {
                ManageTeachersList(userChoice);
            } else if (userChoice == 3)
            {
                DisplayMinistryOptions();
            } else
            {
                Console.WriteLine("ERROR: ");
            }

        }
        static void ManageTeachersList(int userChoice)
        {
            while (true)
            {
                Console.WriteLine(" ");
                Console.WriteLine("[1]View [2]Add [3]Remove [4]Exit");
                userChoice = UserChoice();

                if (userChoice == 1)
                {
                    Console.WriteLine("Current Teachers: ");
                    foreach (string teacher in teachersList)
                    {
                        Console.WriteLine($"- {teacher}");
                    }

                }
                else if (userChoice == 2)
                {
                    Console.Write("How many? ");
                    int amount = Convert.ToInt32(Console.ReadLine());
                    for (int i = 0; i < amount; i++)
                    {
                        Console.Write("Name: ");
                        string name = Console.ReadLine();
                        teachersList.Add(name);
                    }
                    Console.WriteLine("ADDED SUCCESSFULLY");
                }
                else if (userChoice == 3)
                {
                    Console.Write("Enter Name: ");
                    string name = Console.ReadLine();
                    int i = teachersList.IndexOf(name);
                    if (i != -1)
                    {
                        Console.WriteLine("REMOVED SUCCESSFULLY");
                        teachersList.Remove(name);
                    }
                    else
                    {
                        Console.WriteLine($"{name} is not in the list");
                    }
                } else if (userChoice == 4)
                {
                    return;
                } else
                {
                    Console.WriteLine("Error");
                }
            }
            
        }
        static void FunctionsOfOption2(string ministryName)
        {
            Console.WriteLine(" ");
            if(ministryName == "Discipleship Ministry" || ministryName == "Christian Education")
            {
                string topic = ValidationOfMinistriesTopics(ministryName);
                Console.WriteLine($"Topics: {topic}");
            } else if (ministryName == "Worship Ministry")
            {
                string repertiore = ValidationOfMinistriesTopics(ministryName);
                Console.WriteLine($"Repertoire: {repertiore}");
            } else if (ministryName == "Prayer Ministry")
            {
                string prayerRequest = ValidationOfMinistriesTopics(ministryName);
                Console.WriteLine($"Prayer Request: {prayerRequest}");
            }

        }
        static void FunctionsOfOption1(string ministryName)
        {
            string again = "yes";
            do
            {
                Console.WriteLine("   ");
                Console.WriteLine("APRIL 2025");

                int[] availableDates = ValidationOfMinistriesDates(ministryName);
                int userChoice = UserChoice();

                if (availableDates.Contains(userChoice))
                {
                    string speaker = Speaker();
                    string presider = Presider();
                    string description = Description();

                    Console.WriteLine("");
                    Console.WriteLine($"Added {ministryName} Schedule: ");
                    Console.WriteLine($"Date: April {userChoice}, 2025");
                    Console.WriteLine($"Speaker: {speaker}");
                    Console.WriteLine($"Presider: {presider}");
                    Console.WriteLine($"Description: {description}");

                    Console.WriteLine("");
                    Console.WriteLine("Do you want to schedule again? [Yes or No?]");
                    Console.Write("Action: ");
                    again = Console.ReadLine().ToLower();

                }
                else
                {
                    Console.WriteLine("ERROR: Date does not match the available dates");
                }
            } while (again == "yes");
            DisplayMinistryOptions();

        }
        static string ValidationOfMinistriesTopics(string ministryName)
        {
            if(ministryName == "Discipleship Ministry" || ministryName == "Christian Education")
            {
                Console.WriteLine("Topics: ");
                string topics = Console.ReadLine();
                return topics;
            } 
            else if (ministryName == "Worship Ministry")
            {
                Console.WriteLine("Enter your Repertoire: ");
                string repertiore = Console.ReadLine();
                return repertiore;
            }
            else if (ministryName == "Prayer Ministry")
            {
                Console.WriteLine("Enter your Prayer Request: ");
                string prayerRequest = Console.ReadLine();
                return prayerRequest;
            }
            else
            {
                return "Error: Ministry Name not Found";
            }
        }
        static int[] ValidationOfMinistriesDates(string ministryNames)
        {
            if(ministryNames == "Discipleship Ministry" || ministryNames == "Worship Ministry")
            {
                int[] datesSunday = { 6, 13, 20, 27 };
                foreach (int date in datesSunday)
                {
                    Console.WriteLine(date);
                }
                return datesSunday;

            } else if (ministryNames == "Prayer Ministry")
            {
                int[] datesThursday = { 3, 10, 17, 24 };
                foreach (int date in datesThursday)
                {
                    Console.WriteLine(date);
                }
                return datesThursday;
            } else
            {
                Console.WriteLine("Ministry Name does not Exist");
                return new int[0];
            }
        }

        
        static string Speaker()
        {
            Console.Write("Speaker: ");
            string speaker = Console.ReadLine();
            return speaker; 
        }
        static string Presider()
        {
            Console.Write("Presider: ");
            string presider = Console.ReadLine();
            return presider;
        }
        static string Description()
        {
            Console.Write("Description: ");
            string description = Console.ReadLine();
            return description;
        }

    }
}
