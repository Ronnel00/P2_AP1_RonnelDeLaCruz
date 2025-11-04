using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using P2_AP1_RonnelDeLaCruz.DAL;
using P2_AP1_RonnelDeLaCruz.Models;

namespace P2_AP1_RonnelDeLaCruz.Services;

public class PedidosService(IDbContextFactory<Contexto> DbFactory)
{
    public async Task<bool> ExisteAsync(int pedidoId)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.Pedidos.AnyAsync(p => p.PedidoId == pedidoId);
    }

    public async Task<bool> InsertarAsync(Pedidos pedido)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();

        pedido.Total = pedido.Detalles.Sum(d => d.Cantidad * d.Precio);
        contexto.Pedidos.Add(pedido);

        await ActualizarExistenciaAsync(pedido.Detalles.ToArray(), TipoOperacion.Restar);
        return await contexto.SaveChangesAsync() > 0;
    }

    private async Task ActualizarExistenciaAsync(PedidosDetalle[] detalles, TipoOperacion operacion)
    {
        if (detalles.Length == 0)
            return;

        await using var contexto = await DbFactory.CreateDbContextAsync();

        foreach (var det in detalles)
        {
            var componente = await contexto.Componentes.FirstOrDefaultAsync(c => c.ComponenteId == det.ComponenteId);
            if (componente == null)
                continue;

            switch (operacion)
            {
                case TipoOperacion.Restar:
                    componente.Existencia -= det.Cantidad;
                    break;
                case TipoOperacion.Sumar:
                    componente.Existencia += det.Cantidad;
                    break;
            }
        }

        await contexto.SaveChangesAsync();
    }

    public async Task<bool> ModificarAsync(Pedidos pedido)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();

        var pedidoAnterior = await contexto.Pedidos
            .Include(p => p.Detalles)
            .AsNoTracking()
            .FirstOrDefaultAsync(p => p.PedidoId == pedido.PedidoId);

        if (pedidoAnterior == null)
            return false;

        await ActualizarExistenciaAsync(pedidoAnterior.Detalles.ToArray(), TipoOperacion.Sumar);

        pedido.Total = pedido.Detalles.Sum(d => d.Cantidad * d.Precio);
        await ActualizarExistenciaAsync(pedido.Detalles.ToArray(), TipoOperacion.Restar);

        contexto.Pedidos.Update(pedido);
        return await contexto.SaveChangesAsync() > 0;
    }

    public async Task<bool> GuardarAsync(Pedidos pedido)
    {
        if (!await ExisteAsync(pedido.PedidoId))
            return await InsertarAsync(pedido);
        else
            return await ModificarAsync(pedido);
    }

    public async Task<Pedidos?> BuscarAsync(int pedidoId)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();

        return await contexto.Pedidos
            .Include(p => p.Detalles)
            .ThenInclude(d => d.Componente)
            .FirstOrDefaultAsync(p => p.PedidoId == pedidoId);
    }

    public async Task<bool> EliminarAsync(int pedidoId)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();

        var pedido = await contexto.Pedidos
            .Include(p => p.Detalles)
            .FirstOrDefaultAsync(p => p.PedidoId == pedidoId);

        if (pedido == null)
            return false;

        await ActualizarExistenciaAsync(pedido.Detalles.ToArray(), TipoOperacion.Sumar);

        contexto.PedidosDetalles.RemoveRange(pedido.Detalles);
        contexto.Pedidos.Remove(pedido);
        return await contexto.SaveChangesAsync() > 0;
    }

    public async Task<List<Pedidos>> ObtenerListaAsync(Expression<Func<Pedidos, bool>> criterio)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();

        return await contexto.Pedidos
            .Include(p => p.Detalles)
            .ThenInclude(d => d.Componente)
            .Where(criterio)
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<List<Componente>> ObtenerComponentesAsync()
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.Componentes.AsNoTracking().ToListAsync();
    }

    public enum TipoOperacion
    {
        Sumar = 1,
        Restar = 2
    }
}
