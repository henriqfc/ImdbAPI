using Modelo.Domain.Core.Interfaces.Repositorys;
using Modelo.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WepAPI.Infra.Data;

namespace WebAPI.Infra.Repositorys.Repositorys
{
    public class RepositoryUser : RepositoryBase<User>, IRepositoryUser
    {
        private readonly SqlContext _context;
        public RepositoryUser(SqlContext Context)
            : base(Context)
        {
            _context = Context;
        }

        public override void Update(User obj)
        {
            var local = _context.Set<User>().Local.FirstOrDefault(entry => entry.Id == obj.Id);

            if (local != null)
            {
                _context.Entry(local).State = Microsoft.EntityFrameworkCore.EntityState.Detached;
            }

            base.Update(obj);
        }
        public override void Remove(User obj)
        {
            var local = _context.Set<User>().Local.FirstOrDefault(entry => entry.Id == obj.Id);

            if (local != null)
            {
                _context.Entry(local).State = Microsoft.EntityFrameworkCore.EntityState.Detached;
            }

            base.Remove(obj);
        }

        public IEnumerable<User> GetAll(bool isAdmin)
        {
            return _context.Users.Where(u => u.isAdmin == isAdmin);
        }
    }
}
