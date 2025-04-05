﻿namespace Ecom.Api.Helper
{
    public class ResponseAPI
    {
        public ResponseAPI(int statusCode, string? message=null)
        {
            StatusCode = statusCode;
            Message = message??GetMessageFromStatusCode(statusCode);
        }

        private string GetMessageFromStatusCode(int statuscode)
        {
            return statuscode switch
            {
                200 => "Done",
                400 => "Bad Request",
                401 => "Un Authorized",
                500 => "server Error",
                _=> null
            };
        }
        public int StatusCode { get; set; }
        public string? Message { get; set; }
    }
}
