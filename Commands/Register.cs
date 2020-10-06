using ConsoleApp6.Entity;
using System;
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
    class Register : ICommand
    {
        private readonly  Dictionary<string,User> users;


        public Register(Dictionary<string, User> users)
        {
            this.users = users;
        }

        public bool CanRun(string input)
        {
            return input == "Register";
        }

        public string GetMenuRow()
        {
            return "Register - Регистрация";
        }
        public string Run(string input, ref bool isExit)
        {
            User user = new User();    
            WriteLine("Введите логин: ");
            user.Login = ReadLine();

            WriteLine("Введите пароль :");
            user.Password = ReadLine();

            WriteLine("Введите дату рождения: ");
            user.Birthday = DateTime.Parse(ReadLine());

            if (users.ContainsKey(user.Login))
            {
                return "Такой логин уже существует";
            }
            else
            {
                users.Add(user.Login, user);
                BinaryFormatter serializer = new BinaryFormatter();

                using (Stream FileS = File.OpenWrite("Users.txt"))
                {
                    try
                    {
                        serializer.Serialize(FileS, users);
                    }
                    catch (SerializationException e)
                    {
                        WriteLine("Failed to serialize. Reason: " + e.Message);
                        throw;
                    }
                }
                return " Регистрация прошла успешно";
            }
           
        }

    }
}
