using Microsoft.AspNetCore.Builder;
using System.Diagnostics.CodeAnalysis;

namespace ValdoBase.IoC
{
    [ExcludeFromCodeCoverage]
    public static class IoC
    {
        public static void Start(IApplicationBuilder app)
        {
            DatabaseIoC.Start(app);
        }
    }
}