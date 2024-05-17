using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using Jostic.Rusia2018.Application.Interface.UseCases;


namespace Jostic.Rusia2018.Application.Test
{
    [TestClass]
    public class UsersApplicationTest
    {
        private static WebApplicationFactory<Program>? _factory;
        private static IServiceScopeFactory? _scopeFactory;

        [ClassInitialize]
        public static void Initialize(TestContext _)
        {
            _factory = new CustomWebApplicationFactory();
            _scopeFactory = _factory.Services.GetRequiredService<IServiceScopeFactory>();
        }

        [TestMethod]
        public void Authenticate_CuandoNoSeEnvianParametros_RetornarMensajeErrorValidacion()
        {
            using var scope = _scopeFactory!.CreateScope();
            var context = scope.ServiceProvider.GetService<IUsersApplication>();

            // Arrange
            var userName = string.Empty;
            var password = string.Empty;
            var expected = "Errores de validación";

            // Act            
            var result = context!.Authenticate(userName, password);
            var actual = result.Message;

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Authenticate_CuandoSeEnvianParametrosCorrectos_RetornarMensajeExito()
        {
            using var scope = _scopeFactory!.CreateScope();
            var context = scope.ServiceProvider.GetService<IUsersApplication>();

            // Arrange
            var userName = "RICHARD";
            var password = "123456";
            var expected = "Autenticación Exitosa!!!";

            // Act
            var result = context!.Authenticate(userName, password);
            var actual = result.Message;

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Authenticate_CuandoSeEnvianParametrosIncorrectos_RetornarMensajeUsuarioNoExiste()
        {
            using var scope = _scopeFactory!.CreateScope();
            var context = scope.ServiceProvider.GetService<IUsersApplication>();

            // Arrange
            var userName = "RICHARD";
            var password = "123456899";
            var expected = "Usuario no existe!!!";

            // Act
            var result = context!.Authenticate(userName, password);
            var actual = result.Message;

            // Assert
            Assert.AreEqual(expected, actual);
        }
    }
}