using System;
using System.Collections.Generic;
using BusinessObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace DataAccessLayer;

public partial class DrugFreeSystemDbContext : DbContext
{
    public DrugFreeSystemDbContext()
    {
    }

    public DrugFreeSystemDbContext(DbContextOptions<DrugFreeSystemDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Course> Courses { get; set; }

    public virtual DbSet<CourseCertificate> CourseCertificates { get; set; }

    public virtual DbSet<Lesson> Lessons { get; set; }

    public virtual DbSet<LessonResource> LessonResources { get; set; }

    public virtual DbSet<PracticeExercise> PracticeExercises { get; set; }

    public virtual DbSet<Quiz> Quizzes { get; set; }

    public virtual DbSet<QuizOption> QuizOptions { get; set; }

    public virtual DbSet<QuizQuestion> QuizQuestions { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<Survey> Surveys { get; set; }

    public virtual DbSet<SurveyOption> SurveyOptions { get; set; }

    public virtual DbSet<SurveyQuestion> SurveyQuestions { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<UserCourseEnrollment> UserCourseEnrollments { get; set; }

    public virtual DbSet<UserLessonProgress> UserLessonProgresses { get; set; }

    public virtual DbSet<UserModuleQuizResult> UserModuleQuizResults { get; set; }

    public virtual DbSet<UserQuizAnswer> UserQuizAnswers { get; set; }

    public virtual DbSet<UserSurveyAnswer> UserSurveyAnswers { get; set; }

    public virtual DbSet<UserSurveyResponse> UserSurveyResponses { get; set; }

    private string GetConnectionString()
    {
        IConfiguration configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", true, true).Build();
        return configuration["ConnectionStrings:DefaultConnectionString"];
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(GetConnectionString());
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Course>(entity =>
        {
            entity.HasKey(e => e.CourseId).HasName("PK__courses__8F1EF7AE9703E959");

            entity.ToTable("courses");

            entity.Property(e => e.CourseId)
                .ValueGeneratedNever()
                .HasColumnName("course_id");
            entity.Property(e => e.AgeGroup)
                .HasMaxLength(100)
                .HasColumnName("age_group");
            entity.Property(e => e.CertificateAvailable).HasColumnName("certificate_available");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.IsActive)
                .HasDefaultValue(true)
                .HasColumnName("is_active");
            entity.Property(e => e.LessonCount).HasColumnName("lesson_count");
            entity.Property(e => e.Requirements).HasColumnName("requirements");
            entity.Property(e => e.StudentCount).HasColumnName("student_count");
            entity.Property(e => e.ThumbnailUrl)
                .HasMaxLength(1000)
                .HasColumnName("thumbnail_url");
            entity.Property(e => e.Title)
                .HasMaxLength(500)
                .HasColumnName("title");
            entity.Property(e => e.TotalDuration).HasColumnName("total_duration");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("datetime")
                .HasColumnName("updated_at");
        });

        modelBuilder.Entity<CourseCertificate>(entity =>
        {
            entity.HasKey(e => e.CertificateId).HasName("PK__course_c__E2256D31C6815E6B");

            entity.ToTable("course_certificates");

            entity.Property(e => e.CertificateId)
                .ValueGeneratedNever()
                .HasColumnName("certificate_id");
            entity.Property(e => e.CertificateUrl)
                .HasMaxLength(500)
                .HasColumnName("certificate_url");
            entity.Property(e => e.CourseId).HasColumnName("course_id");
            entity.Property(e => e.IssuedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("issued_at");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.Course).WithMany(p => p.CourseCertificates)
                .HasForeignKey(d => d.CourseId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_course_certificates_courses");

            entity.HasOne(d => d.User).WithMany(p => p.CourseCertificates)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_course_certificates_users");
        });

        modelBuilder.Entity<Lesson>(entity =>
        {
            entity.HasKey(e => e.LessonId).HasName("PK__lessons__6421F7BEA6831488");

            entity.ToTable("lessons");

            entity.Property(e => e.LessonId)
                .ValueGeneratedNever()
                .HasColumnName("lesson_id");
            entity.Property(e => e.Content).HasColumnName("content");
            entity.Property(e => e.CourseId).HasColumnName("course_id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.DurationMinutes).HasColumnName("duration_minutes");
            entity.Property(e => e.HasPractice).HasColumnName("has_practice");
            entity.Property(e => e.HasQuiz).HasColumnName("has_quiz");
            entity.Property(e => e.Sequence).HasColumnName("sequence");
            entity.Property(e => e.Title)
                .HasMaxLength(255)
                .HasColumnName("title");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("datetime")
                .HasColumnName("updated_at");

            entity.HasOne(d => d.Course).WithMany(p => p.Lessons)
                .HasForeignKey(d => d.CourseId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_lessons_course");
        });

        modelBuilder.Entity<LessonResource>(entity =>
        {
            entity.HasKey(e => e.ResourceId).HasName("PK__lesson_r__4985FC7360868932");

            entity.ToTable("lesson_resources");

            entity.Property(e => e.ResourceId)
                .ValueGeneratedNever()
                .HasColumnName("resource_id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.LessonId).HasColumnName("lesson_id");
            entity.Property(e => e.ResourceType)
                .HasMaxLength(50)
                .HasColumnName("resource_type");
            entity.Property(e => e.ResourceUrl)
                .HasMaxLength(500)
                .HasColumnName("resource_url");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("datetime")
                .HasColumnName("updated_at");

            entity.HasOne(d => d.Lesson).WithMany(p => p.LessonResources)
                .HasForeignKey(d => d.LessonId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_lesson_resources_lesson");
        });

        modelBuilder.Entity<PracticeExercise>(entity =>
        {
            entity.HasKey(e => e.ExerciseId).HasName("PK__practice__C121418E9871FD0D");

            entity.ToTable("practice_exercises");

            entity.Property(e => e.ExerciseId)
                .ValueGeneratedNever()
                .HasColumnName("exercise_id");
            entity.Property(e => e.AttachmentUrl)
                .HasMaxLength(500)
                .HasColumnName("attachment_url");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.Instruction).HasColumnName("instruction");
            entity.Property(e => e.LessonId).HasColumnName("lesson_id");

            entity.HasOne(d => d.Lesson).WithMany(p => p.PracticeExercises)
                .HasForeignKey(d => d.LessonId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_practice_exercises_lesson");
        });

        modelBuilder.Entity<Quiz>(entity =>
        {
            entity.HasKey(e => e.QuizId).HasName("PK__quizzes__2D7053EC34D11E07");

            entity.ToTable("quizzes");

            entity.HasIndex(e => e.LessonId, "UQ__quizzes__6421F7BF14D4CBF6").IsUnique();

            entity.Property(e => e.QuizId)
                .ValueGeneratedNever()
                .HasColumnName("quiz_id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.LessonId).HasColumnName("lesson_id");
            entity.Property(e => e.PassingScore).HasColumnName("passing_score");
            entity.Property(e => e.Title)
                .HasMaxLength(255)
                .HasColumnName("title");

            entity.HasOne(d => d.Lesson).WithOne(p => p.Quiz)
                .HasForeignKey<Quiz>(d => d.LessonId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_quizzes_lessons");
        });

        modelBuilder.Entity<QuizOption>(entity =>
        {
            entity.HasKey(e => e.OptionId).HasName("PK__quiz_opt__F4EACE1BDF412636");

            entity.ToTable("quiz_options");

            entity.Property(e => e.OptionId)
                .ValueGeneratedNever()
                .HasColumnName("option_id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.IsCorrect).HasColumnName("is_correct");
            entity.Property(e => e.OptionText).HasColumnName("option_text");
            entity.Property(e => e.QuestionId).HasColumnName("question_id");

            entity.HasOne(d => d.Question).WithMany(p => p.QuizOptions)
                .HasForeignKey(d => d.QuestionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_quiz_options_questions");
        });

        modelBuilder.Entity<QuizQuestion>(entity =>
        {
            entity.HasKey(e => e.QuestionId).HasName("PK__quiz_que__2EC2154947C0A017");

            entity.ToTable("quiz_questions");

            entity.Property(e => e.QuestionId)
                .ValueGeneratedNever()
                .HasColumnName("question_id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.QuestionText).HasColumnName("question_text");
            entity.Property(e => e.QuestionType)
                .HasMaxLength(50)
                .HasColumnName("question_type");
            entity.Property(e => e.QuizId).HasColumnName("quiz_id");
            entity.Property(e => e.Sequence).HasColumnName("sequence");

            entity.HasOne(d => d.Quiz).WithMany(p => p.QuizQuestions)
                .HasForeignKey(d => d.QuizId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_quiz_questions_quizzes");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.RoleId).HasName("PK__roles__760965CC1F4D4402");

            entity.ToTable("roles");

            entity.Property(e => e.RoleId)
                .ValueGeneratedNever()
                .HasColumnName("role_id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.Description)
                .HasMaxLength(200)
                .HasColumnName("description");
            entity.Property(e => e.IsActive)
                .HasDefaultValue(true)
                .HasColumnName("is_active");
            entity.Property(e => e.RoleName)
                .HasMaxLength(50)
                .HasColumnName("role_name");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("datetime")
                .HasColumnName("updated_at");
        });

        modelBuilder.Entity<Survey>(entity =>
        {
            entity.HasKey(e => e.SurveyId).HasName("PK__surveys__9DC31A07C8927044");

            entity.ToTable("surveys");

            entity.Property(e => e.SurveyId)
                .ValueGeneratedNever()
                .HasColumnName("survey_id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.EstimatedDuration)
                .HasMaxLength(50)
                .HasColumnName("estimated_duration");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("name");
            entity.Property(e => e.TargetAudience)
                .HasMaxLength(255)
                .HasColumnName("target_audience");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("datetime")
                .HasColumnName("updated_at");
        });

        modelBuilder.Entity<SurveyOption>(entity =>
        {
            entity.HasKey(e => e.OptionId).HasName("PK__survey_o__F4EACE1BCA43F941");

            entity.ToTable("survey_options");

            entity.Property(e => e.OptionId)
                .ValueGeneratedNever()
                .HasColumnName("option_id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.OptionText)
                .HasMaxLength(500)
                .HasColumnName("option_text");
            entity.Property(e => e.QuestionId).HasColumnName("question_id");
            entity.Property(e => e.ScoreValue).HasColumnName("score_value");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("datetime")
                .HasColumnName("updated_at");

            entity.HasOne(d => d.Question).WithMany(p => p.SurveyOptions)
                .HasForeignKey(d => d.QuestionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_survey_options_questions");
        });

        modelBuilder.Entity<SurveyQuestion>(entity =>
        {
            entity.HasKey(e => e.QuestionId).HasName("PK__survey_q__2EC21549B3E020D7");

            entity.ToTable("survey_questions");

            entity.Property(e => e.QuestionId)
                .ValueGeneratedNever()
                .HasColumnName("question_id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.QuestionText).HasColumnName("question_text");
            entity.Property(e => e.QuestionType)
                .HasMaxLength(50)
                .HasColumnName("question_type");
            entity.Property(e => e.Sequence).HasColumnName("sequence");
            entity.Property(e => e.SurveyId).HasColumnName("survey_id");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("datetime")
                .HasColumnName("updated_at");

            entity.HasOne(d => d.Survey).WithMany(p => p.SurveyQuestions)
                .HasForeignKey(d => d.SurveyId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_survey_questions_surveys");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__users__B9BE370F5A607F53");

            entity.ToTable("users");

            entity.Property(e => e.UserId)
                .ValueGeneratedNever()
                .HasColumnName("user_id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .HasColumnName("email");
            entity.Property(e => e.EmailVerified).HasColumnName("email_verified");
            entity.Property(e => e.IsActive)
                .HasDefaultValue(true)
                .HasColumnName("is_active");
            entity.Property(e => e.Password)
                .HasMaxLength(255)
                .HasColumnName("password");
            entity.Property(e => e.RoleId).HasColumnName("role_id");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("datetime")
                .HasColumnName("updated_at");
            entity.Property(e => e.Username)
                .HasMaxLength(100)
                .HasColumnName("username");

            entity.HasOne(d => d.Role).WithMany(p => p.Users)
                .HasForeignKey(d => d.RoleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_users_roles");
        });

        modelBuilder.Entity<UserCourseEnrollment>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__user_cou__3213E83F2BFC718A");

            entity.ToTable("user_course_enrollments");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.CompletedAt)
                .HasColumnType("datetime")
                .HasColumnName("completed_at");
            entity.Property(e => e.CourseId).HasColumnName("course_id");
            entity.Property(e => e.EnrolledAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("enrolled_at");
            entity.Property(e => e.Status)
                .HasMaxLength(50)
                .HasDefaultValue("NotStarted")
                .HasColumnName("status");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("datetime")
                .HasColumnName("updated_at");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.Course).WithMany(p => p.UserCourseEnrollments)
                .HasForeignKey(d => d.CourseId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_user_course_enrollments_courses");

            entity.HasOne(d => d.User).WithMany(p => p.UserCourseEnrollments)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_user_course_enrollments_users");
        });

        modelBuilder.Entity<UserLessonProgress>(entity =>
        {
            entity.HasKey(e => e.ProgressId).HasName("PK__user_les__49B3D8C1530C1F99");

            entity.ToTable("user_lesson_progress");

            entity.Property(e => e.ProgressId)
                .ValueGeneratedNever()
                .HasColumnName("progress_id");
            entity.Property(e => e.CompletedAt)
                .HasColumnType("datetime")
                .HasColumnName("completed_at");
            entity.Property(e => e.LessonId).HasColumnName("lesson_id");
            entity.Property(e => e.Passed).HasColumnName("passed");
            entity.Property(e => e.QuizScore).HasColumnName("quiz_score");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("updated_at");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.Lesson).WithMany(p => p.UserLessonProgresses)
                .HasForeignKey(d => d.LessonId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_user_lesson_progress_lessons");

            entity.HasOne(d => d.User).WithMany(p => p.UserLessonProgresses)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_user_lesson_progress_users");
        });

        modelBuilder.Entity<UserModuleQuizResult>(entity =>
        {
            entity.HasKey(e => e.ResultId).HasName("PK__user_mod__AFB3C3164E09E8A7");

            entity.ToTable("user_module_quiz_result");

            entity.Property(e => e.ResultId)
                .ValueGeneratedNever()
                .HasColumnName("result_id");
            entity.Property(e => e.CorrectCount).HasColumnName("correct_count");
            entity.Property(e => e.LessonId).HasColumnName("lesson_id");
            entity.Property(e => e.Status)
                .HasMaxLength(50)
                .HasColumnName("status");
            entity.Property(e => e.TakenAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("taken_at");
            entity.Property(e => e.TotalQuestions).HasColumnName("total_questions");
            entity.Property(e => e.TotalScore).HasColumnName("total_score");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.Lesson).WithMany(p => p.UserModuleQuizResults)
                .HasForeignKey(d => d.LessonId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_user_module_quiz_result_lessons");

            entity.HasOne(d => d.User).WithMany(p => p.UserModuleQuizResults)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_user_module_quiz_result_users");
        });

        modelBuilder.Entity<UserQuizAnswer>(entity =>
        {
            entity.HasKey(e => e.UserQuizAnswerId).HasName("PK__user_qui__CDA5BE2A4B0D70E8");

            entity.ToTable("user_quiz_answers");

            entity.Property(e => e.UserQuizAnswerId)
                .ValueGeneratedNever()
                .HasColumnName("user_quiz_answer_id");
            entity.Property(e => e.AnswerText).HasColumnName("answer_text");
            entity.Property(e => e.AnsweredAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("answered_at");
            entity.Property(e => e.QuestionId).HasColumnName("question_id");
            entity.Property(e => e.SelectedOptionId).HasColumnName("selected_option_id");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.Question).WithMany(p => p.UserQuizAnswers)
                .HasForeignKey(d => d.QuestionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_user_quiz_answers_questions");

            entity.HasOne(d => d.SelectedOption).WithMany(p => p.UserQuizAnswers)
                .HasForeignKey(d => d.SelectedOptionId)
                .HasConstraintName("FK_user_quiz_answers_selected_option");

            entity.HasOne(d => d.User).WithMany(p => p.UserQuizAnswers)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_user_quiz_answers_users");
        });

        modelBuilder.Entity<UserSurveyAnswer>(entity =>
        {
            entity.HasKey(e => e.AnswerId).HasName("PK__user_sur__33724318BEB94764");

            entity.ToTable("user_survey_answers");

            entity.Property(e => e.AnswerId)
                .ValueGeneratedNever()
                .HasColumnName("answer_id");
            entity.Property(e => e.AnswerText).HasColumnName("answer_text");
            entity.Property(e => e.AnsweredAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("answered_at");
            entity.Property(e => e.OptionId).HasColumnName("option_id");
            entity.Property(e => e.QuestionId).HasColumnName("question_id");
            entity.Property(e => e.ResponseId).HasColumnName("response_id");

            entity.HasOne(d => d.Option).WithMany(p => p.UserSurveyAnswers)
                .HasForeignKey(d => d.OptionId)
                .HasConstraintName("FK_user_survey_answers_options");

            entity.HasOne(d => d.Question).WithMany(p => p.UserSurveyAnswers)
                .HasForeignKey(d => d.QuestionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_user_survey_answers_questions");

            entity.HasOne(d => d.Response).WithMany(p => p.UserSurveyAnswers)
                .HasForeignKey(d => d.ResponseId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_user_survey_answers_responses");
        });

        modelBuilder.Entity<UserSurveyResponse>(entity =>
        {
            entity.HasKey(e => e.ResponseId).HasName("PK__user_sur__EBECD896A214EC12");

            entity.ToTable("user_survey_responses");

            entity.Property(e => e.ResponseId)
                .ValueGeneratedNever()
                .HasColumnName("response_id");
            entity.Property(e => e.RecommendedAction)
                .HasMaxLength(500)
                .HasColumnName("recommended_action");
            entity.Property(e => e.RiskLevel)
                .HasMaxLength(50)
                .HasColumnName("risk_level");
            entity.Property(e => e.SurveyId).HasColumnName("survey_id");
            entity.Property(e => e.TakenAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("taken_at");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.Survey).WithMany(p => p.UserSurveyResponses)
                .HasForeignKey(d => d.SurveyId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_user_survey_responses_survey");

            entity.HasOne(d => d.User).WithMany(p => p.UserSurveyResponses)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_user_survey_responses_user");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
