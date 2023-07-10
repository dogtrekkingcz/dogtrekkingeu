using QrGenerator.Entities;
using SinKien.IBAN4Net;

namespace QrGenerator.Services;

internal class QrPaymentBuilder : IQrBuilder
{
    private PaymentQrRequest Request { get; }

    QrPaymentBuilder(PaymentQrRequest request)
    {
        Request = request;
    }
    
    public string Get()
    {
        string content;
        
        content = "SPD*1.0*";
        content += "ACC:" + GetIban(Request.BankAccount.Replace(" ", "")) + "*";
        content += "AM:" + Request.Price + ".00*";
        content += "CC:CZK*";
        content += "MSG:" + Request.Note + "*";
        content += "X-VS:" + Request.VariableSymbol;

        return content;
    }
    
    private static string GetIban(string bankAccount)
    {
        var prefix = "";
        if (bankAccount.Contains('-'))
            prefix = bankAccount.Substring(0, bankAccount.IndexOf('-'));

        var accountNumber = "";
        if (bankAccount.Contains('-'))
            accountNumber = bankAccount.Substring(bankAccount.IndexOf('-') + 1, bankAccount.IndexOf('/') - bankAccount.IndexOf('-') - 1);
        else
            accountNumber = bankAccount.Substring(0, bankAccount.IndexOf('/'));

        var bankCode = bankAccount.Substring(bankAccount.IndexOf('/') + 1);

        Iban iban = new IbanBuilder()
            .CountryCode(CountryCode.GetCountryCode("CZ"))
            .BankCode(bankCode)
            .AccountNumberPrefix(prefix)
            .AccountNumber(accountNumber)
            .Build();

        return iban.ToString();
    }
}