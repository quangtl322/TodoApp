using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TodoApp.Common.Helpers
{
    public class IoCHelper
    {
        private static ServiceProvider _serviceProvider;

        public static void SetServiceProvider(ServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public static T GetInstance<T>() where T : class
        {
            return _serviceProvider.GetService<T>();
        }

        public static IEnumerable<T> GetInstances<T>() where T : class
        {
            return _serviceProvider.GetServices<T>();
        }
    }
}
