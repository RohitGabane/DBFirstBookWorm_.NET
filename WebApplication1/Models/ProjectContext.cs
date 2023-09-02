using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Models;

public partial class ProjectContext : DbContext
{
    public ProjectContext()
    {
    }

    public ProjectContext(DbContextOptions<ProjectContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AttributeMaster> AttributeMasters { get; set; }

    public virtual DbSet<BeneficiaryMaster> BeneficiaryMasters { get; set; }

    public virtual DbSet<Cart> Carts { get; set; }

    public virtual DbSet<CustomerMaster> CustomerMasters { get; set; }

    public virtual DbSet<GenreMaster> GenreMasters { get; set; }

    public virtual DbSet<InvoiceDetail> InvoiceDetails { get; set; }

    public virtual DbSet<InvoiceTable> InvoiceTables { get; set; }

    public virtual DbSet<LanguageMaster> LanguageMasters { get; set; }

    public virtual DbSet<MyShelf> MyShelves { get; set; }

    public virtual DbSet<ProductAttribute> ProductAttributes { get; set; }

    public virtual DbSet<ProductBenMaster> ProductBenMasters { get; set; }

    public virtual DbSet<ProductMaster> ProductMasters { get; set; }

    public virtual DbSet<ProductTypeMaster> ProductTypeMasters { get; set; }

    public virtual DbSet<PublisherMaster> PublisherMasters { get; set; }

    public virtual DbSet<RoyaltyCalculation> RoyaltyCalculations { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySql("server=localhost;uid=root;pwd=9997111559;database=project", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.32-mysql"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_0900_ai_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<AttributeMaster>(entity =>
        {
            entity.HasKey(e => e.AttributeId).HasName("PRIMARY");

            entity.ToTable("attribute_master");

            entity.Property(e => e.AttributeId).HasColumnName("attribute_id");
            entity.Property(e => e.AttributeDesc)
                .HasMaxLength(255)
                .HasColumnName("attribute_desc");
        });

        modelBuilder.Entity<BeneficiaryMaster>(entity =>
        {
            entity.HasKey(e => e.BenId).HasName("PRIMARY");

            entity.ToTable("beneficiary_master");

            entity.Property(e => e.BenId).HasColumnName("ben_id");
            entity.Property(e => e.BenAccNo)
                .HasMaxLength(255)
                .HasColumnName("ben_acc_no");
            entity.Property(e => e.BenAccType)
                .HasMaxLength(255)
                .HasColumnName("ben_acc_type");
            entity.Property(e => e.BenBankBranch)
                .HasMaxLength(255)
                .HasColumnName("ben_bank_branch");
            entity.Property(e => e.BenBankName)
                .HasMaxLength(255)
                .HasColumnName("ben_bank_name");
            entity.Property(e => e.BenContactNo)
                .HasMaxLength(255)
                .HasColumnName("ben_contact_no");
            entity.Property(e => e.BenEmailId)
                .HasMaxLength(255)
                .HasColumnName("ben_email_id");
            entity.Property(e => e.BenName)
                .HasMaxLength(255)
                .HasColumnName("ben_name");
            entity.Property(e => e.Benifsc)
                .HasMaxLength(255)
                .HasColumnName("benifsc");
            entity.Property(e => e.Benpan)
                .HasMaxLength(255)
                .HasColumnName("benpan");
        });

        modelBuilder.Entity<Cart>(entity =>
        {
            entity.HasKey(e => e.CartId).HasName("PRIMARY");

            entity.ToTable("cart");

            entity.HasIndex(e => e.CustomerCustomerId, "FK12bx6p0wmwqvsb6tjq9w8qgte");

            entity.HasIndex(e => e.ProductProductId, "FKoupaptkkjoqfn4n1puwibsn6k");

            entity.Property(e => e.CartId).HasColumnName("cart_id");
            entity.Property(e => e.CustomerCustomerId).HasColumnName("customer_customer_id");
            entity.Property(e => e.ProductProductId).HasColumnName("product_product_id");
            entity.Property(e => e.Quantity)
                .HasDefaultValueSql("'1'")
                .HasColumnName("quantity");
            entity.Property(e => e.Type)
                .HasMaxLength(255)
                .HasColumnName("type");

            entity.HasOne(d => d.CustomerCustomer).WithMany(p => p.Carts)
                .HasForeignKey(d => d.CustomerCustomerId)
                .HasConstraintName("FK12bx6p0wmwqvsb6tjq9w8qgte");

            entity.HasOne(d => d.ProductProduct).WithMany(p => p.Carts)
                .HasForeignKey(d => d.ProductProductId)
                .HasConstraintName("FKoupaptkkjoqfn4n1puwibsn6k");
        });

        modelBuilder.Entity<CustomerMaster>(entity =>
        {
            entity.HasKey(e => e.CustomerId).HasName("PRIMARY");

            entity.ToTable("customer_master");

            entity.Property(e => e.CustomerId).HasColumnName("customer_id");
            entity.Property(e => e.CustomerContactNo)
                .HasMaxLength(255)
                .HasColumnName("customer_contact_no");
            entity.Property(e => e.CustomerEmail)
                .HasMaxLength(255)
                .HasColumnName("customer_email");
            entity.Property(e => e.CustomerName)
                .HasMaxLength(255)
                .HasColumnName("customer_name");
            entity.Property(e => e.IsPremium)
                .HasColumnType("bit(1)")
                .HasColumnName("is_premium");
            entity.Property(e => e.Password)
                .HasMaxLength(255)
                .HasColumnName("password");
            entity.Property(e => e.PremiumDate).HasColumnName("premium_date");
        });

        modelBuilder.Entity<GenreMaster>(entity =>
        {
            entity.HasKey(e => e.GenreId).HasName("PRIMARY");

            entity.ToTable("genre_master");

            entity.HasIndex(e => e.LanguageId, "FKr1acc4hd88a76kguh611nrowi");

            entity.Property(e => e.GenreId).HasColumnName("genre_id");
            entity.Property(e => e.GenreDesc)
                .HasMaxLength(255)
                .HasColumnName("genre_desc");
            entity.Property(e => e.LanguageId).HasColumnName("language_id");

            entity.HasOne(d => d.Language).WithMany(p => p.GenreMasters)
                .HasForeignKey(d => d.LanguageId)
                .HasConstraintName("FKr1acc4hd88a76kguh611nrowi");
        });

        modelBuilder.Entity<InvoiceDetail>(entity =>
        {
            entity.HasKey(e => e.InvDtlId).HasName("PRIMARY");

            entity.ToTable("invoice_details");

            entity.HasIndex(e => e.ProductId, "FK1anfj9yh7l91txbjf905la63l");

            entity.HasIndex(e => e.InvoiceId, "FKrnurbxh2f855faqps94pjsdh1");

            entity.Property(e => e.InvDtlId).HasColumnName("inv_dtl_id");
            entity.Property(e => e.BasePrice).HasColumnName("base_price");
            entity.Property(e => e.InvoiceId).HasColumnName("invoice_id");
            entity.Property(e => e.ProductId).HasColumnName("product_id");
            entity.Property(e => e.Quantity).HasColumnName("quantity");
            entity.Property(e => e.RentNoOfDays).HasColumnName("rent_no_of_days");
            entity.Property(e => e.TranType)
                .HasMaxLength(255)
                .HasColumnName("tran_type");

            entity.HasOne(d => d.Invoice).WithMany(p => p.InvoiceDetails)
                .HasForeignKey(d => d.InvoiceId)
                .HasConstraintName("FKrnurbxh2f855faqps94pjsdh1");

            entity.HasOne(d => d.Product).WithMany(p => p.InvoiceDetails)
                .HasForeignKey(d => d.ProductId)
                .HasConstraintName("FK1anfj9yh7l91txbjf905la63l");
        });

        modelBuilder.Entity<InvoiceTable>(entity =>
        {
            entity.HasKey(e => e.InvoiceId).HasName("PRIMARY");

            entity.ToTable("invoice_table");

            entity.HasIndex(e => e.CustId, "FK4o8065ly7eowy1fnbhyiahpy9");

            entity.Property(e => e.InvoiceId).HasColumnName("invoice_id");
            entity.Property(e => e.CustId).HasColumnName("cust_id");
            entity.Property(e => e.InvoiceAmount).HasColumnName("invoice_amount");
            entity.Property(e => e.InvoiceDate).HasColumnName("invoice_date");

            entity.HasOne(d => d.Cust).WithMany(p => p.InvoiceTables)
                .HasForeignKey(d => d.CustId)
                .HasConstraintName("FK4o8065ly7eowy1fnbhyiahpy9");
        });

        modelBuilder.Entity<LanguageMaster>(entity =>
        {
            entity.HasKey(e => e.LanguageId).HasName("PRIMARY");

            entity.ToTable("language_master");

            entity.HasIndex(e => e.TypeId, "FKjsk2oy39x5e0lm5mhhongfvoa");

            entity.Property(e => e.LanguageId).HasColumnName("language_id");
            entity.Property(e => e.LanguageDesc)
                .HasMaxLength(255)
                .HasColumnName("language_desc");
            entity.Property(e => e.TypeId).HasColumnName("type_id");

            entity.HasOne(d => d.Type).WithMany(p => p.LanguageMasters)
                .HasForeignKey(d => d.TypeId)
                .HasConstraintName("FKjsk2oy39x5e0lm5mhhongfvoa");
        });

        modelBuilder.Entity<MyShelf>(entity =>
        {
            entity.HasKey(e => e.ShelfId).HasName("PRIMARY");

            entity.ToTable("my_shelf");

            entity.HasIndex(e => e.CustomerId, "FKcda6p3ku4rwecfvmwjv73hpfv");

            entity.HasIndex(e => e.ProductId, "FKfh26p3kj7hk39mr0jrepq4sqv");

            entity.Property(e => e.ShelfId).HasColumnName("shelf_id");
            entity.Property(e => e.CustomerId).HasColumnName("customer_id");
            entity.Property(e => e.IsActive)
                .HasColumnType("bit(1)")
                .HasColumnName("is_active");
            entity.Property(e => e.ProductExpiryDate).HasColumnName("product_expiry_date");
            entity.Property(e => e.ProductId).HasColumnName("product_id");
            entity.Property(e => e.TranType)
                .HasMaxLength(255)
                .HasColumnName("tran_type");

            entity.HasOne(d => d.Customer).WithMany(p => p.MyShelves)
                .HasForeignKey(d => d.CustomerId)
                .HasConstraintName("FKcda6p3ku4rwecfvmwjv73hpfv");

            entity.HasOne(d => d.Product).WithMany(p => p.MyShelves)
                .HasForeignKey(d => d.ProductId)
                .HasConstraintName("FKfh26p3kj7hk39mr0jrepq4sqv");
        });

        modelBuilder.Entity<ProductAttribute>(entity =>
        {
            entity.HasKey(e => e.ProdAttId).HasName("PRIMARY");

            entity.ToTable("product_attribute");

            entity.HasIndex(e => e.ProductId, "FK7fpmqn73o75lqbsidrck4lun4");

            entity.HasIndex(e => e.AttributeId, "FKi1ys4wa8e12ujvxihva030iuq");

            entity.Property(e => e.ProdAttId).HasColumnName("prod_att_id");
            entity.Property(e => e.AttributeId).HasColumnName("attribute_id");
            entity.Property(e => e.AttributeValue)
                .HasMaxLength(255)
                .HasColumnName("attribute_value");
            entity.Property(e => e.ProductId).HasColumnName("product_id");

            entity.HasOne(d => d.Attribute).WithMany(p => p.ProductAttributes)
                .HasForeignKey(d => d.AttributeId)
                .HasConstraintName("FKi1ys4wa8e12ujvxihva030iuq");

            entity.HasOne(d => d.Product).WithMany(p => p.ProductAttributes)
                .HasForeignKey(d => d.ProductId)
                .HasConstraintName("FK7fpmqn73o75lqbsidrck4lun4");
        });

        modelBuilder.Entity<ProductBenMaster>(entity =>
        {
            entity.HasKey(e => e.ProdBenId).HasName("PRIMARY");

            entity.ToTable("product_ben_master");

            entity.HasIndex(e => e.ProdBenProductId, "FK8olgn84rj3ayh6s5qnnes7283");

            entity.HasIndex(e => e.ProdBenBenId, "FKoaf65mkllwss1exas02p6u2cb");

            entity.Property(e => e.ProdBenId).HasColumnName("prod_ben_id");
            entity.Property(e => e.ProdBenBenId).HasColumnName("prod_ben_ben_id");
            entity.Property(e => e.ProdBenPercentage).HasColumnName("prod_ben_percentage");
            entity.Property(e => e.ProdBenProductId).HasColumnName("prod_ben_product_id");

            entity.HasOne(d => d.ProdBenBen).WithMany(p => p.ProductBenMasters)
                .HasForeignKey(d => d.ProdBenBenId)
                .HasConstraintName("FKoaf65mkllwss1exas02p6u2cb");

            entity.HasOne(d => d.ProdBenProduct).WithMany(p => p.ProductBenMasters)
                .HasForeignKey(d => d.ProdBenProductId)
                .HasConstraintName("FK8olgn84rj3ayh6s5qnnes7283");
        });

        modelBuilder.Entity<ProductMaster>(entity =>
        {
            entity.HasKey(e => e.ProductId).HasName("PRIMARY");

            entity.ToTable("product_master");

            entity.HasIndex(e => e.ProductLang, "FK5ej5hub9mmbmwcchyeicda7dy");

            entity.HasIndex(e => e.ProductPublisher, "FKagkt3391ftm6b48u80ni1nv97");

            entity.HasIndex(e => e.ProductGenre, "FKbcg1vs8w9diie5m99wpa3gfh3");

            entity.HasIndex(e => e.TypeId, "FKkqx9yklv6gwn0rx53udabv5bd");

            entity.Property(e => e.ProductId).HasColumnName("product_id");
            entity.Property(e => e.ImagePath)
                .HasMaxLength(255)
                .HasColumnName("image_path");
            entity.Property(e => e.IsLibrary)
                .HasColumnType("bit(1)")
                .HasColumnName("is_library");
            entity.Property(e => e.IsRentable)
                .HasColumnType("bit(1)")
                .HasColumnName("is_rentable");
            entity.Property(e => e.MinRentDays).HasColumnName("min_rent_days");
            entity.Property(e => e.ProductAuthor)
                .HasMaxLength(255)
                .HasColumnName("product_author");
            entity.Property(e => e.ProductBasePrice).HasColumnName("product_base_price");
            entity.Property(e => e.ProductDescriptionLong)
                .HasColumnType("text")
                .HasColumnName("product_description_long");
            entity.Property(e => e.ProductDescriptionShort)
                .HasColumnType("text")
                .HasColumnName("product_description_short");
            entity.Property(e => e.ProductEnglishName)
                .HasMaxLength(255)
                .HasColumnName("product_english_name");
            entity.Property(e => e.ProductGenre).HasColumnName("product_genre");
            entity.Property(e => e.ProductLang).HasColumnName("product_lang");
            entity.Property(e => e.ProductName)
                .HasMaxLength(255)
                .HasColumnName("product_name");
            entity.Property(e => e.ProductOffPriceExpiryDate).HasColumnName("product_off_price_expiry_date");
            entity.Property(e => e.ProductOfferPrice).HasColumnName("product_offer_price");
            entity.Property(e => e.ProductPublisher).HasColumnName("product_publisher");
            entity.Property(e => e.ProductSpCost).HasColumnName("product_sp_cost");
            entity.Property(e => e.Productisbn)
                .HasMaxLength(255)
                .HasColumnName("productisbn");
            entity.Property(e => e.RentPerDay).HasColumnName("rent_per_day");
            entity.Property(e => e.TypeId).HasColumnName("type_id");

            entity.HasOne(d => d.ProductGenreNavigation).WithMany(p => p.ProductMasters)
                .HasForeignKey(d => d.ProductGenre)
                .HasConstraintName("FKbcg1vs8w9diie5m99wpa3gfh3");

            entity.HasOne(d => d.ProductLangNavigation).WithMany(p => p.ProductMasters)
                .HasForeignKey(d => d.ProductLang)
                .HasConstraintName("FK5ej5hub9mmbmwcchyeicda7dy");

            entity.HasOne(d => d.ProductPublisherNavigation).WithMany(p => p.ProductMasters)
                .HasForeignKey(d => d.ProductPublisher)
                .HasConstraintName("FKagkt3391ftm6b48u80ni1nv97");

            entity.HasOne(d => d.Type).WithMany(p => p.ProductMasters)
                .HasForeignKey(d => d.TypeId)
                .HasConstraintName("FKkqx9yklv6gwn0rx53udabv5bd");
        });

        modelBuilder.Entity<ProductTypeMaster>(entity =>
        {
            entity.HasKey(e => e.TypeId).HasName("PRIMARY");

            entity.ToTable("product_type_master");

            entity.Property(e => e.TypeId).HasColumnName("type_id");
            entity.Property(e => e.TypeDesc)
                .HasMaxLength(255)
                .HasColumnName("type_desc");
        });

        modelBuilder.Entity<PublisherMaster>(entity =>
        {
            entity.HasKey(e => e.PublisherId).HasName("PRIMARY");

            entity.ToTable("publisher_master");

            entity.Property(e => e.PublisherId).HasColumnName("publisher_id");
            entity.Property(e => e.PublisherContactNo)
                .HasMaxLength(255)
                .HasColumnName("publisher_contact_no");
            entity.Property(e => e.PublisherName)
                .HasMaxLength(255)
                .HasColumnName("publisher_name");
        });

        modelBuilder.Entity<RoyaltyCalculation>(entity =>
        {
            entity.HasKey(e => e.RoycalId).HasName("PRIMARY");

            entity.ToTable("royalty_calculation");

            entity.HasIndex(e => e.ProductId, "FKas49u6dxu8mu28ylsq0cucx1b");

            entity.HasIndex(e => e.RoyaltyId, "FKcmp8ib2op10447ilfu9fdp80p");

            entity.HasIndex(e => e.BenId, "FKrjpqmehnwed5d3l60foq44e7j");

            entity.Property(e => e.RoycalId).HasColumnName("roycal_id");
            entity.Property(e => e.BasePrice).HasColumnName("base_price");
            entity.Property(e => e.BenId).HasColumnName("ben_id");
            entity.Property(e => e.ProductId).HasColumnName("product_id");
            entity.Property(e => e.Qty).HasColumnName("qty");
            entity.Property(e => e.RoyaltyId).HasColumnName("royalty_id");
            entity.Property(e => e.RoyaltyOnBasePrice).HasColumnName("royalty_on_base_price");
            entity.Property(e => e.RoycalTrandate).HasColumnName("roycal_trandate");
            entity.Property(e => e.SalePrice).HasColumnName("sale_price");
            entity.Property(e => e.TranType)
                .HasMaxLength(255)
                .HasColumnName("tran_type");

            entity.HasOne(d => d.Ben).WithMany(p => p.RoyaltyCalculations)
                .HasForeignKey(d => d.BenId)
                .HasConstraintName("FKrjpqmehnwed5d3l60foq44e7j");

            entity.HasOne(d => d.Product).WithMany(p => p.RoyaltyCalculations)
                .HasForeignKey(d => d.ProductId)
                .HasConstraintName("FKas49u6dxu8mu28ylsq0cucx1b");

            entity.HasOne(d => d.Royalty).WithMany(p => p.RoyaltyCalculations)
                .HasForeignKey(d => d.RoyaltyId)
                .HasConstraintName("FKcmp8ib2op10447ilfu9fdp80p");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
