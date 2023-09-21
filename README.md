# CsharpInterviewQuestion-01

**Question :**<br>Write a method that gets 2 positive big integers as string then returns the result as a string. (**do not use** BigInteger data type)<br>

    public static string Sum(string val1, string val2)
    {
   
    }

**Answer :**<br>
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

Yes
