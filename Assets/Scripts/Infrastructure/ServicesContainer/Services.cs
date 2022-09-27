using System;
using System.Collections.Generic;
using UnityEngine;

namespace TDS.Assets.Infrastructure.ServicesContainer
{
    public class Services
    {
        private const string Tag = nameof(Services);
        private static Services _container;

        public static Services Container=>_container??(_container=new Services());
        
        private readonly Dictionary<Type, IService> _services = new();
        public void Register<TService>(TService implementation) where TService : class, IService
        {
            Type key = typeof(TService);
            if(_services.ContainsKey(key))
            {
                Debug.LogError($"{Tag},{nameof(Register)}:Try add service with key '{key}'," +
                    $" that already exist.");
                return;
            }
            _services.Add(key,implementation);

        }

        public TService Get<TService>() where TService: class, IService
        {
            Type key = typeof(TService);
            if (_services.ContainsKey(key))
            {
                return _services[key] as TService;
            }
            Debug.LogError($"{Tag},{nameof(Get)}:There is no service with key '{key}'," +
                $" that already exist.");
            return default;
        }

        public void UnRegister<TService>() where TService: class, IService
        {
            Type key = typeof(TService);
            if(!_services.ContainsKey(key))
            {
                Debug.LogError($"{Tag},{nameof(UnRegister)}:Try add service with key '{key}'," +
                    $" that already exist.");
                return;
            }

            _services.Remove(key);
        }
        

    }
}