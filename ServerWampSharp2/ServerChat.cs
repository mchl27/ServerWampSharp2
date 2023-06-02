using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using System.Text;
using System.Threading.Tasks;
using WampSharp.V2;
using WampSharp.V2.Realm;

namespace ServerWampSharp2
{
    internal class ServerChat
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Iniciando servidor espere un momento...");

            // Direccion del servidor WAMP
            const string serverAddress = "ws://127.0.0.1:8080/ws";
            // Nombre del reino en el servidor WAMP
            const string realmName = "realm1";
            // Nombre del tema del chat
            const string topic = "com.myapp.chat";

            // Creacion del host WAMP
            DefaultWampHost host = new DefaultWampHost(serverAddress);

            // Se abre el host para aceptar conexiones
            host.Open();

            // Obtengo el reino en el host
            IWampHostedRealm realm = host.RealmContainer.GetRealmByName(realmName);

            // Suscribirse al tema de chat para recibir mensajes
            IDisposable subscription = null;
            subscription =
                realm.Services.GetSubject<string>(topic)
                     .Subscribe(message =>
                     {
                         // Muestra mensaje de la fecha y hora actual junto con el mensaje enviado por el cliente
                         Console.WriteLine($"{DateTime.Now}: " + message);
                         // Reenviar mensaje a todos los clientes suscritos al tema
                         realm.Services.GetSubject<string>(topic).OnNext(message);
                     });

            Console.WriteLine("Servidor Iniciado en la direccion: " + serverAddress);
            Console.ReadLine();

            // Cerrar el host
            subscription.Dispose();
            host.Dispose();
        }
    }
}
