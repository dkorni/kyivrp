using System;
using GTANetworkAPI;

using Microsoft.Extensions.DependencyInjection;

namespace KyivRP
{
    public class Events : Script
    {
        [ServerEvent(Event.PlayerConnected)]
        public void PlayerConnected(Player player)
        {
            player.SendChatMessage("Вітаємо на сервері Kyiv RP!");
        }
    }
}
