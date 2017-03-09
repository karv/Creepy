using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace Creepy
{
	public interface ITileObject
	{
		
	}

	public interface ITile
	{
		Point Location { get; }

		int People { get; }

		ICollection<ITileObject> Objects { get; }
	}
}