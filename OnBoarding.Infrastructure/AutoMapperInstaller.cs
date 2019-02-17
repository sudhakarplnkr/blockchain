namespace OnBoarding.Infrastructure
{
    using AutoMapper;
    using Castle.MicroKernel.Registration;
    using Castle.Windsor;
    using OnBoarding.Data;
    using System;
    using System.Linq;

    public static class AutoMapperInstaller
    {
        public static void Install(IWindsorContainer container)
        {
            container.Register(
            Types.FromAssemblyContaining<ValidatePolicy>()
                .BasedOn<Profile>()
                .WithService.Base()
                .Configure(c => c.Named(c.Implementation.FullName))
                .LifestyleTransient());

            var profiles = container.ResolveAll<Profile>();

            var config = (Action<IMapperConfigurationExpression>)(con => profiles.ToList().ForEach(con.AddProfile));

            Mapper.Initialize(config);           

            container.Register(Component.For<IMapper>().UsingFactoryMethod(x =>
             {
                 return new MapperConfiguration(config).CreateMapper();
             }));

        }
    }
}
