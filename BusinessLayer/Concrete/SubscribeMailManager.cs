using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Concrete
{
    public class SubscribeMailManager
    {
        Repository<SubscribeMail> repoSubscribeMail = new Repository<SubscribeMail>();
        public int BLAdd(SubscribeMail P)
        {
            if (P.Mail.Length <= 10 || P.Mail.Length >= 50)
            {
                return -1;
            }
            return repoSubscribeMail.Insert(P);
        }
    }
}
