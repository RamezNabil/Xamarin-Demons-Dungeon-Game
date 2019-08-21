using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace App15
{
    public class Mechanics
    {

        public static async void GettingAmmo(int playerPos, int pos, int amount, Button[]map, Button Ammo)
        {
            if (playerPos == pos && map[pos].Image == "smallammo.png")
            {
                int tempo = int.Parse(Ammo.Text);
                tempo += amount;
                Ammo.Text = tempo.ToString();
                Ammo.TextColor = Color.Green;
                Ammo.FontSize = 16;
                await Task.Delay(300);
                Ammo.TextColor = Color.Black;
                Ammo.FontSize = 14;
            }
        }

        public static async void GettingPotion(int playerPos , int pos , Button[]map , Button Potions)
        {
            if (playerPos == pos && map[pos].Image == "smallheal.png")
            {
                int tempo = int.Parse(Potions.Text);
                tempo++;
                Potions.Text = tempo.ToString();
                Potions.TextColor = Color.Green;
                Potions.FontSize = 16;
                await Task.Delay(300);
                Potions.TextColor = Color.Black;
                Potions.FontSize = 14;
            }
        }

        public static async void PotionHeal(int heal, Button HP, Button GameoverBTN)
        {
            if(GameoverBTN.IsVisible == true)
            {
                return;
            }
            int tempo = int.Parse(HP.Text);
            tempo += heal;
            if (tempo > 100)
            {
                tempo = 100;
            }
            HP.Text = tempo.ToString();
            HP.TextColor = Color.Green;
            HP.FontSize = 16;
            await Task.Delay(300);
            HP.TextColor = Color.Black;
            HP.FontSize = 14;
        }

        public static async Task Healed(int pos, int playerpos, int heal , Button[]map , Button HP, Button GameoverBTN)
        {
            if (GameoverBTN.IsVisible == true)
            {
                return;
            }
            if (playerpos == pos && map[pos].Image == "hp.png")
            {
                int tempo = int.Parse(HP.Text);
                tempo += heal;
                if (tempo > 100)
                {
                    tempo = 100;
                }
                HP.Text = tempo.ToString();
                HP.TextColor = Color.Green;
                HP.FontSize = 16;
                await Task.Delay(300);
                HP.TextColor = Color.Black;
                HP.FontSize = 14;
            }
        }

        public static async void TakesDamage(int damage , Button HP , Button GameoverBTN, Button a, Button g, Button h, Button l, Button u, Button d, Button r)
        {
            if (HP.Text == "0")
            {
                return;
            }
            int temp = int.Parse(HP.Text);
            temp -= damage;
            HP.Text = temp.ToString();
            HP.TextColor = Color.Red;
            HP.FontSize = 16;
            await Task.Delay(300);
            HP.TextColor = Color.Black;
            HP.FontSize = 14;
            if (temp <= 0)
            {
                Gameover(GameoverBTN,a,g,h,l,u,d,r);
            }
        }

        private static async void Gameover(Button GameoverBTN ,Button a, Button g, Button h, Button l, Button u, Button d, Button r)
        {
            GameoverBTN.Text = "GAME OVER!!";
            GameoverBTN.IsVisible = true;
            a.InputTransparent = true;
            g.InputTransparent = true;
            h.InputTransparent = true;
            l.InputTransparent = true;
            u.InputTransparent = true;
            d.InputTransparent = true;
            r.InputTransparent = true;
            while (GameoverBTN.IsVisible == true)
            {
                GameoverBTN.TextColor = Color.Red;
                GameoverBTN.FontSize = 40;
                await Task.Delay(500);
                GameoverBTN.TextColor = Color.Gray;
                GameoverBTN.FontSize = 38;
                await Task.Delay(500);
            }
        }

        public static async void YouWin(Button GameoverBTN, Button a, Button g, Button h, Button l, Button u, Button d, Button r)
        {
            GameoverBTN.Text = "YOU WIN!!";
            GameoverBTN.IsVisible = true;
            a.InputTransparent = true;
            g.InputTransparent = true;
            h.InputTransparent = true;
            l.InputTransparent = true;
            u.InputTransparent = true;
            d.InputTransparent = true;
            r.InputTransparent = true;
            while (GameoverBTN.IsVisible == true)
            {
                GameoverBTN.TextColor = Color.Green;
                GameoverBTN.FontSize = 40;
                await Task.Delay(500);
                GameoverBTN.TextColor = Color.Gray;
                GameoverBTN.FontSize = 38;
                await Task.Delay(500);
            }
        }

    }
}
