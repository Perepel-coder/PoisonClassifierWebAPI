using Microsoft.EntityFrameworkCore;

namespace PoisonClassifierWebAPI.Server.Models
{
    public class ApplicationDBContext : DbContext
    {
        public DbSet<Substance>? Substances { get; set; }
        public DbSet<SubstanceClass>? SubstanceClasses { get; set; }
        public DbSet<IndustrialVenom>? IndustrialVenoms { get; set; }
        public DbSet<MedicalVenom>? MedicalVenoms { get; set; }
        public DbSet<Organ>? Organs { get; set; }
        public DbSet<Path>? Paths { get; set; }
        public DbSet<Origion>? Origions { get; set; }
        public DbSet<AggregateState>? AggregateStates { get; set; }
        public DbSet<DegreeToxicity>? DegreeToxicities { get; set; }
        public DbSet<NatureImpact>? NatureImpacts { get; set; }
        public DbSet<DegreeImpact>? DegreeImpacts { get; set; }
        public DbSet<Symptom>? Symptoms { get; set; }
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
    }

    #region Database

    public class Substance
    {
        public int Id { get; set; }
        public string? Name { get; set; }

        public int SubstanceClassId { get; set; }
        public SubstanceClass? SubstanceClass { get; set; }

        public IndustrialVenom? IVenom { get; set; } = new();
        public MedicalVenom? MVenom { get; set; } = new();
    }
    public class SubstanceClass
    {
        public int Id { get; set; }
        public string? MainClass { get; set; }
        public string? Chapter { get; set; }
        public string? Group { get; set; }
        public string? SubGroup { get; set; }

        public List<Substance>? Substances { get; set; }
    }
    public class IndustrialVenom
    {
        public int Id { get; set; }

        public DegreeToxicity? DToxicity { get; set; } = new();

        public List<Path>? Paths { get; set; } = new();
        public List<Symptom>? Symptoms { get; set; } = new();

        public int SubstanceId { get; set; }
        public Substance? Substance { get; set; }

        public int NatureImpactId { get; set; }
        public NatureImpact? NatureImpact { get; set; } = new();

        public int DegreeImpactId { get; set; }
        public DegreeImpact? DegreeImpact { get; set; }

    }
    public class MedicalVenom
    {
        public int Id { get; set; }

        public int OrigionId { get; set; }
        public Origion? Origion { get; set; } = new();

        public List<Symptom>? Symptoms { get; set; } = new();

        public int AggregateStateId { get; set; }
        public AggregateState? AggregateState { get; set; }

        public int NatureImpactId { get; set; }
        public NatureImpact? NatureImpact { get; set; } = new();

        public int SubstanceId { get; set; }
        public Substance? Substance { get; set; }

    }
    public class Organ
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public List<Path>? Paths { get; set; }
    }
    public class Path
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public List<Organ>? Organs { get; set; }
        public string? Output { get; set; }
        public List<IndustrialVenom>? IndustrialVenoms { get; set; }
    }
    public class Origion
    {
        public int Id { get; set; }
        public string? Group { get; set; }
        public string? SubGroup { get; set; }

        public List<MedicalVenom>? MedicalVenoms { get; set; }
    }
    public class AggregateState
    {
        public int Id { get; set; }
        public string? State { get; set; }

        public List<MedicalVenom>? MedicalVenoms { get; set; }
    }
    public class DegreeToxicity
    {
        public int Id { get; set; }
        public string? Class1 { get; set; }
        public string? Class2 { get; set; }
        public string? Class3 { get; set; }
        public string? Class4 { get; set; }

        public int IndustrialVenomId { get; set; }
        public IndustrialVenom? IndustrialVenom { get; set; }
    }
    public class NatureImpact
    {
        public int Id { get; set; }
        public string? GroupName { get; set; }
        public string? GroupDescription { get; set; }
        public string? GroupNameSG { get; set; }

        public List<IndustrialVenom>? IndustrialVenoms { get; set; }
        public List<MedicalVenom>? MedicalVenoms { get; set; }
    }
    public class DegreeImpact
    {
        public int Id { get; set; }
        public string? Class { get; set; }
        public string? Comment { get; set; }

        public List<IndustrialVenom>? IndustrialVenoms { get; set; }

    }
    public class Symptom
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public List<IndustrialVenom>? IndustrialVenoms { get; set; }
        public List<MedicalVenom>? MedicalVenoms { get; set; }
    }

    #endregion
}