namespace QuickFiles.Utils
{

    // useless (for now) since most main directorys are stored as env variables
    class GetMachineOwner
    {
        public static string GetOwner()
        {
            return System.Environment.UserName;
        }
    }
}