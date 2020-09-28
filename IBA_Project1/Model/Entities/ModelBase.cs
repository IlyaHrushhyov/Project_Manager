using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBA_Project1.Model.Entities
{
    public abstract class ModelBase: IEntity
    {
        public int Id { get; set; }
    }
}
