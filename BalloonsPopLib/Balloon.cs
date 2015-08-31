using System;
using BalloonsPop.Traversals;

namespace BalloonsPop
{
    public class Balloon
    {
	    private const int MinValue = 1;
	    private const int MaxValue = 4;
	
	    private int value;
        private ITraversalEffect effect;
	
	    public Balloon(int value, ITraversalEffect traversalEffect)
	    {
		    this.Value = value;
	        this.TraversalEffect = traversalEffect;
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
                        string.Format("The value of the balloons must be between {0} and {1}",
                        MinValue, MaxValue)
                    );
			    }
			
			    this.value = value;
		    }
	    }
	
		public ITraversalEffect TraversalEffect
	    {
		    get
		    {
			    return this.effect;
		    }
		
		    private set
		    {
		        if (value == null)
		        {
		            throw new ArgumentNullException("effect");
		        }

			    this.effect = value;
		    }
	    }

        public static Balloon Default
        {
            get { return default(Balloon); }
        }
    }
}
