namespace XDev.ScriptingTool.DependencyInjection
{
    using System;

    /// <summary>
    /// <see cref="IDependencyInjectionContainer"/>
    /// </summary>
    public interface IDependencyInjectionContainer
    {
        /// <summary>
        /// Registers the specified type to be resolved with the specified concrete type.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TConcrete">The type of the concrete.</typeparam>
        /// <returns></returns>
        IDependencyInjectionContainer Register<T, TConcrete>()
            where T : class
            where TConcrete : T;

        /// <summary>
        /// Registers the specified type to be resolved.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        IDependencyInjectionContainer Register<T>()
            where T : class;

        /// <summary>
        /// Registers the specified type to be resolved with the specified concrete type, specifying
        /// the parameters through a anonymous object.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="parameters">The parameters.</param>
        /// <returns></returns>
        IDependencyInjectionContainer Register<T>(object parameters)
            where T : class;

        /// <summary>
        /// Registers the specified type to be resolved with the specified concrete type, specifying
        /// a name and the parameters through a anonymous object.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="parameters">The parameters.</param>
        /// <returns></returns>
        IDependencyInjectionContainer Register<T>(string name, object parameters)
            where T : class;

        /// <summary>
        /// Registers the specified type to be resolved with the specified concrete type, specifying
        /// its construction through a lambda.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="injectionFactoryFunc">The injection factory function.</param>
        /// <returns></returns>
        IDependencyInjectionContainer Register<T>(Func<IDependencyInjectionContainer, T> injectionFactoryFunc)
            where T : class;

        /// <summary>
        /// Registers the specified type to be resolved with the specified concrete type, specifying
        /// the parameters through a anonymous object.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TConcrete">The type of the concrete.</typeparam>
        /// <param name="parameters">The parameters.</param>
        /// <returns></returns>
        IDependencyInjectionContainer Register<T, TConcrete>(object parameters)
            where T : class
            where TConcrete : T;

        /// <summary>
        /// Registers the specified type to be resolved with the specified concrete type, specifying
        /// its' name.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TConcrete">The type of the concrete.</typeparam>
        /// <param name="name">The name.</param>
        /// <returns></returns>
        IDependencyInjectionContainer Register<T, TConcrete>(string name)
            where T : class
            where TConcrete : T;

        /// <summary>
        /// Registers the specified type to be resolved with the specified concrete type, specifying
        /// a name and the parameters through a anonymous object.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TConcrete">The type of the concrete.</typeparam>
        /// <param name="name">The name.</param>
        /// <param name="parameters">The parameters.</param>
        /// <returns></returns>
        IDependencyInjectionContainer Register<T, TConcrete>(string name, object parameters)
            where T : class
            where TConcrete : T;

        /// <summary>
        /// Registers the specified type to be resolved with the specified concrete type, specifying
        /// its construction through a lambda.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TConcrete">The type of the concrete.</typeparam>
        /// <param name="injectionFactoryFunc">The injection factory function.</param>
        /// <returns></returns>
        IDependencyInjectionContainer Register<T, TConcrete>(Func<IDependencyInjectionContainer, TConcrete> injectionFactoryFunc)
            where T : class
            where TConcrete : T;

        /// <summary>
        /// Resolves the requested service type.
        /// </summary>
        /// <typeparam name="TService">The type of the service.</typeparam>
        /// <returns></returns>
        TService Resolve<TService>()
            where TService : class;
    }
}