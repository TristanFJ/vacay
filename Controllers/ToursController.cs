using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CodeWorks.Auth0Provider;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using vacay.Models;
using vacay.Services;

namespace vacay.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class ToursController : ControllerBase
  {
    private readonly ToursService _ts;

    public ToursController(ToursService ts)
    {
      _ts = ts;
    }

    [HttpGet]
    public ActionResult<List<Tour>> GetAll(int id)
    {
      try
      {
        List<Tour> tours = _ts.GetAll();
        return Ok(tours);
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpPost]
    [Authorize]
    public ActionResult<Tour> Create([FromBody] Tour newTour)
    {
      try
      {
        Tour tour = _ts.Create(newTour);
        return Ok(tour);
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpDelete("{id}")]
    [Authorize]
    public async Task<ActionResult<Tour>> Remove(int id)
    {
      Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
      _ts.Remove(id, userInfo.Id);
      return Ok("DELETED");
    }

  }
}