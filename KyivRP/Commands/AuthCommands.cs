﻿//using GTANetworkAPI;
//using GTANetworkMethods;
//using KyivRP.Domain.Constants;
//using KyivRP.Domain.Interfaces.Services;
//using Microsoft.Extensions.DependencyInjection;
//using System;
//using System.Collections.Generic;
//using System.Text;
//using System.Threading.Tasks;
//using Task = System.Threading.Tasks.Task;
//using Player = GTANetworkAPI.Player;
//using KyivRP.Domain.Models;

//namespace KyivRP.Commands.Commands
//{
//    public class AuthCommands : Script
//    {
//        private IAuthService authService;

//        public AuthCommands()
//        {
//            authService = AppContext.ServiceProvider.GetRequiredService<IAuthService>();
//        }

//        [Command("login", "/login username password")]
//        public async Task Login(Player caller, string username, string password)
//        {
//            var result = await authService.Login(username, password);

//            if (result.Value == null)
//            {
//                if (result.Error == Errors.UserDoesNotExist)
//                    NAPI.Task.Run(() => caller.SendChatMessage($"Користувач з ім'ям {username} не існує"));


//                if (result.Error == Errors.InvalidPassword)
//                    NAPI.Task.Run(() => caller.SendChatMessage($"Не вірний пароль!"));
//            }

//            NAPI.Task.Run(() => caller.SendChatMessage($"Ви успішно авторизувалися!"));
//            NAPI.Task.Run(() => NAPI.ClientEvent.TriggerClientEvent(caller, "PlayerFreeze", false));
//            NAPI.Task.Run(() => caller.SetData(nameof(Account), result.Value));
//        }

//        [Command("register", "/register username email password")]
//        public async Task Register(Player caller, string username, string email, string password)
//        {
//            var result = await authService.Register(username, email, password);

//            if(result.Value == null)
//            {
//                if(result.Error == Errors.UserAlreadyRegistered)
//                    NAPI.Task.Run(() => caller.SendChatMessage($"Користувач з ім'ям {username} вже існує"));
//            }

//            NAPI.Task.Run(() => NAPI.ClientEvent.TriggerClientEvent(caller, "PlayerFreeze", false));
//            NAPI.Task.Run(() => caller.SetData(nameof(Account), result.Value));
//        }
//    }
//}
