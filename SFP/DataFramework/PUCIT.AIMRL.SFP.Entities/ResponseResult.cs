using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PUCIT.AIMRL.SFP.Entities
{
    public class ResponseResult
    {
        public Boolean success { get; set; }
        public String error { get; set; }
        public String msg { get; set; }
        public Object data { get; set; }

        public static ResponseResult GetErrorObject(String e = "Some error has occurred!")
        {
            var obj = new ResponseResult()
            {
                success = false,
                error = e,
                msg=e
            };
            return obj;
        }
        public static ResponseResult GetSuccessObject(Object d=null,String msg = "")
        {
            var obj = new ResponseResult()
            {
                success = true,
                data = d,
                msg = msg
            };
            return obj;
        }
    }
}
