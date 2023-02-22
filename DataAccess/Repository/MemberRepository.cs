using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class MemberRepository : IMemberRepository
    {
        private MemberDAO _MemberDAO;



        public MemberRepository()
        {
            _MemberDAO = new MemberDAO();
        }


        public int Login(string email, string password)
        {
            return _MemberDAO.countAcc(email, password);
        }

        public List<Member> ReadAll()
        {
            return _MemberDAO.getAll();
        }
        public int EmailCount(string email)
        {
            return _MemberDAO.countEmail(email);
        }

        public void Create(Member member)
        {
            _MemberDAO.addNew(member);
        }

        public Member GetById(int memberId)
        {
            return _MemberDAO.getById(memberId);
        }

        public void Update(int memberId, Member member)
        {
            _MemberDAO.update(memberId, member);
        }

        public void Remove(int memberId)
        {
            _MemberDAO.delete(memberId);
        }

        public Member GetByEmail(string email)
        {
            return _MemberDAO.getByEmail(email);
        }

        public List<Member> ReadKey(string key)
        {
            return _MemberDAO.getAllKey(key);
        }
    }
}
