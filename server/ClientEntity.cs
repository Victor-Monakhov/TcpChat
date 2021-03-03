using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace server
{
    public struct Parcel
    {
        public string nickname;
        public string message;
        public object something;
    }
    class ClientEntity
    {
        
        public string Id { get; private set; }
        public string Username { get; private set; } = string.Empty;
        ServerEntity _server;
        TcpClient _client;
        NetworkStream _stream;
        public ClientEntity(TcpClient client, ServerEntity server)
        {
            Id = Guid.NewGuid().ToString();
            _client = client;
            _server = server;
        }
        public void Processing()
        {
            try
            {
                _stream = _client.GetStream();
                Parcel parcel = DecodeMessage();
                Username = parcel.nickname;
                parcel.message = $"{parcel.nickname} enter to the chat!\n{parcel.message}";
                _server.Broadcast(parcel, Id);

                while (true)
                {
                    try
                    {
                        parcel = DecodeMessage();
                        Username = parcel.nickname;
                        _server.Broadcast(parcel, Id);
                        Console.WriteLine($"{Username}: {parcel.message}");

                    }
                    catch 
                    {
                        parcel.message = $"{Username} left the chat (((";
                        _server.Broadcast(parcel, Id);
                        Console.WriteLine(parcel.message);
                        throw;
                    }
                }
            }
            catch { }
            finally
            {
                Disconnect();
                _server.DisconnectClient(Id);
            }
        }
        private Parcel DecodeMessage()
        {
            
            byte[] buf = new byte[512];
            int bytesCount = 0;
            string jsonParcel = string.Empty;
            do
            {
                bytesCount = _stream.Read(buf, 0, buf.Length);
                jsonParcel += Encoding.UTF8.GetString(buf, 0, bytesCount);
            } while (_stream.DataAvailable);
            using (JsonReader reader = new JsonTextReader(new StringReader(jsonParcel)))
            {
                JsonSerializer serializer = new JsonSerializer();
                Parcel parcel = serializer.Deserialize<Parcel>(reader);
                return parcel;
            }
        }
        public void SendMessage(byte[] data)
        {
            _stream.Write(data, 0, data.Length);
        }
        public void Disconnect()
        {
            _stream?.Close();
            _client?.Close();
        }
    }
}
