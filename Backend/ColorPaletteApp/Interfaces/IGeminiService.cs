using ColorPaletteApp.Models;

namespace ColorPaletteApp.Interfaces;

public interface IGeminiService
{
    Task<PaletteResponse> GeneratePaletteAsync(string promptText);
}
