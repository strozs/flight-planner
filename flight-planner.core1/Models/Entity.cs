using flight_planner.core1.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace flight_planner.core1.Models
{
    public abstract class Entity : IEntity
    {
        public int Id { get; set; }
    }
}
