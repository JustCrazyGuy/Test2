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
            Biolige biolige = new Biolige();
            History history = new History();
            List<ICommand> commands;
            List<ICommand> nonLogUser = new List<ICommand>();
            List<ICommand> logUser = new List<ICommand>();
            Dictionary<string, User> users = new Dictionary<string, User>();
            CurrentUser currentUser = new CurrentUser();
            nonLogUser.Add(new LogIn(users, currentUser));
            nonLogUser.Add(new Register(users));
            nonLogUser.Add(new ExitCommand());

            logUser.Add(new StartBioQuiz(biolige));
            logUser.Add(new NewQuiz(biolige, history));
            logUser.Add(new SaveInFileHistory(history));
            logUser.Add(new SaveInFileBiolige(biolige));
            logUser.Add(new LoadFromFile(biolige,history));
            logUser.Add(new ChangeQuationInHistory(history));
            logUser.Add(new ChangeAnswersInHistory(history));
            logUser.Add(new ChangeQuationInBiolige(biolige));
            logUser.Add(new ChangeAnswersInBiolige(biolige));
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

