using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public interface IMemberRepository
    {
        public int Login(string email, string password);
        public List<Member> ReadAll();
        public List<Member> ReadKey(string key);

        public int EmailCount(string email);
        
        public Member GetById(int memberId);
        public Member GetByEmail(string email);

        public void Create(Member member);
        public void Update(int memberId, Member member);
        public void Remove(int memberId);

    }
}
