

namespace Capital.Program.Infrastructure.Database
{
    public class CapitalProgramDbContext : DbContext
    {
        public CapitalProgramDbContext(DbContextOptions<CapitalProgramDbContext> options) : base(options)
        { }

        public DbSet<EmployerProgram> EmployerPrograms { get; set; }
        public DbSet<UserProfile> UserProfiles { get; set; }
        public DbSet<QuestionType> QuestionTypes { get; set; }
        public DbSet<MultipleChoiceQuestion> MultipleChoiceQuestions { get; set; }
        public DbSet<YesNoQuestion> YesNoQuestions { get; set; }
        public DbSet<NumericQuestion> NumericQuestions { get; set; }
        public DbSet<ParagraphQuestion> ParagraphQuestions { get; set; }
        public DbSet<DateQuestion> DateQuestions { get; set; }
        public DbSet<DropDownQuestion> DropDownQuestions { get; set; }
        public DbSet<QuestionAnswer> QuestionAnswers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region EmployerPrograms
            modelBuilder.Entity<EmployerProgram>().ToContainer("EmployerPrograms").HasNoDiscriminator();
            modelBuilder.Entity<EmployerProgram>().Property(e => e.Id);
            modelBuilder.Entity<EmployerProgram>().Property(e => e.Id).ToJsonProperty("id");
            #endregion

            #region UserProfile
            modelBuilder.Entity<UserProfile>().ToContainer("UserProfiles").HasNoDiscriminator();
            modelBuilder.Entity<UserProfile>().Property(e => e.Id);
            modelBuilder.Entity<UserProfile>().Property(e => e.Id).ToJsonProperty("id");
            #endregion

            #region QuestionType
            modelBuilder.Entity<QuestionType>().ToContainer("QuestionTypes").HasNoDiscriminator();
            modelBuilder.Entity<QuestionType>().Property(e => e.Id);
            modelBuilder.Entity<QuestionType>().Property(e => e.Id).ToJsonProperty("id");
            #endregion

            #region MultipleChoice
            modelBuilder.Entity<MultipleChoiceQuestion>().ToContainer("MultipleChoiceQuestions").HasNoDiscriminator();
            modelBuilder.Entity<MultipleChoiceQuestion>().Property(e => e.Id);
            modelBuilder.Entity<MultipleChoiceQuestion>().Property(e => e.Id).ToJsonProperty("id");
            #endregion

            #region DropDownQuestion
            modelBuilder.Entity<DropDownQuestion>().ToContainer("DropDownQuestions").HasNoDiscriminator();
            modelBuilder.Entity<DropDownQuestion>().Property(e => e.Id);
            modelBuilder.Entity<DropDownQuestion>().Property(e => e.Id).ToJsonProperty("id");
            #endregion

            #region ParagraphQuestion
            modelBuilder.Entity<ParagraphQuestion>().ToContainer("ParagraphQuestions").HasNoDiscriminator();
            modelBuilder.Entity<ParagraphQuestion>().Property(e => e.Id);
            modelBuilder.Entity<ParagraphQuestion>().Property(e => e.Id).ToJsonProperty("id");
            #endregion

            #region YesNoQuestion
            modelBuilder.Entity<YesNoQuestion>().ToContainer("YesNoQuestions").HasNoDiscriminator();
            modelBuilder.Entity<YesNoQuestion>().Property(e => e.Id);
            modelBuilder.Entity<YesNoQuestion>().Property(e => e.Id).ToJsonProperty("id");
            #endregion

            #region NumericQuestion
            modelBuilder.Entity<NumericQuestion>().ToContainer("NumericQuestions").HasNoDiscriminator();
            modelBuilder.Entity<NumericQuestion>().Property(e => e.Id);
            modelBuilder.Entity<NumericQuestion>().Property(e => e.Id).ToJsonProperty("id");
            #endregion

            #region DateQuestion
            modelBuilder.Entity<DateQuestion>().ToContainer("DateQuestions").HasNoDiscriminator();
            modelBuilder.Entity<DateQuestion>().Property(e => e.Id);
            modelBuilder.Entity<DateQuestion>().Property(e => e.Id).ToJsonProperty("id");
            #endregion

            #region QuestionAnswer
            modelBuilder.Entity<QuestionAnswer>().ToContainer("QuestionAnswers").HasNoDiscriminator();
            modelBuilder.Entity<QuestionAnswer>().Property(e => e.Id);
            modelBuilder.Entity<QuestionAnswer>().Property(e => e.Id).ToJsonProperty("id");
            #endregion


            #region Relationships
            modelBuilder.Entity<EmployerProgram>().HasMany(e => e.UserProfiles).WithOne(e => e.EmployerProgram)
                .HasForeignKey(e => e.EmployerProgramId);
            modelBuilder.Entity<MultipleChoiceQuestion>().HasOne(e => e.EmployerProgram).WithOne(e => e.MultipleChoiceQuestion)
                .HasForeignKey<MultipleChoiceQuestion>(e => e.EmployerProgramId);
            modelBuilder.Entity<DropDownQuestion>().HasOne(e => e.EmployerProgram).WithOne(e => e.DropDownQuestion)
               .HasForeignKey<DropDownQuestion>(e => e.EmployerProgramId);
            modelBuilder.Entity<ParagraphQuestion>().HasOne(e => e.EmployerProgram).WithOne(e => e.ParagraphQuestion)
               .HasForeignKey<ParagraphQuestion>(e => e.EmployerProgramId);
            modelBuilder.Entity<YesNoQuestion>().HasOne(e => e.EmployerProgram).WithOne(e => e.YesNoQuestion)
               .HasForeignKey<YesNoQuestion>(e => e.EmployerProgramId);
            modelBuilder.Entity<NumericQuestion>().HasOne(e => e.EmployerProgram).WithOne(e => e.NumericQuestion)
               .HasForeignKey<NumericQuestion>(e => e.EmployerProgramId);
            modelBuilder.Entity<DateQuestion>().HasOne(e => e.EmployerProgram).WithOne(e => e.DateQuestion)
               .HasForeignKey<DateQuestion>(e => e.EmployerProgramId);
            modelBuilder.Entity<QuestionAnswer>().HasOne(e => e.EmployerProgram).WithMany(e => e.QuestionAnswers)
               .HasForeignKey(e => e.EmployerProgramId);
            modelBuilder.Entity<QuestionAnswer>().HasOne(e => e.UserProfile).WithMany(e => e.QuestionAnswers)
               .HasForeignKey(e => e.UserProfileId);
            #endregion
        }

        //public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        //{

        //    return base.SaveChangesAsync(cancellationToken);
        //}
    }
}
