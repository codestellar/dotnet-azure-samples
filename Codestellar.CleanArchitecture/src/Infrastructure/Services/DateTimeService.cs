using Codestellar.CleanArchitecture.Application.Common.Interfaces;
using System;

namespace Codestellar.CleanArchitecture.Infrastructure.Services
{
    public class DateTimeService : IDateTime
    {
        public DateTime Now => DateTime.Now;
    }
}
