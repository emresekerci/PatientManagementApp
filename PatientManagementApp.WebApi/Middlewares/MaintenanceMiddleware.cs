using PatientManagementApp.Business.Operations.Setting;

namespace PatientManagementApp.WebApi.Middlewares
{
    public class MaintenanceMiddleware
    {
        private readonly RequestDelegate _next;
      
        public MaintenanceMiddleware(RequestDelegate next)
        {
            _next = next;
            
        }

        public async Task Invoke(HttpContext context)
        {
            var _settingService = context.RequestServices.GetRequiredService<ISettingService>(); 
            bool maintenanceMode = _settingService.GetMaintenancecState();
            if(context.Request.Path.StartsWithSegments("/api/auth/login" )|| context.Request.Path.StartsWithSegments("/api/settings"))
            {
                await _next(context);
                return;
            }
            if (maintenanceMode)
            {
                await context.Response.WriteAsync("Şu anda size hizmet verememekteyiz.");
            }
            else
            {
                await _next(context);
            }
        }
    }
}
