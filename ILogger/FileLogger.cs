namespace ILogger
{
    internal class FileLogger : IUserLogger
    {
        public void Log(string message)
        {
            try
            {
                using (var sw = new StreamWriter("errors.txt", true))
                {
                    sw.WriteLine(message);
                }
            }
            catch (Exception)
            {

            }
        }
    }
}