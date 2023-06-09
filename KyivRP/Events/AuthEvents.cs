using GTANetworkAPI;
using KyivRP.Domain.Constants;
using KyivRP.Domain.Interfaces.Services;
using KyivRP.Domain.Models;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;

namespace KyivRP.Events.Events
{
    public class AuthEvents : Script
    {
        private IAuthService authService;

        public AuthEvents()
        {
            authService = AppContext.ServiceProvider.GetRequiredService<IAuthService>();
        }

        [RemoteEvent("Auth.OnLogin")]
        public async Task OnLogin(Player caller, string username, string password)
        {
            var result = await authService.Login(username, password);

            if (result.Value == null)
            {
                if (result.Error == Errors.UserDoesNotExist)
                    NAPI.Task.Run(() => caller.SendChatMessage($"Користувач з ім'ям {username} не існує"));


                if (result.Error == Errors.InvalidPassword)
                    NAPI.Task.Run(() => caller.SendChatMessage($"Не вірний пароль!"));
            }

            NAPI.Task.Run(() => caller.SendChatMessage($"Ви успішно авторизувалися!"));
            NAPI.Task.Run(() => NAPI.ClientEvent.TriggerClientEvent(caller, "PlayerFreeze", false));
            NAPI.Task.Run(() => caller.SetData(nameof(Account), result.Value));
        }

        [RemoteEvent("Auth.OnRegister")]
        public async Task OnRegister(Player caller, string username, string email, string password)
        {
            var result = await authService.Register(username, email, password);

            if (result.Value == null)
            {
                if (result.Error == Errors.UserAlreadyRegistered)
                    NAPI.Task.Run(() => caller.SendChatMessage($"Користувач з ім'ям {username} вже існує"));
            }

            NAPI.Task.Run(() => NAPI.ClientEvent.TriggerClientEvent(caller, "PlayerFreeze", false));
            NAPI.Task.Run(() => caller.SetData(nameof(Account), result.Value));
        }
    }
}
