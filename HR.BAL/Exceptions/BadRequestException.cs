namespace HR.BAL.Exceptions;

public class BadRequestException : Exception
{
	public BadRequestException(string message) : base(message) { }
}