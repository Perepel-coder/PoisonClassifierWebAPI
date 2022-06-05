﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PoisonClassifierWebAPI.Server.Models;

#nullable disable

namespace PoisonClassifierWebAPI.Migrations
{
    [DbContext(typeof(ApplicationDBContext))]
    [Migration("20220410114512_poison-migration")]
    partial class poisonmigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("IndustrialVenomPath", b =>
                {
                    b.Property<int>("IndustrialVenomsId")
                        .HasColumnType("int");

                    b.Property<int>("PathsId")
                        .HasColumnType("int");

                    b.HasKey("IndustrialVenomsId", "PathsId");

                    b.HasIndex("PathsId");

                    b.ToTable("IndustrialVenomPath");
                });

            modelBuilder.Entity("IndustrialVenomSymptom", b =>
                {
                    b.Property<int>("IndustrialVenomsId")
                        .HasColumnType("int");

                    b.Property<int>("SymptomsId")
                        .HasColumnType("int");

                    b.HasKey("IndustrialVenomsId", "SymptomsId");

                    b.HasIndex("SymptomsId");

                    b.ToTable("IndustrialVenomSymptom");
                });

            modelBuilder.Entity("MedicalVenomSymptom", b =>
                {
                    b.Property<int>("MedicalVenomsId")
                        .HasColumnType("int");

                    b.Property<int>("SymptomsId")
                        .HasColumnType("int");

                    b.HasKey("MedicalVenomsId", "SymptomsId");

                    b.HasIndex("SymptomsId");

                    b.ToTable("MedicalVenomSymptom");
                });

            modelBuilder.Entity("OrganPath", b =>
                {
                    b.Property<int>("OrgansId")
                        .HasColumnType("int");

                    b.Property<int>("PathsId")
                        .HasColumnType("int");

                    b.HasKey("OrgansId", "PathsId");

                    b.HasIndex("PathsId");

                    b.ToTable("OrganPath");
                });

