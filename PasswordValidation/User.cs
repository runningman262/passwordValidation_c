using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Runtime.CompilerServices;

namespace PasswordValidation
{
    class User
    {
        public string UserName { get; private set; }

        private string Password { get; set; }

        public string Email { get; private set; }
        public string[] SecurityQuest { get; private set; }

        // store the username to the object
        public bool CreateUserName(string username)
        {
            if (IsUniqueUserName(username))
            {
                UserName = username;
                return true;
            }

            return false;       
        }

        // store the password to the object
        public void CreatePassword(string password)
        {
            Password = password;
        }

        // store the email to the object
        public void CreateEmail(string email)
        {
            Email = email;
        }

        // add the new user to the DB
        public static void AddUser(User newUser)
        {
            UserDB._users.Add(newUser);
        }
        
        // check if the input username already exists
        private bool IsUniqueUserName(string username)
        {

            int userListLength = UserDB._users.Count;
            for (int i = 0; i< userListLength; i++)
            {
                if (UserDB._users[i].UserName == username)
                {
                    return false;
                }
            }
            
            return true;
        }

       
        // create security questions
        public void CreateSecurityQuest(string question)
        {

        }

        // store user data from the DB to the object
        public bool GetUserData(string username)
        {
            int userListLength = UserDB._users.Count;
            int i = 0;
            
            while (i < userListLength)
            {
                if (UserDB._users[i].UserName == username)
                {
                    UserName = UserDB._users[i].UserName;
                    Password = UserDB._users[i].Password;
                    Email = UserDB._users[i].Email;
                    SecurityQuest = UserDB._users[i].SecurityQuest;
                    return true;
                }
                i++;
            }

            return false;
        }

        // check if the entered password is correct
        public bool CheckPassword(string password)
        {
            if (Password == password)
            {
                return true;
            }

            return false;
        }

        // store the new password to the DB
        public void UpdateUserData()
        {
            int userListLength = UserDB._users.Count;
            int i = 0;

            while (i < userListLength)
            {
                if (UserDB._users[i].UserName == UserName)
                {
                    UserDB._users[i].Password = Password;
                    return;
                }
                    
                i++;
            }
        }

    }
}
