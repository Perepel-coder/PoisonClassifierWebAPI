namespace PoisonClassifierWebAPI.Server.Models
{
    public class SubstancesOutput
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? MainClass { get; set; }
        public string? Chapter { get; set; }
        public string? SubGroup { get; set; }
        public string? Group { get; set; }
        public int IVenomId { get; set; }
        public int MVenomId { get; set; }

    }
    public class IndustrialVenomOutput
    {
        public int Id { get; set; }
        public string? DToxicityClass1 { get; set; }
        public string? DToxicityClass2 { get; set; }
        public string? DToxicityClass3 { get; set; }
        public string? DToxicityClass4 { get; set; }

        public string? NatureImpactGroupName { get; set; }
        public string? NatureImpactGroupDescription { get; set; }
        public string? NatureImpactGroupNameSG { get; set; }

        public string? DegreeImpactClass { get; set; }
        public string? DegreeImpactComment { get; set; }

        public int[]? Symptoms { get; set; }
        public int[]? Paths { get; set; }
    }
    public class MedicalVenomOutput
    {
        public int Id { get; set; }

        public string? OrigionGroup { get; set; }
        public string? OrigionSubGroup { get; set; }

        public string? NatureImpactGroupName { get; set; }
        public string? NatureImpactGroupDescription { get; set; }
        public string? NatureImpactGroupNameSG { get; set; }

        public string? AggregateState { get; set; }
    }

    public class SubstanceClassOutput
    {
        public int Id { get; set; }
        public string? MainClass { get; set; }
        public string? Chapter { get; set; }
        public string? Group { get; set; }
        public string? SubGroup { get; set; }
    }
    public class NatureImpactOutput
    {
        public int Id { get; set; }
        public string? GroupName { get; set; }
        public string? GroupDescription { get; set; }
        public string? GroupNameSG { get; set; }
    }
    public class DegreeImpactOutput
    {
        public int Id { get; set; }
        public string? Class { get; set; }
        public string? Comment { get; set; }
    }
    public class OrigionOutput
    {
        public int Id { get; set; }
        public string? Group { get; set; }
        public string? SubGroup { get; set; }
    }

    public class PathOutput
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Organs { get; set; }
        public string? Output { get; set; }
    }
    public class SavePath
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int[]? Organs { get; set; }
        public string? Output { get; set; }
    }
    public class AggregateStateOutput
    {
        public int Id { get; set; }
        public string? State { get; set; }
    }
    public class SymptomOutput
    {
        public int Id { get; set; }
        public string? Name { get; set; }
    }
    public class OrganOutput
    {
        public int Id { get; set; }
        public string? Name { get; set; }
    }
    public class SaveData
    {
        public int Id { get; set; }
        public string[]? Classub { get; set; }
        public string[]? NatureImpact { get; set; }
        public string[]? DegreeImpact { get; set; }
        public string[]? DegreeToxity { get; set; }
        public string[]? Origion { get; set; }
        public string? AggregateState { get; set; }
        public int[]? Symptoms { get; set; }
        public int[]? Paths { get; set; }
    }

    public class POSTClassifierSymptoms
    {
        public string[]? NatureImpactAndOrigion { get; set; }
        public int[]? Symptoms { get; set; }
    }
}
