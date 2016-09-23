namespace XDev.ScriptingTool.ConsolePresentation
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using DependencyInjection;
    using Microsoft.Practices.Unity;

    /// <summary>
    /// <see cref="UnityDependencyInjectionContainer"/>
    /// </summary>
    /// <seealso cref="IDependencyInjectionContainer"/>
    internal class UnityDependencyInjectionContainer : IDependencyInjectionContainer
    {
        /// <summary>
        /// The unity container
        /// </summary>
        private readonly IUnityContainer unityContainer;

        /// <summary>
        /// Initializes a new instance of the <see cref="UnityDependencyInjectionContainer"/> class.
        /// </summary>
        public UnityDependencyInjectionContainer()
        {
            this.unityContainer = new UnityContainer();
        }

        /// <summary>
        /// Registers the specified type to be resolved.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public IDependencyInjectionContainer Register<T>() where T : class
        {
            this.unityContainer.RegisterType<T>();

            return this;
        }

        /// <summary>
        /// Registers the specified type to be resolved with the specified concrete type, specifying
        /// its construction through a lambda.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="injectionFactoryFunc">The injection factory function.</param>
        /// <returns></returns>
        public IDependencyInjectionContainer Register<T>(Func<IDependencyInjectionContainer, T> injectionFactoryFunc) where T : class
        {
            this.unityContainer.RegisterType<T>(new InjectionFactory((uc) => injectionFactoryFunc.Invoke(this)));

            return this;
        }

        /// <summary>
        /// Registers the specified type to be resolved with the specified concrete type, specifying
        /// the parameters through a anonymous object.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="parameters">The parameters.</param>
        /// <returns></returns>
        public IDependencyInjectionContainer Register<T>(object parameters) where T : class
        {
            object[] parametersArray = this.GetParameters(parameters).ToArray();
            InjectionConstructor injectionConstructor = new InjectionConstructor(parametersArray);
            this.unityContainer.RegisterType<T>(injectionConstructor);

            return this;
        }

        /// <summary>
        /// Registers the specified type to be resolved with the specified concrete type, specifying
        /// a name and the parameters through a anonymous object.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="name"></param>
        /// <param name="parameters">The parameters.</param>
        /// <returns></returns>
        public IDependencyInjectionContainer Register<T>(string name, object parameters) where T : class
        {
            object[] parametersArray = this.GetParameters(parameters).ToArray();
            InjectionConstructor injectionConstructor = new InjectionConstructor(parametersArray);
            this.unityContainer.RegisterType<T>(name, injectionConstructor);

            return this;
        }

        /// <summary>
        /// Registers the specified type to be resolved with the specified concrete type.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TConcrete">The type of the concrete.</typeparam>
        /// <returns></returns>
        public IDependencyInjectionContainer Register<T, TConcrete>()
            where T : class
            where TConcrete : T
        {
            this.unityContainer.RegisterType<T, TConcrete>();

            return this;
        }

        /// <summary>
        /// Registers the specified type to be resolved with the specified concrete type, specifying
        /// its construction through a lambda.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TConcrete">The type of the concrete.</typeparam>
        /// <param name="injectionFactoryFunc">The injection factory function.</param>
        /// <returns></returns>
        public IDependencyInjectionContainer Register<T, TConcrete>(Func<IDependencyInjectionContainer, TConcrete> injectionFactoryFunc)
            where T : class
            where TConcrete : T
        {
            this.unityContainer.RegisterType<T, TConcrete>(new InjectionFactory((uc) => injectionFactoryFunc.Invoke(this)));

            return this;
        }

        /// <summary>
        /// Registers the specified type to be resolved with the specified concrete type, specifying
        /// its' name.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TConcrete">The type of the concrete.</typeparam>
        /// <param name="name">The name.</param>
        /// <returns></returns>
        public IDependencyInjectionContainer Register<T, TConcrete>(string name)
            where T : class
            where TConcrete : T
        {
            this.unityContainer.RegisterType<T, TConcrete>(name);

            return this;
        }

        /// <summary>
        /// Registers the specified type to be resolved with the specified concrete type, specifying
        /// the parameters through a anonymous object.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TConcrete">The type of the concrete.</typeparam>
        /// <param name="parameters">The parameters.</param>
        /// <returns></returns>
        public IDependencyInjectionContainer Register<T, TConcrete>(object parameters)
            where T : class
            where TConcrete : T
        {
            object[] parametersArray = this.GetParameters(parameters).ToArray();
            InjectionConstructor injectionConstructor = new InjectionConstructor(parametersArray);
            this.unityContainer.RegisterType<T, TConcrete>(injectionConstructor);

            return this;
        }

        /// <summary>
        /// Registers the specified type to be resolved with the specified concrete type, specifying
        /// a name and the parameters through a anonymous object.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TConcrete">The type of the concrete.</typeparam>
        /// <param name="name">The name.</param>
        /// <param name="parameters">The parameters.</param>
        /// <returns></returns>
        public IDependencyInjectionContainer Register<T, TConcrete>(string name, object parameters)
            where T : class
            where TConcrete : T
        {
            object[] parametersArray = this.GetParameters(parameters).ToArray();
            InjectionConstructor injectionConstructor = new InjectionConstructor(parametersArray);
            this.unityContainer.RegisterType<T, TConcrete>(name, injectionConstructor);

            return this;
        }

        /// <summary>
        /// Resolves the requested service type.
        /// </summary>
        /// <typeparam name="TService">The type of the service.</typeparam>
        /// <returns></returns>
        public TService Resolve<TService>() where TService : class
        {
            return this.unityContainer.Resolve<TService>();
        }

        /// <summary>
        /// Gets the parameters.
        /// </summary>
        /// <param name="parameters">The parameters.</param>
        /// <returns></returns>
        private IEnumerable<object> GetParameters(object parameters)
        {
            Type anonymousType = parameters.GetType();

            return anonymousType.GetProperties(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic)
                .Select(pi => pi.GetValue(parameters));
        }
    }
}