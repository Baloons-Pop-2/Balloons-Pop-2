using System;
using BalloonsPop;
using BalloonsPop.Traversals;

namespace BalloonsPopConsoleApp
{
    public class Balloon : IBalloon
    {
        private ITraversalEffect effect;
	
	    public Balloon(int value, ITraversalEffect traversalEffect)
	    {
		    this.Value = value;
	        this.TraversalEffect = traversalEffect;
	    }

        public int Value { get; set; }
	
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
