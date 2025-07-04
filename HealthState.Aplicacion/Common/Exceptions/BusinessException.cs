using System.Diagnostics.CodeAnalysis;

namespace HealthState.Aplicacion.Common.Exceptions
{
    [ExcludeFromCodeCoverage]
    public class BusinessException : Exception
    {
        public BusinessException(string message) : base(message) { }

        public static BusinessException Instance(string message) => new BusinessException(message);
    }
    public class NotFoundException : Exception
    {
        public NotFoundException(string message) : base(message) { }

        public static NotFoundException Instance(string message) => new NotFoundException(message);
    }
}
