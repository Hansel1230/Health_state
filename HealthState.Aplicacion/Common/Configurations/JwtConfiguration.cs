namespace HealthState.Aplicacion.Common.Configurations
{
    public class JwtConfiguration
    {
        public string Key { get; set; }
        public bool Expire { get; set; }
        public int ExpireTime { get; set; }
    }
}
