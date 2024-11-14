using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace PatientManagementApp.WebApi.Filters
{
    public class TimeControlFilter : ActionFilterAttribute 
    {
        public string StartTime { get; set; }
        public string EndTime { get; set; }

        public override void OnActionExecuting(ActionExecutingContext context)
        {

            var now = DateTime.Now.TimeOfDay;
            StartTime = "00:00";
            EndTime = "00:00";
            if (now >= TimeSpan.Parse(StartTime) && now <= TimeSpan.Parse(EndTime))
            {
                base.OnActionExecuting(context);
            }
            else
            {
                context.Result = new ContentResult
                {
                    Content = "Bu saatler arasında istek atılamaz.",
                    StatusCode = 403
                };
            }



            
        }
    }
}
