namespace HealthState.Aplicacion.Common.Models
{
    public class PaginationResponseModel<T>(IEnumerable<T> data, int totalCount, int? skip = 0, int? take = 10) where T : class
    {
        public int? Skip { get; set; } = skip;
        public int? Take { get; set; } = take;
        public int TotalCount { get; set; } = totalCount;
        public IEnumerable<T> Data { get; set; } = data;
    }
}
