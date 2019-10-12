using System;
using System.Collections.Generic;

namespace HRM.Model.Entities.Factory
{
    public class Factory : BaseEntity
    {
        public string Name { get; set; }

        public ICollection<Unit.Unit> Units { get; set; }
    }
}