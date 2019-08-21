using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace App15
{
    public class Enemy
    {
        private int m;
        private FileImageSource image;
        private int position;

        public Enemy(int pos , Button[] map, int[] varr, Button hp, Button GameoverBTN,
            Button AttackBTN,Button GunBTN,Button HealBTN,Button LeftBTN,Button UpBTN,Button DownBTN,Button RightBTN)
        {
            m = 0;
            image = "enemy.png";
            position = pos;
            map[pos].Image = image;
            Animate(map, varr, hp ,GameoverBTN, AttackBTN, GunBTN, HealBTN, LeftBTN, UpBTN, DownBTN, RightBTN);
        }

        public async void Animate(Button[] map , int[]varr , Button HP ,Button GameoverBTN,  Button AttackBTN,Button GunBTN,Button HealBTN,
            Button LeftBTN, Button UpBTN,Button DownBTN,Button RightBTN)
        {
            if (map[position].BackgroundColor == Color.Firebrick && m == 0)
            {

                m++;
                while (true)
                {
                    await Task.Delay(1000);
                    if (map[position].Image != "enemy.png")
                    {
                        break;
                    }
                    for (int j = 0; j < varr.Length; j++)
                    {
                        if (position + varr[j] < 0 || position + varr[j] > 119 || ((varr[j] == -13 || varr[j] == -1 || varr[j] == 11) && position % 12 == 0)
                            || ((varr[j] == 13 || varr[j] == 1 || varr[j] == -11) && (position + 1) % 12 == 0) || varr[j] == 0)
                        {
                            continue;
                        }
                        if (map[position + varr[j]].Image == "wall.png" || map[position + varr[j]].Image == "chest.png"
                            || map[position + varr[j]].Image == "enemy.png" || map[position + varr[j]].Image == "boss.png"
                            || map[position + varr[j]].Image == "bulletup.png" || map[position + varr[j]].Image == "bulletleft.png"
                            || map[position + varr[j]].Image == "bulletdown.png" || map[position + varr[j]].Image == "bulletright.png"
                            || map[position + varr[j]].Image == "portal.png")
                        {
                            continue;
                        }
                        if (map[position + varr[j]].Image == "player.png")
                        {
                            Mechanics.TakesDamage(10,HP,GameoverBTN,AttackBTN,GunBTN,HealBTN,LeftBTN,UpBTN,DownBTN,RightBTN);
                            continue;
                        }
                        map[position + varr[j]].Image = "flame.png";
                    }

                    await Task.Delay(500);

                    for (int j = 0; j < varr.Length; j++)
                    {
                        if (position + varr[j] < 0 || position + varr[j] > 119 || ((varr[j] == -13 || varr[j] == -1 || varr[j] == 11) && position % 12 == 0)
                            || ((varr[j] == 13 || varr[j] == 1 || varr[j] == -11) && (position + 1) % 12 == 0) || varr[j] == 0)
                        {
                            continue;
                        }
                        if (map[position + varr[j]].Image == "wall.png" || map[position + varr[j]].Image == "chest.png"
                             || map[position + varr[j]].Image == "enemy.png" || map[position + varr[j]].Image == "boss.png" 
                             || map[position + varr[j]].Image == "portal.png")
                        {
                            continue;
                        }
                        if (map[position + varr[j]].Image == "player.png")
                        {
                            continue;
                        }
                        map[position + varr[j]].Image = null;
                    }

                }
            }
        }
    }
}
