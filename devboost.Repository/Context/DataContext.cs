using devboost.Domain.Model;
using Microsoft.EntityFrameworkCore;

namespace devboost.Repository.Context
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {
        }

        public DbSet<Drone> Drone { get; set; }
        public DbSet<Pedido> Pedido { get; set; }
        public DbSet<PedidoDrone> PedidoDrone { get; set; }
        public DbSet<User> User { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            DroneModel(builder);
            PedidoModel(builder);
            PedidoDroneModel(builder);
            UserModel(builder);
        }

        void DroneModel(ModelBuilder builder)
        {
            builder.Entity<Drone>().HasKey(x => x.Id);
            builder.Entity<Drone>()
                .Property(x => x.StatusDrone)
                .HasColumnName("Status");
        }

        void PedidoModel(ModelBuilder builder)
        {
            builder.Entity<Pedido>()
                .HasKey(x => x.Id);
        }

        void PedidoDroneModel(ModelBuilder builder)
        {
            builder.Entity<PedidoDrone>().ToTable("Pedido_Drone");

            builder.Entity<PedidoDrone>()
                .HasKey(x => new { x.PedidoId, x.DroneId });

            builder.Entity<PedidoDrone>()
                .Property(x => x.PedidoId)
                .HasColumnName("Pedido_Id");

            builder.Entity<PedidoDrone>()
                .Property(x => x.DroneId)
                .HasColumnName("Drone_Id");

            builder.Entity<PedidoDrone>()
                .HasOne(x => x.Pedido)
                .WithMany(x => x.PedidosDrones)
                .HasForeignKey(x => x.PedidoId);

            builder.Entity<PedidoDrone>()
                .HasOne(x => x.Drone)
                .WithMany(x => x.PedidosDrones)
                .HasForeignKey(x => x.DroneId);
        }

        void UserModel(ModelBuilder builder)
        {
            builder.Entity<User>().ToTable("Usuario");

            builder.Entity<User>()
                .HasKey(x => x.Id);

            builder.Entity<User>()
                .Property(x => x.Id)
                .HasColumnName("ID");

            builder.Entity<User>()
                .Property(x => x.UserName)
                .HasColumnName("Nome");

            builder.Entity<User>()
                .Property(x => x.Paswword)
                .HasColumnName("Senha");

            builder.Entity<User>()
                .Property(x => x.Role)
                .HasColumnName("Papel");
        }
    }
}
