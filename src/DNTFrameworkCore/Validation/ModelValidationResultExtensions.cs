using System.Collections.Generic;
using System.Linq;
using DNTFrameworkCore.Extensions;
using DNTFrameworkCore.Functional;

namespace DNTFrameworkCore.Validation
{
    public static class ModelValidationResultExtensions
    {
        public static Result ToResult(this IEnumerable<ModelValidationResult> results)
        {
            var failures = results as ModelValidationResult[] ?? results.ToArray();
            if (!failures.Any()) return Result.Ok();

            var message = string.Join("\n", failures.Where(a => a.MemberName.IsEmpty()));

            var result = Result.Failed(message, failures);

            return result;
        }
    }
}