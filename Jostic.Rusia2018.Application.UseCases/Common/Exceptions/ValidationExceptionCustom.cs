using Jostic.Rusia2018.Transversal.Common;

namespace Jostic.Rusia2018.Application.UseCases.Common.Exceptions
{
    public class ValidationExceptionCustom : Exception
    {
        public IEnumerable<BaseError>? Errors { get; }

        public ValidationExceptionCustom() : base("One or more validations failures")
        {
            Errors = new List<BaseError>();
        }

        public ValidationExceptionCustom(IEnumerable<BaseError>? errors) : this()
        {
            Errors = errors;
        }
    }
}