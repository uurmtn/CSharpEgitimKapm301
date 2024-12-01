using CSharpEgitimKapm301.DataAccessLayer.Abstract;
using CSharpEgitimKapm301.DataAccessLayer.Repositories;
using CSharpEgitimKapm301.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpEgitimKapm301.DataAccessLayer.EntityFramework
{
    public class EfAdminDal : GenericRepository<Admin>, IAdminDal
    {

    }
}
