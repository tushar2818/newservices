using System;
using System.Collections.Generic;
using System.Data;
using System.Dynamic;
using System.Globalization;

namespace CityService.DTO
{
    public static class Converters
    {
        public static List<dynamic> ConvertToDataTable(DataTable dataTable)
        {
            var result = new List<dynamic>();
            foreach (DataRow row in dataTable.Rows)
            {
                dynamic dyn = new ExpandoObject();
                foreach (DataColumn column in dataTable.Columns)
                {
                    var dic = (IDictionary<string, object>)dyn;
                    dic[column.ColumnName] = row[column];
                }
                result.Add(dyn);
            }
            return result;
        }
        public static dynamic ConvertToModel(DataTable dataTable)
        {
            var result = new List<dynamic>();
            foreach (DataRow row in dataTable.Rows)
            {
                dynamic dyn = new ExpandoObject();
                foreach (DataColumn column in dataTable.Columns)
                {
                    var dic = (IDictionary<string, object>)dyn;
                    dic[column.ColumnName] = row[column];
                }
                result.Add(dyn);
            }
            return result[0];
        }
        public static string GetEpochTime(DateTime dateTime)
        {
            dateTime = GetIndianDate(dateTime);
            var epoch = (long)((dateTime.ToUniversalTime() -
                new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalSeconds);

            string epochDateTime = epoch.ToString();

            return epochDateTime;
        }
        public static string GetCurrentEpochTime()
        {
            var epoch = (long)(GetIndianDate(DateTime.UtcNow) -
                new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalSeconds;

            string epochDateTime = epoch.ToString();

            return epochDateTime;
        }

        public static object GetCityTypeFromId(string cityType)
        {
            return cityType == "1" ? "State" :
                cityType == "2" ? "District" :
                cityType == "3" ? "Taluka" :
                cityType == "4" ? "Village" : "Area";
        }

        public static string epoch2string(string epoch)
        {
            if (string.IsNullOrEmpty(epoch))
                return epoch;

            var utime = (long)Convert.ToDouble(epoch);

            string epochDateTime = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc).AddSeconds(utime).ToString(Constants.DATE_TIME_FORMAT);

            return epochDateTime;
        }
        public static DateTime epoch2DateTime(string epoch)
        {
            if (string.IsNullOrEmpty(epoch))
                return new DateTime();

            var utime = (long)Convert.ToDouble(epoch);
            return new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc).AddSeconds(utime);
        }
        public static DateTime GetIndianDate(DateTime dateTime = new DateTime())
        {
            TimeZoneInfo ZONE = TimeZoneInfo.FindSystemTimeZoneById(Constants.DATE_TIME_ZONE);
            DateTime indianTime;
            if (dateTime.Year == 0)
                indianTime = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, ZONE);
            else
                indianTime = TimeZoneInfo.ConvertTime(dateTime, ZONE);
            return indianTime;
        }
    }
}