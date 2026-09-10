using Azure.AI.OpenAI;
using ExpenseClassifier.Agents;
using ExpenseClassifier.Models;
using ExpenseClassifier.Tools;
using Microsoft.Extensions.AI;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddSingleton<CompanyPolicyTool>();

builder.Services.AddScoped<AzureOpenAIClient>(sp =>
{
    var config = sp.GetRequiredService<IConfiguration>();
    var endpoint = config["AzureOpenAI:Endpoint"] ?? throw new InvalidOperationException("AzureOpenAI:Endpoint is not configured.");
    var apiKey = config["AzureOpenAI:ApiKey"] ?? throw new InvalidOperationException("AzureOpenAI:ApiKey is not configured.");

    return new AzureOpenAIClient(new Uri(endpoint), new System.ClientModel.ApiKeyCredential(apiKey));
});

builder.Services.AddScoped<IChatClient>(sp =>
{
    var config = sp.GetRequiredService<IConfiguration>();
    var deploymentName = config["AzureOpenAI:DeploymentName"] ?? throw new InvalidOperationException("AzureOpenAI:DeploymentName is not configured.");

    var client = sp.GetRequiredService<AzureOpenAIClient>();
    return client.GetChatClient(deploymentName).AsIChatClient();
});

var app = builder.Build();


app.MapPost("/classify", async (IExpenseClassifierAgent agent, RequestDto request, CancellationToken cancellationToken) =>
{
    var result = await agent.Classify(request.Description, cancellationToken);
    return Results.Ok(result);
});


await app.RunAsync();


