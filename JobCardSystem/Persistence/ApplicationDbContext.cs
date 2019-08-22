
using System.Data.Entity;
using JobCardSystem.Core.Domain;
using JobCardSystem.Core.Domain.Configurations;
using JobCardSystem.Models;
using JobCardSystem.Persistence.EntityConfigurations;
using JobCardSystem.Persistence.EntityConfigurations.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace JobCardSystem.Persistence
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
            this.Configuration.LazyLoadingEnabled = false;
            Database.SetInitializer<ApplicationDbContext>(new CreateDatabaseIfNotExists<ApplicationDbContext>());
        }

        //public override IDbSet<ApplicationUser> Users { get; set; }
        //public override IDbSet<IdentityRole> Roles { get; set; }

        public DbSet<Area> Areas { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<JobCard> JobCards { get; set; }
        public DbSet<JobStatus> JobStatuses { get; set; }
        public DbSet<JobType> JobTypes { get; set; }
        public DbSet<MaintenanceContract> MaintenanceContracts { get; set; }
        public DbSet<PaymentRecord> PaymentRecords { get; set; }
        public DbSet<PaymentType> PaymentTypes { get; set; }
        public DbSet<PurchaseOrder> PurchaseOrders { get; set; }
        public DbSet<Quotation> Quotations { get; set; }
        public DbSet<ServiceContract> ServiceContracts { get; set; }
        public DbSet<StockItem> StockItems { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<PurchaseOrderItem> PurchaseOrderItems { get; set; }
        public DbSet<CustomerSignature> CustomerSignatures { get; set; }
        public DbSet<ApplicationUserSignature> ApplicationUserSignatures { get; set; }
        public DbSet<JobStatusHistory> JobStatusHistories { get; set; }
        //
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Image> Images { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new AreaConfiguration());
            modelBuilder.Configurations.Add(new InvoiceConfiguration());
            modelBuilder.Configurations.Add(new JobCardConfiguration());
            modelBuilder.Configurations.Add(new JobStatusConfiguration());
            modelBuilder.Configurations.Add(new JobTypeConfiguration());
            modelBuilder.Configurations.Add(new MaintenanceContractConfiguration());
            modelBuilder.Configurations.Add(new PaymentRecordConfiguration());
            modelBuilder.Configurations.Add(new PaymentTypeConfiguration());
            modelBuilder.Configurations.Add(new PurchaseOrderConfiguration());
            modelBuilder.Configurations.Add(new QuotationConfiguration());
            modelBuilder.Configurations.Add(new ServiceContractConfiguration());
            modelBuilder.Configurations.Add(new StockConfiguration());
            modelBuilder.Configurations.Add(new CustomerConfiguration());
            modelBuilder.Configurations.Add(new SupplierConfiguration());
            modelBuilder.Configurations.Add(new PurchaseOrderItemConfiguration());
            modelBuilder.Configurations.Add(new ApplicationUserSignatureConfiguration());
            modelBuilder.Configurations.Add(new CustomerSignatureConfiguration());
            // Fluent API Configurations for Identity.
            modelBuilder.Configurations.Add(new ApplicationUserConfiguration());
            modelBuilder.Configurations.Add(new IdentityUserLoginConfiguration());
            modelBuilder.Configurations.Add(new IdentityRoleConfiguration());
            modelBuilder.Configurations.Add(new IdentityUserRoleConfiguration());

        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

    }

}