using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace PasswordValidation
{
    class Program
    {
        static void InputUserName(User user)
        {
            bool userFound = false;
            while (!userFound)
            {
                Console.Write("Username: ");
                userFound = user.GetUserData(Console.ReadLine().ToLower());
                if (!userFound)
                    Console.WriteLine("User does not exist");

            }

                
        }
        static void Main(string[] args)
        {
            // 1. Ask the user if they want to Sign Up, Login, or Forgot Password
            // store the options to a string for easy writing to the console
            string[] options = new string[] { "1 - Signup", "2 - Login", "3 - Forgot Password" };

            if (options.Length < 1)
                throw new IndexOutOfRangeException("Array must have at least one element");
            
            bool running = true;

            // loop to continue prompting until done logging in, creating, resetting password, etc.
            while (running)
            {

                int choice = -1;
                

                foreach (string option in options)
                {
                    Console.WriteLine(option);
                }

                Console.Write("Choose an option (Enter to quit): ");
                   
                string response = Console.ReadLine();

                // error handling
                try
                {
                    choice = int.Parse(response);
                }
                catch (Exception)
                {
                    if (string.IsNullOrWhiteSpace(response))
                    {
                        running = false;
                        break;
                    }

                }


                // continue with program if it hasn't been quit
                if (running)
                {
                    User user = new User();
                    // 2. Signup to require a unique username, password, email address, and two security questions and answers
                    if (choice == 1)
                    {
                        bool userCreated = false;
                        
                        
                        while (!userCreated)
                        {
                            Console.Write("Choose a username: ");

                            userCreated = user.CreateUserName(Console.ReadLine().ToLower());
                            if (!userCreated)
                                Console.WriteLine("Sorry, that username already exists.");

                        }

                        Console.Write("Choose a password: ");
                        user.CreatePassword(Console.ReadLine());

                        Console.Write("Enter your Email: ");
                        user.CreateEmail(Console.ReadLine());

                        
                        User.AddUser(user);
                        
                    }
                    // 3. Login only requires correct username and password
                    else if (choice == 2)
                    {
                                            
                        InputUserName(user);
                        
                        Console.Write("Password: ");
                        bool correctPassword = user.CheckPassword(Console.ReadLine());
                        
                        if (correctPassword)
                            Console.WriteLine($"Welcome back, {user.UserName}");
                        else
                            Console.WriteLine("Password is incorrect.");
                    }
                    // 4. Forgot Password requires the correct username and answer both security questions
                    else if (choice == 3)
                    {
                        InputUserName(user);
                        Console.Write("Enter new password: ");
                        user.CreatePassword(Console.ReadLine());
                        user.UpdateUserData();
                    }
                    // if invalid entry
                    else
                    {
                        Console.WriteLine("Please select a valid option.");
                    }

                }
                
            
            }
            
            
            


        }
    }
}
