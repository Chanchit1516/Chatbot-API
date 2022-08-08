using Chatbot_API.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Chatbot_API.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> option) : base(option)
        {

        }

        public DbSet<CHAT_HISTORIE> CHAT_HISTORIE { get; set; }
        public DbSet<CHAT_HISTORIE_DETAIL> CHAT_HISTORIE_DETAIL { get; set; }
    }
}
