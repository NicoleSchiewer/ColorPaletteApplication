using ColorPaletteApp.Interfaces;
using ColorPaletteApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace ColorPaletteApp.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PaletteController(IGeminiService geminiService) : ControllerBase
{
    [HttpPost]
    public async Task<ActionResult<PaletteResponse>> GeneratePalette([FromBody] PromptRequest request)
    {
        try
        {
            var result = await geminiService.GeneratePaletteAsync(request.Prompt);
            return Ok(result);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Error generating palette: {ex.Message}");
        }
    }

    [HttpOptions]
    public IActionResult Preflight()
    {
        Response.Headers.Append("Access-Control-Allow-Origin", "https://color-palette-application.vercel.app");
        Response.Headers.Append("Access-Control-Allow-Methods", "POST, OPTIONS");
        Response.Headers.Append("Access-Control-Allow-Headers", "Content-Type");
        return NoContent();
    }

}
