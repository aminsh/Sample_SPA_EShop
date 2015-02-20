using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core;
using Domain.Data;
using Domain.Model;

namespace Domain.Service.Utility
{
    public static class Repository<TModel> where TModel : EntityBase
    {
        public static IRepositoy<TModel> Instance
        {
            get { return DependencyManager.Resolve<IUnitOfWork>().GetRepository<TModel>(); }
        }
    }
}
