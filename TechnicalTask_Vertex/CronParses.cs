using System.Text;
using System.Xml;

namespace TechnicalTask_Vertex;

public class CronParses
{
    static void Main(string[] args)
    {
        var expression = Console.ReadLine();

        if (expression != null)
        {
            ParseCronExpression(expression);
        }
    }

    public static void ParseCronExpression(string expression)
    {
        string[] subs = expression.Split(' ');

        if (subs.Length < 6)
        {
            Console.WriteLine("Invalid parameters");
        }

        var minutes = BuildMinutes(subs[0]);
        var hours = BuildHours(subs[1]);
        var dayOfMonths = BuildDayOfMonths(subs[2]);
        var months = BuildMonths(subs[3]);
        var dayOfWeek = BuildWeeks(subs[4]);
        
        Console.WriteLine($"minute {minutes}");
        Console.WriteLine($"hour {hours}");
        Console.WriteLine($"day of month {dayOfMonths}");
        Console.WriteLine($"month {months}");
        Console.WriteLine($"day of week {dayOfWeek}");
        Console.WriteLine($"command {subs[5]}");
    }

    private static string BuildMinutes(string minutes)
    {
        if (minutes.Contains(','))
        {
            var values = minutes.Split(',');
            
            return string.Join(' ', values);
        }
        
        if (minutes.Contains('/'))
        {
            var values = minutes.Split('/');
            var sum = 0;
            var list = new List<string>();
            
            if (values[0] == "*")
            {
                list.Add("0");
                while (sum < 59)
                {
                    sum += int.Parse(values[1]);
                    list.Add($"{sum}");
                    if (sum + int.Parse(values[1]) > 59)
                    {
                        break;
                    }
                }
            }

            return string.Join(' ', list);
        }

        if (minutes == "*")
        {
            var list = new List<string>();
            
            var sum = 0;
            while (sum <= 59)
            {
                list.Add($"{sum}");
                sum++;
            }

            return string.Join(' ', list);
        }
        
        if (minutes.Contains('-'))
        {
            var values = minutes.Split('-');
            var list = new List<string>();
            StringBuilder sb = new StringBuilder();
            if (values[0] != "0" && values[1] != "0" && int.TryParse(values[0], out int result) && int.TryParse(values[1], out int result1))
            {
                var firstValue = int.Parse(values[0]);
                var secondValue = int.Parse(values[1]);

                while (firstValue < secondValue + 1)
                {
                    list.Add($"{firstValue}");
                    firstValue++;
                }

                return string.Join(' ', list);
            }
            else
            {
                return "0";
            }
        }
        
        return minutes;
    }
    
    private static string BuildHours(string hours)
    {
        if (hours.Contains(','))
        {
            var values = hours.Split(',');
            
            return string.Join(' ', values);
        }
        
        if (hours.Contains('/'))
        {
            var values = hours.Split('/');
            var sum = 0;
            var list = new List<string>();
        
            if (values[0] == "*")
            {
                list.Add("0");
                while (sum < 23)
                {
                    sum += int.Parse(values[1]);
                    list.Add($"{sum}");
                    if (sum + int.Parse(values[1]) > 23)
                    {
                        break;
                    }
                }
            }

            return string.Join(' ', list);
        }

        if (hours == "*")
        {
            StringBuilder sb = new StringBuilder("");
            var sum = 0;
            while (sum <= 23)
            {
                sb.Append($"{sum}");
                sum++;
            }

            return sb.ToString();
        }
        
        if (hours.Contains('-'))
        {
            var values = hours.Split('-');
            var list = new List<string>();
            StringBuilder sb = new StringBuilder();
            if (values[0] != "0" && values[1] != "0" && int.TryParse(values[0], out int result) && int.TryParse(values[1], out int result1))
            {
                var firstValue = int.Parse(values[0]);
                var secondValue = int.Parse(values[1]);

                while (firstValue < secondValue + 1)
                {
                    list.Add($"{firstValue}");
                    firstValue++;
                }

                return string.Join(' ', list);
            }
            else
            {
                return "0";
            }
        }
        
        return hours;
    }
    
