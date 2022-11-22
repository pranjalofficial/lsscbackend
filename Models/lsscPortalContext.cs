using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace WebApplication3.Models
{
    public partial class lsscPortalContext : DbContext
    {
        public lsscPortalContext()
        {
        }

        public lsscPortalContext(DbContextOptions<lsscPortalContext> options)
            : base(options)
        {
        }

        public virtual DbSet<SkilledPerson> SkilledPerson { get; set; }
        public virtual DbSet<TblAssessmentBatch> TblAssessmentBatch { get; set; }
        public virtual DbSet<TblAssessmentProof> TblAssessmentProof { get; set; }
        public virtual DbSet<TblCandidateList> TblCandidateList { get; set; }
        public virtual DbSet<TblCenter> TblCenter { get; set; }
        public virtual DbSet<TblCompanyRequirment> TblCompanyRequirment { get; set; }
        public virtual DbSet<TblFinalResult> TblFinalResult { get; set; }
        public virtual DbSet<TblNos> TblNos { get; set; }
        public virtual DbSet<TblPracticalQuestion> TblPracticalQuestion { get; set; }
        public virtual DbSet<TblPracticalResult> TblPracticalResult { get; set; }
        public virtual DbSet<TblProject> TblProject { get; set; }
        public virtual DbSet<TblQp> TblQp { get; set; }
        public virtual DbSet<TblQuestionBank> TblQuestionBank { get; set; }
        public virtual DbSet<TblQuestionPaperVersion> TblQuestionPaperVersion { get; set; }
        public virtual DbSet<TblTheoryQuestions> TblTheoryQuestions { get; set; }
        public virtual DbSet<TblTheoryResult> TblTheoryResult { get; set; }
        public virtual DbSet<TblTotalPracticalMarks> TblTotalPracticalMarks { get; set; }
        public virtual DbSet<TblTrainingPartner> TblTrainingPartner { get; set; }
        public virtual DbQuery<CenterAssesorInfo> CenterAssesors { get; set; }
        public virtual DbQuery<theoryResult> TheoryResults { get; set; }
        public virtual DbQuery<Image> Image { get; set; }
        public virtual DbQuery<projectData> projectData { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=tcp:lssc.database.windows.net,1433;Initial Catalog=lsscPortal;Persist Security Info=False;User ID=lssc;Password=Pranjal@1;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SkilledPerson>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.LastDesignation).HasColumnName("lastDesignation");

                entity.Property(e => e.MotherName)
                    .HasColumnName("motherName")
                    .IsUnicode(false);

                entity.Property(e => e.SpAddhar).HasColumnName("spAddhar");

                entity.Property(e => e.SpAddress).HasColumnName("spAddress");

                entity.Property(e => e.SpDateOfBirth)
                    .HasColumnName("spDateOfBirth")
                    .HasColumnType("date");

                entity.Property(e => e.SpDistrict).HasColumnName("spDistrict");

                entity.Property(e => e.SpEducation).HasColumnName("spEducation");

                entity.Property(e => e.SpFatherName).HasColumnName("spFatherName");

                entity.Property(e => e.SpGender).HasColumnName("spGender");

                entity.Property(e => e.SpImage).HasColumnName("spImage");

                entity.Property(e => e.SpMobile).HasColumnName("spMobile");

                entity.Property(e => e.SpName)
                    .IsRequired()
                    .HasColumnName("spName");

                entity.Property(e => e.SpPinCode).HasColumnName("spPinCode");

                entity.Property(e => e.SpState).HasColumnName("spState");

                entity.Property(e => e.SpWork).HasColumnName("spWork");

                entity.Property(e => e.WorkedComapny).HasColumnName("workedComapny");
            });

            modelBuilder.Entity<TblAssessmentBatch>(entity =>
            {
                entity.HasKey(e => e.AsId);

                entity.ToTable("tblAssessmentBatch");

                entity.Property(e => e.AsId).HasColumnName("asId");

                entity.Property(e => e.AsAssesmentEndtDate)
                    .HasColumnName("asAssesmentEndtDate")
                    .HasColumnType("date");

                entity.Property(e => e.AsAssesmentStartDate)
                    .HasColumnName("asAssesmentStartDate")
                    .HasColumnType("date");

                entity.Property(e => e.AsAssessmentEndTime).HasColumnName("asAssessmentEndTime");

                entity.Property(e => e.AsAssessmentStartTime).HasColumnName("asAssessmentStartTime");

                entity.Property(e => e.AsBangla).HasColumnName("asBangla");

                entity.Property(e => e.AsCenterId)
                    .HasColumnName("asCenterId")
                    .HasMaxLength(30);

                entity.Property(e => e.AsCity)
                    .IsRequired()
                    .HasColumnName("asCity")
                    .HasMaxLength(30);

                entity.Property(e => e.AsContactPerson)
                    .HasColumnName("asContactPerson")
                    .HasMaxLength(40);

                entity.Property(e => e.AsContactPersonEmailId)
                    .HasColumnName("asContactPersonEmailId")
                    .HasMaxLength(40);

                entity.Property(e => e.AsContactPersonPhoneNo).HasColumnName("asContactPersonPhoneNo");

                entity.Property(e => e.AsEnglish).HasColumnName("asEnglish");

                entity.Property(e => e.AsFacilitator)
                    .IsRequired()
                    .HasColumnName("asFacilitator")
                    .HasMaxLength(30);

                entity.Property(e => e.AsHindi).HasColumnName("asHindi");

                entity.Property(e => e.AsPartner)
                    .IsRequired()
                    .HasColumnName("asPartner")
                    .HasMaxLength(40);

                entity.Property(e => e.AsProjectId)
                    .IsRequired()
                    .HasColumnName("asProjectId")
                    .HasMaxLength(20);

                entity.Property(e => e.AsQpId)
                    .IsRequired()
                    .HasColumnName("asQpId")
                    .HasMaxLength(100);

                entity.Property(e => e.AsQuestionBankId)
                    .IsRequired()
                    .HasColumnName("asQuestionBankID")
                    .HasMaxLength(12);

                entity.Property(e => e.AsQuestionVersion)
                    .IsRequired()
                    .HasColumnName("asQuestionVersion")
                    .HasMaxLength(12);

                entity.Property(e => e.AsRemarks)
                    .HasColumnName("asRemarks")
                    .HasMaxLength(100);

                entity.Property(e => e.AsSdmsbatchName)
                    .IsRequired()
                    .HasColumnName("asSDMSBatchName")
                    .HasMaxLength(20);

                entity.Property(e => e.AsState)
                    .IsRequired()
                    .HasColumnName("asState")
                    .HasMaxLength(30);

                entity.Property(e => e.AsTamil).HasColumnName("asTamil");

                entity.Property(e => e.AsTrainingEndDate)
                    .HasColumnName("asTrainingEndDate")
                    .HasColumnType("date");

                entity.Property(e => e.AsTrainingStartDate)
                    .HasColumnName("asTrainingStartDate")
                    .HasColumnType("date");

                entity.Property(e => e.AsType)
                    .IsRequired()
                    .HasColumnName("asType")
                    .HasMaxLength(20);

                entity.HasOne(d => d.AsCenter)
                    .WithMany(p => p.TblAssessmentBatch)
                    .HasForeignKey(d => d.AsCenterId)
                    .HasConstraintName("FK__tblAssess__asCen__14270015");

                entity.HasOne(d => d.AsProject)
                    .WithMany(p => p.TblAssessmentBatch)
                    .HasForeignKey(d => d.AsProjectId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_asseprojectID");

                entity.HasOne(d => d.AsQp)
                    .WithMany(p => p.TblAssessmentBatch)
                    .HasForeignKey(d => d.AsQpId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_asQP");

                entity.HasOne(d => d.AsQuestionBank)
                    .WithMany(p => p.TblAssessmentBatch)
                    .HasForeignKey(d => d.AsQuestionBankId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_qbID");

                entity.HasOne(d => d.AsQuestionVersionNavigation)
                    .WithMany(p => p.TblAssessmentBatch)
                    .HasForeignKey(d => d.AsQuestionVersion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_QuestionVersion");
            });

            modelBuilder.Entity<TblAssessmentProof>(entity =>
            {
                entity.HasKey(e => e.AsId);

                entity.ToTable("tblAssessmentProof");

                entity.Property(e => e.AsId).HasColumnName("asID");

                entity.Property(e => e.AsAddharPhoto).HasColumnName("asAddharPhoto");

                entity.Property(e => e.AsAssesser)
                    .HasColumnName("asAssesser")
                    .HasMaxLength(30);

                entity.Property(e => e.AsCandidateId)
                    .HasColumnName("asCandidateId")
                    .HasMaxLength(50);

                entity.Property(e => e.AsPersonalPhoto).HasColumnName("asPersonalPhoto");

                entity.Property(e => e.AsbatchId).HasColumnName("asbatchID");

                entity.HasOne(d => d.Asbatch)
                    .WithMany(p => p.TblAssessmentProof)
                    .HasForeignKey(d => d.AsbatchId)
                    .HasConstraintName("FK_batchIDas");
            });

            modelBuilder.Entity<TblCandidateList>(entity =>
            {
                entity.HasKey(e => e.ClEnrollmentNo);

                entity.ToTable("tblCandidateList");

                entity.Property(e => e.ClEnrollmentNo)
                    .HasColumnName("clEnrollmentNo")
                    .HasMaxLength(400)
                    .ValueGeneratedNever();

                entity.Property(e => e.ClName)
                    .IsRequired()
                    .HasColumnName("clName");

                entity.Property(e => e.ClPracticalDone)
                    .HasColumnName("clPracticalDone")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.ClReqNo).HasColumnName("clReqNo");

                entity.Property(e => e.ClTheoryDeone)
                    .HasColumnName("clTheoryDeone")
                    .HasDefaultValueSql("((0))");
            });

            modelBuilder.Entity<TblCenter>(entity =>
            {
                entity.HasKey(e => e.CenterCode);

                entity.ToTable("tblCenter");

                entity.Property(e => e.CenterCode)
                    .HasColumnName("centerCode")
                    .HasMaxLength(30)
                    .ValueGeneratedNever();

                entity.Property(e => e.CenterAddress).HasColumnName("centerAddress");

                entity.Property(e => e.CenterContactNo).HasColumnName("centerContactNo");

                entity.Property(e => e.CenterContactPerson)
                    .HasColumnName("centerContactPerson")
                    .HasMaxLength(30);

                entity.Property(e => e.CenterEmailId)
                    .HasColumnName("centerEmailID")
                    .HasMaxLength(40);

                entity.Property(e => e.CenterName)
                    .IsRequired()
                    .HasColumnName("centerName")
                    .HasMaxLength(40);
            });

            modelBuilder.Entity<TblCompanyRequirment>(entity =>
            {
                entity.HasKey(e => e.CrId);

                entity.ToTable("tblCompanyRequirment");

                entity.Property(e => e.CrId).HasColumnName("crId");

                entity.Property(e => e.CrCompanyName).HasColumnName("crCompanyName");

                entity.Property(e => e.CrDateOfJoining)
                    .HasColumnName("crDateOfJoining")
                    .HasColumnType("date");

                entity.Property(e => e.CrDistrict).HasColumnName("crDistrict");

                entity.Property(e => e.CrDuration).HasColumnName("crDuration");

                entity.Property(e => e.CrExperience).HasColumnName("crExperience");

                entity.Property(e => e.CrFunction).HasColumnName("crFunction");

                entity.Property(e => e.CrGender).HasColumnName("crGender");

                entity.Property(e => e.CrNoOfPosition).HasColumnName("crNoOfPosition");

                entity.Property(e => e.CrPositionRequired).HasColumnName("crPositionRequired");

                entity.Property(e => e.CrQualification).HasColumnName("crQualification");

                entity.Property(e => e.CrRequestedDepartment).HasColumnName("crRequestedDepartment");

                entity.Property(e => e.CrSkillSets).HasColumnName("crSKillSets");

                entity.Property(e => e.CrSpecificDetails).HasColumnName("crSpecificDetails");

                entity.Property(e => e.CrState).HasColumnName("crState");
            });

            modelBuilder.Entity<TblFinalResult>(entity =>
            {
                entity.HasKey(e => e.FrId);

                entity.ToTable("tblFinalResult");

                entity.Property(e => e.FrId).HasColumnName("frID");

                entity.Property(e => e.FrCandidateId)
                    .IsRequired()
                    .HasColumnName("frCandidateId")
                    .HasMaxLength(50);

                entity.Property(e => e.FrFinalResult).HasColumnName("frFinalResult");

                entity.Property(e => e.FrPracticalId).HasColumnName("frPracticalID");

                entity.Property(e => e.FrPracticalResult).HasColumnName("frPracticalResult");

                entity.Property(e => e.FrTheoryId).HasColumnName("frTheoryID");

                entity.Property(e => e.FrTheoryResult).HasColumnName("frTheoryResult");

                entity.Property(e => e.FrbatchId).HasColumnName("frbatchID");

                entity.HasOne(d => d.FrPractical)
                    .WithMany(p => p.TblFinalResult)
                    .HasForeignKey(d => d.FrPracticalId)
                    .HasConstraintName("FK_PracticalResultIDfr");

                entity.HasOne(d => d.FrTheory)
                    .WithMany(p => p.TblFinalResult)
                    .HasForeignKey(d => d.FrTheoryId)
                    .HasConstraintName("FK_theoryResultIDfr");

                entity.HasOne(d => d.Frbatch)
                    .WithMany(p => p.TblFinalResult)
                    .HasForeignKey(d => d.FrbatchId)
                    .HasConstraintName("FK_batchIDfr");
            });

            modelBuilder.Entity<TblNos>(entity =>
            {
                entity.HasKey(e => e.NosCode);

                entity.ToTable("tblNOS");

                entity.Property(e => e.NosCode)
                    .HasColumnName("nosCode")
                    .HasMaxLength(50)
                    .ValueGeneratedNever();

                entity.Property(e => e.NosActive).HasColumnName("nosActive");

                entity.Property(e => e.NosName)
                    .IsRequired()
                    .HasColumnName("nosName")
                    .HasMaxLength(100);

                entity.Property(e => e.NosQpCode)
                    .HasColumnName("nosQpCode")
                    .HasMaxLength(100);

                entity.HasOne(d => d.NosQpCodeNavigation)
                    .WithMany(p => p.TblNos)
                    .HasForeignKey(d => d.NosQpCode)
                    .HasConstraintName("FK_nosQpConn");
            });

            modelBuilder.Entity<TblPracticalQuestion>(entity =>
            {
                entity.HasKey(e => e.PqCode);

                entity.ToTable("tblPracticalQuestion");

                entity.Property(e => e.PqCode).HasColumnName("pqCode");

                entity.Property(e => e.PqCommonQuestion).HasColumnName("pqCommonQuestion");

                entity.Property(e => e.PqLang)
                    .HasColumnName("pqLang")
                    .HasMaxLength(50);

                entity.Property(e => e.PqMarks).HasColumnName("pqMarks");

                entity.Property(e => e.PqNos)
                    .IsRequired()
                    .HasColumnName("pqNOS")
                    .HasMaxLength(50);

                entity.Property(e => e.PqPc)
                    .HasColumnName("pqPC")
                    .HasMaxLength(100);

                entity.Property(e => e.PqQuestion).HasColumnName("pqQuestion");

                entity.Property(e => e.PqType)
                    .IsRequired()
                    .HasColumnName("pqType")
                    .HasMaxLength(30);

                entity.Property(e => e.PqVersionOfQb)
                    .HasColumnName("pqVersionOfQB")
                    .HasMaxLength(12);

                entity.HasOne(d => d.PqNosNavigation)
                    .WithMany(p => p.TblPracticalQuestion)
                    .HasForeignKey(d => d.PqNos)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_nosOfPQ");

                entity.HasOne(d => d.PqVersionOfQbNavigation)
                    .WithMany(p => p.TblPracticalQuestion)
                    .HasForeignKey(d => d.PqVersionOfQb)
                    .HasConstraintName("FK_pqVersionID");
            });

            modelBuilder.Entity<TblPracticalResult>(entity =>
            {
                entity.HasKey(e => e.PrId);

                entity.ToTable("tblPracticalResult");

                entity.Property(e => e.PrId).HasColumnName("prID");

                entity.Property(e => e.PrCandidateId)
                    .IsRequired()
                    .HasColumnName("prCandidateId")
                    .HasMaxLength(50);

                entity.Property(e => e.PrMarks).HasColumnName("prMarks");

                entity.Property(e => e.PrNos)
                    .HasColumnName("prNOS")
                    .HasMaxLength(50);

                entity.Property(e => e.PrQuestionId).HasColumnName("prQuestionID");

                entity.Property(e => e.PrType).HasColumnName("prType");

                entity.Property(e => e.PrbatchId).HasColumnName("prbatchID");

                entity.HasOne(d => d.PrNosNavigation)
                    .WithMany(p => p.TblPracticalResult)
                    .HasForeignKey(d => d.PrNos)
                    .HasConstraintName("FK__tblPracti__prNOS__151B244E");

                entity.HasOne(d => d.PrQuestion)
                    .WithMany(p => p.TblPracticalResult)
                    .HasForeignKey(d => d.PrQuestionId)
                    .HasConstraintName("FK_questionIDPR");

                entity.HasOne(d => d.Prbatch)
                    .WithMany(p => p.TblPracticalResult)
                    .HasForeignKey(d => d.PrbatchId)
                    .HasConstraintName("FK_batchIDPR");
            });

            modelBuilder.Entity<TblProject>(entity =>
            {
                entity.HasKey(e => e.ProjId);

                entity.ToTable("tblProject");

                entity.Property(e => e.ProjId)
                    .HasColumnName("projId")
                    .HasMaxLength(20)
                    .ValueGeneratedNever();

                entity.Property(e => e.ProjAssesmentType)
                    .HasColumnName("projAssesmentType")
                    .HasMaxLength(20);

                entity.Property(e => e.ProjDesp)
                    .HasColumnName("projDesp")
                    .HasMaxLength(100);

                entity.Property(e => e.ProjManager)
                    .IsRequired()
                    .HasColumnName("projManager")
                    .HasMaxLength(30);

                entity.Property(e => e.ProjName)
                    .IsRequired()
                    .HasColumnName("projName")
                    .HasMaxLength(40);
            });

            modelBuilder.Entity<TblQp>(entity =>
            {
                entity.HasKey(e => e.QpCode);

                entity.ToTable("tblQP");

                entity.Property(e => e.QpCode)
                    .HasColumnName("qpCode")
                    .HasMaxLength(100)
                    .ValueGeneratedNever();

                entity.Property(e => e.QpActive).HasColumnName("qpActive");

                entity.Property(e => e.QpMaxEdlevel)
                    .HasColumnName("qpMaxEDLevel")
                    .HasMaxLength(30);

                entity.Property(e => e.QpMinEdlevel)
                    .HasColumnName("qpMinEDLevel")
                    .HasMaxLength(30);

                entity.Property(e => e.QpName)
                    .IsRequired()
                    .HasColumnName("qpName")
                    .HasMaxLength(100);

                entity.Property(e => e.QpNoOfNos).HasColumnName("qpNoOfNOS");

                entity.Property(e => e.QpNsqfLevel).HasColumnName("qpNsqfLevel");

                entity.Property(e => e.QpSectorName)
                    .HasColumnName("qpSectorName")
                    .HasMaxLength(20);
            });

            modelBuilder.Entity<TblQuestionBank>(entity =>
            {
                entity.HasKey(e => e.QbQuestionCode);

                entity.ToTable("tblQuestionBank");

                entity.Property(e => e.QbQuestionCode)
                    .HasColumnName("qbQuestionCode")
                    .HasMaxLength(12)
                    .HasComputedColumnSql("('QB'+CONVERT([nvarchar](10),[qbQuestionID]))")
                    .ValueGeneratedNever();

                entity.Property(e => e.QbName)
                    .IsRequired()
                    .HasColumnName("qbName")
                    .HasMaxLength(100);

                entity.Property(e => e.QbQuestionId)
                    .HasColumnName("qbQuestionID")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.QbRelatedQp)
                    .HasColumnName("qbRelatedQP")
                    .HasMaxLength(100);

                entity.HasOne(d => d.QbRelatedQpNavigation)
                    .WithMany(p => p.TblQuestionBank)
                    .HasForeignKey(d => d.QbRelatedQp)
                    .HasConstraintName("FK_qbQpConn");
            });

            modelBuilder.Entity<TblQuestionPaperVersion>(entity =>
            {
                entity.HasKey(e => e.QvVersionCode);

                entity.ToTable("tblQuestionPaperVersion");

                entity.Property(e => e.QvVersionCode)
                    .HasColumnName("qvVersionCode")
                    .HasMaxLength(12)
                    .HasComputedColumnSql("('QV'+CONVERT([nvarchar](10),[qvVersionID]))")
                    .ValueGeneratedNever();

                entity.Property(e => e.QvBangla).HasColumnName("qvBangla");

                entity.Property(e => e.QvHindi).HasColumnName("qvHindi");

                entity.Property(e => e.QvName)
                    .IsRequired()
                    .HasColumnName("qvName")
                    .HasMaxLength(50);

                entity.Property(e => e.QvQbcode)
                    .HasColumnName("qvQBCode")
                    .HasMaxLength(12);

                entity.Property(e => e.QvTamil).HasColumnName("qvTamil");

                entity.Property(e => e.QvType)
                    .IsRequired()
                    .HasColumnName("qvType")
                    .HasMaxLength(30);

                entity.Property(e => e.QvVersionId)
                    .HasColumnName("qvVersionID")
                    .ValueGeneratedOnAdd();

                entity.HasOne(d => d.QvQbcodeNavigation)
                    .WithMany(p => p.TblQuestionPaperVersion)
                    .HasForeignKey(d => d.QvQbcode)
                    .HasConstraintName("FK_QBCode");
            });

            modelBuilder.Entity<TblTheoryQuestions>(entity =>
            {
                entity.HasKey(e => e.TqCode);

                entity.ToTable("tblTheoryQuestions");

                entity.Property(e => e.TqCode).HasColumnName("tqCode");

                entity.Property(e => e.TqCorrectAnswer).HasColumnName("tqCorrectAnswer");

                entity.Property(e => e.TqDifficultyLevel)
                    .HasColumnName("tqDIfficultyLevel")
                    .HasMaxLength(40)
                    .HasDefaultValueSql("('Easy')");

                entity.Property(e => e.TqImg).HasColumnName("tqImg");

                entity.Property(e => e.TqLanguage)
                    .HasColumnName("tqLanguage")
                    .HasMaxLength(50);

                entity.Property(e => e.TqMarks).HasColumnName("tqMarks");

                entity.Property(e => e.TqNos)
                    .HasColumnName("tqNOS")
                    .HasMaxLength(50);

                entity.Property(e => e.TqOption1)
                    .IsRequired()
                    .HasColumnName("tqOption1");

                entity.Property(e => e.TqOption2)
                    .IsRequired()
                    .HasColumnName("tqOption2");

                entity.Property(e => e.TqOption3)
                    .IsRequired()
                    .HasColumnName("tqOption3");

                entity.Property(e => e.TqOption4)
                    .IsRequired()
                    .HasColumnName("tqOption4");

                entity.Property(e => e.TqQuestion)
                    .IsRequired()
                    .HasColumnName("tqQuestion");

                entity.Property(e => e.TqVersionOfQb)
                    .HasColumnName("tqVersionOfQB")
                    .HasMaxLength(12);

                entity.HasOne(d => d.TqNosNavigation)
                    .WithMany(p => p.TblTheoryQuestions)
                    .HasForeignKey(d => d.TqNos)
                    .HasConstraintName("FK__tblTheory__tqNOS__3A4CA8FD");

                entity.HasOne(d => d.TqVersionOfQbNavigation)
                    .WithMany(p => p.TblTheoryQuestions)
                    .HasForeignKey(d => d.TqVersionOfQb)
                    .HasConstraintName("FK_versionID");
            });

            modelBuilder.Entity<TblTheoryResult>(entity =>
            {
                entity.HasKey(e => e.TrId);

                entity.ToTable("tblTheoryResult");

                entity.Property(e => e.TrId).HasColumnName("trID");

                entity.Property(e => e.TrCandidateId)
                    .IsRequired()
                    .HasColumnName("trCandidateId")
                    .HasMaxLength(50);

                entity.Property(e => e.TrMarks1).HasColumnName("trMarks1");

                entity.Property(e => e.TrMarks10).HasColumnName("trMarks10");

                entity.Property(e => e.TrMarks11).HasColumnName("trMarks11");

                entity.Property(e => e.TrMarks12).HasColumnName("trMarks12");

                entity.Property(e => e.TrMarks13).HasColumnName("trMarks13");

                entity.Property(e => e.TrMarks14).HasColumnName("trMarks14");

                entity.Property(e => e.TrMarks15).HasColumnName("trMarks15");

                entity.Property(e => e.TrMarks16).HasColumnName("trMarks16");

                entity.Property(e => e.TrMarks17).HasColumnName("trMarks17");

                entity.Property(e => e.TrMarks18).HasColumnName("trMarks18");

                entity.Property(e => e.TrMarks19).HasColumnName("trMarks19");

                entity.Property(e => e.TrMarks2).HasColumnName("trMarks2");

                entity.Property(e => e.TrMarks20).HasColumnName("trMarks20");

                entity.Property(e => e.TrMarks3).HasColumnName("trMarks3");

                entity.Property(e => e.TrMarks4).HasColumnName("trMarks4");

                entity.Property(e => e.TrMarks5).HasColumnName("trMarks5");

                entity.Property(e => e.TrMarks6).HasColumnName("trMarks6");

                entity.Property(e => e.TrMarks7).HasColumnName("trMarks7");

                entity.Property(e => e.TrMarks8).HasColumnName("trMarks8");

                entity.Property(e => e.TrMarks9).HasColumnName("trMarks9");

                entity.Property(e => e.TrTotalMarks).HasColumnName("trTotalMarks");

                entity.Property(e => e.TrbatchId).HasColumnName("trbatchID");

                entity.HasOne(d => d.Trbatch)
                    .WithMany(p => p.TblTheoryResult)
                    .HasForeignKey(d => d.TrbatchId)
                    .HasConstraintName("FK_batchID");
            });

            modelBuilder.Entity<TblTotalPracticalMarks>(entity =>
            {
                entity.HasKey(e => e.TpmId);

                entity.ToTable("tblTotalPracticalMarks");

                entity.Property(e => e.TpmId).HasColumnName("tpmID");

                entity.Property(e => e.TpmCandidateId)
                    .IsRequired()
                    .HasColumnName("tpmCandidateId")
                    .HasMaxLength(50);

                entity.Property(e => e.TpmTotalMarks).HasColumnName("tpmTotalMarks");

                entity.Property(e => e.TpmbatchId).HasColumnName("tpmbatchID");

                entity.HasOne(d => d.Tpmbatch)
                    .WithMany(p => p.TblTotalPracticalMarks)
                    .HasForeignKey(d => d.TpmbatchId)
                    .HasConstraintName("FK_batchIDtpm");
            });

            modelBuilder.Entity<TblTrainingPartner>(entity =>
            {
                entity.HasKey(e => e.TpCode);

                entity.ToTable("tblTrainingPartner");

                entity.Property(e => e.TpCode).HasColumnName("tpCode");

                entity.Property(e => e.TpActive).HasColumnName("tpActive");

                entity.Property(e => e.TpName)
                    .HasColumnName("tpName")
                    .HasMaxLength(50);
            });
        }
    }
}
