﻿using Microsoft.EntityFrameworkCore;
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

    private async Task AfectarExistencia(EntradasHuacalesDetalle[] detalle, TipoOperacion tipoOperacion)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        foreach(var item in detalle)
        {
            var tipoHuacal = await contexto.TiposHuacales.SingleAsync(e => e.TipoId == item.TipoId);
            if (tipoOperacion == TipoOperacion.Resta)
                tipoHuacal.Existencia -= item.Cantidad;
            else
                tipoHuacal.Existencia += item.Cantidad;
            await contexto.SaveChangesAsync();
        }
    }


    private async Task<bool> Insertar(EntradasHuacales huacales)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        contexto.EntradasHuacales.Add(huacales);
        await AfectarExistencia(huacales.EntradaHuacaleDetalle.ToArray(), TipoOperacion.Suma);
        return await contexto.SaveChangesAsync() > 0;
    }

    private async Task<bool> Modificar(EntradasHuacales huacales)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        var original = await contexto.EntradasHuacales
            .Include(e => e.EntradaHuacaleDetalle)
            .AsNoTracking()
            .SingleOrDefaultAsync(e => e.IdEntrada == huacales.IdEntrada);

        if (original == null) return false;

        await AfectarExistencia(original.EntradaHuacaleDetalle.ToArray(), TipoOperacion.Resta);

        contexto.entradasHuacalesDetalles.RemoveRange(original.EntradaHuacaleDetalle);

        contexto.Update(huacales);

        await AfectarExistencia(huacales.EntradaHuacaleDetalle.ToArray(), TipoOperacion.Suma);

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
        return await contexto.EntradasHuacales.Include(e => e.EntradaHuacaleDetalle).FirstOrDefaultAsync(e => e.IdEntrada == idhuacales);
    }

    public async Task<bool> Eliminar(int idhuacales)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        var entrada = await Buscar(idhuacales);

        await AfectarExistencia(entrada.EntradaHuacaleDetalle.ToArray(), TipoOperacion.Resta);
        contexto.entradasHuacalesDetalles.RemoveRange(entrada.EntradaHuacaleDetalle);
        contexto.EntradasHuacales.Remove(entrada);
        return await contexto.SaveChangesAsync() > 0;
    }

    public async Task<List<EntradasHuacales>> Listar(Expression<Func<EntradasHuacales, bool>> criterio)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.EntradasHuacales.
            Include(d => d.EntradaHuacaleDetalle)
            .Where(criterio)
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<List<TiposHuacales>> ListarTipos()
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.TiposHuacales.Where(t => t.TipoId > 0).AsNoTracking().ToListAsync();
    }

    public enum TipoOperacion
    {
        Suma = 1,
        Resta = 2
    }

}
