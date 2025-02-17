using FluentNHibernate.Conventions.Helpers;
using FluentNHibernate.Mapping;
using FluentNHybernateCRUD.Models;

namespace FluentNHybernateCRUD.Mappings
{
    public class empmap : ClassMap<employee>
    {
        public empmap() 
        {
            Table("employee");
            Id(x => x.Id).GeneratedBy.Identity();
            Map(x => x.name).Not.Nullable();
            Map(x => x.dept).Not.Nullable();
            Map(x => x.salary).Not.Nullable();
        } 
    }
}
