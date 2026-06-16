using System;
using System.Collections.Generic;
using UnityEngine;

namespace LLib
{
    public static class Services
    {
        private static readonly Dictionary<Type, object> ServicesByType = new();
        private static bool _useAutoCleanup = true;

        
        public static void Register<T>(T service) where T : class
        {
            var type = typeof(T);
            
            if (!ServicesByType.TryGetValue(type, out var containsService))
            {
                ServicesByType[type] = service;
                return;
            }

            if (containsService != null)
            {
                Debug.LogWarning($"{typeof(T)} : ALREADY REGISTERED. Ignore new one.");
                return;
            }
            
            if (_useAutoCleanup)
            {
                ServicesByType.Remove(type);
            }
        }


        public static void Unregister<T>() where T : class
        {
            var type = typeof(T);
            
            ServicesByType.Remove(type);
        }


        public static T Get<T>() where T : class
        {
            if (ServicesByType.TryGetValue(typeof(T), out var service))
                return (T)service;

            Debug.LogWarning($"NOT REGISTERED : {typeof(T)}");
            return null;
        }

        
        public static void Replace<T>(T service) where T : class
        {
            var type = typeof(T);
            
            if (ServicesByType.ContainsKey(type))
            {
                ServicesByType[type] = service;
            }
        }
        

        public static void SetAutoCleanup(bool value)
        {
            _useAutoCleanup = value;
        }
    }
}