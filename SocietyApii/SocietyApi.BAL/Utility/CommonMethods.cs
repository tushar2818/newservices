namespace SocietyApi.BAL
{
    public class CommonMethods
    {
        public static string GetMessage(LogType logType, LogAction logAction)
        {
            var status = logAction == LogAction.Add ? "Added" : logAction == LogAction.Update ? "Updated" : "Deleted";
            return string.Format("{0} {1} successfully", CommonMethods.GetLogTypeName(logType), status);
        }

        public static string GetLogTypeName(LogType logType)
        {
            switch (logType)
            {
                case LogType.CompanyMaster:
                    return "Company Master";
                case LogType.DesignationMaster:
                    return "Designation Master";
                case LogType.EmployeeMaster:
                    return "Employee Master";
                case LogType.FlatMaster:
                    return "Flat Master";
                case LogType.FlatTypeMaster:
                    return "Flat Type Master";
                case LogType.FloorMaster:
                    return "Floor Master";
                case LogType.ProjectEmployee:
                    return "Project Employee";
                case LogType.ProjectMaster:
                    return "Project Master";
                case LogType.WingMaster:
                    return "Wing Master"; 
            }
            return logType.ToString();
        }

    } 
}
