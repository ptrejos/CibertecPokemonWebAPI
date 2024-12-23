using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cibertec.Pokemon.Application.Common
{
    public interface IResult
    {
        bool HasSucceeded { get; }
    }

    public interface IResult<T> : IResult
    {
        T Value { get; }
    }

    public class SuccessResult : IResult
    {

        public SuccessResult()
        {
            HasSucceeded = true;
        }

        public bool HasSucceeded { get; private set; }
    }

    public class SuccessResult<T> : IResult<T>
    {

        public SuccessResult() => HasSucceeded = true;

        public SuccessResult(T value) : this() => Value = value;

        public T Value { get; }

        public bool HasSucceeded { get; }

    }
    public class FailureResult : IResult
    {
        public bool HasSucceeded { get; private set; }

    }

    public class FailureResult<T> : IResult where T : class
    {

        public FailureResult(DetailEror detailEror) => HasSucceeded = false;

        public FailureResult(string errors)
        {

            Value = (new Dictionary<string, string>());
            Value.Add("ERROR", errors);
        }

        public bool HasSucceeded { get; private set; }

        public Dictionary<string, string> Value { get; set; }

    }


    public class DetailEror
    {

        public string ErrorCode { get; set; }
        public string Message { get; set; }

        public DetailEror(string errorCode, string message)
        {

            ErrorCode = errorCode;
            Message = message;
        }

    }
}
