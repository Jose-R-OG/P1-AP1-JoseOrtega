using P1_AP1_JoseOrtega.Models;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using P1_AP1_JoseOrtega.DAL;

namespace P1_AP1_JoseOrtega.Services;

public class RegistroServicecs(IDbContextFactory<Contexto> DbFactory)
{

    public async Task<List<EntradasHuacales>> Listar(Expression<Func<EntradasHuacales, bool>> criterio)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.Registro.Where(criterio).AsNoTracking().ToListAsync();
    }
}
