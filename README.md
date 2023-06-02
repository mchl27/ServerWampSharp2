# Chat en tiempo real usando WampSharp - Subscriber

Este proyecto implementa un chat en tiempo real utilizando la biblioteca WampSharp. Permite a los usuarios conectarse al servidor y participar en conversaciones en tiempo real.

## Características

- Conexión de múltiples clientes al servidor de chat.
- Publicación y recepción de mensajes en tiempo real.
- Notificación de ingreso y salida de usuarios en el chat.

## Requisitos previos

- [.NET Framework](https://dotnet.microsoft.com/download) (versión 3.1 o superior)
- [WampSharp.Default](https://www.nuget.org/packages/WampSharp.Default) (se instala automáticamente al compilar el proyecto o ejecutar el siguiente comando en consola: Install-Package WampSharp.Default -Pre)

## Instalación y uso

1. Clona el repositorio o descarga los archivos.
2. Abre el proyecto en Visual Studio.
3. Compila y ejecuta el proyecto del servidor (`ServerChat`) en una instancia de Visual Studio.
4. Compila y ejecuta el proyecto del cliente (`ClienteChat`) en otra instancia de Visual Studio.
5. Ingresa un nombre de usuario en el cliente y comienza a enviar mensajes en el chat.

## Estructura del proyecto

El proyecto se divide en dos partes principales: el cliente y el servidor.

- `ClienteChat`: Contiene la lógica y la interfaz de usuario para el cliente de chat.
- `ServerChat`: Contiene la lógica del servidor de chat.

## Documentación Proyecto
Encontrara la documentación en el siguite link en [Drive](https://drive.google.com/drive/folders/1f5hfXCkpAZQ_d9y0P7ee6rm-bglGHfMz?usp=sharing)

## Bibliotecas utilizadas

Este proyecto utiliza la biblioteca WampSharp para la comunicación en tiempo real. WampSharp es una implementación de WAMP (Web Application Messaging Protocol) para .NET. Proporciona una forma sencilla de conectar clientes y servidores y establecer una comunicación bidireccional eficiente.

Puedes encontrar más información sobre WampSharp en su [sitio web oficial](https://wampsharp.net/) - Elad Zelingher o [Github](https://github.com/Code-Sharp/WampSharp.git). Asegúrate de revisar la documentación oficial de WampSharp para obtener más detalles sobre cómo se integra en este proyecto.

Agradecemos a los desarrolladores de WampSharp por su contribución a la comunidad y su excelente biblioteca.

## Contribución

Las contribuciones son bienvenidas. Si encuentras algún problema o tienes alguna mejora, por favor, abre un nuevo issue o envía un pull request.

## Licencia

Este proyecto está licenciado bajo [MIT License](LICENSE).
