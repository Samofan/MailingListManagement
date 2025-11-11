using Asp.Versioning;
using MailingListManagement.ApiService.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;

namespace MailingListManagement.ApiService.Controllers;

//[ApiController]
[ApiVersion("1")]
//[Route("[controller]")]
public class MailingListsController : ODataController
{
    private readonly List<MailingList> _mailingLists = Enumerable.Range(1, 5).Select(i => new MailingList($"Mailing List {i}")).ToList();

    [HttpGet]
    [EnableQuery]
    public IActionResult Get() => Ok(_mailingLists);
}
