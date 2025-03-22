using System;

namespace churchmanagementsystem
{
    internal class Program
    {
        static List<string> usernames = new List<string>();
        static List<string> passwords = new List<string>();

        static void Main(string[] args)
        {
            DisplayDashboard();
        }

        static void DisplayDashboard()
        {
            
            Console.WriteLine("\nWELCOME TO ADELINA CHRISTIAN CHURCH");
            DisplayLine();
            Console.WriteLine("[1] Register");
            Console.WriteLine("[2] Log in");
            Console.WriteLine("[3] Log in as an Admin (Leader)");

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
                } else
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
                    DisplayMinistryDashBoard();
                }

                attempt++;
                Console.WriteLine("No username or password found. Try Again");
                Console.WriteLine($"Attempt: {attempt} of {maxAttempt}");
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

        static void DisplayMinistryDashBoard()
        {
            Console.WriteLine("\n Welcome to Adelina Christian Church");
            Console.WriteLine("Ministry: ");

            string[] ministry = {"[1] Christian Education", "[2] Evangelism Ministry",
                    "[3] Worship Ministry", "[4] Discipleship Ministry",
                    "[5] Admin", "[6] Prayer Ministry", "[7] Exit"};

            foreach (string options in ministry)
            {
                Console.WriteLine(options);
            }

            int userChoice = UserChoice();
            string[] ministryName = {"Christian Education", "Evangelism Ministry", "Worship Ministry",
                                    "Discipleship Ministry", "Admin", "Prayer Ministry"};
            if(userChoice == 7){
                DisplayDashboard();
            }
            else if(userChoice >= 1 || userChoice <= 6 )
            {
                MinistryDashboard(ministryName[userChoice - 1]);
            } else
            {
                Console.WriteLine("ERROR: Number exceeds the range");
                DisplayMinistryDashBoard();
            }
            
        }
        static void MinistryDashboard(string ministryName)
        {
            while (true)
            {
                Console.WriteLine($"\n {ministryName}");
                DisplayLine();
                Console.WriteLine("No data");
                Console.WriteLine("[2] Return to User Dashboard");

                int userChoice = UserChoice();
                if (userChoice == 2)
                {
                    DisplayMinistryDashBoard();
                    return;
                }
                else
                {
                    Console.WriteLine("Invalid Input");
                }
            }
        }
    }
}
