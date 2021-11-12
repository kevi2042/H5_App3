namespace AppProjekt.Constants
{
    public class ApiConstants
    {
        //public const string BaseApiUrl = "https://10.0.2.2:5001/";
        //public const string MeasurementEndpoint = "api/measurement"; // local web api

        public const string BaseApiUrl = "https://api.thingspeak.com/";
        public const string ReadEndpoint = "channels/1558340/";
        public const string WriteEndpoint = "update";

        public const string Feeds = "feeds.json";

        public const string Write_API_Key = "59XRPZUY21ZSBYH1";            // My thingspeak API Key
        public const string Read_API_Key = "0754RWY57WEPKRFQ";             // My thingspeak API Key
    }
}
