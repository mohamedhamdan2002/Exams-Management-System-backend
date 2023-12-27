﻿// <auto-generated />
using System;
using Domain.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Domain.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Domain.Entities.Models.Answer", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("ExamSolutionId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("QuestionId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("ExamSolutionId");

                    b.HasIndex("QuestionId");

                    b.ToTable("Answer");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Answer");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("Domain.Entities.Models.Category", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .HasMaxLength(250)
                        .HasColumnType("VARCHAR");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("VARCHAR");

                    b.HasKey("Id");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("Domain.Entities.Models.Exam", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CategoryId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Date")
                        .HasColumnType("date");

                    b.Property<TimeSpan>("Duration")
                        .HasColumnType("time");

                    b.Property<string>("Level")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("VARCHAR");

                    b.Property<string>("Term")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("VARCHAR");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("VARCHAR");

                    b.Property<decimal>("TotalMarks")
                        .HasPrecision(6, 3)
                        .HasColumnType("decimal(6,3)");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Exams", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.Models.ExamQuestion", b =>
                {
                    b.Property<Guid>("ExamId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("QuestionId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("ExamId", "QuestionId");

                    b.HasIndex("QuestionId");

                    b.ToTable("ExamQuestion");
                });

            modelBuilder.Entity("Domain.Entities.Models.ExamSolution", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("ExamId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("TotalMarks")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("ExamId");

                    b.ToTable("ExamSolutions");
                });

            modelBuilder.Entity("Domain.Entities.Models.Question", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Difficulty")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("VARCHAR");

                    b.Property<decimal>("Mark")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("VARCHAR");

                    b.HasKey("Id");

                    b.ToTable((string)null);

                    b.UseTpcMappingStrategy();
                });

            modelBuilder.Entity("Domain.Entities.Models.BooleanAnswer", b =>
                {
                    b.HasBaseType("Domain.Entities.Models.Answer");

                    b.Property<bool>("Value")
                        .HasColumnType("bit");

                    b.HasDiscriminator().HasValue("BooleanAnswer");
                });

            modelBuilder.Entity("Domain.Entities.Models.ChoiceAnswer", b =>
                {
                    b.HasBaseType("Domain.Entities.Models.Answer");

                    b.Property<string>("Choice")
                        .IsRequired()
                        .HasColumnType("nvarchar(1)");

                    b.HasDiscriminator().HasValue("ChoiceAnswer");
                });

            modelBuilder.Entity("Domain.Entities.Models.MultipleChocieQuestion", b =>
                {
                    b.HasBaseType("Domain.Entities.Models.Question");

                    b.Property<string>("CorrectChoice")
                        .IsRequired()
                        .HasColumnType("nvarchar(1)");

                    b.Property<string>("OptionA")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OptionB")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OptionC")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OptionD")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.ToTable("MultipleChocieQuestions");
                });

            modelBuilder.Entity("Domain.Entities.Models.TrueAndFalseQuestion", b =>
                {
                    b.HasBaseType("Domain.Entities.Models.Question");

                    b.Property<bool>("CorrectAnswer")
                        .HasColumnType("bit");

                    b.ToTable("TrueAndFalseQuestions");
                });

            modelBuilder.Entity("Domain.Entities.Models.Answer", b =>
                {
                    b.HasOne("Domain.Entities.Models.ExamSolution", null)
                        .WithMany("Answers")
                        .HasForeignKey("ExamSolutionId");

                    b.HasOne("Domain.Entities.Models.Question", "Question")
                        .WithMany()
                        .HasForeignKey("QuestionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Question");
                });

            modelBuilder.Entity("Domain.Entities.Models.Exam", b =>
                {
                    b.HasOne("Domain.Entities.Models.Category", "Category")
                        .WithMany("Exams")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("Domain.Entities.Models.ExamQuestion", b =>
                {
                    b.HasOne("Domain.Entities.Models.Exam", "Exam")
                        .WithMany("Questions")
                        .HasForeignKey("ExamId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.Models.Question", "Question")
                        .WithMany("Exams")
                        .HasForeignKey("QuestionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Exam");

                    b.Navigation("Question");
                });

            modelBuilder.Entity("Domain.Entities.Models.ExamSolution", b =>
                {
                    b.HasOne("Domain.Entities.Models.Exam", "Exam")
                        .WithMany("Solutions")
                        .HasForeignKey("ExamId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Exam");
                });

            modelBuilder.Entity("Domain.Entities.Models.Category", b =>
                {
                    b.Navigation("Exams");
                });

            modelBuilder.Entity("Domain.Entities.Models.Exam", b =>
                {
                    b.Navigation("Questions");

                    b.Navigation("Solutions");
                });

            modelBuilder.Entity("Domain.Entities.Models.ExamSolution", b =>
                {
                    b.Navigation("Answers");
                });

            modelBuilder.Entity("Domain.Entities.Models.Question", b =>
                {
                    b.Navigation("Exams");
                });
#pragma warning restore 612, 618
        }
    }
}
