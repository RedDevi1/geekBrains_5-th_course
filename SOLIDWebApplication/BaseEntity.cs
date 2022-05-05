using System.ComponentModel.DataAnnotations.Schema;

namespace SOLIDWebApplication
{
    public class BaseEntity<TUniqueId> where TUniqueId : struct
    {
        public TUniqueId Id { get; set; }
        public bool IsDeleted { get; set; }
    }
}
