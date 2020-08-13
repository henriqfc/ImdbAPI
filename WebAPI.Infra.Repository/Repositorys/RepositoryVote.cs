using Modelo.Domain.Core.Interfaces.Repositorys;
using Modelo.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WepAPI.Infra.Data;

namespace WebAPI.Infra.Repositorys.Repositorys
{
    public class RepositoryVote : RepositoryBase<Vote>, IRepositoryVote
    {
        private readonly SqlContext _context;
        public RepositoryVote(SqlContext Context)
            : base(Context)
        {
            _context = Context;
        }

        public override void Update(Vote obj)
        {
            var local = _context.Set<Vote>().Local.FirstOrDefault(entry => entry.Id == obj.Id);

            if (local != null)
            {
                _context.Entry(local).State = Microsoft.EntityFrameworkCore.EntityState.Detached;
            }

            base.Update(obj);
        }
        public override void Remove(Vote obj)
        {
            var local = _context.Set<Vote>().Local.FirstOrDefault(entry => entry.Id == obj.Id);

            if (local != null)
            {
                _context.Entry(local).State = Microsoft.EntityFrameworkCore.EntityState.Detached;
            }

            base.Remove(obj);
        }
    }
}
