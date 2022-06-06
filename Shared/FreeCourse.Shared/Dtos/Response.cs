using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace FreeCourse.Shared.Dtos
{
    public class Response<T>
    {
        public T Data { get; private set; }

        [JsonIgnore]
        public int StatusCode { get; private set; }
        [JsonIgnore]
        public bool IsSuccessful { get; private set; }
        public List<string> Errors { get; set; }
        //static factory method 
        public static Response<T> Success(T Data, int StatusCode)
        {
            return new Response<T> { Data = Data, StatusCode = StatusCode, IsSuccessful = true };
        }
        public static Response<T> Success(int StatusCode)
        {
            return new Response<T> { Data = default(T), StatusCode = StatusCode, IsSuccessful = true };
        }
        public static Response<T> Fail(List<string> errors, int StatusCode)
        {
            return new Response<T>
            {
                Errors = errors,
                StatusCode = StatusCode,
                IsSuccessful = false
            };
        }
        public static Response<T> Fail(string error, int StatusCode)
        {
            return new Response<T>
            {
                Errors = new List<string>() { error },
                StatusCode = StatusCode,
                IsSuccessful = false
            };
        }
    }
}
