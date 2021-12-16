using Entity.Clientes.Application.Handlers;
using Entity.Clientes.Data.Contexto;
using Entity.Clientes.Data.Repositories;
using Entity.Clientes.Domain.Repositories;
using Entity.Pedidos.Data.Contexto;
using Entity.Pedidos.Data.Repositories;
using Entity.Pedidos.Domain.Repositories;
using Entity.Produtos.Application.Handlers;
using Entity.Produtos.Data.Contexto;
using Entity.Produtos.Data.Repositories;
using Entity.Produtos.Domain.Repositories;
using Entity.Shared.Mediator;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Entity.Pedidos.Application.Handlers;
using Entity.Produtos.Application.Queries;
using MediatR;
using Entity.Produtos.Application.Commands;
using Entity.Produtos.Application.Events;

namespace entity_framework
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var connetionString = Configuration.GetConnectionString("DefaultConnection");
            //services.AddDbContext<DbContexto>(options => options.UseMySql(connetionString, ServerVersion.AutoDetect(connetionString)));
            services.AddDbContext<ProdutosDbContexto>(options => options.UseMySql(connetionString, ServerVersion.AutoDetect(connetionString)));
            services.AddDbContext<ClienteDbContexto>(options => options.UseMySql(connetionString, ServerVersion.AutoDetect(connetionString)));
            services.AddDbContext<PedidosDbContexto>(options => options.UseMySql(connetionString, ServerVersion.AutoDetect(connetionString)));

            //registrar servicos
            services.AddScoped<ClienteDbContexto>();
            services.AddScoped<ProdutosDbContexto>();
            services.AddScoped<PedidosDbContexto>();
            services.AddScoped<IClienteRepository, ClienteRepository>();
            services.AddScoped<IPedidosRepository, PedidosRepository>();
            services.AddScoped<IProdutosRepository, ProdutosRepository>();
            services.AddScoped<IFornecedoresRepository, FornecedoresRepository>();
            services.AddScoped<IFornecedoresQueries, FornecedoresQueries>();

            //eventos
            services.AddSingleton<IMediatorHandler, MediatorHandler>((provider) => 
            {
                var mediator = new MediatorHandler();
                mediator.RegistrarEventoHandler(new ClienteRegistradoEventoHandler());
                mediator.RegistrarEventoHandler(new ProdutosPedidosEventoHandler());
                mediator.RegistrarComandoHandler(new CadastrarPedidoHandler(provider));
                mediator.RegistrarComandoHandler(new AtualizarPedidoHandler(provider));
                mediator.RegistrarComandoHandler(new RemoverPedidoHandler(provider));
                return mediator;
            });

            services.AddMediatR(typeof(Startup));

            services.AddScoped<IMediatorBibliotecaHandler, MediatorBibliotecaHandler>();

            services.AddScoped<IRequestHandler<NovoFornecedorCommand, bool>, FornecedoresCommandHandler>();
            services.AddScoped<IRequestHandler<AtualizarFornecedorCommand, bool>, FornecedoresCommandHandler>();
            services.AddScoped<IRequestHandler<RemoverFornecedorCommand, bool>, FornecedoresCommandHandler>();
            services.AddScoped<INotificationHandler<FornecedorInativadoEvent>, FornecedorEventHandler>();

            services.AddControllersWithViews();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
