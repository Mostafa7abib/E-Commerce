using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Product : BaseEntity<int>
    {
        //public int Id { get; set; } inherited from BaseEntity
        public string Name { get; set; }
        public string Description { get; set; }
        public string PictureUrl { get; set; }
        public decimal Price { get; set; }
        #region Relation
        #region ProductBrand
        //Navigational property [One {ProductBrand}]
        public ProductBrand ProductBrand { get; set; }
        //Foreign key
        public int BrandId { get; set; }
        #endregion
        #region ProductType
        //Navigational property [One {ProductType}]
        public ProductType ProductType { get; set; }
        //Foreign key
        public int TypeId { get; set; } 
        #endregion 
        #endregion
    }
}
