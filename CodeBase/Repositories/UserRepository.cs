using CodeBase.Context;
using CodeBase.Model;
using System.Collections.Generic;
using System.Linq;

namespace CodeBase.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationContext _context;
        public UserRepository(ApplicationContext context)
        {
            _context = context;
        }
        //Get all dusers
        public IEnumerable<User> GetAll()
        {
            return _context.User.ToList();
        }
        ////Get Departments by Id
        //public Department GetDeptById(short deptId)
        //{
        //    var deptData = _context.Department.Where(d => d.DepartmentID == deptId).FirstOrDefault();
        //    return deptData;
        //}
        //public IEnumerable<EmployeeDepartmentHistory> GetEmpDeptById(short deptId)
        //{
        //    var list = _context.EmployeeDepartmentHistory.Where(d => d.DepartmentID == deptId).ToList();
        //    return list;
        //}
        ////from Person.Person table, (int BusinessEtityID )
        //public Person GetPersonById(int Id)
        //{
        //    Person prn = _context.Person.Where(p => p.BusinessEntityID == Id).FirstOrDefault();
        //    return prn;
        //}
        ////from Person.EmailAddress table (int BusinessEtityID)
        //public PersonEmailAddress GetEmailById(int Id)
        //{
        //    PersonEmailAddress EAddress = _context.EmailAddress.Where(e => e.BusinessEntityID == Id).FirstOrDefault();
        //    return EAddress;
        //}
    }
}
