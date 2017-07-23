# DotNet.Extensions.FileProviders
Net Core String File Provider

https://www.nuget.org/packages/DotNet.Extensions.FileProviders/

```
public static IConfigurationRoot CreateJsonConfiguration(StringFileProvider fileProvider)
        {
            IConfigurationRoot result;
            var configBuilder = new ConfigurationBuilder();
            configBuilder.AddJsonFile(fileProvider, "string", false, false);
            result = configBuilder.Build();
            return result;
        }
```