
using Entity.Projects;
using Entity.Telegram;
using Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Args;
using TelegramService.Commands;
using TelegramService.Interfaces;

namespace TelegramService
{
    public class StartTelegram : ITelegramPushService
    {
        IEnumerable<ITeleCommands> _commands;
        TelegramBotClient _client;
        ITelegramUserService _user;
        IInlineService _inline;
        IProjectService _project;
        public StartTelegram(TelegramBotClient client,
            IEnumerable<ITeleCommands> cmnds,
            ITelegramUserService user,
            IInlineService inline,
            IProjectService project
            )
        {
            var me = client.GetMeAsync().Result;
            Console.WriteLine($"Hello, World! I am user {me.Id} and my name is {me.FirstName}.");

            _commands = cmnds;
            _client = client;
            _user = user;
            _inline = inline;
            _project = project;
            _client.OnMessage += botMessage;
            _client.OnCallbackQuery += callBackMessage;
            _client.StartReceiving();


        }

        private void callBackMessage(object sender, CallbackQueryEventArgs e)
        {



        }

        private async void botMessage(object sender, MessageEventArgs e)
        {
            var user = _user.GetFirst(m => m.TUserId == e.Message.From.Id);
            if (user == null)
            {
                var command = _commands.FirstOrDefault(m => m.Name == "/start");
                await command.Run(user, e.Message);
                return;
            }
            ITeleCommands cmd = null;
            cmd = _commands.FirstOrDefault(m => m.Name == e.Message.Text);
            if (cmd != null) { await Run(cmd, user, e); }
            //By Inline
            cmd = ByInline(user, e, cmd);
            await Run(cmd, user, e);
        }
        public async Task NotFoundCommand(TelegramUser user, MessageEventArgs e)
        {

        }
        public async Task Run(ITeleCommands cmd, TelegramUser user, MessageEventArgs e)
        {
            if (cmd == null)
            {

            }
            await cmd.Run(user, e.Message);
        }
        //First
        public ITeleCommands ByInline(TelegramUser user, MessageEventArgs e, ITeleCommands cmd)
        {
            var inline = _inline.GetInline(e.Message.Text);
            if (inline == null) return ByProject(user, e, cmd);
            cmd = _commands.FirstOrDefault(m => m.Name.ToLower() == inline.CommandName);
            return cmd ?? ByProject(user, e, cmd);
        }
        public ITeleCommands ByProject(TelegramUser user, MessageEventArgs e, ITeleCommands cmd)
        {
            var project = _project.GetFirst(m => m.Name.ToLower() == e.Message.Text.ToLower());
            if (project != null)
            {
                cmd = _commands.FirstOrDefault(m => m.Name == "/project");
                cmd.SetData<Project>(project);
            }
            return cmd ?? ByLastCommand(user, e, cmd);
        }
        //Last
        public ITeleCommands ByLastCommand(TelegramUser userm, MessageEventArgs e, ITeleCommands cmd)
        {
            return cmd;
        }

    }
}
