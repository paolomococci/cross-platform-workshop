namespace PetLibrary;
public class PetException : Exception
{
  public PetException() : base() { }
  public PetException(string message) : base(message) { }
  public PetException(string message, Exception innerException) : base(message, innerException) { }
}
