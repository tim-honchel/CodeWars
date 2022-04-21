using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace TestCode
{


    //SimpleFun #26: Weak Numbers

    public class Challenge
    {

        public static int Stray(int[] numbers)
        {
            int recurring = numbers[0] == numbers[1] || numbers[0] == numbers[2] ? numbers[0] : numbers[1];
            foreach (int num in numbers)
            {
                if (num != recurring) { return num; }
            }
            return 0;
        }

        public static double TankVol(int h, int d, int vt)
        {
            double diameter = Convert.ToDouble(d);
            double radius = diameter / 2;
            double height = Convert.ToDouble(h);
            double volume = Convert.ToDouble(vt);
            double tankLength = vt / (Math.PI * Math.Pow(radius, 2));
            double area = 0;

            return tankLength * area;
        }


        public string Likes(string[] name)
        {
            if (name.Length == 0)
            {
                return "no one likes this";
            }
            else if (name.Length == 1)
            {
                return $"{name[0]} likes this";
            }
            else if (name.Length == 2)
            {
                return $"{name[0]} and {name[1]} like this";
            }
            else if (name.Length == 3)
            {
                return $"{name[0]}, {name[1]} and {name[2]} like this";
            }
            else
            {
                return $"{name[0]}, {name[1]} and {name.Length - 2} others like this";
            }
        }
        public static string Add(string a, string b)
        {
            var digits = Math.Max(a.Length, b.Length) + 1;
            var array = new int[digits];
            var intA = 0;
            var intB = 0;
            var intC = 0;
            var carry = 0;
            for (int index = -1; index >= -array.Length; index--)
            {
                try
                {
                    intA = Convert.ToInt32(a[a.Length + index].ToString());

                }
                catch (Exception)
                {
                    intA = 0;
                }
                try
                {
                    intB = Convert.ToInt32(b[b.Length + index].ToString());
                }
                catch (Exception)
                {
                    intB = 0;
                }
                intC = intA + intB + carry;
                if (intC >= 10)
                {
                    carry = 1;
                    intC -= 10;
                }
                else
                {
                    carry = 0;
                }
                array[digits + index] = intC; ;
            }
            var answer = "";
            for (int i = 0; i < array.Length; i++)
            {
                if (i > 0 || array[i] > 0)
                {
                    answer += array[i].ToString();
                }
            }

            return answer;

        }

        public static bool IsVeryEvenNumber(int number)
        {
            while (true)
            {
                Console.WriteLine($"main: {number}");
                if (number % 2 == 0)
                {
                    if (number < 10)
                    {
                        return true;
                    }
                    else
                    {
                        number = Reduce(number);
                    }
                }
                else
                {
                    return false;
                }
            }
        }
        public static int Reduce(int number)
        {
            Console.WriteLine($"reducing: {number}");
            var numbers = Convert.ToString(number);
            var sum = 0;
            foreach (char num in numbers)
            {
                Console.WriteLine($"adding: {Convert.ToInt32(num.ToString())}");
                sum += Convert.ToInt32(num.ToString());
            }
            return sum;
        }
        public static String DateNbDays(double a0, double a, double p)
        {
            var days = Math.Ceiling((Math.Log10(a) - Math.Log10(a0)) / Math.Log10(1 + p / 36000));
            DateTime start = new DateTime(2016, 1, 1);
            DateTime finish = start.AddDays(days);
            var month = finish.Month >= 10 ? $"{finish.Month}" : $"0{finish.Month}";
            var day = finish.Day >= 10 ? $"{finish.Day}" : $"0{finish.Day}";
            var answer = $"{finish.Year}-{month}-{day}";
            return answer;

        }
        public static int KookaCounter(string laughing)
        {
            var count = 0;
            var previous = "";
            var current = "";
            for (var i = 0; i < laughing.Length; i += 2)
            {
                current = laughing.Substring(i, 2);
                if (current.Equals(previous) == false)
                {
                    count++;
                }
                previous = current;
            }
            return count;
        }
        public static bool validBraces(string braces)
        {
            if (braces.Length == 0)
            {
                return false;
            }
            var next_close = new List<char>();
            foreach (char c in braces)
            {
                if (c == '(' || c == '{' || c == '[')
                {
                    next_close.Insert(0, c);
                }
                else if (c == ')' || c == '}' || c == ']')
                {
                    var opening_brace = new Dictionary<char, char>() {
                        {')','('},
                        {'}','{'},
                        {']','['}
                    };
                    try
                    {
                        if (next_close[0] == opening_brace[c])
                        {
                            next_close.RemoveAt(0);
                        }
                        else
                        {
                            return false;
                        }
                    }
                    catch (Exception)
                    {
                        return false;
                    }
                }
            }
            if (next_close.Count == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static bool IsPrime(int n)
        {
            if (Math.Abs(n) <= 1)
            {
                return false;
            }
            for (int i = 2; i < Math.Sqrt(Math.Abs(n)); i++)
            {
                if (Math.Abs(n) % i == 0)
                {
                    return false;
                }
            }
            return true;
        }
        public static string Change(string s, string prog, string version)
        {
            var answer = "";
            var begin = s.IndexOf("Version: ");
            var statedVersion = s.Substring(begin + 9).Split("\n")[0];
            Console.WriteLine(statedVersion);
            if (statedVersion.Count(x => x.Equals('.')) != 1)
            {
                answer = "ERROR: VERSION or PHONE";
            }
            else if (statedVersion.Split('.')[0] == "" || statedVersion.Split('.')[1] == "")
            {
                answer = "ERROR: VERSION or PHONE";
            }
            else
            {
                if (statedVersion == "2.0")
                {
                    version = "2.0";
                }
                var start = s.IndexOf("Phone: ");
                var phone = s.Substring(start + 7).Split("\n")[0];
                var correctFormat = @"^[+]?[1]?[-]?[0-9]{3}?[-]?[0-9]{3}?[-]?[0-9]{4}$";
                if (Regex.IsMatch(phone, correctFormat))
                {
                    answer = $"Program: {prog} Author: g964 Phone: +1 - 503 - 555 - 0090 Date: 2019-01-01 Version: {version}";
                }
                else
                {
                    answer = "ERROR: VERSION or PHONE";
                }

            }
            return answer;
        }
        public static string Travel(string r, string zipcode)
        {
            var allAddresses = new List<string>(r.Split(","));
            var matchingAddresses ="";
            var matchingHouseNumbers = "";
            foreach (string address in allAddresses)
            {
                if (address.Contains(zipcode) == true)
                {
                    var houseNumber = "";
                    for (int i= 0; i < address.Length; i++)
                    {
                        if (address[i].Equals(' '))
                        {
                            houseNumber= address.Substring(0,i);
                            break;
                        }
                    }

                    matchingHouseNumbers += houseNumber + ",";
                    matchingAddresses += address.Split($" {zipcode}")[0].Substring(houseNumber.Length) + ",";
                    
                }
            }
            if (matchingAddresses.Length > 0)
            {
                matchingAddresses = matchingAddresses.Substring(0, matchingAddresses.Length - 1);
                matchingHouseNumbers = matchingHouseNumbers.Substring(0,matchingHouseNumbers.Length - 1);
            }
            return $"{zipcode}:{matchingAddresses}/{matchingHouseNumbers}";
        }
        public static string Battle(string x, string y)
        {
            var points = new Dictionary<char, int>()
            {
                { 'A',1 }, { 'B',2 },  { 'C',3 }, { 'D',4 }, { 'E',5 }, { 'F',6 }, { 'G',7 }, { 'H',8 }, { 'I',9 }, { 'J',10 }, { 'K',11 }, { 'L',12 }, { 'M',13 }, { 'N',14 }, { 'O',15 }, { 'P',16 }, { 'Q',17 }, { 'R',18 }, { 'S',19 }, { 'T',20 }, { 'U',21 }, { 'V',22 }, { 'W',23 }, { 'X',24 }, { 'Y',25 }, { 'Z',26 },
            };
            var score1 = 0;
            var score2 = 0;
            foreach (char c in x)
            {
                score1 += points[c];
            }
            foreach (char c in y)
            {
                score2 += points[c];
            }
            if (score1 > score2)
            {
                return x;
            }
            else if (score1 < score2)
            {
                return y;
            }
            else
            {
                return "Tie!";
            }
            return "";
        }
        public static string Swap(string str)
        {
            //var opposites = new Dictionary<char, char>()
            //{
                //{ 'A','a' }, { 'B','b' },  { 'C','c' }, { 'D','d' }, { 'E','e' }, { 'F','f' }, { 'G','g' }, { 'H','h' }, { 'I','i' }, { 'J','j' }, { 'K',11 }, { 'L',12 }, { 'M',13 }, { 'N',14 }, { 'O',15 }, { 'P',16 }, { 'Q',17 }, { 'R',18 }, { 'S',19 }, { 'T',20 }, { 'U',21 }, { 'V',22 }, { 'W',23 }, { 'X',24 }, { 'Y',25 }, { 'Z',26 },
            //};
            var newString = "";
            foreach (char c in str)
            {
                if (Char.IsUpper(c) == true)
                {
                    newString += c.ToString().ToLower();
                }
                else
                {
                    newString += c.ToString().ToUpper();
                }
            }

            return newString;
        }
        public static double[] Tribonacci(double[] signature, int n)
        {
            var answer = new double[n];
            if (n >= 3)
            {      
                answer[0] = signature[0];
                answer[1] = signature[1];
                answer[2] = signature[2];
                for (int i = 3; i < n; i++)
                {
                    answer[i] = answer[i - 1] + answer[i - 2] + answer[i - 3];
                }
                return answer;
            }
            else if (n > 0)
            {
                for (int i = 0; i < n; i++)
                {
                    answer[i] = signature[i];
                }
                return answer;
            }
            else
            {
                return answer;
            }
        }

        public static double[] xbonacci(double[] signature, int n)
        {
            var answer = new double[n];
            if (n > 0 && signature.Length > 0)
            {
                for (int i = 0; i < signature.Length && i < n; i++)
                {
                    answer[i] = signature[i];
                }
                for (int i = signature.Length; i < n; i++)
                {
                    answer[i] = 0;
                    for (int j = 1; j <= signature.Length; j++)
                    {
                        if (i - j >= 0)
                        {
                            answer[i] += answer[i - j];
                        }
                    }
                }
            }
            return answer;
        }
        public static string FridayTheThirteenths(int Start, int End = int.MinValue)
        {
            var month = 1;
            var year = Start;
            var answer = "";
            if (End < Start)
            {
                End = Start;
            }
            while (year <= End)
            {
                DateTime date = new DateTime(year, month, 13);
                if (date.DayOfWeek == DayOfWeek.Friday)
                {
                    answer += $"{month}/13/{year} ";
                }
                month++;
                if (month > 12)
                {
                    year++;
                    month = 1;
                }
            }
            answer = answer.TrimEnd();
            return answer;
        }
        public static bool comp(int[] a, int[] b)
        {
            if (a is not null && b is not null && a.Length == b.Length)
            {
                var counter = new Dictionary<int, int>();
                foreach (int i in a)
                {
                    if (counter.ContainsKey(i) == false)
                    {
                        counter[i] = 0;
                    }
                    else
                    {
                        counter[i]++;
                    }
                }
                foreach (int i in b)
                {

                }
            }
            return false;
        }
        public bool IsNarcissistic(long n)
        {
            var stringNum = n.ToString();
            double numDigits = stringNum.Length;
            double sum = 0;
            foreach (char num in stringNum)
            {
                sum += Math.Pow(Convert.ToUInt64(num.ToString()), numDigits);
            }
            if (Convert.ToUInt64(sum) == Convert.ToUInt64(n))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public String isSumOfCubes(String s)
        {
            var numberGroups = new List<int>();
            var numberList = "0123456789";
            for (int i = 0; i < s.Length; i++)
            {
                if (i < s.Length - 2 && numberList.Contains(s[i].ToString()) && numberList.Contains(s[i + 1].ToString()) && numberList.Contains(s[i + 2].ToString()))
                {
                    numberGroups.Add(Convert.ToInt16(s.Substring(i, 3)));
                    i+=2;
                }
                else if (i < s.Length - 1 && numberList.Contains(s[i].ToString()) && numberList.Contains(s[i + 1].ToString()))
                {
                    numberGroups.Add(Convert.ToInt16(s.Substring(i,2)));
                    i++;
                }
                else if (numberList.Contains(s[i].ToString()))
                {
                    numberGroups.Add(Convert.ToInt16(s[i].ToString()));
                }

            }
            double total = 0;
            var answer = "";
            foreach (int n in numberGroups)
            {
                var stringNum = n.ToString();
                double numDigits = stringNum.Length;
                double sum = 0;
                foreach (char num in stringNum)
                {
                    sum += Math.Pow(Convert.ToUInt64(num.ToString()), 3);
                }
                if (Convert.ToUInt64(sum) == Convert.ToUInt64(n))
                {
                    total += sum;
                    answer += stringNum + " ";
                }
            }
            if (answer.Length > 0)
            {
                answer += total + " Lucky";
            }
            else
            {
                answer = "Unlucky";
            }
            return answer;
        }
        public string Rot13(string input)
        {
            var letters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
            var deciphered = "";
            foreach (char letter in input)
            {
                var index = letters.IndexOf(letter.ToString());
                if (index == -1)
                {
                    deciphered += letter.ToString();
                }
                else if (index < 13)
                {
                    deciphered += letters[index + 13];
                }
                else if (index < 26)
                {
                    deciphered += letters[index - 13];
                }
                else if (index < 39)
                {
                    deciphered += letters[index + 13];
                }
                else
                {
                    deciphered += letters[index - 13];
                }
            }
            return deciphered;
        }
        static void Main(string[] args)
        {

            var s = Console.ReadLine();
            //Console.WriteLine(Rot13(s));
            Console.ReadKey();
        }
                

    }
}

