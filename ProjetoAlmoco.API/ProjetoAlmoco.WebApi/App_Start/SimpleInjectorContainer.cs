using ProjetoAlmoco.Domain;
using ProjetoAlmoco.Domain.Interfaces.Repository;
using ProjetoAlmoco.Domain.Interfaces.Service;
using ProjetoAlmoco.Infra.Data.Repositories;
using SimpleInjector;
using SimpleInjector.Lifestyles;

namespace ProjetoAlmoco.WebApi.App_Start
{
    public class SimpleInjectorContainer
    {
        private static readonly Container container = new Container();

        public static Container Build()
        {
            container.Options.DefaultScopedLifestyle = new AsyncScopedLifestyle();

            //container.Register<INotification, Notification>(Lifestyle.Scoped);

            RegisterRepositories();
            RegisterServices();

            container.Verify();
            return container;
        }

        private static void RegisterRepositories()
        {
            container.Register<IAlimentoRepository, AlimentoRepository>();
            container.Register<ICategoriaRepository, CategoriaRepository>();
            container.Register<IClienteRepository, ClienteRepository>();
            container.Register<IPedidoRepository, PedidoRepository>();

            container.Register<IAlimentoService, AlimentoService>();
            container.Register<ICategoriaService, CategoriaService>();
            container.Register<IClienteService, ClienteService>();
            container.Register<IPedidoService, PedidoService>();
        }

        private static void RegisterServices()
        {
        }
    }
}