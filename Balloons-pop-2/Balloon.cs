using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BalloonsPops
{
    public class Balloon
    {
	    private const int MinValue = 1;
	    private const int MaxValue = 4;
	
	    private int value;
	    private TraversalPattern traversal;
	
	    public Balloon(int value, TraversalPattern traversal = TraversalPattern.Default)
	    {
		    this.Value = value;
		    this.TraversalPattern = traversal;
	    }
	
	    public int Value
	    {
		    get
		    {
			    return this.value;
		    }
		
		    private set
		    {
			    if (value < Balloon.MinValue || value > Balloon.MaxValue)
			    {
                    throw new ArgumentOutOfRangeException(
                        String.Format("The value of the balloons must be between {0} and {1}",
                        MinValue, MaxValue)
                    );
			    }
			
			    this.value = value;
		    }
	    }
	
		public TraversalPattern TraversalPattern
	    {
		    get
		    {
			    return this.traversal;
		    }
		
		    private set
		    {	
			    this.traversal = value;
		    }
	    }
    }
}
