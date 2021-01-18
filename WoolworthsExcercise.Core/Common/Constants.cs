namespace WoolworthsExcercise.Core.Common
{
    public class Constants
    {
        //TODO can be retrived from appseting
        public const string UserName = "Test";
        public static class Environment
        {
            
            public static class ConfigurationNames
            {

                public const string MinimumLogLevel = "minimumLogLevel";
                public const string WoolworthsApiKeyBaseUrl = "http://dev-wooliesx-recruitment.azurewebsites.net";
                public const string WoolworthsApiKey = "10795aeb-8afa-45ff-a823-331b613108f0";
            }
        }
        public static class ErrorCodes
        {
            public static class TrolleyRequest
            {
                public const string InvalidObjectInRequest = "203";
            }
        }
        public static class ValidatorMessages
        {
            internal const string InvalidObjectInRequest = "Invalid object provided in the request.";
            internal const string EmptyBodyRequest = "Empty object provided in the request.";
        }
    }
}
