# CsharpInterviewQuestion-01

**Question :**<br>

Write a method that gets 2 positive big integers as string then returns the result as a string. (**do not use** BigInteger data type)<br>

    public static string Sum(string val1, string val2)
    {
   
    }

**Answer :**<br>

    using System;
    using System.Text;
    
    class Program
    {
      public static string Sum(string val1, string val2)
      {
        if (val1.Length > val2.Length)
            val2 = val2.PadLeft(val1.Length, '0');
         else
            val1=val1.PadLeft(val2.Length, '0');    

        var sb= new StringBuilder();
        int leapVal = 0;

        for (int i = val1.Length - 1; i >= 0; i--) 
        {
            int firstVal = int.Parse(val1[i].ToString());
            int lastVal = int.Parse(val2[i].ToString());

            int total = firstVal + lastVal + leapVal;
            leapVal = total > 9 ? 1 : 0;
            total %= 10;

            sb.Insert(0, total);
        }
        if (leapVal > 0) sb.Insert(0, 1);
        return sb.ToString();
      }

      static void Main()
      {
        string v1 = "900000000000000000000000000000000000000000000000000000000005";
        string v2 = "200000000000000000000000000000000000000000000000000000000007";
        string result = Sum(v1, v2);
        Console.WriteLine(v1);
        Console.WriteLine(v2);
        Console.WriteLine("------------------------------------------------------------");
        Console.WriteLine(result);
      }
    }

This method performs the addition process that we do with paper and pencil. I got it from an interview video :<br>
https://www.youtube.com/watch?v=7gDlAVWY3Lo<br>

**Answer 2 :** This solution uses the same algorithm by using Lists instead of StringBuilder..<br>

    using System;
    using System.Linq;
    using System.Runtime.Intrinsics;
    using System.Text;

    class Program
    {
        static void Main()
        {
            string v1 = "900000000000000000000000000000000000000000000000000000000007";
            string v2 = "200000000000000000000000000000000000000000000000000000000007";
            Sum vres = new Sum(v1,v2);

            Console.WriteLine(v1);
            Console.WriteLine(v2);
            Console.WriteLine("------------------------------------------------------------");
            Console.WriteLine(vres.ToString());
        }
    }

    public class Sum
    {
        List<int> digits;
        List<int> digits2;
        List<int> result;

        public Sum(string num, string num2)
        {       
            digits = new List<int>();
            digits2 = new List<int>();
            result= new List<int>();
            // Initialize the digits list with the individual digits of the number
            foreach (char digitChar in num)
            {
                digits.Add(int.Parse(digitChar.ToString()));
            }
            foreach (char digitChar in num2)
            {
                digits2.Add(int.Parse(digitChar.ToString()));
            }
            //Padleft 0 to the list if required
            if (digits.Count > digits2.Count) 
            { 
                int diff = digits.Count - digits2.Count;
                for (int i = 0; i < diff; i++) { digits2.Insert(0, 0); }
            }else if (digits.Count < digits2.Count) 
            {
                int diff = digits2.Count - digits.Count;
                for (int i = 0; i < diff; i++) { digits.Insert(0, 0); }
            }
        
            int leapVal = 0;
            for (int i = digits.Count - 1; i >= 0; i--) 
            { 
                int firstVal= digits[i];
                int lastVal= digits2[i];
                int total = firstVal + lastVal + leapVal;
                leapVal = total > 9 ? 1 : 0;
                total %= 10;
                result.Insert(0, total);
            }
            if(leapVal > 0) result.Insert(0, 1);
        }

        public override string ToString()
        {    
            return string.Join(string.Empty, result.Select(n => n.ToString()));
        }
    }
