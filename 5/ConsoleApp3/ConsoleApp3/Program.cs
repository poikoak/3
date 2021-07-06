using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
namespace ConsoleApp3
{
    class Program
    {
        void massa()
        {
            Console.WriteLine(@"Enter Mass: kg., g.");

            string str = Console.ReadLine();

            // MatchCollection m = Regex.Matches(str, @"^([01]|[0-9])+\wkg+\s+([0-9])+\wg?");
            MatchCollection m = Regex.Matches(str, @"^(\d+kg)?(\s*([1-9]|[1-9][0-9])+g)?$");
            if (m.Count > 0) Console.WriteLine("Yes. Correct data: ");
            else Console.WriteLine("No, invalid data");



        }

        void IP()
        {
            Console.WriteLine(@"Enter Ip address: 192.168.0.23");

            string str = Console.ReadLine();

            // MatchCollection m = Regex.Matches(str, @"^([01]|[0-9])+\wkg+\s+([0-9])+\wg?");
            MatchCollection m = Regex.Matches(str, @"^((25[0-5]|2[0-4][0-9]|1[0-9][0-9]|[1-9]?[0-9])\.){3}(25[0-5]|2[0-4][0-9]|1[0-9][0-9]|[1-9][0-9]?)$");
            if (m.Count > 0) Console.WriteLine("Yes. Correct data: ");
            else Console.WriteLine("No, invalid data");



        }

        void mail()
        {
            Console.WriteLine(@"Enter mail: ");

            string str = Console.ReadLine();

            // MatchCollection m = Regex.Matches(str, @"^([01]|[0-9])+\wkg+\s+([0-9])+\wg?");
            MatchCollection m = Regex.Matches(str, @"^((
            ([A-Za-z0-9]+_+)|
            ([A-Za-z0-9]+\-+)|
            ([A-Za-z0-9]+\.+)|
            ([A-Za-z0-9]+\++))
            *[A-Za-z0-9]+
            @((\w+\-+)|(\w+\.))
            *\w{1,63}\.[a-zA-Z]{2,6})$");
            if (m.Count > 0) Console.WriteLine("Yes. Correct data: ");
            else Console.WriteLine("No, invalid data");



        }

        void telefon()
        {
            Console.WriteLine(@"Enter number of phone: ");

            string str = Console.ReadLine();

           
            MatchCollection m = Regex.Matches(str, @"^((8|\+7)[\- ]?)?(\(?\d{3}\)?[\- ]?)?[\d\- ]{7,10}$");
            if (m.Count > 0) Console.WriteLine("Yes. Correct data: ");
            else Console.WriteLine("No, invalid data");



        }

        void city()
        {
            Console.WriteLine(@"Enter number of phone: ");

            string str = Console.ReadLine();


            MatchCollection m = Regex.Matches(str, @"^((г+\.\w+\s)?)?(ул+\.\w+\,|пр+\.\w+\,|пл+\.\w+\,)?(д+\.\d+\,)?(кв+\.\d)");
            if (m.Count > 0) Console.WriteLine("Yes. Correct data: ");
            else Console.WriteLine("No, invalid data");



        }
        static void Main(string[] args)
        {
            Program ms = new Program();
            //ms.massa();
            //ms.IP();
            //ms.mail();
            //ms.telefon();
            ms.city();
        }
    }
}
