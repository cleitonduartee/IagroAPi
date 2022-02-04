using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.ExceptionPersonalizada
{
    [Serializable]
    public class NotFoundExceptionPersonalizado : Exception
    {
        public NotFoundExceptionPersonalizado(string msg) : base(msg) { }
    }
}
