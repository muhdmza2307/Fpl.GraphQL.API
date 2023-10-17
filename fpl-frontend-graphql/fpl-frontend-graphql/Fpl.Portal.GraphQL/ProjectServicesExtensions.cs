using Fpl.Portal.Common.Services;
using Fpl.Portal.Common.Services.Interfaces;
using Fpl.Portal.GraphQL.DataLoaders;
using Fpl.Portal.GraphQL.Directives;
using Fpl.Portal.GraphQL.Types;
using Fpl.Portal.Repository.FunctionCallers;
using Fpl.Portal.Repository.FunctionCallers.Interfaces;
using HotChocolate.Execution.Configuration;
using HotChocolate.Types;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Fpl.Portal.Common.Configuration.Options;
using Fpl.Portal.GraphQL.Types.EnumTypes;
using Fpl.Portal.Handlers.Fixtures;
using Fpl.Portal.Mapping;

namespace Fpl.Portal.GraphQL
{
    internal static class ProjectServicesExtensions
    {
        public static IServiceCollection AddProjectServices(this IServiceCollection services) =>
            services
                .AddSingleton<IFunctionRequestService, FunctionRequestService>();

        public static IServiceCollection AddProjectFunctionCallers(this IServiceCollection services) =>
            services
                .AddSingleton<IDroidRepository, DroidRepository>()
                .AddSingleton<IGetBootstrapStaticFunctionCaller, GetBootstrapStaticFunctionCaller>()
                .AddSingleton<IGetFixtureFunctionCallerById, GetFixtureByIdFunctionCaller>();
        
        public static IServiceCollection AddProjectHandlers(this IServiceCollection services) =>
            services
                .AddSingleton<IGetFixtureByIdHandler, GetFixtureByIdHandler>();

        public static IRequestExecutorBuilder AddProjectScalarTypes(this IRequestExecutorBuilder builder) =>
            builder.BindRuntimeType<DateTime, DateType>();

        public static IRequestExecutorBuilder AddProjectDirectives(this IRequestExecutorBuilder builder) =>
            builder
                .AddDirectiveType<UpperDirectiveType>()
                .AddDirectiveType<LowerDirectiveType>()
                .AddDirectiveType<IncludeDirectiveType>()
                .AddDirectiveType<SkipDirectiveType>();

        public static IRequestExecutorBuilder AddProjectDataLoaders(this IRequestExecutorBuilder builder) => 
            builder.AddDataLoader<IDroidDataLoader, DroidDataLoader>();

        public static IRequestExecutorBuilder AddProjectTypes(this IRequestExecutorBuilder builder) =>
            builder
                .SetSchema<MainSchema>()
                .AddQueryTypes()
                .AddEnumTypes()
                .AddType<CharacterInterface>()
                .AddType<DroidObject>();

        private static IRequestExecutorBuilder AddQueryTypes(this IRequestExecutorBuilder builder) =>
            builder.AddQueryType(x => x.Name("Query"))
                .AddType<GetFixturesObject>();

        private static IRequestExecutorBuilder AddEnumTypes(this IRequestExecutorBuilder builder) => builder
            .AddType<StatIdentifierTypeEnumObject>();

        public static IServiceCollection RegisterAutoMapper(this IServiceCollection services)
        {
            var mapperConfig = new MapperConfiguration(configuration =>
            {
                configuration.AddProfiles(FplGraphQlProfiles.Profiles);
            });

            var mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);

            return services;
        }
    }
}
