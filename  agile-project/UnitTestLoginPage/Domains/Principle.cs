using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BookStoreTests
{
    public class Principle
    {
        public int ID { set; get; }
        public string Username { set; get; }
        public string Password { set; get; }

        public Boolean LogIn(string userName, string passWord)
        {
            var dbUser = new DALUserPrinciple();
            Principle user = dbUser.LogIn(userName, passWord);
            if (user != null)
            {
                ID = 1;
                Username = user.Username;
                Password = user.Password;
                return true;
            }
            else
            {
                ID = -1;
                return false;
            }

        }

        public Boolean SignUp(string userName, string passWord)
        {

            if(userName == null || userName == "" || passWord == null || passWord == "")
            {
                ID = -1;
                return false;
            }
            else
            {
                var rUser = new DALUserPrinciple();
                Principle userR = rUser.LogIn(userName, passWord);

                if (userR == null)
                {

                    ID = 1;
                    return true;
                    /*  int userid = rUser.SignUp(userName, passWord);

                      if (userid >= 0 )
                      {
                          ID = 1;
                          return true;
                      }
                      else
                      {
                          ID = -1;
                          return false;
                      } */
                }
                else
                {
                    ID = -1;
                    return false;
                }
            }
            
        }

    }
}