using System.Diagnostics;
using System.Net;
using System.Net.Sockets;
using System.Text;
namespace AstrixControl.Module
{
    public class NetUdpClient : UdpClient
    {

        public void SendString(string data, IPEndPoint? endPoint)
        {

            var RequestData = Encoding.UTF8.GetBytes(data);
            Send(RequestData, RequestData.Length, endPoint ?? new IPEndPoint(IPAddress.Broadcast, 8888));
        }

        public string ReadString()
        {
            byte[] bytes_data = { };
            IPEndPoint ServerEp = new IPEndPoint(IPAddress.Any, 0);
            try
            {
                bytes_data = Receive(ref ServerEp);
            }
            catch (System.Exception e)
            {

                Debug.WriteLine(e.Message);
            }
            return Encoding.UTF8.GetString(bytes_data);
        }
    }
}
