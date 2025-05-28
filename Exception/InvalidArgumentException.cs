namespace user_service.Exception;

public class InvalidArgumentException :System.Exception
{
    public InvalidArgumentException (string message) : base( message){}
}