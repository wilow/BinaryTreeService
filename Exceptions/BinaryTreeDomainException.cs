namespace BinaryTreeService.Exceptions;

public class BinaryTreeDomainException : Exception
{
    public BinaryTreeDomainException()
    { }

    public BinaryTreeDomainException(string message)
        : base(message)
    { }

    public BinaryTreeDomainException(string message, Exception innerException)
        : base(message, innerException)
    { }
}
