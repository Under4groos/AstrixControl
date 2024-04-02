using System.Net;
using System.Net.Sockets;
using System.Text;

namespace sv_AstrixControl.Module
{
    public class ThreadUdpClient : IDisposable
    {
        private UdpClient _udp;

        public ThreadUdpClient() { }
        public ThreadUdpClient(int port = 8888)
        {
            _udp = new UdpClient(port);
        }
        private IPEndPoint ClientEp = new IPEndPoint(IPAddress.Any, 0);
        public Action<IPAddress, string> EvRequestData;
        public void Send(string data)
        {
            var ResponseData = Encoding.ASCII.GetBytes(data);
            _udp.Send(ResponseData, ResponseData.Length, ClientEp);
        }
        public void Init()
        {
            new Thread(() =>
            {
                while (true)
                {
                    var ClientRequestData = _udp.Receive(ref ClientEp);
                    string ClientRequest = Encoding.UTF8.GetString(ClientRequestData);
                    if (EvRequestData != null)
                        EvRequestData(ClientEp.Address, ClientRequest);
                }
            }).Start();
        }
        public void Dispose()
        {
            _udp.Dispose();
        }
    }
}
