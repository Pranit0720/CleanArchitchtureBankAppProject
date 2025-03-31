using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp.Application.Exceptions
{
    public class InsufficientBalance:Exception
    {
        public InsufficientBalance(string msg):base(msg)
        {
            
        }
    }
}
