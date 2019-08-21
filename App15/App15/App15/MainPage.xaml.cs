using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace App15
{
    public partial class MainPage : ContentPage
    {
        Button[] map = new Button[120];
        int[] varr = new int[9];  // vision array


        Enemy e1, e2, e3;
        int m4 = 0;
        int m5 = 0, m6 = 0, m7 = 0, m8 = 0, m9 = 0, m10 = 0;
        int level = 1;

        public MainPage()
        {
            InitializeComponent();

            map[0] = b0;
            map[1] = b1;
            map[2] = b2;
            map[3] = b3;
            map[4] = b4;
            map[5] = b5;
            map[6] = b6;
            map[7] = b7;
            map[8] = b8;
            map[9] = b9;

            map[10] = b10;
            map[11] = b11;
            map[12] = b12;
            map[13] = b13;
            map[14] = b14;
            map[15] = b15;
            map[16] = b16;
            map[17] = b17;
            map[18] = b18;
            map[19] = b19;

            map[20] = b20;
            map[21] = b21;
            map[22] = b22;
            map[23] = b23;
            map[24] = b24;
            map[25] = b25;
            map[26] = b26;
            map[27] = b27;
            map[28] = b28;
            map[29] = b29;

            map[30] = b30;
            map[31] = b31;
            map[32] = b32;
            map[33] = b33;
            map[34] = b34;
            map[35] = b35;
            map[36] = b36;
            map[37] = b37;
            map[38] = b38;
            map[39] = b39;

            map[40] = b40;
            map[41] = b41;
            map[42] = b42;
            map[43] = b43;
            map[44] = b44;
            map[45] = b45;
            map[46] = b46;
            map[47] = b47;
            map[48] = b48;
            map[49] = b49;

            map[50] = b50;
            map[51] = b51;
            map[52] = b52;
            map[53] = b53;
            map[54] = b54;
            map[55] = b55;
            map[56] = b56;
            map[57] = b57;
            map[58] = b58;
            map[59] = b59;

            map[60] = b60;
            map[61] = b61;
            map[62] = b62;
            map[63] = b63;
            map[64] = b64;
            map[65] = b65;
            map[66] = b66;
            map[67] = b67;
            map[68] = b68;
            map[69] = b69;

            map[70] = b70;
            map[71] = b71;
            map[72] = b72;
            map[73] = b73;
            map[74] = b74;
            map[75] = b75;
            map[76] = b76;
            map[77] = b77;
            map[78] = b78;
            map[79] = b79;

            map[80] = b80;
            map[81] = b81;
            map[82] = b82;
            map[83] = b83;
            map[84] = b84;
            map[85] = b85;
            map[86] = b86;
            map[87] = b87;
            map[88] = b88;
            map[89] = b89;

            map[90] = b90;
            map[91] = b91;
            map[92] = b92;
            map[93] = b93;
            map[94] = b94;
            map[95] = b95;
            map[96] = b96;
            map[97] = b97;
            map[98] = b98;
            map[99] = b99;

            map[100] = b100;
            map[101] = b101;
            map[102] = b102;
            map[103] = b103;
            map[104] = b104;
            map[105] = b105;
            map[106] = b106;
            map[107] = b107;
            map[108] = b108;
            map[109] = b109;

            map[110] = b110;
            map[111] = b111;
            map[112] = b112;
            map[113] = b113;
            map[114] = b114;
            map[115] = b115;
            map[116] = b116;
            map[117] = b117;
            map[118] = b118;
            map[119] = b119;

            varr[0] = -13;
            varr[1] = -12;
            varr[2] = -11;
            varr[3] = -1;
            varr[4] = 0;
            varr[5] = 1;
            varr[6] = 11;
            varr[7] = 12;
            varr[8] = 13;


            //for (int i = 0; i < 120; i++)
            //{
            //    map[i].IsVisible = true;
            //    map[i].BackgroundColor = Color.Firebrick;
            //}
            //map[108].Image = "player.png";
            //HP.Text = "10000";
            level = 1;
            Level_1();

        }

        private void BackBTN_Clicked(object sender, EventArgs e)
        {
            Navigation.PopAsync();

        }

        private async void AttackBTN_Clicked(object sender, EventArgs e)
        {
            int playerPos = 0;
            int swords = 0;
            for(int i=0; i<120; i++)
            {
                if(map[i].Image == "player.png")
                {
                    playerPos = i;
                    break;
                }
            }
            for (int j = 0; j < varr.Length; j++)
            {
                if (playerPos + varr[j] < 0 || playerPos + varr[j] > 119 || ((varr[j] == -13 || varr[j] == -1 || varr[j] == 11) && playerPos % 12 == 0)
                    || ((varr[j] == 13 || varr[j] == 1 || varr[j] == -11) && (playerPos + 1) % 12 == 0) || varr[j]==0)
                {
                    continue;
                }
                if(map[playerPos+varr[j]].Image != "enemy.png" && map[playerPos+varr[j]].Image != "boss.png"
                    && map[playerPos + varr[j]].Image != "smallattack.png")
                {
                    continue;
                }
                map[playerPos + varr[j]].Image = "smallattack.png";
                swords++;
            }
            if(swords==0)
            {
                return;
            }
            AttackBTN.InputTransparent = true;
            UpBTN.IsEnabled = false;
            DownBTN.IsEnabled = false;
            RightBTN.IsEnabled = false;
            LeftBTN.IsEnabled = false;
            await Task.Delay(300);
            for (int j = 0; j < varr.Length; j++)
            {
                if (playerPos + varr[j] < 0 || playerPos + varr[j] > 119 || ((varr[j] == -13 || varr[j] == -1 || varr[j] == 11) && playerPos % 12 == 0)
                    || ((varr[j] == 13 || varr[j] == 1 || varr[j] == -11) && (playerPos + 1) % 12 == 0) || varr[j] == 0)
                {
                    continue;
                }
                if (map[playerPos + varr[j]].Image != "enemy.png" && map[playerPos + varr[j]].Image != "boss.png"
                    && map[playerPos + varr[j]].Image != "smallattack.png")
                {
                    continue;
                }
                map[playerPos + varr[j]].Image = null;
            }
            UpBTN.IsEnabled = true;
            DownBTN.IsEnabled = true;
            RightBTN.IsEnabled = true;
            LeftBTN.IsEnabled = true;
            AttackBTN.BackgroundColor = Color.Gray;
            AttackBTN.FontSize = 22;
            AttackBTN.TextColor = Color.Aqua;
            AttackBTN.Text = "3";
            await Task.Delay(1000);
            AttackBTN.Text = "2";
            await Task.Delay(1000);
            AttackBTN.Text = "1";
            await Task.Delay(1000);
            AttackBTN.Text = null;
            AttackBTN.BackgroundColor = Color.White;
            await Task.Delay(100);
            AttackBTN.BackgroundColor = Color.Wheat;
            AttackBTN.InputTransparent = false;
        }

        private async void GunBTN_Clicked(object sender, EventArgs e)
        {
            if (Ammo.Text == "0")
            {
                return;
            }
            int playerPos = 0;
            for (int i = 0; i < 120; i++)
            {
                if (map[i].Image == "player.png")
                {
                    playerPos = i;
                    break;
                }
            }
            int a = 1;
            int b = -1;
            int c = -12;
            int d = 12;
            bool exit1 = false, exit2 = false, exit3 = false, exit4 = false;
            int temp = int.Parse(Ammo.Text);
            temp--;
            Ammo.Text = temp.ToString();
            GunBTN.InputTransparent = true;
            UpBTN.IsEnabled = false;
            DownBTN.IsEnabled = false;
            RightBTN.IsEnabled = false;
            LeftBTN.IsEnabled = false;
            int enable = 0;
            while (true)
            {
                enable++;
                Console.WriteLine((playerPos + a).ToString() + " " +
                    (playerPos + b).ToString() + " " + (playerPos + c).ToString() + " " + (playerPos + d).ToString() + " ");
                if (exit1 && exit2 && exit3 && exit4)
                {
                    break;
                }
                //RIGHT
                if(playerPos+a ==64)
                {
                    a-=12;
                }
                if((playerPos+1)%12==0 )
                {
                    exit1 = true;
                }
                else if((playerPos + a + 1) % 12 == 0  )
                {
                    exit1 = true;
                    if ((map[playerPos + a].Image == null || map[playerPos + a].Image == "enemy.png"
                    || map[playerPos + a].Image == "boss.png" || map[playerPos + a].Image == "flame.png"))
                        map[playerPos + a].Image = "bulletright.png";
                }
                else if((map[playerPos+a].Image == null || map[playerPos+a].Image == "enemy.png" 
                    || map[playerPos+a].Image == "boss.png" || map[playerPos + a].Image == "flame.png") && !exit1)
                {
                    map[playerPos + a].Image = "bulletright.png";
                    a++;
                }
                else
                {
                    exit1 = true;
                }

                //LEFT
                if (playerPos %12 == 0 )
                {
                    exit2 = true;
                }
                else if ((playerPos + b) % 12 == 0 )
                {
                    exit2 = true;
                    if ((map[playerPos + b].Image == null || map[playerPos + b].Image == "enemy.png"
                    || map[playerPos + b].Image == "boss.png" || map[playerPos + b].Image == "flame.png"))
                        map[playerPos + b].Image = "bulletleft.png";
                }
                else if ((map[playerPos + b].Image == null || map[playerPos + b].Image == "enemy.png" 
                    || map[playerPos + b].Image == "boss.png" || map[playerPos + b].Image == "flame.png") && !exit2)
                {
                    map[playerPos + b].Image = "bulletleft.png";
                    b--;
                }
                else
                {
                    exit2 = true;
                }

                //UP
                if(playerPos <=11)
                {
                    exit3 = true;
                }
                else if (playerPos + c <= 11)
                {
                    exit3 = true;
                    if ((map[playerPos + c].Image == null || map[playerPos + c].Image == "enemy.png"
                    || map[playerPos + c].Image == "boss.png" || map[playerPos + c].Image == "flame.png"))
                        map[playerPos + c].Image = "bulletup.png";
                }
                else if ((map[playerPos + c].Image == null || map[playerPos + c].Image == "enemy.png" 
                    || map[playerPos + c].Image == "boss.png" || map[playerPos + c].Image == "flame.png") && !exit3)
                {
                    map[playerPos + c].Image = "bulletup.png";
                    c-=12;
                }
                else
                {
                    exit3 = true;
                }

                //DOWN
                if(playerPos>=108 )
                {
                    exit4 = true;
                }
                else if (playerPos + d >= 108 )
                {
                    exit4 = true;
                    if ((map[playerPos + d].Image == null || map[playerPos + d].Image == "enemy.png"
                    || map[playerPos + d].Image == "boss.png" || map[playerPos + d].Image == "flame.png"))
                        map[playerPos + d].Image = "bulletdown.png";
                }
                else if ((map[playerPos + d].Image == null || map[playerPos + d].Image == "enemy.png" 
                    || map[playerPos + d].Image == "boss.png" || map[playerPos + d].Image == "flame.png") && !exit4)
                {
                    map[playerPos + d].Image = "bulletdown.png";
                    d+=12;
                }
                else
                {
                    exit4 = true;
                }
                await Task.Delay(50);
                for(int i=0; i<120; i++)
                {
                    if(map[i].Image=="bulletup.png" || map[i].Image == "bulletdown.png" || map[i].Image == "bulletleft.png" ||
                        map[i].Image == "bulletright.png")
                    {
                        map[i].Image = null;
                    }
                }
                if(enable==4)
                {
                    UpBTN.IsEnabled = true;
                    DownBTN.IsEnabled = true;
                    RightBTN.IsEnabled = true;
                    LeftBTN.IsEnabled = true;
                }
            }
            UpBTN.IsEnabled = true;
            DownBTN.IsEnabled = true;
            RightBTN.IsEnabled = true;
            LeftBTN.IsEnabled = true;
            GunBTN.BackgroundColor = Color.Gray;
            GunBTN.FontSize = 22;
            GunBTN.TextColor = Color.Aqua;
            GunBTN.Text = "5";
            await Task.Delay(1000);
            GunBTN.Text = "4";
            await Task.Delay(1000);
            GunBTN.Text = "3";
            await Task.Delay(1000);
            GunBTN.Text = "2";
            await Task.Delay(1000);
            GunBTN.Text = "1";
            await Task.Delay(1000);
            GunBTN.Text = null;
            GunBTN.BackgroundColor = Color.White;
            await Task.Delay(100);
            GunBTN.BackgroundColor = Color.Wheat;
            GunBTN.InputTransparent = false;
        }

        private async void HealBTN_Clicked(object sender, EventArgs e)
        {
            if(Potions.Text == "0" || HP.Text == "100" || HP.Text == "0")
            {
                return;
            }
            HealBTN.InputTransparent = true;
            int temp = int.Parse(Potions.Text);
            temp--;
            Potions.Text = temp.ToString();
            Mechanics.PotionHeal(50, HP, GameoverBTN);
            HealBTN.BackgroundColor = Color.Gray;
            HealBTN.FontSize = 22;
            HealBTN.TextColor = Color.Aqua;
            HealBTN.Text = "5";
            await Task.Delay(1000);
            HealBTN.Text = "4";
            await Task.Delay(1000);
            HealBTN.Text = "3";
            await Task.Delay(1000);
            HealBTN.Text = "2";
            await Task.Delay(1000);
            HealBTN.Text = "1";
            await Task.Delay(1000);
            HealBTN.Text = null;
            HealBTN.BackgroundColor = Color.White;
            await Task.Delay(100);
            HealBTN.BackgroundColor = Color.Wheat;
            HealBTN.InputTransparent = false;
        }

        private async void Movement(object sender, EventArgs e)
        {
            Button input = (Button)sender;
            int pos = 0;
            int currentlevel = level;
            for(int i=0; i<120; i++)
            {
                if(map[i].Image == "player.png")
                {
                    //UP
                    if(input.ClassId == "1")
                    {
                        if (i <= 11 || map[i - 12].Image == "wall.png")
                        {
                            break;
                        }
                        pos = i - 12;
                    }
                    //LEFT
                    else if(input.ClassId == "2")
                    {
                        if (i % 12 == 0 || map[i - 1].Image == "wall.png")
                        {
                            break;
                        }
                        pos = i - 1;
                    }
                    //RIGHT
                    else if(input.ClassId == "3")
                    {
                        if ((i + 1) % 12 == 0 || map[i + 1].Image == "wall.png")
                        {
                            break;
                        }
                        pos = i + 1;
                    }
                    //DOWN
                    else if(input.ClassId == "4")
                    {
                        if (i >= 108 || map[i + 12].Image == "wall.png")
                        {
                            break;
                        }
                        pos = i + 12;
                    }
                    if(pos==33 && level==3)
                    {
                        map[i].Image = null;
                        map[38].Image = "player.png";
                        break;
                    }
                    else if(pos == 26 && level == 3)
                    {
                        map[i].Image = null;
                        map[45].Image = "player.png";
                        break;
                    }
                    else if(pos==0 && level==4)
                    {
                        map[i].Image = null;
                        map[107].Image = "player.png";
                        break;
                    }
                    else if (pos == 119 && level == 4)
                    {
                        map[i].Image = null;
                        map[12].Image = "player.png";
                        break;
                    }
                    else if (map[pos].Image == "flame.png")
                    {
                        Mechanics.TakesDamage(10,HP,GameoverBTN, AttackBTN, GunBTN, HealBTN, LeftBTN, UpBTN, DownBTN, RightBTN);
                    }
                    else if(map[pos].Image == "enemy.png")
                    {
                        break;
                    }
                    else if( (pos==52 || pos==53 || pos==65 || pos==64) && map[52].Image == "boss.png")
                    {
                        break;
                    }
                    if(pos == 64)
                    {
                        pos = 52;
                    }
                    else if(pos == 53)
                    {
                        pos = 54;
                    }
                    LevelEncountersAsync(pos);
                    if (currentlevel == level)
                    {
                        map[i].Image = null;
                        map[pos].Image = "player.png";
                        //Mechanics.Vision(pos, varr, map);
                        LevelEncountersAsync(pos);
                    }
                    break;
                }
            }

        }
 

        // LEVEL 1
        private void Level_1()
        {
            GameoverBTN.IsVisible = false;
            for (int i=0; i<120; i++)
            {
                map[i].IsVisible = true;
                map[i].BackgroundColor = Color.Firebrick;
            }

            //Setting Player's Starting Position
            map[108].Image = "player.png";
            UpBTN.InputTransparent = false;
            RightBTN.InputTransparent = false;
            DownBTN.InputTransparent = false;
            LeftBTN.InputTransparent = false;

            //Starting with Nothing
            AttackBTN.Image = null;
            GunBTN.Image = null;
            HealBTN.Image = null;
            AttackBTN.IsEnabled = false;
            GunBTN.IsEnabled = false;
            HealBTN.IsEnabled = false;

            Ammo.Text = "";
            Ammo.Image = null;
            Ammo.InputTransparent = true;

            Potions.Text = "";
            Potions.Image = null;
            Potions.InputTransparent = true;

            //Setting the Walls
            for (int i=0; i<11; i++)
            {
                Wall(map[96 + i]);
            }
            
            for(int i=0; i<7; i++)
            {
                Wall(map[22 + i * 12]);
            }

            for (int i = 0; i < 9; i++)
            {
                Wall(map[13 + i]);
            }

            for (int i = 0; i < 7; i++)
            {
                Wall(map[22 + i * 12]);
            }

            for (int i = 0; i < 5; i++)
            {
                Wall(map[25 + i * 12]);
            }

            for (int i = 0; i < 7; i++)
            {
                Wall(map[73 + i]);
            }

            for (int i = 0; i < 4; i++)
            {
                Wall(map[44 + i * 12]);
            }

            for (int i = 0; i < 5; i++)
            {
                Wall(map[39 + i]);
            }

            //Getting the Sword
            Chest(map[109]);

            //Meeting the First Enemy
            e1 = new Enemy(119, map, varr, HP, GameoverBTN, AttackBTN, GunBTN, HealBTN, LeftBTN, UpBTN, DownBTN, RightBTN);

            //More Enemies
            e2 = new Enemy(11, map, varr, HP, GameoverBTN, AttackBTN, GunBTN, HealBTN, LeftBTN, UpBTN, DownBTN, RightBTN);
            e3 = new Enemy(0, map, varr, HP, GameoverBTN, AttackBTN, GunBTN, HealBTN, LeftBTN, UpBTN, DownBTN, RightBTN);

            //Getting Healed
            Heal(map[84]);

            //Revealing the Map
            //Eye(map[113]);

            //Boss Time
            Boss(map[52]);

            //Boss Animation
            if (map[52].Image == "boss.png")
                Boss1(52, map, HP, GameoverBTN);

            //Exit
            Door(map[54]);
        }

        public async void Boss1(int pos, Button[] map, Button HP, Button GameoverBTN)
        {
            if (map[pos].BackgroundColor == Color.Firebrick && m4 == 0)
            {

                m4++;

                while (true)
                {
                    await Task.Delay(1000);
                    if (map[pos].Image != "boss.png" || level>1)
                    {
                        break;
                    }


                    //First Flame Wave Apeears
                    if (map[51].Image == "player.png")
                    {
                        Mechanics.TakesDamage(20, HP, GameoverBTN, AttackBTN, GunBTN, HealBTN, LeftBTN, UpBTN, DownBTN, RightBTN);
                    }
                    else
                    {
                        map[51].Image = "flame.png";
                    }
                    if (map[63].Image == "player.png")
                    {
                        Mechanics.TakesDamage(20, HP, GameoverBTN, AttackBTN, GunBTN, HealBTN, LeftBTN, UpBTN, DownBTN, RightBTN);
                    }
                    else
                    {
                        map[63].Image = "flame.png";
                    }


                    await Task.Delay(500);

                    //First Flame Wave Disappears
                    if (map[51].Image == "player.png")
                    {

                    }
                    else
                    {
                        map[51].Image = null;
                    }
                    if (map[63].Image == "player.png")
                    {

                    }
                    else
                    {
                        map[63].Image = null;
                    }



                    //Second Flame Wave Appears
                    if (map[50].Image == "player.png")
                    {
                        Mechanics.TakesDamage(20, HP, GameoverBTN, AttackBTN, GunBTN, HealBTN, LeftBTN, UpBTN, DownBTN, RightBTN);
                    }
                    else
                    {
                        map[50].Image = "flame.png";
                    }
                    if (map[62].Image == "player.png")
                    {
                        Mechanics.TakesDamage(20, HP, GameoverBTN, AttackBTN, GunBTN, HealBTN, LeftBTN, UpBTN, DownBTN, RightBTN);
                    }
                    else
                    {
                        map[62].Image = "flame.png";
                    }

                    await Task.Delay(500);


                    //Second Flame Wave Disappears
                    if (map[50].Image == "player.png")
                    {
                    }
                    else
                    {
                        map[50].Image = null;
                    }
                    if (map[62].Image == "player.png")
                    {
                    }
                    else
                    {
                        map[62].Image = null;
                    }

                }
            }
        }
        // LEVEL 1



        // LEVEL 2
        private void Level_2()
        {

            // Getting the Gun
            Chest(map[96]);

            // Enemies
            Enemy e1 = new Enemy(119, map, varr, HP, GameoverBTN, AttackBTN, GunBTN, HealBTN, LeftBTN, UpBTN, DownBTN, RightBTN);
            Enemy e2 = new Enemy(0, map, varr, HP, GameoverBTN, AttackBTN, GunBTN, HealBTN, LeftBTN, UpBTN, DownBTN, RightBTN);
            Enemy e4 = new Enemy(86, map, varr, HP, GameoverBTN, AttackBTN, GunBTN, HealBTN, LeftBTN, UpBTN, DownBTN, RightBTN);
            Enemy e5 = new Enemy(33, map, varr, HP, GameoverBTN, AttackBTN, GunBTN, HealBTN, LeftBTN, UpBTN, DownBTN, RightBTN);
            Enemy e6 = new Enemy(69, map, varr, HP, GameoverBTN, AttackBTN, GunBTN, HealBTN, LeftBTN, UpBTN, DownBTN, RightBTN);
            Enemy e7 = new Enemy(91, map, varr, HP, GameoverBTN, AttackBTN, GunBTN, HealBTN, LeftBTN, UpBTN, DownBTN, RightBTN);

            // Getting Ammo
            Bullets(map[95]);

            // Walls
            for(int i=0; i<10; i++)
            {
                Wall(map[97 + i]);
            }
            for (int i = 0; i < 7; i++)
            {
                Wall(map[13 + i * 12]);
            }
            Wall(map[82]);
            Wall(map[83]);
            Wall(map[94]);
            Wall(map[17]);
            Wall(map[29]);
            Wall(map[28]);
            Wall(map[40]);
            Wall(map[39]);
            for (int i = 0; i < 3; i++)
            {
                Wall(map[14 + i]);
            }
            for (int i = 0; i < 5; i++)
            {
                Wall(map[7 + i]);
            }
            for (int i = 0; i < 5; i++)
            {
                Wall(map[19 + i]);
            }
            for (int i = 0; i < 4; i++)
            {
                Wall(map[41 + i]);
            }
            for (int i = 0; i < 6; i++)
            {
                Wall(map[75 + i]);
            }
            for (int i = 0; i < 4; i++)
            {
                Wall(map[44 + i * 12]);
            }
            for (int i = 0; i < 4; i++)
            {
                Wall(map[35 + i * 12]);
            }

            // Boss and Exit
            Boss(map[52]);
            Door(map[54]);
            //Boss animation
            if (map[52].Image == "boss.png")
                Boss2(52);
        }

        private async void Boss2(int pos)
        {
            if (map[pos].BackgroundColor == Color.Firebrick && m5 == 0)
            {

                m5++;

                while (true)
                {
                    if (map[pos].Image != "boss.png" || level > 2)
                    {
                        break;
                    }


                    if (map[51].Image == "player.png")
                    {
                        Mechanics.TakesDamage(20, HP, GameoverBTN, AttackBTN, GunBTN, HealBTN, LeftBTN, UpBTN, DownBTN, RightBTN);
                    }
                    else
                    {
                        map[51].Image = "flame.png";
                    }
                    await Task.Delay(300);
                    if (map[51].Image == "player.png")
                    {

                    }
                    else
                    {
                        map[51].Image = null;
                    }
                    if (map[pos].Image != "boss.png" || level > 2)
                    {
                        break;
                    }


                    if (map[63].Image == "player.png")
                    {
                        Mechanics.TakesDamage(20, HP, GameoverBTN, AttackBTN, GunBTN, HealBTN, LeftBTN, UpBTN, DownBTN, RightBTN);
                    }
                    else
                    {
                        map[63].Image = "flame.png";
                    }
                    await Task.Delay(300);
                    if (map[63].Image == "player.png")
                    {

                    }
                    else
                    {
                        map[63].Image = null;
                    }
                    if (map[pos].Image != "boss.png" || level > 2)
                    {
                        break;
                    }


                    if (map[62].Image == "player.png")
                    {
                        Mechanics.TakesDamage(20, HP, GameoverBTN, AttackBTN, GunBTN, HealBTN, LeftBTN, UpBTN, DownBTN, RightBTN);
                    }
                    else
                    {
                        map[62].Image = "flame.png";
                    }
                    await Task.Delay(300);
                    if (map[62].Image == "player.png")
                    {
                    }
                    else
                    {
                        map[62].Image = null;
                    }
                    if (map[pos].Image != "boss.png" || level > 2)
                    {
                        break;
                    }


                    if (map[50].Image == "player.png")
                    {
                        Mechanics.TakesDamage(20, HP, GameoverBTN, AttackBTN, GunBTN, HealBTN, LeftBTN, UpBTN, DownBTN, RightBTN);
                    }
                    else
                    {
                        map[50].Image = "flame.png";
                    }
                    await Task.Delay(300);
                    if (map[50].Image == "player.png")
                    {
                    }
                    else
                    {
                        map[50].Image = null;
                    }
                    if (map[pos].Image != "boss.png" || level > 2)
                    {
                        break;
                    }
                }
            }
        }
        // LEVEL 2

        
        
        // LEVEL 3
        private void Level_3()
        {
            //Walls
            for(int i=0; i<12; i++)
            {
                Wall(map[96 + i]);
            }
            for (int i = 0; i < 11; i++)
            {
                Wall(map[73 + i]);
            }
            for (int i = 0; i < 5; i++)
            {
                Wall(map[13 + i*12]);
            }
            for (int i = 0; i < 10; i++)
            {
                Wall(map[13 + i]);
            }
            for (int i = 0; i < 4; i++)
            {
                Wall(map[22 + i * 12]);
            }
            for (int i = 0; i < 3; i++)
            {
                Wall(map[44 + i * 12]);
            }
            for (int i = 0; i < 4; i++)
            {
                Wall(map[40 + i]);
            }
            Wall(map[27]);
            Wall(map[32]);
            Wall(map[39]);

            //Not Wall
            map[104].Image = null;
            map[15].Image = null;
            map[20].Image = null;

            //Flames
            for (int i = 0; i < 4; i++)
            {
                map[28 + i].Image = "flame.png";
            }

            //Getting Potion
            Chest(map[72]);

            //Getting one more Potion
            Potion(map[15]);

            //Enemies
            Enemy e1 = new Enemy(85, map, varr, HP, GameoverBTN, AttackBTN, GunBTN, HealBTN, LeftBTN, UpBTN, DownBTN, RightBTN);
            Enemy e2 = new Enemy(88, map, varr, HP, GameoverBTN, AttackBTN, GunBTN, HealBTN, LeftBTN, UpBTN, DownBTN, RightBTN);
            Enemy e3 = new Enemy(94, map, varr, HP, GameoverBTN, AttackBTN, GunBTN, HealBTN, LeftBTN, UpBTN, DownBTN, RightBTN);
            Enemy e4 = new Enemy(24, map, varr, HP, GameoverBTN, AttackBTN, GunBTN, HealBTN, LeftBTN, UpBTN, DownBTN, RightBTN);
            Enemy e5 = new Enemy(35, map, varr, HP, GameoverBTN, AttackBTN, GunBTN, HealBTN, LeftBTN, UpBTN, DownBTN, RightBTN);
            Enemy e6 = new Enemy(70, map, varr, HP, GameoverBTN, AttackBTN, GunBTN, HealBTN, LeftBTN, UpBTN, DownBTN, RightBTN);
            Enemy e7 = new Enemy(62, map, varr, HP, GameoverBTN, AttackBTN, GunBTN, HealBTN, LeftBTN, UpBTN, DownBTN, RightBTN);

            //Portals
            Portal(map[33]);
            Portal(map[26]);

            //Boss
            Boss(map[52]);
            Boss3(52);

            //Door
            Door(map[54]);
        }

        private async void Boss3(int pos)
        {
            if (map[pos].BackgroundColor == Color.Firebrick && m6 == 0)
            {

                m6++;

                while (true)
                {
                    if (map[pos].Image != "boss.png" || level > 3)
                    {
                        break;
                    }


                    for (int i = 0; i < 11; i++)
                    {
                        if (map[119 - i].Image == "wall.png" || map[119 - i].Image == "boss.png")
                        {
                            continue;
                        }
                        else if (map[119 - i].Image == "player.png")
                        {
                            Mechanics.TakesDamage(10, HP, GameoverBTN, AttackBTN, GunBTN, HealBTN, LeftBTN, UpBTN, DownBTN, RightBTN);
                        }
                        else
                        {
                            map[119 - i].Image = "flame.png";
                        }
                        if (map[11 - i].Image == "wall.png" || map[11 - i].Image == "boss.png")
                        {
                            continue;
                        }
                        else if (map[11 - i].Image == "player.png")
                        {
                            Mechanics.TakesDamage(10, HP, GameoverBTN, AttackBTN, GunBTN, HealBTN, LeftBTN, UpBTN, DownBTN, RightBTN);
                        }
                        else
                        {
                            map[11 - i].Image = "flame.png";
                        }
                        await Task.Delay(100);
                        if (map[119-i].Image == "wall.png" || map[119-i].Image == "boss.png")
                        {
                            continue;
                        }
                        else if (map[119-i].Image == "player.png")
                        {

                        }
                        else
                        {
                            map[119-i].Image = null;
                        }
                        if (map[11 - i].Image == "wall.png" || map[11 - i].Image == "boss.png")
                        {
                            continue;
                        }
                        else if (map[11 - i].Image == "player.png")
                        {

                        }
                        else
                        {
                            map[11 - i].Image = null;
                        }
                        if (map[pos].Image != "boss.png" || level > 3)
                        {
                            break;
                        }
                    }

                    for (int i = 0; i < 11; i++)
                    {
                        if (map[109 + i].Image == "wall.png" || map[109 + i].Image == "boss.png")
                        {
                            continue;
                        }
                        else if (map[109 + i].Image == "player.png")
                        {
                            Mechanics.TakesDamage(10, HP, GameoverBTN, AttackBTN, GunBTN, HealBTN, LeftBTN, UpBTN, DownBTN, RightBTN);
                        }
                        else
                        {
                            map[109 + i].Image = "flame.png";
                        }
                        if (map[1 + i].Image == "wall.png" || map[1 + i].Image == "boss.png")
                        {
                            continue;
                        }
                        else if (map[1 + i].Image == "player.png")
                        {
                            Mechanics.TakesDamage(10, HP, GameoverBTN, AttackBTN, GunBTN, HealBTN, LeftBTN, UpBTN, DownBTN, RightBTN);
                        }
                        else
                        {
                            map[1 + i].Image = "flame.png";
                        }
                        await Task.Delay(100);
                        if (map[109 + i].Image == "wall.png" || map[109 + i].Image == "boss.png")
                        {
                            continue;
                        }
                        else if (map[109 + i].Image == "player.png")
                        {

                        }
                        else
                        {
                            map[109 + i].Image = null;
                        }
                        if (map[1 + i].Image == "wall.png" || map[1 + i].Image == "boss.png")
                        {
                            continue;
                        }
                        else if (map[1 + i].Image == "player.png")
                        {

                        }
                        else
                        {
                            map[1 + i].Image = null;
                        }
                        if (map[pos].Image != "boss.png" || level > 3)
                        {
                            break;
                        }
                    }

                }
            }
        }
        // LEVEL 3



        // LEVEL 4
        private void Level_4()
        {
            //Walls
            for(int i=0; i<10; i++)
            {
                Wall(map[1 + i * 12]);
            }
            for (int i = 0; i < 9; i++)
            {
                Wall(map[22 + i * 12]);
            }
            for (int i = 0; i < 5; i++)
            {
                Wall(map[39 + i]);
            }
            for (int i = 0; i < 4; i++)
            {
                Wall(map[44 + i * 12]);
            }
            for (int i = 0; i < 4; i++)
            {
                Wall(map[76 + i]);
            }
            Wall(map[86]);
            Wall(map[50]);
            Wall(map[14]);
            Wall(map[93]);
            Wall(map[57]);
            Wall(map[21]);

            //Enemies
            Enemy e1 = new Enemy(85, map, varr, HP, GameoverBTN, AttackBTN, GunBTN, HealBTN, LeftBTN, UpBTN, DownBTN, RightBTN);
            Enemy e2 = new Enemy(49, map, varr, HP, GameoverBTN, AttackBTN, GunBTN, HealBTN, LeftBTN, UpBTN, DownBTN, RightBTN);
            Enemy e3 = new Enemy(13, map, varr, HP, GameoverBTN, AttackBTN, GunBTN, HealBTN, LeftBTN, UpBTN, DownBTN, RightBTN);
            Enemy e4 = new Enemy(94, map, varr, HP, GameoverBTN, AttackBTN, GunBTN, HealBTN, LeftBTN, UpBTN, DownBTN, RightBTN);
            Enemy e5 = new Enemy(58, map, varr, HP, GameoverBTN, AttackBTN, GunBTN, HealBTN, LeftBTN, UpBTN, DownBTN, RightBTN);
            Enemy e6 = new Enemy(22, map, varr, HP, GameoverBTN, AttackBTN, GunBTN, HealBTN, LeftBTN, UpBTN, DownBTN, RightBTN);
            Enemy e7 = new Enemy(39, map, varr, HP, GameoverBTN, AttackBTN, GunBTN, HealBTN, LeftBTN, UpBTN, DownBTN, RightBTN);
            Enemy e8 = new Enemy(45, map, varr, HP, GameoverBTN, AttackBTN, GunBTN, HealBTN, LeftBTN, UpBTN, DownBTN, RightBTN);
            Enemy e9 = new Enemy(63, map, varr, HP, GameoverBTN, AttackBTN, GunBTN, HealBTN, LeftBTN, UpBTN, DownBTN, RightBTN);

            //Portals
            Portal(map[0]);
            Portal(map[119]);

            //Bullets
            Bullets(map[11]);

            //Boss
            Boss(map[52]);
            Boss4(52);

            //Door
            Door(map[54]);
        }

        private async void Boss4(int pos)
        {
            while (true)
            {
                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < 6; j++)
                    {
                        if (map[3 + j + i * 12].Image == "wall.png" || map[3 + j + i * 12].Image == "boss.png")
                        {
                            continue;
                        }
                        else if (map[3 + j + i * 12].Image == "player.png")
                        {
                            Mechanics.TakesDamage(10, HP, GameoverBTN, AttackBTN, GunBTN, HealBTN, LeftBTN, UpBTN, DownBTN, RightBTN);
                        }
                        else
                        {
                            Flame(map[3 + j + i * 12]);
                        }
                    }
                    await Task.Delay(175);
                    for (int j = 0; j < 6; j++)
                    {
                        if (map[3 + j + i * 12].Image == "wall.png" || map[3 + j + i * 12].Image == "boss.png")
                        {
                            continue;
                        }
                        else if (map[3 + j + i * 12].Image == "player.png")
                        {
                            Mechanics.TakesDamage(10, HP, GameoverBTN, AttackBTN, GunBTN, HealBTN, LeftBTN, UpBTN, DownBTN, RightBTN);
                        }
                        else
                        {
                            map[3 + j + i * 12].Image = null;
                        }
                    }
                    if (map[pos].Image != "boss.png" || level > 4)
                    {
                        return;
                    }
                }
                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < 6; j++)
                    {
                        if (map[87 + j + i * 12].Image == "wall.png" || map[87 + j + i * 12].Image == "boss.png")
                        {
                            continue;
                        }
                        else if (map[87 + j + i * 12].Image == "player.png")
                        {
                            Mechanics.TakesDamage(10, HP, GameoverBTN, AttackBTN, GunBTN, HealBTN, LeftBTN, UpBTN, DownBTN, RightBTN);
                        }
                        else
                        {
                            Flame(map[87 + j + i * 12]);
                        }
                    }
                    await Task.Delay(175);
                    for (int j = 0; j < 6; j++)
                    {
                        if (map[87 + j + i * 12].Image == "wall.png" || map[87 + j + i * 12].Image == "boss.png")
                        {
                            continue;
                        }
                        else if (map[87 + j + i * 12].Image == "player.png")
                        {
                            Mechanics.TakesDamage(10, HP, GameoverBTN, AttackBTN, GunBTN, HealBTN, LeftBTN, UpBTN, DownBTN, RightBTN);
                        }
                        else
                        {
                            map[87 + j + i * 12].Image = null;
                        }
                    }
                    if (map[pos].Image != "boss.png" || level > 4)
                    {
                        return;
                    }
                }
            }
        }
        // LEVEL 4


        // LEVEL 5
        private void Level_5()
        {
            //Walls
            for(int i=0; i<6; i++)
            {
                Wall(map[39 + i]);
            }
            for (int i = 0; i < 6; i++)
            {
                Wall(map[75 + i]);
            }
            for (int i = 0; i < 11; i++)
            {
                Wall(map[96 + i]);
            }
            Wall(map[51]);
            Wall(map[63]);
            Wall(map[56]);
            Wall(map[68]);

            //Enemies
            Enemy e1 = new Enemy(0, map, varr, HP, GameoverBTN, AttackBTN, GunBTN, HealBTN, LeftBTN, UpBTN, DownBTN, RightBTN);
            Enemy e2 = new Enemy(2, map, varr, HP, GameoverBTN, AttackBTN, GunBTN, HealBTN, LeftBTN, UpBTN, DownBTN, RightBTN);
            Enemy e3 = new Enemy(4, map, varr, HP, GameoverBTN, AttackBTN, GunBTN, HealBTN, LeftBTN, UpBTN, DownBTN, RightBTN);
            Enemy e4 = new Enemy(6, map, varr, HP, GameoverBTN, AttackBTN, GunBTN, HealBTN, LeftBTN, UpBTN, DownBTN, RightBTN);
            Enemy e5 = new Enemy(8, map, varr, HP, GameoverBTN, AttackBTN, GunBTN, HealBTN, LeftBTN, UpBTN, DownBTN, RightBTN);
            Enemy e6 = new Enemy(10, map, varr, HP, GameoverBTN, AttackBTN, GunBTN, HealBTN, LeftBTN, UpBTN, DownBTN, RightBTN);

            Enemy e7 = new Enemy(13, map, varr, HP, GameoverBTN, AttackBTN, GunBTN, HealBTN, LeftBTN, UpBTN, DownBTN, RightBTN);
            Enemy e8 = new Enemy(15, map, varr, HP, GameoverBTN, AttackBTN, GunBTN, HealBTN, LeftBTN, UpBTN, DownBTN, RightBTN);
            Enemy e9 = new Enemy(17, map, varr, HP, GameoverBTN, AttackBTN, GunBTN, HealBTN, LeftBTN, UpBTN, DownBTN, RightBTN);
            Enemy e10 = new Enemy(19, map, varr, HP, GameoverBTN, AttackBTN, GunBTN, HealBTN, LeftBTN, UpBTN, DownBTN, RightBTN);
            Enemy e11 = new Enemy(21, map, varr, HP, GameoverBTN, AttackBTN, GunBTN, HealBTN, LeftBTN, UpBTN, DownBTN, RightBTN);
            Enemy e12 = new Enemy(23, map, varr, HP, GameoverBTN, AttackBTN, GunBTN, HealBTN, LeftBTN, UpBTN, DownBTN, RightBTN);

            Enemy e13 = new Enemy(24, map, varr, HP, GameoverBTN, AttackBTN, GunBTN, HealBTN, LeftBTN, UpBTN, DownBTN, RightBTN);
            Enemy e14 = new Enemy(26, map, varr, HP, GameoverBTN, AttackBTN, GunBTN, HealBTN, LeftBTN, UpBTN, DownBTN, RightBTN);
            Enemy e15 = new Enemy(28, map, varr, HP, GameoverBTN, AttackBTN, GunBTN, HealBTN, LeftBTN, UpBTN, DownBTN, RightBTN);
            Enemy e16 = new Enemy(30, map, varr, HP, GameoverBTN, AttackBTN, GunBTN, HealBTN, LeftBTN, UpBTN, DownBTN, RightBTN);
            Enemy e17 = new Enemy(32, map, varr, HP, GameoverBTN, AttackBTN, GunBTN, HealBTN, LeftBTN, UpBTN, DownBTN, RightBTN);
            Enemy e18 = new Enemy(34, map, varr, HP, GameoverBTN, AttackBTN, GunBTN, HealBTN, LeftBTN, UpBTN, DownBTN, RightBTN);

            Enemy e19 = new Enemy(37, map, varr, HP, GameoverBTN, AttackBTN, GunBTN, HealBTN, LeftBTN, UpBTN, DownBTN, RightBTN);
            Enemy e20 = new Enemy(45, map, varr, HP, GameoverBTN, AttackBTN, GunBTN, HealBTN, LeftBTN, UpBTN, DownBTN, RightBTN);
            Enemy e21 = new Enemy(47, map, varr, HP, GameoverBTN, AttackBTN, GunBTN, HealBTN, LeftBTN, UpBTN, DownBTN, RightBTN);

            Enemy e22 = new Enemy(48, map, varr, HP, GameoverBTN, AttackBTN, GunBTN, HealBTN, LeftBTN, UpBTN, DownBTN, RightBTN);
            Enemy e23 = new Enemy(50, map, varr, HP, GameoverBTN, AttackBTN, GunBTN, HealBTN, LeftBTN, UpBTN, DownBTN, RightBTN);
            Enemy e24 = new Enemy(58, map, varr, HP, GameoverBTN, AttackBTN, GunBTN, HealBTN, LeftBTN, UpBTN, DownBTN, RightBTN);

            Enemy e25 = new Enemy(61, map, varr, HP, GameoverBTN, AttackBTN, GunBTN, HealBTN, LeftBTN, UpBTN, DownBTN, RightBTN);
            Enemy e26 = new Enemy(69, map, varr, HP, GameoverBTN, AttackBTN, GunBTN, HealBTN, LeftBTN, UpBTN, DownBTN, RightBTN);
            Enemy e27 = new Enemy(71, map, varr, HP, GameoverBTN, AttackBTN, GunBTN, HealBTN, LeftBTN, UpBTN, DownBTN, RightBTN);

            Enemy e28 = new Enemy(72, map, varr, HP, GameoverBTN, AttackBTN, GunBTN, HealBTN, LeftBTN, UpBTN, DownBTN, RightBTN);
            Enemy e29 = new Enemy(74, map, varr, HP, GameoverBTN, AttackBTN, GunBTN, HealBTN, LeftBTN, UpBTN, DownBTN, RightBTN);
            Enemy e30 = new Enemy(82, map, varr, HP, GameoverBTN, AttackBTN, GunBTN, HealBTN, LeftBTN, UpBTN, DownBTN, RightBTN);

            Enemy e31 = new Enemy(85, map, varr, HP, GameoverBTN, AttackBTN, GunBTN, HealBTN, LeftBTN, UpBTN, DownBTN, RightBTN);
            Enemy e32 = new Enemy(87, map, varr, HP, GameoverBTN, AttackBTN, GunBTN, HealBTN, LeftBTN, UpBTN, DownBTN, RightBTN);
            Enemy e33 = new Enemy(89, map, varr, HP, GameoverBTN, AttackBTN, GunBTN, HealBTN, LeftBTN, UpBTN, DownBTN, RightBTN);
            Enemy e34 = new Enemy(91, map, varr, HP, GameoverBTN, AttackBTN, GunBTN, HealBTN, LeftBTN, UpBTN, DownBTN, RightBTN);
            Enemy e35 = new Enemy(93, map, varr, HP, GameoverBTN, AttackBTN, GunBTN, HealBTN, LeftBTN, UpBTN, DownBTN, RightBTN);
            Enemy e36 = new Enemy(95, map, varr, HP, GameoverBTN, AttackBTN, GunBTN, HealBTN, LeftBTN, UpBTN, DownBTN, RightBTN);

            //Last Equipment
            Bullets(map[112]);
            Potion(map[110]);
            Potion(map[114]);
            map[116].Image = "Message.png";

            //Boss
            Boss(map[52]);
            Boss5(52);

            //Door
            Door(map[54]);
        }

        private async void Boss5(int pos)
        {
            while(true)
            {
                for (int j = 0; j < 96; j++)
                {
                    if (map[j].Image == "wall.png" || map[j].Image == "boss.png" || map[j].Image == "enemy.png"
                        || j==54 || j==55 || j==66 || j==67)
                    {
                        continue;
                    }
                    else if (map[j].Image == "player.png")
                    {
                        Mechanics.TakesDamage(10, HP, GameoverBTN, AttackBTN, GunBTN, HealBTN, LeftBTN, UpBTN, DownBTN, RightBTN);
                    }
                    else
                    {
                        Flame(map[j]);
                    }
                    await Task.Delay(75);
                    if (map[j].Image == "wall.png" || map[j].Image == "boss.png" || map[j].Image == "enemy.png"
                        || j == 54 || j == 55 || j == 66 || j == 67)
                    {
                        continue;
                    }
                    else if (map[j].Image == "player.png")
                    {
                        Mechanics.TakesDamage(10, HP, GameoverBTN, AttackBTN, GunBTN, HealBTN, LeftBTN, UpBTN, DownBTN, RightBTN);
                    }
                    else
                    {
                        map[j].Image = null;
                    }
                    if (map[pos].Image != "boss.png" || level > 5)
                    {
                        return;
                    }
                }
            }
        }
        // LEVEL 5


        private async Task LevelEncountersAsync(int playerPos)
        {
            //lvl 1
            if (level == 1)
            {
                //Getting the Sword Animation
                if (playerPos == 109 && map[109].Image == "chest.png" && level == 1)
                {
                    AttackBTN.Image = "attack.png";
                    AttackBTN.BackgroundColor = Color.White;
                    map[97].Image = "smallattack.png";
                    await Task.Delay(300);
                    AttackBTN.BackgroundColor = Color.Wheat;
                    map[97].Image = "wall.png";
                    AttackBTN.IsEnabled = true;
                }

                //Monster Attack Animation
                e1.Animate(map, varr, HP, GameoverBTN, AttackBTN, GunBTN, HealBTN, LeftBTN, UpBTN, DownBTN, RightBTN);
                e2.Animate(map, varr, HP, GameoverBTN, AttackBTN, GunBTN, HealBTN, LeftBTN, UpBTN, DownBTN, RightBTN);
                e3.Animate(map, varr, HP, GameoverBTN, AttackBTN, GunBTN, HealBTN, LeftBTN, UpBTN, DownBTN, RightBTN);

                //Getting Healed Animation
                await Mechanics.Healed(84, playerPos, 50, map, HP, GameoverBTN);

                ////Getting the Eye
                //Mechanics.Eye(113, playerPos, map,HP,GameoverBTN);

                //Getting to Level 2
                if (playerPos == 54 && level == 1)
                {
                    UpBTN.IsEnabled = false;
                    DownBTN.IsEnabled = false;
                    RightBTN.IsEnabled = false;
                    DownBTN.IsEnabled = false;
                    map[54].Image = null;
                    level++;
                    Reset();
                    Level_2();
                    await Task.Delay(300);
                    UpBTN.IsEnabled = true;
                    DownBTN.IsEnabled = true;
                    RightBTN.IsEnabled = true;
                    DownBTN.IsEnabled = true;
                }
            }
            //lvl 2
            else if (level == 2)
            {
                //Getting the Gun
                if (playerPos == 96 && map[96].Image == "chest.png")
                {
                    UpBTN.IsEnabled = false;
                    DownBTN.IsEnabled = false;
                    RightBTN.IsEnabled = false;
                    DownBTN.IsEnabled = false;
                    GunBTN.Image = "gun.png";
                    GunBTN.BackgroundColor = Color.White;
                    map[84].Image = "smallgun.png";
                    Ammo.Image = "ammo.png";
                    Ammo.Text = "1";
                    await Task.Delay(300);
                    GunBTN.BackgroundColor = Color.Wheat;
                    map[84].Image = null;
                    GunBTN.IsEnabled = true;
                    UpBTN.IsEnabled = true;
                    DownBTN.IsEnabled = true;
                    RightBTN.IsEnabled = true;
                    DownBTN.IsEnabled = true;
                }

                //Getting ammo
                Mechanics.GettingAmmo(playerPos, 95, 5, map, Ammo);

                //Getting to level 3
                if (playerPos == 54 && level == 2)
                {
                    UpBTN.IsEnabled = false;
                    DownBTN.IsEnabled = false;
                    RightBTN.IsEnabled = false;
                    DownBTN.IsEnabled = false;
                    map[54].Image = null;
                    level++;
                    Reset();
                    Level_3();
                    await Task.Delay(300);
                    UpBTN.IsEnabled = true;
                    DownBTN.IsEnabled = true;
                    RightBTN.IsEnabled = true;
                    DownBTN.IsEnabled = true;
                }
            }
            //lvl 3
            else if(level == 3)
            {
                // Getting First Potion
                if (playerPos == 72 && map[72].Image == "chest.png")
                {
                    UpBTN.IsEnabled = false;
                    DownBTN.IsEnabled = false;
                    RightBTN.IsEnabled = false;
                    DownBTN.IsEnabled = false;
                    HealBTN.Image = "heal.png";
                    HealBTN.BackgroundColor = Color.White;
                    map[60].Image = "smallheal.png";
                    Potions.Image = "heal.png";
                    Potions.Text = "1";
                    await Task.Delay(300);
                    HealBTN.BackgroundColor = Color.Wheat;
                    map[60].Image = null;
                    HealBTN.IsEnabled = true;
                    UpBTN.IsEnabled = true;
                    DownBTN.IsEnabled = true;
                    RightBTN.IsEnabled = true;
                    DownBTN.IsEnabled = true;
                }

                // Another Potion
                Mechanics.GettingPotion(playerPos, 15, map, Potions);

                // Going to level 4
                if (playerPos == 54 && level == 3)
                {
                    UpBTN.IsEnabled = false;
                    DownBTN.IsEnabled = false;
                    RightBTN.IsEnabled = false;
                    DownBTN.IsEnabled = false;
                    level++;
                    Reset();
                    Level_4();
                    await Task.Delay(300);
                    UpBTN.IsEnabled = true;
                    DownBTN.IsEnabled = true;
                    RightBTN.IsEnabled = true;
                    DownBTN.IsEnabled = true;
                }

            }
            //lvl4
            else if(level == 4)
            {
                Mechanics.GettingAmmo(playerPos, 11, 2, map, Ammo);

                // Going to level 5
                if (playerPos == 54 && level == 4)
                {
                    UpBTN.IsEnabled = false;
                    DownBTN.IsEnabled = false;
                    RightBTN.IsEnabled = false;
                    DownBTN.IsEnabled = false;
                    level++;
                    Reset();
                    Level_5();
                    await Task.Delay(300);
                    UpBTN.IsEnabled = true;
                    DownBTN.IsEnabled = true;
                    RightBTN.IsEnabled = true;
                    DownBTN.IsEnabled = true;
                }
            }
            //lvl5
            else if(level == 5)
            {
                bool open = true;
                Mechanics.GettingAmmo(playerPos, 112, 5, map, Ammo);
                Mechanics.GettingPotion(playerPos, 110, map, Potions);
                Mechanics.GettingPotion(playerPos, 114, map, Potions);

                if (playerPos == 116 && map[116].Image == "Message.png")
                {
                    await DisplayAlert("Instructions", "Kill All enemies to get to the Boss", "OK");
                }

                if (map[51].Image == "wall.png")
                {
                    for (int i = 0; i < 96; i++)
                    {
                        if (map[i].Image == "enemy.png")
                        {
                            open = false;
                            break;
                        }
                    }
                    if (open)
                    {
                        map[51].Image = null;
                        map[63].Image = null;
                    }
                }

                // THE END
                if (playerPos == 54 && level == 5)
                {
                    Mechanics.YouWin(GameoverBTN,AttackBTN,GunBTN,HealBTN,LeftBTN,UpBTN,DownBTN,RightBTN);
                }
            }
        }




        private void Wall(Button button)
        {
            button.Image = "wall.png";
        }

        private void Potion(Button button)
        {
            button.Image = "smallheal.png";
        }

        private void Bullets(Button button)
        {
            button.Image = "smallammo.png";
        }

        private void Chest(Button button)
        {
            button.Image = "chest.png";
        }

        private void Heal(Button button)
        {
            button.Image = "hp.png";
        }

        private void Eye(Button button)
        {
            button.Image = "eye.png";
        }

        private void Boss(Button button)
        {
            button.Image = "boss.png";
        }

        private void Door(Button button)
        {
            button.Image = "door.png";
        }

        private void Portal(Button button)
        {
            button.Image = "portal.png";
        }

        private void Flame(Button button)
        {
            button.Image = "flame.png";
        }

        private void Reset()
        {
            for (int i = 0; i < 120; i++)
            {
                map[i].Image = null;
            }
            map[108].Image = "player.png";
        }

    }
}
