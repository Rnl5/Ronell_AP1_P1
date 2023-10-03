using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Ronell_AP1_P1.DAL;

public class AportesBLL
{
    private readonly Context _context;

    public AportesBLL(Context context)
    {
        _context = context;
    }

    public bool YaExiste(int AporteId)
    {
        return _context.Aportes.Any(a => a.AporteId == AporteId);
    }

    public bool Insertar(Aportes aportes)
    {
        _context.Aportes.Add(aportes);
        return _context.SaveChanges() > 0;
    }
    
    public bool Modificar(Aportes aportes)
    {
        _context.Entry(aportes).State = EntityState.Modified;
        return _context.SaveChanges() > 0;
    }

    public bool Guardar(Aportes aportes)
    {
        if(!YaExiste(aportes.AporteId))
        {
            return Insertar(aportes);
        }
        else
        {
            return Modificar(aportes);
        }
    }

    public bool Eliminar(Aportes aportes)
    {
        _context.Entry(aportes).State = EntityState.Deleted;
        return _context.SaveChanges() > 0;
    }

    public Aportes? Buscar(int AporteId)
    {
        return _context.Aportes
                .Where(a => a.AporteId == AporteId)
                .AsNoTracking()
                .SingleOrDefault();
    }

    public List<Aportes> GetAportes(Expression<Func<Aportes, bool>> Criterio)
    {
        return _context.Aportes
                .AsNoTracking()
                .Where(Criterio)
                .ToList();  
    }

    public bool ExistenDatos(Aportes aportes)
    {
        var mismosDatos = _context.Aportes.Any(a => a.Fecha == aportes.Fecha || a.Persona == aportes.Persona || a.Observacion == aportes.Observacion || a.Monto == aportes.Monto);
        return !mismosDatos;
    }
}