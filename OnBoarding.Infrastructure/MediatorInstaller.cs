namespace OnBoarding.Infrastructure
{
    using FluentValidation;
    using Castle.MicroKernel.Registration;
    using Castle.MicroKernel.Resolvers.SpecializedResolvers;
    using Castle.Windsor;
    using Data;
    using MediatorPipeline;
    using MediatR;
    using MediatR.Pipeline;
    using System.Collections.Generic;

    public static class MediatorInstaller
    {
        public static void Install(IWindsorContainer container)
        {
            container.Kernel.Resolver.AddSubResolver(new CollectionResolver(container.Kernel));
            container.Kernel.AddHandlersFilter(new ContravariantFilter());

            container.Register(Classes.FromAssemblyContaining<ValidatePolicy>().BasedOn(typeof(IRequestHandler<,>)).WithServiceAllInterfaces().LifestylePerWebRequest());

            container.Register(Component.For<IMediator>().ImplementedBy<Mediator>());
            container.Register(Component.For<SingleInstanceFactory>().UsingFactoryMethod<SingleInstanceFactory>(k => t => k.Resolve(t)));
            container.Register(Component.For<MultiInstanceFactory>().UsingFactoryMethod<MultiInstanceFactory>(k => t => (IEnumerable<object>)k.ResolveAll(t)));

            //Pipeline
            container.Register(Component.For(typeof(IPipelineBehavior<,>)).ImplementedBy(typeof(RequestPreProcessorBehavior<,>)).NamedAutomatically("PreProcessorBehavior").LifestylePerWebRequest());
            container.Register(Component.For(typeof(IPipelineBehavior<,>)).ImplementedBy(typeof(RequestPostProcessorBehavior<,>)).NamedAutomatically("PostProcessorBehavior").LifestylePerWebRequest());
            container.Register(Component.For(typeof(IPipelineBehavior<,>)).ImplementedBy(typeof(ValidationPipelineBehavior<,>)).NamedAutomatically("Pipeline").LifestylePerWebRequest());
            container.Register(Component.For(typeof(IPipelineBehavior<,>)).ImplementedBy(typeof(UnitOfWorkBehavior<,>)).NamedAutomatically("UnitOfWorkPipeline").LifestylePerWebRequest());

            container.Register(Classes.FromAssemblyContaining<ValidatePolicy>().BasedOn(typeof(IValidator<>)).WithService.FirstInterface().LifestylePerWebRequest());
        }
    }
}
