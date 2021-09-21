using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20210730_BattleShipOOP
{
    class OutOfFieldException : Exception
    {
       
        public OutOfFieldException()
        {

        }

        public OutOfFieldException(string message)
        {

        }

        public OutOfFieldException(string message, Exception innerException)
        {
            
        }

    }
}
