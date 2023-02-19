namespace Shipping.Exceptions
{
    public class DuplicateException : ApplicationException
    {
        public DuplicateException(string name, object key)
           : base($"Entity \"{name}\" ({key}) Duplicate.")
        {

        }
    }
}
