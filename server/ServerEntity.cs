using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace server
{
    class ServerEntity
    {
        private List<ClientEntity> _clients = new List<ClientEntity>();
        private TcpListener _listener;
        private string _ip;
        private int _port;

        public ServerEntity(string ip = "127.0.0.1", int port = 8080)
        {
            _ip = ip;
            _port = port;
        }
        public void Listen()
        {
            try
            {
                _listener = new TcpListener(IPAddress.Parse(_ip), _port);
                _listener.Start();

                Console.WriteLine($"Server started at {_ip}:{_port}");

                while (true)
                {
                    TcpClient tcpClient = _listener.AcceptTcpClient();

                    ClientEntity client = new ClientEntity(tcpClient, this);
                    _clients.Add(client);

                    new Thread(client.Processing).Start();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"ERROR: {ex.Message}");

                DisconnectAll();
            }
        }
        public void Broadcast(Parcel parcel, string id)
        {
            bool uniq = true;
            List<string> nicks = new List<string>();
            foreach (ClientEntity client in _clients)
                nicks.Add(client.Username);
            for (int i = 0; i < _clients.Count; ++i)
                for (int j = i + 1; j < _clients.Count; ++j)
                {
                    if (_clients[i].Username == _clients[j].Username)
                    {
                        uniq = false;
                        break;
                    }
                };
            if (!uniq )
            {
                parcel.message = $"Nickname already used. Try again";
                parcel.nickname = string.Empty;
                nicks.Remove(parcel.nickname);
            }
            parcel.something = Serializer(nicks);
            byte[] data = Encoding.UTF8.GetBytes(Serializer(parcel));
            for (int i = 0; i < _clients.Count; ++i)
            {
                _clients[i].SendMessage(data);
            }
        }
        private string Serializer(object value)
        {
            using (TextWriter writer = new StringWriter())
            {
                JsonSerializer serializer = new JsonSerializer();
                serializer.Serialize(writer, value);
                return writer.ToString();
            }
        }
        public void DisconnectClient(string id)
        {
            ClientEntity client = _clients.FirstOrDefault(c => c.Id == id);
            if (client != null)
                _clients.Remove(client);
        }
        public void DisconnectAll()
        {
            _listener?.Stop();
            for (int i = 0; i < _clients.Count; ++i)
                _clients[i].Disconnect();
        }
    }
}
