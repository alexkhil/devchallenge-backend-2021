﻿namespace DevChallenge.Api.Endpoints;

public interface IEndpointDefinition
{
    void DefineServices(IServiceCollection services);

    void DefineEndpoints(WebApplication app);
}
