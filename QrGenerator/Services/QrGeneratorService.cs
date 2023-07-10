using QRCoder;
using QrGenerator.Entities;

namespace QrGenerator.Services;

internal class QrGeneratorService : IQrGeneratorService
{
    public byte[] GeneratePng(IQrBuilder builderService)
    {
        var content = builderService.Get();
        
        QRCodeGenerator qrGenerator = new QRCodeGenerator();
        QRCodeData qrCodeData = qrGenerator.CreateQrCode(content, QRCodeGenerator.ECCLevel.Q);
        PngByteQRCode qrCode = new PngByteQRCode(qrCodeData);
        var qrPng = qrCode.GetGraphic(20);
        
        return qrPng;
    }
}