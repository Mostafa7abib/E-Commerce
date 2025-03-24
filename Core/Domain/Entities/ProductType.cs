using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class ProductType : BaseEntity<int>
    {
        //public int Id { get; set; } inherited from BaseEntity
        public string Name { get; set; }
    }
}
