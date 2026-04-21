namespace BrazilianHolidaysApi.Exceptions;

public class NegocioException : Exception
{
    public NegocioException(string mensagem) : base(mensagem)
    {
    }
}