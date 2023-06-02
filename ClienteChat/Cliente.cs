using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WampSharp.V2;
using WampSharp.V2.Client;
using WampSharp.V2.Realm;

namespace ClienteChat
{
    internal class Cliente
    {
        public static async Task Main(string[] args)
        {

            Console.WriteLine("Iniciando Cliente #1");

            // Creacion del canal WAMP
            DefaultWampChannelFactory factory =
                new DefaultWampChannelFactory();


            // Direccion del servidor WAMP
            const string serverAddress = "ws://127.0.0.1:8080/ws";
            // Reino del servidor WAMP
            const string realmName = "realm1";
            // Nombre del tema de chat
            const string topic = "com.myapp.chat";

            // Creacion del canal y conexion al servidor WAMP
            IWampChannel channel =
                factory.CreateJsonChannel(serverAddress, realmName);

            // Abro la conexion con el servidor
            await channel.Open().ConfigureAwait(false);

            // Obtengo la interfaz del reino previamente creado
            IWampRealmProxy realmProxy = channel.RealmProxy;

            // Ingreso de datos del cliente
            Console.Write("ingrese un usuario: ");
            string username = Console.ReadLine();

            Console.WriteLine($"Bienvenido {username}");

            // Publicar mensaje en el tema chat creado para notificar la entrada del usuario
            realmProxy.Services.GetSubject<string>(topic)
                                         .OnNext($"Ha ingresado: {username}");

            // Suscribirse al tema de chat para recibir mensajes
            IDisposable subscription = null;
            subscription =
                realmProxy.Services.GetSubject<string>(topic)
                          .Subscribe(message =>
                          {
                              string[] parts = message.Split(':');
                              string sender = parts[0];
                              string content = parts[1];

                              if (sender != username)
                              {
                                  Console.WriteLine($"{sender}: {content}");
                              }
                          });

            Console.WriteLine("Escribe un mensaje o 'exit' para salir.");

            while (true)
            {
                string input = Console.ReadLine();

                if (input.ToLower() == "exit")
                {
                    // Publicar mensaje en el tema chat creado para notificar la desconexion del usuario
                    realmProxy.Services.GetSubject<string>(topic)
                                         .OnNext($"El usuario: {username} se ha desconectado");
                    break;
                }

                string chatMessage = $"{username}:{input}";

                // Publicar mensaje en el tema chat
                realmProxy.Services.GetSubject<string>(topic)
                                         .OnNext(chatMessage);
            }

            // Cerrar el Canal
            subscription.Dispose();
            channel.Close();
        }


    }
}
