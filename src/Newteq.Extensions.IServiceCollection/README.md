# Dependency Injection Extensions
By default the `TryAddSingleton` (or other scopes) in the `Microsoft.Extensions.DependencyInjection.Extensions` namespace/library only allows you to add a single item for a defined interface.
Using this package's extenstions will allow you to register more than 1 implementation for a specified interface.
The can be useful if you want to inject a specific instance that extends off the same interface.

The use case of this package is extremely unquie but it can be used to add in DI if your needs match the above.

# Usage Example

To make use of this, simply do the following

```
public static void AddGeneralLogging(this IServiceCollection services)
        {
            services.TryAddMultiSingleton<ILoggingService, LoggingService>();
			services.TryAddMultiSingleton<ILoggingService, AnotherLoggingService>();
        }
```

# Available Methods

You can use the following extensions methods off `IServiceCollection`

  - TryAddMultiSingleton
  - TryAddMultiScoped
  - TryAddMultiTransient