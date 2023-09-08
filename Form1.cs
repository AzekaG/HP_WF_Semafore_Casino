using HP_WF_Semafore_Casino.Model;
using HP_WF_Semafore_Casino.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Permissions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace HP_WF_Semafore_Casino
{
    public partial class Form1 : Form
    {
        Game game;
        ImageList imageList;
        Random random= new Random();
        public Form1()
        {
            
            InitializeComponent();
            imageList = new ImageList();
            
            imageList.Images.Add(System.Drawing.Image.FromFile(@"Resources\icons8-неймар-48.png"));
            imageList.Images.Add(System.Drawing.Image.FromFile(@"Resources\icons8-озил-48.png"));
            imageList.Images.Add(System.Drawing.Image.FromFile(@"Resources\icons8-роналдо-48 (1).png"));
            imageList.Images.Add(System.Drawing.Image.FromFile(@"Resources\icons8-роналдо-48.png"));
            imageList.Images.Add(System.Drawing.Image.FromFile(@"Resources\icons8-салах-48.png"));
            imageList.Images.Add(System.Drawing.Image.FromFile(@"Resources\icons8-суарес-48.png"));
            imageList.Images.Add(System.Drawing.Image.FromFile(@"Resources\Без названия.png"));
            imageList.Images.Add(System.Drawing.Image.FromFile(@"Resources\icons8-американская-рулетка-48.png"));
            game = new Game();
            
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            game.StartGame(this);
            IniLabels();                    //инициализация элементов
            game.NumberOfGame++;            //подсчет игры для отчета
           
            listBox1.DataSource = null;
            listBox1.DataSource = game.Report;
           



        }

        public void IniLabels()
        {
            int tempcount = 0;
            foreach (var el in Controls)
            {
                if (el.GetType() == typeof(Label))      
                {
                    if ((el as Label).Name == "lblWinNumber")
                    {
                        (el as Label).Text = game.GetWinNumber().ToString();
                        (el as Label).Image = imageList.Images[7];
                        continue;
                    }
                    if (game.GetPlayers()[tempcount].ToString() != null)
                        (el as Label).Text = game.GetPlayers()[tempcount].ToString();
                    else (el as Label).Text = "Место пусто";
                    (el as Label).Image = imageList.Images[random.Next(0,6)];
                    (el as Label).ImageAlign = ContentAlignment.MiddleLeft;
                    (el as Label).TextAlign = ContentAlignment.TopLeft;


                    tempcount++;
               
                }
            }
            
        }



        
    }
}
