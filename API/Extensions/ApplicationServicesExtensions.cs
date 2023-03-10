using API.Errors;
using Core.Interfaces;
using Infrastructure.Data;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace API.Extensions
{
  public static class ApplicationServicesExtensions
  {
    /*
    1. Extending IServiceCollection
    2. Return extended services back to Startup.cs
    */
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
      services.AddScoped<ITokenService, TokenService>();
      services.AddScoped<IOrderServices, OrderService>();
      services.AddScoped<IUnitOfWork, UnitOfWork>();
      services.AddScoped<IProductRepository, ProductRepository>();
      services.AddScoped<IBasketRepository, BasketRepository>();
      services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

      services.Configure<ApiBehaviorOptions>(options => 
      {
        options.InvalidModelStateResponseFactory = actionContext => 
        {
          var errors = actionContext.ModelState
            .Where(e => e.Value.Errors.Count > 0)
            .SelectMany(x => x.Value.Errors)
            .Select(x => x.ErrorMessage).ToArray();

          var errorResponse = new ApiValidationErrorResponse
          {
            Errors = errors
          };

          return new BadRequestObjectResult(errorResponse);
        };
      });

      return services;
    }    
  }
}