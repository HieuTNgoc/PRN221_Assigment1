using BusinessObject;
using DataAccess.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class MemberDAO
    {
        private Asm1PRNContext _Context;
        private string _AdminEmail;
        private string _AdminPassword;
        
        public MemberDAO()
        {
            _Context = DataProvider.Ins.DB;
            var Member = _Context.Members.FirstOrDefault();
            _AdminEmail = _Context.AdminEmail;
            _AdminPassword = _Context.AdminPassword;
        }

        public int countAcc(string email, string password)
        {
            if (email == _AdminEmail && password == _AdminPassword) return -1;
            return _Context.Members.Where(x => x.Email == email && x.Password == password).Count();
        }

        public int countEmail(string email)
        {
            if (email == _AdminEmail) return -1;
            return _Context.Members.Where(x => x.Email == email).Count();
        }
        public List<Member> getAll()
        {
            return _Context.Members.ToList();
        }

        public List<Member> getAllKey(string key)
        {
            return _Context.Members.Where(x=> x.Email.Contains(key)).ToList();

        }
        public Member getById(int memberId)
        {
            return _Context.Members.Where(x => x.MemberId == memberId).SingleOrDefault();
        }

        public Member getByEmail(string email)
        {
            return _Context.Members.Where(x=> x.Email == email).SingleOrDefault();  
        }

        public void addNew(Member member)
        {
            try
            {
                _Context.Members.Add(member);
                _Context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void update(int memberId, Member member)
        {
            try
            {
                var mem = _Context.Members.Where(x=>x.MemberId == memberId).SingleOrDefault();
                if (mem == null)
                {
                    throw new Exception("Can not read selected Member!");
                }
                mem.CompanyName = member.CompanyName;
                mem.City = member.City;
                mem.Country = member.Country;
                mem.Password = member.Password;
                mem.Email = member.Email;
                _Context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void delete(int memberId)
        {
            try
            {
                var mem = _Context.Members.Where(x => x.MemberId == memberId).SingleOrDefault();
                if (mem == null)
                {
                    throw new Exception("Can not read selected Member!");
                }
                _Context.Members.Remove(mem);
                _Context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


    }
}
