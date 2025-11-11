using MailingListManagement.ApiService.Models;
using Microsoft.AspNetCore.Mvc;

namespace MailingListManagement.ApiService.Controllers;

[ApiController]
[Route("[controller]")]
public class MailingListsController : ControllerBase
{
    private static readonly List<Guid> _guids = [
        new Guid("b8309eaf-2293-4335-b2e0-75a8534e0c70"),
        new Guid("f00c7246-ebe1-4dc5-9f36-dadfd312cf60"),
        new Guid("15e7e4d5-70c8-4511-82dc-1d299fd546b5"),
        new Guid("d44e416f-0d72-4536-b79d-0922b37b7513"),
        new Guid("795cc3b9-b8c7-4cbe-a86a-85455033174b")
    ];
    private readonly List<MailingList> _mailingLists = Enumerable.Range(0, 4).Select(i => new MailingList(_guids[i], $"Mailing List {i}")).ToList();

    [HttpGet]
    public IActionResult Get() => Ok(_mailingLists);
}
