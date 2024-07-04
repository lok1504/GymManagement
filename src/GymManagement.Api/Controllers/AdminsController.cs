using GymManagement.Application.Admins.Commands.CreateAdmin;
using GymManagement.Application.Admins.Queries.GetAdmin;
using GymManagement.Application.Admins.Queries.GetAdmins;
using GymManagement.Contracts.Admins;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace GymManagement.Api.Controllers;

[Route("admins")]
public class AdminsController : ApiController
{
    private readonly ISender _mediator;

    public AdminsController(ISender mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> CreateAdmin()
    {
        var command = new CreateAdminCommand();

        var createAdminResult = await _mediator.Send(command);

        return createAdminResult.Match(
            admin => CreatedAtAction(
                nameof(GetAdmin),
                new { adminId = admin.Id },
                new AdminResponse(admin.Id, admin.SubscriptionId)),
            Problem);
    }

    [HttpGet("{adminId:guid}")]
    public async Task<IActionResult> GetAdmin(Guid adminId)
    {
        var command = new GetAdminQuery(adminId);

        var getAdminResult = await _mediator.Send(command);
        return getAdminResult.Match(
            admin => Ok(new AdminResponse(admin.Id, admin.SubscriptionId)),
            Problem);
    }

    [HttpGet]
    public async Task<IActionResult> ListAdmins()
    {
        var command = new ListAdminsQuery();

        var listAdminsResult = await _mediator.Send(command);

        return listAdminsResult.Match(
            admins => Ok(admins.ConvertAll(admin => new AdminResponse(admin.Id, admin.SubscriptionId))),
            Problem);
    }
}
