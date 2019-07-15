# Dependency Injection Extensions
This repo contains an ASP.NET Core nuget package for some assistance to help with dependency injection

The main purpose of this repoistory is to allow consumers to use a new extension method added to the `IServiceCollection` called `TryAdd{Scope/Lifetime}`. This extends the functionality of the existing calls on `IServiceCollection` to `Add`.

This extension helps you to ensure that a Service and Implementation is only ever registered once.

# Usage Example

To make use of this, simply do the following

```
public static void AddGeneralLogging(this IServiceCollection services)
        {
            services.TryAddSingleton<ILoggingService, LoggingService>();
        }
```

# Available Methods

You can use the following extensions methods off `IServiceCollection`

  - TryAddSingleton
  - TryAddScoped
  - TryAddTransient