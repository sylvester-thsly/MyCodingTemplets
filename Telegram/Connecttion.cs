using Telegram.Bot;
using Microsoft.Extensions.Configuration;

namespace MyCodingTemplates.Telegram;

public class TelegramBotTemplate
{
    private readonly TelegramBotClient _botClient;
    private readonly IConfiguration _configuration;

    public TelegramBotTemplate(IConfiguration configuration)
    {
        _configuration = configuration;
        
        // This looks for the token in any appsettings file
        var token = _configuration["BotConfiguration:Token"]!; 
        _botClient = new TelegramBotClient(token);
    }

    public async Task StartAsync()
    {
        var adminId = _configuration.GetValue<long>("BotConfiguration:AdminId");

        _botClient.OnMessage += async (message, type) =>
        {
            // Security: Only respond to the Admin
            if (message.Chat.Id != adminId) return;

            if (message.Text == "/start")
            {
                await _botClient.SendMessage(message.Chat.Id, "🛰️ Template Bot Online.");
            }
            
            // ADD YOUR NEW BOT LOGIC HERE
        };

        Console.WriteLine("🛰️ Telegram Bot is listening...");
        await Task.Delay(-1);
    }
}