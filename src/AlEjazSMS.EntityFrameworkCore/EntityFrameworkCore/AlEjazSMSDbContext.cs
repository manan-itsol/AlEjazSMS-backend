using AlEjazSMS.Branches;
using AlEjazSMS.Classes;
using AlEjazSMS.FeeStructures;
using AlEjazSMS.FeeTransactions;
using AlEjazSMS.Sections;
using AlEjazSMS.StudentFees;
using AlEjazSMS.Students;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.AuditLogging.EntityFrameworkCore;
using Volo.Abp.BackgroundJobs.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Volo.Abp.FeatureManagement.EntityFrameworkCore;
using Volo.Abp.Identity;
using Volo.Abp.Identity.EntityFrameworkCore;
using Volo.Abp.OpenIddict.EntityFrameworkCore;
using Volo.Abp.PermissionManagement.EntityFrameworkCore;
using Volo.Abp.SettingManagement.EntityFrameworkCore;
using Volo.Abp.TenantManagement;
using Volo.Abp.TenantManagement.EntityFrameworkCore;

namespace AlEjazSMS.EntityFrameworkCore;

[ReplaceDbContext(typeof(IIdentityDbContext))]
[ReplaceDbContext(typeof(ITenantManagementDbContext))]
[ConnectionStringName("Default")]
public class AlEjazSMSDbContext :
    AbpDbContext<AlEjazSMSDbContext>,
    IIdentityDbContext,
    ITenantManagementDbContext
{
    /* Add DbSet properties for your Aggregate Roots / Entities here. */

    #region Entities from the modules

    /* Notice: We only implemented IIdentityDbContext and ITenantManagementDbContext
     * and replaced them for this DbContext. This allows you to perform JOIN
     * queries for the entities of these modules over the repositories easily. You
     * typically don't need that for other modules. But, if you need, you can
     * implement the DbContext interface of the needed module and use ReplaceDbContext
     * attribute just like IIdentityDbContext and ITenantManagementDbContext.
     *
     * More info: Replacing a DbContext of a module ensures that the related module
     * uses this DbContext on runtime. Otherwise, it will use its own DbContext class.
     */

    //Identity
    public DbSet<IdentityUser> Users { get; set; }
    public DbSet<IdentityRole> Roles { get; set; }
    public DbSet<IdentityClaimType> ClaimTypes { get; set; }
    public DbSet<OrganizationUnit> OrganizationUnits { get; set; }
    public DbSet<IdentitySecurityLog> SecurityLogs { get; set; }
    public DbSet<IdentityLinkUser> LinkUsers { get; set; }

    // Tenant Management
    public DbSet<Tenant> Tenants { get; set; }
    public DbSet<TenantConnectionString> TenantConnectionStrings { get; set; }

    #endregion

    public DbSet<Student> Students { get; set; }
    public DbSet<Branch> Branches { get; set; }
    public DbSet<Class> Classes { get; set; }
    public DbSet<Section> Sections { get; set; }
    public DbSet<ClassSection> ClassSections { get; set; }
    public DbSet<FeeStructure> FeeStructures { get; set; }
    public DbSet<FeeStructureLineItem> StructureLineItems { get; set; }
    public DbSet<StudentFee> StudentFees { get; set; }
    public DbSet<FeeTransaction> FeeTransactions { get; set; }

    public AlEjazSMSDbContext(DbContextOptions<AlEjazSMSDbContext> options)
        : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        /* Include modules to your migration db context */

        builder.ConfigurePermissionManagement();
        builder.ConfigureSettingManagement();
        builder.ConfigureBackgroundJobs();
        builder.ConfigureAuditLogging();
        builder.ConfigureIdentity();
        builder.ConfigureOpenIddict();
        builder.ConfigureFeatureManagement();
        builder.ConfigureTenantManagement();

        /* Configure your own tables/entities inside here */

        builder.Entity<Student>(b =>
        {
            b.ToTable("Students");

            //auto configure for the base class props
            b.ConfigureByConvention();

            b.Property(x => x.Name).IsRequired().HasMaxLength(200);
            b.Property(x => x.CNIC).HasMaxLength(20);
            b.Property(x => x.PhoneNumber).HasMaxLength(13);
            b.Property(x => x.FatherName).HasMaxLength(200);
            b.Property(x => x.FatherCNIC).HasMaxLength(20);
            b.Property(x => x.PresentAddress).HasMaxLength(500);

            b.HasIndex(x => new { x.RollNo, x.ClassSectionId })
                .IsUnique(true);

            b.HasOne(x => x.ClassSection)
                .WithMany()
                .HasForeignKey(x => x.ClassSectionId)
                .IsRequired();
        });

        builder.Entity<StudentFeeStructure>(b =>
        {
            b.ToTable("StudentFeeStructures");

            //auto configure for the base class props
            b.ConfigureByConvention();

            b.HasOne(x => x.Student)
                .WithMany(x => x.StudentFeeStructures)
                .HasForeignKey(x => x.StudentId)
                .IsRequired();

            b.HasOne(x => x.FeeStructure)
                .WithMany(x => x.StudentFeeStructures)
                .HasForeignKey(x => x.FeeStructureId)
                .IsRequired();

            b.HasIndex(x => new { x.StudentId, x.FeeStructureId})
                .IsUnique();
        });

        builder.Entity<Branch>(b =>
        {
            b.ToTable("Branches");

            //auto configure for the base class props
            b.ConfigureByConvention();

            b.Property(x => x.Code).IsRequired().HasMaxLength(10);
            b.Property(x => x.Name).IsRequired().HasMaxLength(100);
        });

        builder.Entity<Class>(b =>
        {
            b.ToTable("Classes");

            //auto configure for the base class props
            b.ConfigureByConvention();

            b.Property(x => x.Code).IsRequired().HasMaxLength(3);
            b.Property(x => x.Name).IsRequired().HasMaxLength(50);

            b.HasOne(x => x.Branch)
                .WithMany(x => x.Classes)
                .HasForeignKey(x => x.BranchId)
                .IsRequired();
        });

        builder.Entity<Section>(b =>
        {
            b.ToTable("Sections");

            //auto configure for the base class props
            b.ConfigureByConvention();

            b.Property(x => x.Name).IsRequired().HasMaxLength(50);

        });

        builder.Entity<ClassSection>(b =>
        {
            b.ToTable("ClassSections");

            //auto configure for the base class props
            b.ConfigureByConvention();

            b.HasOne(x => x.Class)
                .WithMany(x => x.ClassSections)
                .HasForeignKey(x => x.ClassId)
                .IsRequired();

            b.HasOne(x => x.Section)
                .WithMany(x => x.ClassSections)
                .HasForeignKey(x => x.SectionId)
                .IsRequired();

            b.HasIndex(x => new { x.SectionId, x.ClassId })
                .IsUnique();
        });

        builder.Entity<FeeStructure>(b =>
        {
            b.ToTable("FeeStructures");

            //auto configure for the base class props
            b.ConfigureByConvention();

            b.Property(x => x.Title).IsRequired().HasMaxLength(200);
            b.Property(x => x.Description).HasMaxLength(500);
        });

        builder.Entity<FeeStructureLineItem>(b =>
        {
            b.ToTable("FeeStructureLineItems");

            //auto configure for the base class props
            b.ConfigureByConvention();

            b.Property(x => x.ShortDescription).IsRequired().HasMaxLength(150);
            b.Property(x => x.Amount).HasColumnType("decimal(18,2)");

            b.HasOne(x => x.FeeStructure)
                .WithMany(x => x.LineItems)
                .HasForeignKey(x => x.FeeStructureId)
                .IsRequired();
        });

        builder.Entity<StudentFee>(b =>
        {
            b.ToTable("StudentFees");

            //auto configure for the base class props
            b.ConfigureByConvention();

            b.Property(x => x.Amount).HasColumnType("decimal(18,2)");

            b.HasOne(x => x.Student)
                .WithMany()
                .HasForeignKey(x => x.StudentId)
                .IsRequired();

            b.HasOne(x => x.FeeStructure)
                .WithMany()
                .HasForeignKey(x => x.FeeStructureId)
                .IsRequired();
        });

        builder.Entity<FeeTransaction>(b =>
        {
            b.ToTable("FeeTransactions");

            //auto configure for the base class props
            b.ConfigureByConvention();

            b.Property(x => x.Amount).HasColumnType("decimal(18,2)");

            b.HasOne(x => x.StudentFee)
                .WithMany(x => x.FeeTransactions)
                .HasForeignKey(x => x.StudentFeeId)
                .IsRequired();
        });
    }
}
