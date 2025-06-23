namespace HealthState.Dominio.Types
{
    public interface ISoftDelete
    {
        public bool IsDeleted { get; set; }
        public DateTime? Deleted { get; set; }
        public string DeletedBy { get; set; }
    }
}
