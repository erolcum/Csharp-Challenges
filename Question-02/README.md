Without Linq line in Program.cs, **Solve()** method should be like this :<br>

![i2](https://github.com/erolcum/Csharp-Challenges/assets/110387801/3c5b1ab8-4bba-416d-b7c6-712391845b8c)
<br>
    public string Solve()
    {			
	    for(int i=0; i<1000; i++)
	    {
		    string checkIt = i.ToString().PadLeft(3,'0');
		    int checkAll = 0;
		    foreach(IFind j in hints)
		    {
			    int test = j.Query(checkIt) ? 1 : 0;
			    checkAll += test;
		    }
		  if(hints.Count()==checkAll) return checkIt;				
	    }			
	  return "No solution!";
  }
