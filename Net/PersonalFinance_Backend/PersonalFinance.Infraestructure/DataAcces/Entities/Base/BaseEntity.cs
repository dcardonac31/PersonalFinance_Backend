using System;

namespace PersonalFinance.Infraestructure.DataAcces.Entities.Base
{
    public abstract class BaseEntity
    {
        public DateTime? CreationDate { get; set; }
        public string CreationUser { get; set; }
        public DateTime? ModificationDate { get; set; }
        public string ModificationUser { get; set; }
        public bool Deleted { get; set; }
    }
}
