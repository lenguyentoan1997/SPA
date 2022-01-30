using SpaLNT.Models.Spa;
using System;

namespace SpaLNT.Data.Infrastructure.Interfaces
{
    public interface IDbFactory : IDisposable
    {
        SpaDbContext Init();
    }
}
