namespace BLL.Exception
{
    public class InternalException : System.Exception
    {
        public InternalException()
        { 
        }

        public InternalException(string message)
            :base(message)
        {
        }
    }
}
