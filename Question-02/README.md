Without Linq line in Program.cs, **Solve()** method should be like this :<br>

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


![i2](https://github.com/erolcum/Csharp-Challenges/assets/110387801/9d365af6-9fe5-4195-9e6c-a7adac0d4b2d)


