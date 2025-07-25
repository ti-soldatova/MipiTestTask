using Microsoft.AspNetCore.Mvc;
using MipiTestTask.Application.Interfaces;

namespace MipiTestTask.Controllers;

[ApiController]
[Route("api/[controller]")]
public class DocumentsController : ControllerBase
{
    private readonly IDocumentApplicationService _documentApplicationService;

    public DocumentsController(IDocumentApplicationService documentApplicationService)
    {
        _documentApplicationService = documentApplicationService;
    }

    [HttpGet("{id}")]
    public IActionResult GetById(Guid id)
    {
        var document = _documentApplicationService.GetDocumentById(id);
        return Ok(document);
    }

    [HttpGet]
    public IActionResult GetByUserName([FromQuery] string user)
    {
        var documents = _documentApplicationService.GetDocumentsByUser(user);
        return Ok(documents);
    }
}
