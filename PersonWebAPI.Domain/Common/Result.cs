using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonWebAPI.Domain.Common
{
    public class Result<T>
    {

        public bool IsSucces { get; }

        public bool IsFailer => !IsSucces;

        public T Value { get; }

        public string Error { get; }


        protected Result(T value, bool isSucces, string error)
        {
            IsSucces = isSucces;
            Value = value;
            Error = error;
        }

        public static Result<T> Success(T value) => new Result<T>(value, true, null);

        public static Result<T> Failure(string error) => new Result<T>(default,false, error);
       
    }
}
