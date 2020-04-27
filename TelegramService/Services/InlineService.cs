using Entity.Telegram;
using MongoRepositorys.MongoContext;
using MongoRepositorys.Repository;
using System.Linq;
using TelegramService.Interfaces;

namespace TelegramService.Services
{
    public class InlineService : MongoRepository<InlineButton>, IInlineService
    {
        public InlineService(IMongoContext context) : base(context)
        {
        }
        public InlineButton GetInline(string text)
        {
           return GetFirst(m => m.Langs.Any(n => n.Value == text));
        }

    }
}
