﻿// <auto-generated />
using System;
using Infracstructures;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Infracstructures.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.20")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Domain.Models.Account", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("NEWID()");

                    b.Property<string>("Address")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(max)")
                        .HasDefaultValue("");

                    b.Property<string>("Avatar")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Birthday")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("CreatedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)")
                        .HasDefaultValue("");

                    b.Property<bool>("Gender")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.Property<Guid?>("GuardianId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Phone")
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("RefreshToken")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Status")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(max)")
                        .HasDefaultValue("False");

                    b.Property<Guid?>("UpdatedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("UpdatedTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.HasIndex("GuardianId");

                    b.ToTable("Account", (string)null);
                });

            modelBuilder.Entity("Domain.Models.Award", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("NEWID()");

                    b.Property<string>("Artifact")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double?>("Cash")
                        .HasColumnType("float");

                    b.Property<Guid?>("CreatedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("EducationalLevelId")
                        .IsRequired()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<string>("Rank")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Status")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(max)")
                        .HasDefaultValue("False");

                    b.Property<Guid?>("UpdatedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("UpdatedTime")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("EducationalLevelId");

                    b.ToTable("Award", (string)null);
                });

            modelBuilder.Entity("Domain.Models.AwardSchedule", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("NEWID()");

                    b.Property<Guid?>("AwardId")
                        .IsRequired()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("CreatedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<Guid?>("ScheduleId")
                        .IsRequired()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Status")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(max)")
                        .HasDefaultValue("False");

                    b.Property<Guid?>("UpdatedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("UpdatedTime")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("AwardId");

                    b.HasIndex("ScheduleId");

                    b.ToTable("AwardSchedule", (string)null);
                });

            modelBuilder.Entity("Domain.Models.Collection", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("NEWID()");

                    b.Property<Guid?>("AccountId")
                        .IsRequired()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("CreatedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Image")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Status")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(max)")
                        .HasDefaultValue("False");

                    b.Property<Guid?>("UpdatedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("UpdatedTime")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("AccountId");

                    b.ToTable("Collection", (string)null);
                });

            modelBuilder.Entity("Domain.Models.Contest", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("NEWID()");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("CreatedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("EndTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("StaffId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("StartTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Status")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(max)")
                        .HasDefaultValue("False");

                    b.Property<Guid?>("UpdatedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("UpdatedTime")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("StaffId");

                    b.ToTable("Contest", (string)null);
                });

            modelBuilder.Entity("Domain.Models.EducationalLevel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("NEWID()");

                    b.Property<Guid?>("ContestId")
                        .IsRequired()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("CreatedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EducationLevel")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("EndTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("StartTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Status")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(max)")
                        .HasDefaultValue("False");

                    b.Property<Guid?>("UpdatedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("UpdatedTime")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("ContestId");

                    b.ToTable("EducationalLevel", (string)null);
                });

            modelBuilder.Entity("Domain.Models.Image", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("NEWID()");

                    b.Property<Guid?>("CreatedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("PostId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Status")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(max)")
                        .HasDefaultValue("False");

                    b.Property<Guid?>("UpdatedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("UpdatedTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("PostId");

                    b.ToTable("Image", (string)null);
                });

            modelBuilder.Entity("Domain.Models.Notification", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("NEWID()");

                    b.Property<Guid?>("AccountId")
                        .IsRequired()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("CreatedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedTime")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsReaded")
                        .HasColumnType("bit");

                    b.Property<string>("Message")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Status")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(max)")
                        .HasDefaultValue("False");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("UpdatedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("UpdatedTime")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("AccountId");

                    b.ToTable("Notification", (string)null);
                });

            modelBuilder.Entity("Domain.Models.Painting", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("NEWID()");

                    b.Property<Guid>("AccountId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("AwardId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Code")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("CreatedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("FinalDecisionTimestamp")
                        .HasColumnType("datetime2");

                    b.Property<string>("Image")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("ReviewedTimestamp")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("RoundId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("ScheduleId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("SubmittedTimestamp")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("TopicId")
                        .IsRequired()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("UpdatedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("UpdatedTime")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("AccountId");

                    b.HasIndex("AwardId");

                    b.HasIndex("RoundId");

                    b.HasIndex("ScheduleId");

                    b.HasIndex("TopicId");

                    b.ToTable("Painting", (string)null);
                });

            modelBuilder.Entity("Domain.Models.PaintingCollection", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("NEWID()");

                    b.Property<Guid?>("CollectionId")
                        .IsRequired()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("PaintingId")
                        .IsRequired()
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("CollectionId");

                    b.HasIndex("PaintingId");

                    b.ToTable("PaintingCollection", (string)null);
                });

            modelBuilder.Entity("Domain.Models.Post", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("NEWID()");

                    b.Property<Guid?>("CreatedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("StaffId")
                        .IsRequired()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Status")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(max)")
                        .HasDefaultValue("False");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("UpdatedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("UpdatedTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Url")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("StaffId");

                    b.ToTable("Post", (string)null);
                });

            modelBuilder.Entity("Domain.Models.Resources", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("NEWID()");

                    b.Property<string>("Artifact")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Cash")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("ContestId")
                        .IsRequired()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("CreatedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedTime")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("SponsorId")
                        .IsRequired()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Status")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(max)")
                        .HasDefaultValue("False");

                    b.Property<Guid?>("UpdatedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("UpdatedTime")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("ContestId");

                    b.HasIndex("SponsorId");

                    b.ToTable("Resources", (string)null);
                });

            modelBuilder.Entity("Domain.Models.Round", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("NEWID()");

                    b.Property<Guid?>("CreatedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("EducationalLevelId")
                        .IsRequired()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("EndTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("StartTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Status")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(max)")
                        .HasDefaultValue("False");

                    b.Property<Guid?>("UpdatedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("UpdatedTime")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("EducationalLevelId");

                    b.ToTable("Round", (string)null);
                });

            modelBuilder.Entity("Domain.Models.Schedule", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("NEWID()");

                    b.Property<Guid?>("CreatedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("ExaminerId")
                        .IsRequired()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("RoundId")
                        .IsRequired()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Status")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(max)")
                        .HasDefaultValue("False");

                    b.Property<Guid?>("UpdatedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("UpdatedTime")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("ExaminerId");

                    b.HasIndex("RoundId");

                    b.ToTable("Schedule", (string)null);
                });

            modelBuilder.Entity("Domain.Models.Sponsor", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("NEWID()");

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("CreatedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Delegate")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Status")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(max)")
                        .HasDefaultValue("False");

                    b.Property<Guid?>("UpdatedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("UpdatedTime")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Sponsor", (string)null);
                });

            modelBuilder.Entity("Domain.Models.Topic", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("NEWID()");

                    b.Property<Guid?>("CreatedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Image")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("RoundId")
                        .IsRequired()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Status")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(max)")
                        .HasDefaultValue("False");

                    b.Property<Guid?>("UpdatedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("UpdatedTime")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("RoundId");

                    b.ToTable("Topic", (string)null);
                });

            modelBuilder.Entity("Domain.Models.Account", b =>
                {
                    b.HasOne("Domain.Models.Account", "Guardian")
                        .WithMany("SubAccounts")
                        .HasForeignKey("GuardianId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("Guardian");
                });

            modelBuilder.Entity("Domain.Models.Award", b =>
                {
                    b.HasOne("Domain.Models.EducationalLevel", "EducationalLevel")
                        .WithMany("Award")
                        .HasForeignKey("EducationalLevelId")
                        .IsRequired();

                    b.Navigation("EducationalLevel");
                });

            modelBuilder.Entity("Domain.Models.AwardSchedule", b =>
                {
                    b.HasOne("Domain.Models.Award", "Award")
                        .WithMany("AwardSchedule")
                        .HasForeignKey("AwardId")
                        .IsRequired();

                    b.HasOne("Domain.Models.Schedule", "Schedule")
                        .WithMany("AwardSchedule")
                        .HasForeignKey("ScheduleId")
                        .IsRequired();

                    b.Navigation("Award");

                    b.Navigation("Schedule");
                });

            modelBuilder.Entity("Domain.Models.Collection", b =>
                {
                    b.HasOne("Domain.Models.Account", "Account")
                        .WithMany("Collection")
                        .HasForeignKey("AccountId")
                        .IsRequired();

                    b.Navigation("Account");
                });

            modelBuilder.Entity("Domain.Models.Contest", b =>
                {
                    b.HasOne("Domain.Models.Account", "Account")
                        .WithMany("CreateContest")
                        .HasForeignKey("StaffId")
                        .IsRequired();

                    b.Navigation("Account");
                });

            modelBuilder.Entity("Domain.Models.EducationalLevel", b =>
                {
                    b.HasOne("Domain.Models.Contest", "Contest")
                        .WithMany("EducationalLevel")
                        .HasForeignKey("ContestId")
                        .IsRequired();

                    b.Navigation("Contest");
                });

            modelBuilder.Entity("Domain.Models.Image", b =>
                {
                    b.HasOne("Domain.Models.Post", "Post")
                        .WithMany("Images")
                        .HasForeignKey("PostId")
                        .IsRequired();

                    b.Navigation("Post");
                });

            modelBuilder.Entity("Domain.Models.Notification", b =>
                {
                    b.HasOne("Domain.Models.Account", "Account")
                        .WithMany("Notifications")
                        .HasForeignKey("AccountId")
                        .IsRequired();

                    b.Navigation("Account");
                });

            modelBuilder.Entity("Domain.Models.Painting", b =>
                {
                    b.HasOne("Domain.Models.Account", "Account")
                        .WithMany("Painting")
                        .HasForeignKey("AccountId")
                        .IsRequired();

                    b.HasOne("Domain.Models.Award", "Award")
                        .WithMany("Painting")
                        .HasForeignKey("AwardId");

                    b.HasOne("Domain.Models.Round", "Round")
                        .WithMany("Painting")
                        .HasForeignKey("RoundId")
                        .IsRequired();

                    b.HasOne("Domain.Models.Schedule", "Schedule")
                        .WithMany("Painting")
                        .HasForeignKey("ScheduleId");

                    b.HasOne("Domain.Models.Topic", "Topic")
                        .WithMany()
                        .HasForeignKey("TopicId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Account");

                    b.Navigation("Award");

                    b.Navigation("Round");

                    b.Navigation("Schedule");

                    b.Navigation("Topic");
                });

            modelBuilder.Entity("Domain.Models.PaintingCollection", b =>
                {
                    b.HasOne("Domain.Models.Collection", "Collection")
                        .WithMany("PaintingCollection")
                        .HasForeignKey("CollectionId")
                        .IsRequired();

                    b.HasOne("Domain.Models.Painting", "Painting")
                        .WithMany("PaintingCollection")
                        .HasForeignKey("PaintingId")
                        .IsRequired();

                    b.Navigation("Collection");

                    b.Navigation("Painting");
                });

            modelBuilder.Entity("Domain.Models.Post", b =>
                {
                    b.HasOne("Domain.Models.Account", "Account")
                        .WithMany("Post")
                        .HasForeignKey("StaffId")
                        .IsRequired();

                    b.Navigation("Account");
                });

            modelBuilder.Entity("Domain.Models.Resources", b =>
                {
                    b.HasOne("Domain.Models.Contest", "Contest")
                        .WithMany("Resources")
                        .HasForeignKey("ContestId")
                        .IsRequired();

                    b.HasOne("Domain.Models.Sponsor", "Sponsor")
                        .WithMany("Resources")
                        .HasForeignKey("SponsorId")
                        .IsRequired();

                    b.Navigation("Contest");

                    b.Navigation("Sponsor");
                });

            modelBuilder.Entity("Domain.Models.Round", b =>
                {
                    b.HasOne("Domain.Models.EducationalLevel", "EducationalLevel")
                        .WithMany("Round")
                        .HasForeignKey("EducationalLevelId")
                        .IsRequired();

                    b.Navigation("EducationalLevel");
                });

            modelBuilder.Entity("Domain.Models.Schedule", b =>
                {
                    b.HasOne("Domain.Models.Account", "Account")
                        .WithMany("Schedule")
                        .HasForeignKey("ExaminerId")
                        .IsRequired();

                    b.HasOne("Domain.Models.Round", "Round")
                        .WithMany("Schedule")
                        .HasForeignKey("RoundId")
                        .IsRequired();

                    b.Navigation("Account");

                    b.Navigation("Round");
                });

            modelBuilder.Entity("Domain.Models.Topic", b =>
                {
                    b.HasOne("Domain.Models.Round", "Round")
                        .WithMany("Topic")
                        .HasForeignKey("RoundId")
                        .IsRequired();

                    b.Navigation("Round");
                });

            modelBuilder.Entity("Domain.Models.Account", b =>
                {
                    b.Navigation("Collection");

                    b.Navigation("CreateContest");

                    b.Navigation("Notifications");

                    b.Navigation("Painting");

                    b.Navigation("Post");

                    b.Navigation("Schedule");

                    b.Navigation("SubAccounts");
                });

            modelBuilder.Entity("Domain.Models.Award", b =>
                {
                    b.Navigation("AwardSchedule");

                    b.Navigation("Painting");
                });

            modelBuilder.Entity("Domain.Models.Collection", b =>
                {
                    b.Navigation("PaintingCollection");
                });

            modelBuilder.Entity("Domain.Models.Contest", b =>
                {
                    b.Navigation("EducationalLevel");

                    b.Navigation("Resources");
                });

            modelBuilder.Entity("Domain.Models.EducationalLevel", b =>
                {
                    b.Navigation("Award");

                    b.Navigation("Round");
                });

            modelBuilder.Entity("Domain.Models.Painting", b =>
                {
                    b.Navigation("PaintingCollection");
                });

            modelBuilder.Entity("Domain.Models.Post", b =>
                {
                    b.Navigation("Images");
                });

            modelBuilder.Entity("Domain.Models.Round", b =>
                {
                    b.Navigation("Painting");

                    b.Navigation("Schedule");

                    b.Navigation("Topic");
                });

            modelBuilder.Entity("Domain.Models.Schedule", b =>
                {
                    b.Navigation("AwardSchedule");

                    b.Navigation("Painting");
                });

            modelBuilder.Entity("Domain.Models.Sponsor", b =>
                {
                    b.Navigation("Resources");
                });
#pragma warning restore 612, 618
        }
    }
}