            modelBuilder.Entity("PoisonClassifierWebAPI.Server.Models.AggregateState", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("State")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("AggregateStates");
                });

            modelBuilder.Entity("PoisonClassifierWebAPI.Server.Models.DegreeImpact", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Class")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Comment")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("DegreeImpacts");
                });

            modelBuilder.Entity("PoisonClassifierWebAPI.Server.Models.DegreeToxicity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Class1")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Class2")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Class3")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Class4")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("IndustrialVenomId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("IndustrialVenomId")
                        .IsUnique();

                    b.ToTable("DegreeToxicities");
                });

            modelBuilder.Entity("PoisonClassifierWebAPI.Server.Models.IndustrialVenom", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("DegreeImpactId")
                        .HasColumnType("int");

                    b.Property<int>("NatureImpactId")
                        .HasColumnType("int");

                    b.Property<int>("SubstanceId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("DegreeImpactId");

                    b.HasIndex("NatureImpactId");

                    b.HasIndex("SubstanceId")
                        .IsUnique();

                    b.ToTable("IndustrialVenoms");
                });

            modelBuilder.Entity("PoisonClassifierWebAPI.Server.Models.MedicalVenom", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("AggregateStateId")
                        .HasColumnType("int");

                    b.Property<int>("NatureImpactId")
                        .HasColumnType("int");

                    b.Property<int>("OrigionId")
                        .HasColumnType("int");

                    b.Property<int>("SubstanceId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AggregateStateId");

                    b.HasIndex("NatureImpactId");

                    b.HasIndex("OrigionId");

                    b.HasIndex("SubstanceId")
                        .IsUnique();

                    b.ToTable("MedicalVenoms");
                });

            modelBuilder.Entity("PoisonClassifierWebAPI.Server.Models.NatureImpact", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("GroupDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("GroupDescriptionSG")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("GroupName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("GroupNameSG")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("NatureImpacts");
                });

            modelBuilder.Entity("PoisonClassifierWebAPI.Server.Models.Organ", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Organs");
                });

            modelBuilder.Entity("PoisonClassifierWebAPI.Server.Models.Origion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Group")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SubGroup")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Origions");
                });

            modelBuilder.Entity("PoisonClassifierWebAPI.Server.Models.Path", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Output")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Paths");
                });

            modelBuilder.Entity("PoisonClassifierWebAPI.Server.Models.Substance", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SubstanceClassId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("SubstanceClassId");

                    b.ToTable("Substances");
                });

            modelBuilder.Entity("PoisonClassifierWebAPI.Server.Models.SubstanceClass", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Chapter")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Group")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MainClass")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SubGroup")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("SubstanceClasses");
                });

            modelBuilder.Entity("PoisonClassifierWebAPI.Server.Models.Symptom", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Symptoms");
                });

            modelBuilder.Entity("IndustrialVenomPath", b =>
                {
                    b.HasOne("PoisonClassifierWebAPI.Server.Models.IndustrialVenom", null)
                        .WithMany()
                        .HasForeignKey("IndustrialVenomsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PoisonClassifierWebAPI.Server.Models.Path", null)
                        .WithMany()
                        .HasForeignKey("PathsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("IndustrialVenomSymptom", b =>
                {
                    b.HasOne("PoisonClassifierWebAPI.Server.Models.IndustrialVenom", null)
                        .WithMany()
                        .HasForeignKey("IndustrialVenomsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PoisonClassifierWebAPI.Server.Models.Symptom", null)
                        .WithMany()
                        .HasForeignKey("SymptomsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MedicalVenomSymptom", b =>
                {
                    b.HasOne("PoisonClassifierWebAPI.Server.Models.MedicalVenom", null)
                        .WithMany()
                        .HasForeignKey("MedicalVenomsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PoisonClassifierWebAPI.Server.Models.Symptom", null)
                        .WithMany()
                        .HasForeignKey("SymptomsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("OrganPath", b =>
                {
                    b.HasOne("PoisonClassifierWebAPI.Server.Models.Organ", null)
                        .WithMany()
                        .HasForeignKey("OrgansId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PoisonClassifierWebAPI.Server.Models.Path", null)
                        .WithMany()
                        .HasForeignKey("PathsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("PoisonClassifierWebAPI.Server.Models.DegreeToxicity", b =>
                {
                    b.HasOne("PoisonClassifierWebAPI.Server.Models.IndustrialVenom", "IndustrialVenom")
                        .WithOne("DToxicity")
                        .HasForeignKey("PoisonClassifierWebAPI.Server.Models.DegreeToxicity", "IndustrialVenomId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("IndustrialVenom");
                });

            modelBuilder.Entity("PoisonClassifierWebAPI.Server.Models.IndustrialVenom", b =>
                {
                    b.HasOne("PoisonClassifierWebAPI.Server.Models.DegreeImpact", "DegreeImpact")
                        .WithMany("IndustrialVenoms")
                        .HasForeignKey("DegreeImpactId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PoisonClassifierWebAPI.Server.Models.NatureImpact", "NatureImpact")
                        .WithMany("IndustrialVenoms")
                        .HasForeignKey("NatureImpactId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PoisonClassifierWebAPI.Server.Models.Substance", "Substance")
                        .WithOne("IVenom")
                        .HasForeignKey("PoisonClassifierWebAPI.Server.Models.IndustrialVenom", "SubstanceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("DegreeImpact");

                    b.Navigation("NatureImpact");

                    b.Navigation("Substance");
                });

            modelBuilder.Entity("PoisonClassifierWebAPI.Server.Models.MedicalVenom", b =>
                {
                    b.HasOne("PoisonClassifierWebAPI.Server.Models.AggregateState", "AggregateState")
                        .WithMany("MedicalVenoms")
                        .HasForeignKey("AggregateStateId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PoisonClassifierWebAPI.Server.Models.NatureImpact", "NatureImpact")
                        .WithMany("MedicalVenoms")
                        .HasForeignKey("NatureImpactId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PoisonClassifierWebAPI.Server.Models.Origion", "Origion")
                        .WithMany("MedicalVenoms")
                        .HasForeignKey("OrigionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PoisonClassifierWebAPI.Server.Models.Substance", "Substance")
                        .WithOne("MVenom")
                        .HasForeignKey("PoisonClassifierWebAPI.Server.Models.MedicalVenom", "SubstanceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AggregateState");

                    b.Navigation("NatureImpact");

                    b.Navigation("Origion");

                    b.Navigation("Substance");
                });

            modelBuilder.Entity("PoisonClassifierWebAPI.Server.Models.Substance", b =>
                {
                    b.HasOne("PoisonClassifierWebAPI.Server.Models.SubstanceClass", "SubstanceClass")
                        .WithMany("Substances")
                        .HasForeignKey("SubstanceClassId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("SubstanceClass");
                });

            modelBuilder.Entity("PoisonClassifierWebAPI.Server.Models.AggregateState", b =>
                {
                    b.Navigation("MedicalVenoms");
                });

            modelBuilder.Entity("PoisonClassifierWebAPI.Server.Models.DegreeImpact", b =>
                {
                    b.Navigation("IndustrialVenoms");
                });

            modelBuilder.Entity("PoisonClassifierWebAPI.Server.Models.IndustrialVenom", b =>
                {
                    b.Navigation("DToxicity")
                        .IsRequired();
                });

            modelBuilder.Entity("PoisonClassifierWebAPI.Server.Models.NatureImpact", b =>
                {
                    b.Navigation("IndustrialVenoms");

                    b.Navigation("MedicalVenoms");
                });

            modelBuilder.Entity("PoisonClassifierWebAPI.Server.Models.Origion", b =>
                {
                    b.Navigation("MedicalVenoms");
                });

            modelBuilder.Entity("PoisonClassifierWebAPI.Server.Models.Substance", b =>
                {
                    b.Navigation("IVenom")
                        .IsRequired();

                    b.Navigation("MVenom")
                        .IsRequired();
                });

            modelBuilder.Entity("PoisonClassifierWebAPI.Server.Models.SubstanceClass", b =>
                {
                    b.Navigation("Substances");
                });
#pragma warning restore 612, 618
        }
    }
}
