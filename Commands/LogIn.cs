using ConsoleApp6.Entity;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace ConsoleApp6.Commands
{
    class LogIn : ICommand
    {
        private readonly Dictionary<string, User> users;
        private readonly CurrentUser currentUser;

        public LogIn(Dictionary<string, User> users, CurrentUser currentUser)
        {
            try
            {
                using (Stream FileS = File.OpenRead("Users.txt"))
                {
                    try
                    {
                        BinaryFormatter Serializer = new BinaryFormatter();
                        users = (Dictionary<string, User>)Serializer.Deserialize(FileS);
                    }
                    catch (SerializationException e)
                    {
                        WriteLine("Failed to deserialize. Reason: " + e.Message);
                        throw;
                    }
                }
                foreach (var count in users)
                {
                    this.users = users;
                }
                this.currentUser = currentUser;
            }
            catch
            {
                using (Stream FileS = File.OpenWrite("Users.txt"))
                {
                    //Небольшой костыль чтобы избежать вылета при первом запуске
                }

            }
        }

        public bool CanRun(string input)
        {
            return input == "LogIn";
        }

        public string GetMenuRow()
        {
            return "LogIn - авторизация";
        }
        public string Run(string input, ref bool isExit)
        {
            string currentLogin;
            string currentPassword;
            WriteLine("Введите логин: ");
            currentLogin = ReadLine();
            WriteLine("Введите пароль: ");
            currentPassword = ReadLine();

            User user;
           

            users.TryGetValue(currentLogin, out user);

            if (!users.TryGetValue(currentLogin, out user ) || currentPassword!=user.Password)
            {
                return "Логин или пароль неверны!";
            }
           
            currentUser.user = user;
                return "Добро Пожаловать! " + user.Login;
        }
    }
}
