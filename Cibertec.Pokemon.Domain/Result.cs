﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cibertec.Pokemon.Domain
{
    public class Result<T>
    {

        public bool IsSuccess { get; }
        public T Data { get; }
        public string Error { get; }

        private Result(bool isSuccess, T data, string error)
        {
            IsSuccess = isSuccess;
            Data = data;
            Error = error;
        }

        public static Result<T> Success(T data) => new(true, data, null);
        public static Result<T> Failure(string error) => new(false, default, error);
    }
}
