//http://www.entityframeworktutorial.net/code-first/foreignkey-dataannotations-attribute-in-code-first.aspx
//https://docs.microsoft.com/en-us/ef/core/get-started/aspnetcore/existing-db
//to update database
//https://stackoverflow.com/questions/50767086/class-library-wth-ef-core-2-1-no-executable-found-matching-command-dotnet-ef
//https://stackoverflow.com/questions/44074992/how-to-update-db-using-code-first-net-core

using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace SocietyApi.DATA
{
    public class ApplicationContext: DbContext
    {
        public ApplicationContext(DbContextOptions opts) : base(opts)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            } 
        }




        public DbSet<AppConfigurations> AppConfigurations { get; set; }
        public DbSet<BuildingMaster> BuildingMaster { get; set; }
        public DbSet<BuildingMasterFields> BuildingMasterFields { get; set; }
        public DbSet<ClientMaster> ClientMaster { get; set; }
        public DbSet<ClientMasterFields> ClientMasterFields { get; set; }
        public DbSet<CommonDesignation> CommonDesignation { get; set; }
        public DbSet<CommonDocument> CommonDocument { get; set; }
        public DbSet<CommonTableType> CommonTableType { get; set; }
        public DbSet<CompanyMaster> CompanyMaster { get; set; }
        public DbSet<CompanyMasterFields> CompanyMasterFields { get; set; }
        public DbSet<ComplaintMaster> ComplaintMaster { get; set; }
        public DbSet<ComplaintMasterFields> ComplaintMasterFields { get; set; }
        public DbSet<ComplaintProgressType> ComplaintProgressType { get; set; }
        public DbSet<ComplaintStatus> ComplaintStatus { get; set; }
        public DbSet<ComplaintType> ComplaintType { get; set; }
        public DbSet<ComplaintTypePersons> ComplaintTypePersons { get; set; }
        public DbSet<DesignationMaster> DesignationMaster { get; set; }
        public DbSet<DesignationType> DesignationType { get; set; }
        public DbSet<DesignationTypeMapping> DesignationTypeMapping { get; set; }
        public DbSet<DeviceType> DeviceType { get; set; }
        public DbSet<DocumentType> DocumentType { get; set; }
        public DbSet<FlatMaster> FlatMaster { get; set; }
        public DbSet<FlatMasterFields> FlatMasterFields { get; set; }
        public DbSet<FlatTypeMaster> FlatTypeMaster { get; set; }
        public DbSet<FloorMaster> FloorMaster { get; set; }
        public DbSet<GateMaster> GateMaster { get; set; }
        public DbSet<GateWingMapping> GateWingMapping { get; set; }
        public DbSet<InstructionFields> InstructionFields { get; set; }
        public DbSet<Instructions> Instructions { get; set; }
        public DbSet<LookupData> LookupData { get; set; }
        public DbSet<LookupKey> LookupKey { get; set; }
        public DbSet<LookupMaster> LookupMaster { get; set; }
        public DbSet<MaintainanceBuilding> MaintainanceBuilding { get; set; }
        public DbSet<MaintainanceFlat> MaintainanceFlat { get; set; }
        public DbSet<MaintainanceProject> MaintainanceProject { get; set; }
        public DbSet<MaintainanceWing> MaintainanceWing { get; set; }
        public DbSet<PersonMaster> PersonMaster { get; set; }
        public DbSet<PersonMasterDevices> PersonMasterDevices { get; set; }
        public DbSet<PersonMasterFields> PersonMasterFields { get; set; }
        public DbSet<PriorityType> PriorityType { get; set; }
        public DbSet<ProjectMaster> ProjectMaster { get; set; }
        public DbSet<ProjectMasterFields> ProjectMasterFields { get; set; }
        public DbSet<TemplateMaster> TemplateMaster { get; set; }
        public DbSet<VisitorAppoinment> VisitorAppoinment { get; set; }
        public DbSet<VisitorAppoinmentStatus> VisitorAppoinmentStatus { get; set; }
        public DbSet<VisitorAppoinmentStatusType> VisitorAppoinmentStatusType { get; set; }
        public DbSet<VisitorColleagues> VisitorColleagues { get; set; }
        public DbSet<VisitorMaster> VisitorMaster { get; set; }
        public DbSet<VisitorMasterFields> VisitorMasterFields { get; set; }
        public DbSet<VisitorPerson> VisitorPerson { get; set; }
        public DbSet<VisitorPersonFields> VisitorPersonFields { get; set; }
        public DbSet<VisitorPurposeType> VisitorPurposeType { get; set; }
        public DbSet<VisitorVisitedFlats> VisitorVisitedFlats { get; set; }
        public DbSet<WingMaster> WingMaster { get; set; }
        public DbSet<WingMasterFields> WingMasterFields { get; set; }

    }
}
