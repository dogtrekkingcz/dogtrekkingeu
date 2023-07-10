using QrGenerator.Entities;

namespace QrGenerator.Services;

public interface IQrGeneratorService
{
    byte[] GeneratePng(IQrBuilder qrBuilder);
}