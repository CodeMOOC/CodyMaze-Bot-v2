using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace CodyMazeBot {
    public static class ServiceCollectionExtensions {

        public static void AddAllScoped<I>(this IServiceCollection services) {
            var assembly = Assembly.GetExecutingAssembly();
            var types = from t in assembly.ExportedTypes
                        where !t.IsAbstract && t.IsAssignableTo(typeof(I))
                        select t;
            foreach(var t in types) {
                services.AddScoped(t);
            }
        }

    }
}
