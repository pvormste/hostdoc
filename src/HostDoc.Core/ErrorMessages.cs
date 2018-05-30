namespace HostDoc.Core
{
    public static class ErrorMessages
    {       
        public static string DirectoryNotFoundMessage(string hostLocation)
        {
            return $"Error: host file could not be found. ({hostLocation})";
        }

        public static string UnauthorizedAccessMessage()
        {
            return "Error: Not enough access rights. Did you run as super user?";
        }
    }
}