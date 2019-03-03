namespace IdentityService.BAL
{
    public class CommonMethods
    {
        public static string GetMessage(LogType logType, LogAction logAction)
        {
            var status = logAction == LogAction.Add ? "Added" : logAction == LogAction.Update ? "Updated" : "Deleted";
            return string.Format("{0} {1} successfully", logType, status);
        }
    } 
}
