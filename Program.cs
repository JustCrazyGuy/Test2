using ConsoleApp6.Commands;
using ConsoleApp6.Entity;
using ConsoleApp6.Victoryns;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace ConsoleApp6
{
    class Program
    {
        public bool TrueLog = false;
        static void Main(string[] args)
        {
            bool isExit = false;
            string input;
            string commandResult;
            Quiz quiz = new Quiz();
            List<ICommand> commands;
            List<ICommand> nonLogUser = new List<ICommand>();
            List<ICommand> logUser = new List<ICommand>();
            Dictionary<string, User> users = new Dictionary<string, User>();
            CurrentUser currentUser = new CurrentUser();
            nonLogUser.Add(new LogIn(users, currentUser));
            nonLogUser.Add(new Register(users));
            nonLogUser.Add(new ExitCommand());

            logUser.Add(new StartBioQuiz(quiz));
            logUser.Add(new NewQuiz(quiz));
            logUser.Add(new SaveInFileHistory(quiz));
            logUser.Add(new SaveInFileBiolige(quiz));
            logUser.Add(new LoadFromFile(quiz));
            logUser.Add(new ChangeQuationInHistory(quiz));
            logUser.Add(new ChangeAnswersInHistory(quiz));
            logUser.Add(new ChangeQuationInBiolige(quiz));
            logUser.Add(new ChangeAnswersInBiolige(quiz));
            logUser.Add(new ChangePassword(users));
            logUser.Add(new ChangeBirthday(users));
            logUser.Add(new ExitCommand());

            do
            {
                if (currentUser.user != null) {
                    commands = logUser;
                }
                else
                {
                    commands = nonLogUser;
                }

                WriteLine("===========================================");
                foreach (ICommand command in commands)
                {
                    WriteLine(command.GetMenuRow());
                }
                WriteLine();
                Write("Введите команду: ");
                input = ReadLine();
                foreach (ICommand command in commands)
                {
                    if (command.CanRun(input))
                    {

                        commandResult = command.Run(input, ref isExit);
                        // WriteLine("твоя ошибка");
                        WriteLine(commandResult);
                        break;
                    }
                }
            } while (!isExit);
        }
    }
}

