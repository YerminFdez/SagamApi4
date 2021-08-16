using Data;
using Data.Interfaces;
using System.Net.NetworkInformation;

namespace SagamApi4.Services
{
    public static class ConnectionHelper
    {
        public static IConnectionFactory GetConnection()
        {
            try
            {
                return new DbConnectionFactory("Sagam");
            }
            catch (System.Exception ex)
            {                
                throw ex;
            }
           
        }

        internal static DbContext GetContext()
        {
            try
            {
                return new DbContext(GetConnection());
            }
            catch (System.Exception ex)
            {                
                throw ex;
            }            
        }

        public static bool PingHost(string nameOrAddress)
        {
            if(nameOrAddress.Contains(","))
            {
                int index = nameOrAddress.IndexOf(',');
                nameOrAddress = nameOrAddress.Substring(0, index);
            }


            bool pingable = false;
            Ping pinger = null;

            try
            {                
                pinger = new Ping();                
                PingReply reply = pinger.Send(nameOrAddress);                
                pingable = reply.Status == IPStatus.Success;
            }
            catch (PingException pe)
            {
                throw pe;
            }
            finally
            {
                if (pinger != null)
                {
                    pinger.Dispose();
                }
            }

            return pingable;
        }
    }
}
