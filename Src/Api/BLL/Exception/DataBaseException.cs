namespace BLL.Exception
{
    public class DataBaseException : System.Exception
    {
        public DataBaseException()
        {
        }

        public DataBaseException(string message)
            : base(message)
        {
        }
    }
}
