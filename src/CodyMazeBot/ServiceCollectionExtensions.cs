using System.Reflection;

namespace CodyMazeBot {
    public static class ServiceCollectionExtensions {

        public static void AddAllScoped<I>(
            this IServiceCollection services,
            Action<Type> action = null
        ) {
            var assembly = Assembly.GetExecutingAssembly();
            var types = from t in assembly.ExportedTypes
                        where !t.IsAbstract && t.IsAssignableTo(typeof(I))
                        select t;
            foreach(var t in types) {
                services.AddScoped(t);
                if(action != null) {
                    action(t);
                }
            }
        }

    }
}
