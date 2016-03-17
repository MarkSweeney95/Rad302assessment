using Rad302Assingment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rad302Assingment.DAL
{
    interface IBossRepo : IDisposable
    {
        IEnumerable<Bosses> GetBosses();
        Bosses Get
    }
}
