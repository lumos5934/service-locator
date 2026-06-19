using System;
using System.Collections.Concurrent;
using UnityEngine;

namespace LLib
{
    public static class Services
    {
        private static readonly ConcurrentDictionary<Type, object> ServicesByType = new();

        public static void Register<T>(T service) where T : class
        {
            if (service == null) 
                throw new ArgumentNullException(nameof(service));
            
            var type = typeof(T);
            
            if (!ServicesByType.TryAdd(type, service))
            {
                Debug.LogWarning($"{typeof(T).Name} : ALREADY REGISTERED. Ignore new one.");
            }
        }

        public static void Unregister<T>() where T : class
        {
            ServicesByType.TryRemove(typeof(T), out _);
        }

        public static T Get<T>() where T : class
        {
            if (ServicesByType.TryGetValue(typeof(T), out var service))
                return (T)service;

            Debug.LogWarning($"NOT REGISTERED : {typeof(T).Name}");
            return null;
        }

        public static void Replace<T>(T service) where T : class
        {
            if (service == null) 
                throw new ArgumentNullException(nameof(service));
            
            ServicesByType[typeof(T)] = service;
        }
    }
}