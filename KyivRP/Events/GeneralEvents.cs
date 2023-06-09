using System;
using GTANetworkAPI;
using KyivRP.Domain.Models;
using Microsoft.Extensions.DependencyInjection;
using Org.BouncyCastle.Asn1.X509;

namespace KyivRP.Events
{
    public class GeneralEvents : Script
    {
        [ServerEvent(Event.PlayerConnected)]
        public void PlayerConnected(Player player)
        {
            player.SendChatMessage("Вітаємо на сервері Kyiv RP!");
        }

        [ServerEvent(Event.PlayerSpawn)]
        public void PlayerSpawned(Player player)
        {
            if (!player.HasData(nameof(Account)))
            {
                NAPI.ClientEvent.TriggerClientEvent(player, "PlayerFreeze", true);
                // player.SendChatMessage($"Будь ласка авторизуйтися, командою /login або /reg ");
            }
        }
    }
}
