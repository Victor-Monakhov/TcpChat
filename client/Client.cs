using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace client
{
    static class Client 
    {
        private struct Parcel
        {
            public string nickname;
            public string message;
            public object something;
        }
        private static TcpClient _client;
        private static NetworkStream _stream;
        private static object _sendLocker = new object();
        private static object _msgLocker = new object();
        private static bool _send = false;
        private static string _outgoingMessage = string.Empty;
        private static List<ISubscriber> _subscribers = new List<ISubscriber>();
        public static List<string> WhiteList { get; set; } = new List<string>();
        public static List<string> Messages { get; private set; } = new List<string>();
        public static List<string> Users { get; private set; } = new List<string>();
        public static string UserName { get; set; } = string.Empty;
        public static string Host { get; set; } = "127.0.0.1";
        public static int Port { get; set; } = 8080;
        public static bool Work { get; set; } = true;
        public static void SetSend(bool value)
        {
            lock (_sendLocker)
            {
                _send = value;
            }
        }
        public static void SetOutgoingMessage(string value)
        {
            lock (_msgLocker)
            {
                _outgoingMessage = value;
            }
        }
        public static void Subscribe(ISubscriber subscriber)
        {
            if (subscriber != null)
                _subscribers.Add(subscriber);
        }
        public static void Unsubscribe(ISubscriber subscriber)
        {
            foreach (ISubscriber member in _subscribers)
                if (member == subscriber)
                    _subscribers.Remove(member);
        }
        private static void Notify()
        {
            foreach (ISubscriber member in _subscribers)
                member.LoadNews();
        }
        public static void Run()
        {
            if (_outgoingMessage.Length > 0 && UserName.Length >= 2)
            {
                try
                {
                    using (_client = new TcpClient())
                    {
                        _client.Connect(Host, Port);
                        using (_stream = _client.GetStream())
                        {
                            new Thread(ReceiveMessages).Start();
                            SendMessages();
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"ERROR: {ex.Message}");
                }
                finally
                {
                    _stream?.Close();
                    _client?.Close();
                }
            }
        }
        private static void ReceiveMessages()
        {
            try
            {
                while (Work)
                {
                    byte[] buf = new byte[1024];
                    int byteCount = 0;
                    string jsonParcel = string.Empty;
                    do
                    {
                        if (Work && _stream != null)
                        {
                            byteCount = _stream.Read(buf, 0, buf.Length);
                            jsonParcel += Encoding.UTF8.GetString(buf, 0, byteCount);
                        }
                    } while (_stream.DataAvailable);
                    Parcel parcel = ParcelDeserializer(jsonParcel);
                    parcel.something = ListStrDeserializer((string)parcel.something);
                    Users = (List<string>)parcel.something;
                    Notify();
                    if (parcel.message.Contains($"already used. Try again"))
                    {
                        Messages.Add(parcel.message);
                    }
                    else
                    {
                        foreach (var item in WhiteList)
                        {
                            if (parcel.nickname.Contains(item.ToString()))
                            {
                                Messages.Add(parcel.nickname + ":\n" + parcel.message);
                                break;
                            }
                        }
                    }
                    
                }
            }
            catch { Thread.CurrentThread.Abort(); }
            finally
            {
                _stream?.Close();
                _client?.Close();
            }
        }
        private static void SendMessages()
        {
            while (Work)
            {
                if (_send && _outgoingMessage.Length > 0 && UserName.Length >= 1)
                {
                    Parcel parcel = new Parcel()
                    {
                        nickname = UserName,
                        message = _outgoingMessage,
                        something = null
                    };
                    using (TextWriter writer = new StringWriter())
                    {
                        JsonSerializer serializer = new JsonSerializer();
                        serializer.Serialize(writer, parcel);
                        byte[] data = Encoding.UTF8.GetBytes(writer.ToString());
                        _stream.Write(data, 0, data.Length);
                        SetOutgoingMessage(string.Empty);
                        SetSend( false);
                    }
                }
            }
        }
        private static Parcel ParcelDeserializer(string jsonObject)
        {
            using (JsonReader reader = new JsonTextReader(new StringReader(jsonObject)))
            {
                JsonSerializer serializer = new JsonSerializer();
                return serializer.Deserialize<Parcel>(reader);
            }
        }
        private static List<string> ListStrDeserializer(string jsonObject)
        {
            using (JsonReader reader = new JsonTextReader(new StringReader(jsonObject)))
            {
                JsonSerializer serializer = new JsonSerializer();
                return serializer.Deserialize<List<string>>(reader);
            }
        }
    }
}
