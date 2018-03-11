namespace MyLands.Backend.Models
{
    using Domain;

    public class LocalDataContext : DataContext
    {
        public System.Data.Entity.DbSet<MyLands.Domain.User> Users { get; set; }

        public System.Data.Entity.DbSet<MyLands.Domain.UserType> UserTypes { get; set; }
        //public System.Data.Entity.DbSet<MyLands.Domain.User> Users { get; set; }

        //public System.Data.Entity.DbSet<MyLands.Domain.UserType> UserTypes { get; set; }
    }
}