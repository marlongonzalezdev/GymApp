namespace GymAppMovil
{
    public class ServiceConfig
    {
        #region baseUrl
        public const string baseUrl = "http://192.168.1.2:45457/";
        #endregion        

        #region endpoints
        public const string getUser = "GetUser";
        #endregion

        private static ServiceConfig instance = null;

        protected ServiceConfig() { }

        public static ServiceConfig Instance
        {
            get
            {
                if (instance == null)
                    instance = new ServiceConfig();

                return instance;
            }
        }
    }
}
