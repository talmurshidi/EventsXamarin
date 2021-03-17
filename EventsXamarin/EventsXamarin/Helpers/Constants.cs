using System;
using System.Collections.Generic;
using System.Text;

namespace EventsXamarin.Helpers
{
    public static class Constants
    {
        public const string DateFormat = "MM/dd/yyyy";

        //Language abbreviation
        public const string EnglishLang = "en";

        //Http status code
        public const int Success = 200;
        public const int Unauthorized = 401;
        public const int NotFound = 404;
        public const int ServerError = 500;
        public const int Unproccessable = 422;
        public const int ServerTimeout = 408;
        public const int NotModified = 304;
        public const int Created = 201;
        public const int Forbidden = 403;
        public const int NoContent = 204;
        public const int BadRequest = 400;
        public const int TooManyRequests = 429;
    }
}
