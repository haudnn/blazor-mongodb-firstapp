namespace FirstApp.Helpers;
public class RenderTimeHelper
{
    public static List<string> RenderTime(string startTime, string endTime, int step)
    {
        var times = new List<string>();
        var startHour = int.Parse(startTime.Split(':')[0]);
        var startMinute = int.Parse(startTime.Split(':')[1]);
        var endHour = int.Parse(endTime.Split(':')[0]);
        var endMinute = int.Parse(endTime.Split(':')[1]);
        var startTotalMinutes = startHour * 60 + startMinute;
        var endTotalMinutes = endHour * 60 + endMinute;
        var currentTotalMinutes = startTotalMinutes;
        while (currentTotalMinutes <= endTotalMinutes)
        {
            var currentHour = (int)Math.Floor((decimal)currentTotalMinutes / 60);
            var currentMinute = currentTotalMinutes % 60;
            var formattedTime = $"{currentHour.ToString().PadLeft(2, '0')}:{currentMinute.ToString().PadLeft(2, '0')}";
            times.Add(formattedTime);
            currentTotalMinutes += step;
        }

        return times;
    }
    public static string FormatTime(bool isEndTime)
    {

        var currentTime = DateTimeOffset.UtcNow.ToOffset(TimeSpan.FromHours(7));
        // isEndTime: for format endtime
        var hour = isEndTime ? currentTime.Hour + 1 : currentTime.Hour;
        var minute = currentTime.Minute;
        var roundedMinute = minute < 30 ? 30 : 0;
        var roundedTime = $"{hour:00}:{roundedMinute:00}";
        return roundedTime;
    }

}


// DateTime timeUtc = DateTime.UtcNow;
// TimeZoneInfo tz = TimeZoneInfo.FindSystemTimeZoneById("SE Asia Standard Time");
// DateTime currentDateTime = TimeZoneInfo.ConvertTimeFromUtc(timeUtc, tz);
// string currentTime = currentDateTime.ToString("HH:mm:ss");