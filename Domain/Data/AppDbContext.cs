using Domain.Entities.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Data
{
    public class AppDbContext : IdentityDbContext<User>
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Exam> Exams { get; set; }
        //public DbSet<MultipleChoiceQuestion> MultipleChocieQuestions { get; set; }
        //public DbSet<TrueAndFalseQuestion> TrueAndFalseQuestions { get; set; }
        public DbSet<Question> Questions => Set<Question>();
        public DbSet<ExamSolution> ExamSolutions { get; set; }
        public DbSet<ExamQuestion> ExamQuestions { get; set; }
        //public DbSet<ChoiceAnswer> ChoiceAnswers { get; set; }
        //public DbSet<BooleanAnswer> BooleanAnswers { get; set; }
        public DbSet<Answer> Answers => Set<Answer>();
        public AppDbContext(DbContextOptions<AppDbContext> options) 
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
        }
    }
}
