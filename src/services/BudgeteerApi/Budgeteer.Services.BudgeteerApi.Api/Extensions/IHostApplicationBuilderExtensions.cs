using Azure.Identity;
using Microsoft.Extensions.Configuration.AzureAppConfiguration;

namespace Budgeteer.Services.BudgeteerApi.Api.Extensions;

public static class IHostApplicationBuilderExtensions
{
    public static IHostApplicationBuilder AddHostConfigurations(
        this IHostApplicationBuilder builder
    )
    {
        builder
            .AddAzureAppConfigurationStore();

        return builder;
    }

    // TODO: Use Options pattern
    private static IHostApplicationBuilder AddAzureAppConfigurationStore(
        this IHostApplicationBuilder builder    
    )
    {
        builder
            .Configuration
            .AddAzureAppConfiguration(options =>
                {
                    string appName = builder
                        .Configuration
                        .GetValue<string>(
                            "App:Name"
                        )!;

                    ChainedTokenCredential credential = new(
                        new AzureCliCredential(),
                        new DefaultAzureCredential(),
                        new ManagedIdentityCredential()
                    );

                    options
                        .Connect(
                            new Uri(
                                builder.Configuration.GetConnectionString("AppConfigurationStore")!
                            ),
                            credential
                        )
                        .Select(
                            KeyFilter.Any, 
                            LabelFilter.Null
                        )
                        .Select(
                            KeyFilter.Any, 
                            appName
                        );

                    options
                        .ConfigureKeyVault(keyVault =>
                            keyVault.SetCredential(
                                credential
                            )
                        );
                }
            );

        return builder;
    }
}
