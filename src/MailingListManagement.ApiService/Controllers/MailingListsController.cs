using MailingListManagement.ApiService.Models;
using Microsoft.AspNetCore.Mvc;

namespace MailingListManagement.ApiService.Controllers;

[ApiController]
[Route("[controller]")]
public class MailingListsController : ControllerBase
{
    private readonly List<MailingList> _mailingLists = Enumerable.Range(1, 5).Select(i => new MailingList(Guid.NewGuid(), $"Mailing List {i}")).ToList();

    [HttpGet]
    public IActionResult Get() => Ok(_mailingLists);
}
