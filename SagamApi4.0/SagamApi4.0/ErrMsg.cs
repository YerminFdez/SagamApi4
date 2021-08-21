using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SagamApi4
{
    public static class ErrMsg
    {
        public static Exception GetErr(int err)
        {
            string msg;
            switch (err)
            {
                case -532462766:
                    msg = "Los datos suministrado no son validos";
                    break;
                default:
                    msg = "Ha ocurrido un error";
                    break;
            }

            return new Exception(msg);
        }
    }
}