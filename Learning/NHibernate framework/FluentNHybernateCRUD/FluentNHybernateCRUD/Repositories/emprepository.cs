using System.Transactions;
using FluentNHybernateCRUD.Helper;
using FluentNHybernateCRUD.Models;

namespace FluentNHybernateCRUD.Repositories
{
    public class emprepository
    {
        public void add(employee employee)
        {
            using(var session=nhibernatehelper.OpenSession())
            using(var transaction = session.BeginTransaction())
            {
                session.Save(employee);
                transaction.Commit();
            }   
        }
        public List<employee> getall() 
        {
            using (var session = nhibernatehelper.OpenSession())
            {
                var ans=session.Query<employee>().ToList();
                if (ans == null)
                {
                    return new List<employee>();
                }
                return ans;
            }
        }
        public employee getbyid(int id) 
        {
            using (var session = nhibernatehelper.OpenSession())
            {
                if (id <= 0)
                {
                    return null;
                }
                var ans = session.Get<employee>(id);
                return ans;
            }
        }

        public void Update(employee employee) 
        { 
            using (var session = nhibernatehelper.OpenSession())
            using (var transaction = session.BeginTransaction())
            {
                session.Update(employee); 
                transaction.Commit();
            }
        }

        public void Delete(int id) 
        {
            using (var session = nhibernatehelper.OpenSession())
            using (var transaction = session.BeginTransaction()) 
            {
                var stuid = session.Get<employee>(id);
                if( stuid != null)
                {
                    session.Delete(stuid);
                    transaction.Commit();
                }
            }
                
        }
    }
}
