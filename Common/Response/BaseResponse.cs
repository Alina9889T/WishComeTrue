using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WishComeTrue.Common.Enum;

namespace WishComeTrue.Common.Response
{
    public interface IBaseResponse<T>
    {
        string Description { get; }
        StatusCode StatusCode { get; }
        T Data { get; }
    }
    public class BaseResponse<T> : IBaseResponse<T>
    {
        public string Description { get; set; }
        public StatusCode StatusCode { get; set; }
        public T Data { get; set; }
    }
}
