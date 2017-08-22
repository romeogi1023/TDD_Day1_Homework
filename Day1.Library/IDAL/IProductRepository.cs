using Day1.Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day1.Library.IDAL
{
    public partial interface IProductRepository
    {
        List<Product> GetAll();
    }
}
