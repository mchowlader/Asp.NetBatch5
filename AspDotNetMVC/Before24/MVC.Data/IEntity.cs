using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC.Data
{
    public interface IEntity<Tkey>
    {
        Tkey Id { get; set; }
    }
}
