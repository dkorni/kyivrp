using GTANetworkAPI;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;

namespace KyivRP.Commands
{
    public class AdminCommands : Script
    {
        [Command("veh", "/veh VehId to spawn")]
        public void CreateVeh(Player player, string vehname, int color1, int color2)
        {
            var vehhash = NAPI.Util.GetHashKey(vehname);
            if (vehhash <= 0)
            {
                player.SendChatMessage("Veh doesn't exist");
                return;
            }

            var veh = NAPI.Vehicle.CreateVehicle(vehhash, player.Position, player.Heading, color1, color2);
            veh.NumberPlate = "AA1111XB";
            veh.EngineStatus = true;
            veh.Locked = false;
            player.SetIntoVehicle(veh, (int)VehicleSeat.Driver);
        }

        [Command("ban", "/ban playername reason")]
        public void Ban(Player caller, string name, string reason)
        {
            // check if player online
            var player = NAPI.Player.GetPlayerFromName(name);
            if (player != null)
            {
                NAPI.Player.BanPlayer(player);
                NAPI.Chat.SendChatMessageToAll($"Гравець {name} був забений довічно адміністратором {caller.Name} по причині '{reason}'.");
            }
            else
            {
                caller.SendChatMessage($"Гравець з ніком {name} не знайдений.");
            }
        }


        [Command("kick", "/kick playername reason")]
        public void Kick(Player caller, string name, string reason)
        {
            // check if player online
            var player = NAPI.Player.GetPlayerFromName(name);
            if (player != null)
            {
                NAPI.Player.KickPlayer(player);
                NAPI.Chat.SendChatMessageToAll($"Гравець {name} був кікнутий адміністратором {caller.Name} по причині '{reason}'.");
            }
            else
            {
                caller.SendChatMessage($"Гравець з ніком {name} не знайдений.");
            }
        }

        [Command("giveweapon", "/giveweapon weaponname playername ammo")]
        public void GiveWeapon(Player caller, string weaponname, string playername, int ammo)
        {
            var weaponHash = NAPI.Util.GetHashKey(weaponname);

            var player = NAPI.Player.GetPlayerFromName(playername);
            if (player != null)
            {
                if (Enum.TryParse(weaponname, out WeaponHash w))
                    player.SetWeaponAmmo(w, ammo);
                else
                    caller.SendChatMessage($"Параметр weaponname не вірний");

            }
            else
            {
                caller.SendChatMessage($"Гравець з ніком {playername} не знайдений.");
            }
        }

        [Command("setweather", "/setweather weather")]
        public void SetWeather(Player caller, string weather)
        {
            if (Enum.TryParse(weather, out Weather w))
                NAPI.World.SetWeather(w);
            else
                caller.SendChatMessage($"Параметр weather не вірний, оберіть  EXTRASUNNY, CLEAR, CLOUDS, SMOG, FOGGY, OVERCAST, RAIN, THUNDER, CLEARING, NEUTRAL, SNOW, BLIZZARD, SNOWLIGHT, XMAS");
        }

        [Command("settime", "/settime hours minutes seconds")]
        public void SetTime(Player caller, int hours, int minutes, int seconds)
        {
            NAPI.World.SetTime(hours, minutes, seconds);
        }
    }
}