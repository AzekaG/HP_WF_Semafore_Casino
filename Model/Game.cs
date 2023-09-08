using HP_WF_Semafore_Casino.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;

namespace HP_WF_Semafore_Casino.Model
{
    internal class Game
    {
        static Semaphore semaphore;
        int MaxPlayersOnTheTable = 5;
        public int CountPlayersToday = 0;
        public int NumberOfGame = 0;
        string[] Names = { "Oleg", "Victor", "Alla", "Gevorg", "Sergio", "Anastasia", "Alex", "Grigoriy", "leonid" };
        Random random = new Random();
        List<Player> players;
        public List<string> Report = new List<string>();
        int WinNumber = 0;              //выиграшный номер




        public Game()
        {
            CountPlayersToday = random.Next(20,100);
            semaphore = new Semaphore(MaxPlayersOnTheTable, CountPlayersToday);
            players = new List<Player>();

        }



        public void StartGame(Form1 form)
        {
            WinNumber = GetWinNumber();
            UpdatePlayers();
            NumberOfGame++;
            for(int i = players.Count(); i <= MaxPlayersOnTheTable; i++)         //как поставить зависимость семафора? 
            {
                IniPlayers();
            }

            FinishDay(form);
        }

       

        public void IniPlayers()
        {
            Task task = new Task(CreatePlayers);
            task.Start();
        }

        public void CreatePlayers()
        {
            semaphore.WaitOne();
            Player player= new Player()
            {
                Name = Names[random.Next(0, Names.Length - 1)],
                Balance = 100,
                Number = random.Next(0, 37),
                Rate = random.Next(1, 100)
            };
            players.Add(player);
            semaphore.Release();
        }



        public void UpdatePlayers()         
        {
            List<Player> playersTemp = new List<Player>();
                      
            if (NumberOfGame!=0)
            {
                foreach(var el in players)
                {
                    if(el.Number == WinNumber)
                    {
                        el.UpdateCashDouble();
                        playersTemp.Add(el);
                        el.SetRate(random.Next(1,el.Balance));
                        Report.Add($"Выиграшный нмоер : " + WinNumber);
                        Report.Add($"{el.PlayerNum} {el.Name} wiт ,+{el.Rate}");
                    }
                    else
                    {
                        el.UpdateCashLoseGame();
                        if(el.Balance>0)
                        {
                            el.SetRate(random.Next(1, el.Balance));
                            playersTemp.Add(el);
                        }
                        if(el.Balance == 0 ) 
                        {
                            Report.Add(el.PlayerNum + " " + el.Name + " покинул игру");
                        }
                    }
                   
                }

              
            }
            players = playersTemp;
        }


        public void FinishDay(Form1 form)
        {
            if (CountPlayersToday < Player.PlayerNumber)
            {
                MessageBox.Show("Day was Finished, Report in File!");

                FileWriter.Writer(Report);
                Thread.Sleep(2000);
                MessageBox.Show("Close Casino", "bue", MessageBoxButtons.OK);
                form.Close();
            };
        }









        public int GetWinNumber()           //выпавшее число
        {

            return random.Next(0, 37);
        }

        public List<Player> GetPlayers()
        {
            return players;
        }





















    }
}
