using Microsoft.EntityFrameworkCore;
using P1_AP1_JoseOrtega.Models;
using P1_AP1_JoseOrtega.DAL;
using System.Linq.Expressions;

namespace P1_AP1_JoseOrtega.Services;

public class EntradasHuacalesServices(IDbContextFactory<Contexto> DbFactory)
{
    private async Task<bool> Existe(int  idhuacales)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.EntradasHuacales.AnyAsync(e => e.IdEntrada == idhuacales);
    }


    private async Task<bool> Insertar(EntradasHuacales huacales)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        contexto.EntradasHuacales.Add(huacales);
        return await contexto.SaveChangesAsync() > 0;
    }

    private async Task<bool> Modificar(EntradasHuacales huacales)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        contexto.EntradasHuacales.Update(huacales);
        return await contexto.SaveChangesAsync() > 0;
    }

    public async Task<bool> Guardar(EntradasHuacales huacales)
    {
        if (!await Existe(huacales.IdEntrada))
        {
            return await Insertar(huacales);
        }
        else 
        {
            return await Modificar(huacales);
        }
    }

    public async Task<EntradasHuacales?> Buscar(int idhuacales)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.EntradasHuacales.FirstOrDefaultAsync(e => e.IdEntrada == idhuacales);
    }

    public async Task<bool> Eliminar(int idhuacales)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.EntradasHuacales.Where(e => e.IdEntrada == idhuacales).AsNoTracking().ExecuteDeleteAsync() > 0;
    }

    public async Task<List<EntradasHuacales>> Listar(Expression<Func<EntradasHuacales, bool>> criterio)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.EntradasHuacales
            .Where(criterio)
            .AsNoTracking()
            .ToListAsync();
    }

}