    private static string BuildDayOfMonths(string dayOfMonths)
    {
        if (dayOfMonths.Contains(','))
        {
            var values = dayOfMonths.Split(',');
            
            return string.Join(' ', values);
        }
        
        if (dayOfMonths.Contains('/'))
        {
            var values = dayOfMonths.Split('/');
            var list = new List<string>();
            var sum = 1;
        
            if (values[0] == "*")
            {
                list.Add("1");
                while (sum <= 31)
                {
                    sum += int.Parse(values[1]);
                    list.Add($"{sum}");
                    if (sum + int.Parse(values[1]) > 31)
                    {
                        break;
                    }
                }
            }
            return string.Join(' ', list);
        }

        if (dayOfMonths == "*")
        {
            StringBuilder sb = new StringBuilder("");
            var sum = 1;
            while (sum <= 31)
            {
                sb.Append($"{sum}");
                sum++;
            }

            return sb.ToString();
        }
        
        if (dayOfMonths.Contains('-'))
        {
            var values = dayOfMonths.Split('-');
            var list = new List<string>();
            StringBuilder sb = new StringBuilder();
            if (values[0] != "0" && values[1] != "0" && int.TryParse(values[0], out int result) && int.TryParse(values[1], out int result1))
            {
                var firstValue = int.Parse(values[0]);
                var secondValue = int.Parse(values[1]);

                while (firstValue < secondValue + 1)
                {
                    list.Add($"{firstValue}");
                    firstValue++;
                }

                return string.Join(' ', list);
            }
            else
            {
                return "0";
            }
        }
        
        return dayOfMonths;
    }
    
    private static string BuildMonths(string months)
    {
        if (months.Contains(','))
        {
            var values = months.Split(',');
            
            return string.Join(' ', values);
        }
        
        if (months.Contains('/'))
        {
            var values = months.Split('/');
            var sum = 1;
            var list = new List<string>();
        
            if (values[0] == "*")
            {
                list.Add("1");
                while (sum < 12)
                {
                    sum += int.Parse(values[1]);
                    list.Add($"{sum}");
                    if (sum + int.Parse(values[1]) > 12)
                    {
                        break;
                    }
                }
            }

            return string.Join(' ', list);
        }

        if (months == "*")
        {
            var list = new List<string>();
            var sum = 1;
            while (sum <= 12)
            {
                list.Add($"{sum}");
                sum++;
            }

            return string.Join(' ', list);
        }
        
        if (months.Contains('-'))
        {
            var values = months.Split('-');
            var list = new List<string>();
            StringBuilder sb = new StringBuilder();
            if (values[0] != "0" && values[1] != "0" && int.TryParse(values[0], out int result) && int.TryParse(values[1], out int result1))
            {
                var firstValue = int.Parse(values[0]);
                var secondValue = int.Parse(values[1]);

                while (firstValue < secondValue + 1)
                {
                    list.Add($"{firstValue}");
                    firstValue++;
                }

                return string.Join(' ', list);
            }
            else
            {
                return "0";
            }
        }
        
        return months;
    }
    
    private static string BuildWeeks(string weeks)
    {
        if (weeks.Contains(','))
        {
            var values = weeks.Split(',');
            
            return string.Join(' ', values);
        }
        
        if (weeks.Contains('/'))
        {
            var values = weeks.Split('/');
            var sum = 0;
            var list = new List<string>();
        
            if (values[0] == "*")
            {
                list.Add("1");
                while (sum <= 7)
                {
                    sum += int.Parse(values[1]);
                    list.Add($"{sum}");
                    if (sum + int.Parse(values[1]) > 7)
                    {
                        break;
                    }
                }
            }

            return string.Join(' ', list);
        }

        if (weeks == "*")
        {
            StringBuilder sb = new StringBuilder("");
            var sum = 1;
            while (sum <= 31)
            {
                sb.Append($"{sum}");
                sum++;
            }

            return sb.ToString();
        }

        if (weeks.Contains('-'))
        {
            var values = weeks.Split('-');
            var list = new List<string>();
            StringBuilder sb = new StringBuilder();
            if (values[0] != "0" && values[1] != "0" && int.TryParse(values[0], out int result) && int.TryParse(values[1], out int result1))
            {
                var firstValue = int.Parse(values[0]);
                var secondValue = int.Parse(values[1]);

                while (firstValue < secondValue + 1)
                {
                    list.Add($"{firstValue}");
                    firstValue++;
                }

                return string.Join(' ', list);
            }
            else
            {
                return "0";
            }
        }

        return weeks;
    }
    
}