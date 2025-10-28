using Microsoft.EntityFrameworkCore;
using P2_AP1_RonnelDeLaCruz.DAL;
using P2_AP1_RonnelDeLaCruz.Models;
using System.Linq.Expressions;

namespace P2_AP1_RonnelDeLaCruz.Services;

public class RegistrosService
{
    public class RegistroServices(IDbContextFactory<Contexto> DbFactory)
    {
        public async Task<List<Registros>> GetList(Expression<Func<Registros, bool>> criterio)
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();
            return await contexto.Registros
                .Where(criterio)
                .AsNoTracking()
                .ToListAsync();

        }
    }
}
