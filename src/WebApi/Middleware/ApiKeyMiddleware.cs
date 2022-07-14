namespace Nikan.Services.BasicData.WebApi.Middleware;

public class ApiKeyMiddleware
{
  private readonly RequestDelegate _next;
  private const string APIKEYNAME = "x-api-key";
  private readonly IConfiguration _configuration;
  private readonly string _apikeyvalue;
  public ApiKeyMiddleware(RequestDelegate next, IConfiguration configuration)
  {
    _next = next;
    _configuration = configuration;
    _apikeyvalue = _configuration[APIKEYNAME];
  }
  public async Task InvokeAsync(HttpContext context)
  {
    if (context.Request.ContentType?.ToLower() == "application/grpc")
    {

      if (!context.Request.Headers.ContainsKey(APIKEYNAME))
      {

        context.Response.StatusCode = 402;
        return;
      }
      if (!context.Request.Headers.Where(i => i.Key == APIKEYNAME
      && i.Value == _apikeyvalue
      ).Any()) {

        context.Response.StatusCode = 401;
        return;
      }

     







    }



    await _next(context);
  }
}
