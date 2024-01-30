using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using System.Net;

namespace N8SwagRinLab.Controllers;

/// <summary>
/// for 健康狀態檢查
/// </summary>
[Route("healthz")]
[ApiController]
[AllowAnonymous]
public class HealthCheckController(HealthCheckService healthCheckService)
  : ControllerBase
{
  [HttpGet]
  public async Task<ActionResult> Get()
  {
    HealthReport report = await healthCheckService.CheckHealthAsync();
    var result = new
    {
      status = report.Status.ToString(),
      errors = report.Entries.Select(e => new
      {
        name = e.Key,
        status = e.Value.Status.ToString(),
        description = e.Value.Description,
        data = e.Value.Data
      }),
    };

    return report.Status == HealthStatus.Healthy
      ? this.Ok(result)
      : this.StatusCode((int)HttpStatusCode.ServiceUnavailable, result);
  }
}
