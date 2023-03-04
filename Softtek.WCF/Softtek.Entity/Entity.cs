using Softtek.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Softtek.Entity
{
    public abstract class Entity : IEntity
    {
        public int Id { get; set; }
    }
}
