using System.Data.Entity;

namespace Comp_Club
{
    public class Entities : DbContext
    {
        // Приватное статическое поле для Singleton
        private static Entities _instance;

        // Объект блокировки для потокобезопасности
        private static readonly object _lock = new object();

        // Приватный конструктор, чтобы предотвратить создание экземпляров извне
        private Entities(): base("name=ComputerClubDB") // строка подключения из App.config
        {}

        // Публичное статическое свойство для доступа к Singleton-экземпляру
        public static Entities Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (_lock)
                    {
                        if (_instance == null)
                            _instance = new Entities();
                    }
                }
                return _instance;
            }
        }

        // Таблицы (наборы данных)
        public DbSet<Client> Clients { get; set; }
        public DbSet<GuestVisitStat> GuestVisitStat { get; set; }   
        public DbSet<DailyRevenue> DailyRevenue { get; set; }       
        public DbSet<PopularDish> PopularDish { get; set; }        
        public DbSet<RepairParts> RepairParts { get; set; }

    }
}
