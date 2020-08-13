using Autofac;
using Modelo.Domain.Core.Interfaces.Repositorys;
using Modelo.Domain.Core.Interfaces.Services;
using Modelo.Domain.Services.Services;
using System;
using System.Collections.Generic;
using System.Text;
using WebAPI.Application.Interfaces;
using WebAPI.Application.Services;
using WebAPI.Infra.Cross.Adapter.Interfaces;
using WebAPI.Infra.Cross.Adapter.Map;
using WebAPI.Infra.Repositorys.Repositorys;

namespace WebAPI.Infra.Cross.IOC
{
    public class ConfigurationIOC
    {
        public static void Load(ContainerBuilder builder)
        {
            #region Registra IOC

            #region IOC Application
            builder.RegisterType<ApplicationServiceUser>().As<IApplicationServiceUser>();
            builder.RegisterType<ApplicationServiceMovie>().As<IApplicationServiceMovie>();
            builder.RegisterType<ApplicationServiceVote>().As<IApplicationServiceVote>();
            #endregion

            #region IOC Services
            builder.RegisterType<ServiceUser>().As<IServiceUser>();
            builder.RegisterType<ServiceMovie>().As<IServiceMovie>();
            builder.RegisterType<ServiceVote>().As<IServiceVote>();
            #endregion

            #region IOC Repositorys SQL
            builder.RegisterType<RepositoryMovie>().As<IRepositoryMovie>();
            builder.RegisterType<RepositoryUser>().As<IRepositoryUser>();
            builder.RegisterType<RepositoryVote>().As<IRepositoryVote>();
            #endregion

            #region IOC Mapper
            builder.RegisterType<MapperMovie>().As<IMapperMovie>();
            builder.RegisterType<MapperUser>().As<IMapperUser>();
            builder.RegisterType<MapperVote>().As<IMapperVote>();
            #endregion

            #endregion

        }
    }
}
