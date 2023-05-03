using System;
using System.Collections.Generic;

namespace DeveloperSample.Container
{
    public class Container
    {
        private readonly Dictionary<Type, Type> _typeMap = new Dictionary<Type, Type>();

        public void Bind(Type interfaceType, Type implementationType)
        {
            if (!interfaceType.IsAssignableFrom(implementationType))
            {
                throw new ArgumentException($"Type {implementationType.FullName} does not implement interface {interfaceType.FullName}");
            }

            _typeMap[interfaceType] = implementationType;
        }

        public T Get<T>()
        {
            return (T)Get(typeof(T));
        }

        private object Get(Type type)
        {
            if (_typeMap.TryGetValue(type, out var implementationType))
            {
                var constructor = implementationType.GetConstructors()[0];
                var parameters = constructor.GetParameters();

                if (parameters.Length == 0)
                {
                    return Activator.CreateInstance(implementationType);
                }

                var parameterValues = new object[parameters.Length];
                for (int i = 0; i < parameters.Length; i++)
                {
                    parameterValues[i] = Get(parameters[i].ParameterType);
                }

                return constructor.Invoke(parameterValues);
            }

            throw new ArgumentException($"Type {type.FullName} is not registered with the container");
        }
    }
}
