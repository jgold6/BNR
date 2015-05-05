using System;

namespace Blocky
{
	public class BNRExecutor
	{
		public delegate int Equation(int x, int y);

		public Equation equation {get; set;}

		public int computeWith(int value1, int value2)
		{
			if (equation == null)
				return 0;
			return equation(value1, value2);
		}

		public BNRExecutor()
		{
		}
	}
}

