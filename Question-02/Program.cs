static void Main()
{
	Solver solution = new Solver(GetHints());
	var password = solution.Solve();
	Console.WriteLine("Password is : " + password);
}

public interface IFind
{
	bool Query(string checkIt);
}

class ExactMatch : IFind
{
	private string hint;
	public ExactMatch(string hint)
	{
		this.hint = hint;
	}
	public bool Query(string checkIt)
	{
		for(int i=0; i < checkIt.Length; i++)
		{
			if(checkIt[i]==hint[i]) return true;
		}
		return false;
	}
}

class NoMatch : IFind
{
	private string hint;
	public NoMatch(string hint)
	{
		this.hint = hint;
	}
	public bool Query(string checkIt)
	{
		for(int i=0; i < checkIt.Length; i++)
		{
			if(checkIt.Contains(hint[i])) return false;
		}
		return true;
	}
}

class RightDigitWrongPlace : IFind
{
	private string hint;
	public RightDigitWrongPlace(string hint)
	{
		this.hint = hint;
	}
	public bool Query(string checkIt)
	{
		for(int i=0; i < checkIt.Length; i++)
		{
			if((checkIt.Contains(hint[i])) && (checkIt[i] != hint[i]))
				return true;
		}
		return false;
	}
}

class TwoRightDigitWrongPlace : IFind
{
	private string hint;
	public TwoRightDigitWrongPlace(string hint)
	{
		this.hint = hint;
	}
	public bool Query(string checkIt)
	{
		int matchCount = 0;
		for(int i=0; i < checkIt.Length; i++)
		{
			if((checkIt.Contains(hint[i])) && (checkIt[i] != hint[i]))
				matchCount++;
		}
		return matchCount==2;
	}
}

static List<IFind> GetHints()
{
	return new List<IFind>()
	{
		new ExactMatch("682"),
		new RightDigitWrongPlace("614"),
		new RightDigitWrongPlace("780"),
		new TwoRightDigitWrongPlace("206"),
		new NoMatch("738")
	};
}

class Solver
{
	private List<IFind> hints;
	public Solver(List<IFind> hints)
	{
		this.hints = hints;
	}

	public string Solve()
	{
		for(int i=0; i<1000; i++)
		{
			string checkIt = i.ToString().PadLeft(3,'0');
			if(hints.All(x => x.Query(checkIt))) return checkIt; //Linq magic
		}
		return "No solution!";
	}
}