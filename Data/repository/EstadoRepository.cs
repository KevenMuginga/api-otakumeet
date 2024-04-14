using Core.domain;
using Data.context;
using Manager.interfaces.repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.repository
{
    public class EstadoRepository: IEstadoRepository
    {
        private readonly Context _context;

        public EstadoRepository(Context context)
        {
            this._context = context;
        }

        public async Task<ICollection<Estado>> GetAllAsync()
        {
            return await _context.Estado
                .AsNoTracking()
                .ToListAsync();
        }
        public async Task<Estado> GetByIdAsync(int Id)
        {
            return await _context.Estado
                .AsNoTracking()
                .SingleOrDefaultAsync(p => p.Id == Id);
        }

        public async Task<Estado> PostAsync(Estado estado)
        {
            await _context.Estado.AddAsync(estado);
            await _context.SaveChangesAsync();
            return estado;
        }

        public async Task<Estado> PutAsync(Estado estado)
        {
            var estadoConsultado = await _context.Estado.FindAsync(estado.Id);
            if (estadoConsultado == null)
            {
                return null;
            }

            _context.Entry(estadoConsultado).CurrentValues.SetValues(estado);

            await _context.SaveChangesAsync();
            return estado;
        }

        public async Task DeleteAsync(int Id)
        {
            var estadoConsultado = await _context.Estado.FindAsync(Id);
            if (estadoConsultado == null)
            {

            }

            _context.Estado.Remove(estadoConsultado);
            await _context.SaveChangesAsync();
        }
    }
}
