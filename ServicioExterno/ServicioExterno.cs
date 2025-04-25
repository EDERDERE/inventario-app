using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Threading;
using System.Threading.Tasks;

namespace BackgroundServiceLibrary
{
    public class ServicioExterno : IHostedService
    {
        private readonly ILogger<ServicioExterno> _logger;
        private Timer _timer;

        public ServicioExterno(ILogger<ServicioExterno> logger)
        {
            _logger = logger;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Servicio en segundo plano iniciado.");
            _timer = new Timer(RealizarTareaAutomatica, null, TimeSpan.Zero, TimeSpan.FromSeconds(5));
            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            _timer?.Change(Timeout.Infinite, 0);
            _logger.LogInformation("Servicio en segundo plano detenido.");
            return Task.CompletedTask;
        }

        private void RealizarTareaAutomatica(object state)
        {
            CopiarArchivo();   
            EnviarCorreoSimulado();
        }

        private void CopiarArchivo()
        {
            string sourcePath = @"C:\app\origen\archivo.txt"; 
            string destinationPath = @"C:\app\destino\archivo.txt"; 

            try
            {
                File.Copy(sourcePath, destinationPath, true);
                _logger.LogInformation("Archivo copiado exitosamente.");
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al copiar el archivo: {ex.Message}");
            }
        }

        private void EnviarCorreoSimulado()
        {
            try
            {
                var mailMessage = new MailMessage("from@example.com", "to@example.com")
                {
                    Subject = "Correo simulado",
                    Body = "Este es un correo simulado enviado desde un servicio en segundo plano."
                };

                var smtpClient = new SmtpClient("smtp.example.com")
                {
                    Port = 25,
                    Credentials = new NetworkCredential("usuario", "contraseña"),
                    EnableSsl = false
                };

                smtpClient.Send(mailMessage);
                _logger.LogInformation("Correo enviado exitosamente.");
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al enviar correo: {ex.Message}");
            }
        }
    }
}
