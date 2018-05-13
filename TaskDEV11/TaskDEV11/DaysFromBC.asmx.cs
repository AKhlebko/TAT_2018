using System.Web.Services;

namespace TaskDEV11
{
    /// <summary>
    /// Simple WebService which counts number of days from BC
    /// </summary>
    [WebService(Namespace = "http://localhost/DaysFromBC/DaysFromBC.asmx/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    public class DaysFromBC : WebService
    {
        /// <summary>
        /// Method counts number of days from BC
        /// </summary>
        /// <param name="dateInStringFormat">
        /// Date in DD/MM/YYYY format
        /// </param>
        /// <returns>
        /// Number of days from BC
        /// </returns>
        [WebMethod]
        public int CountDaysFromBC(string dateInStringFormat)
        {
            Date date = new Date(dateInStringFormat);
            int response = date.Day;
            for (int i = 0; i < date.Month - 1; i++)
            {
                response += Date.MonthDays[i];
            }
            response += (date.Year * 365);
            response += date.GetLeapYearsExtraDays(date.Year - 1);
            return response;
        }
    }
}
