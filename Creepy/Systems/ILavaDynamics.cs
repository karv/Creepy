using Microsoft.Xna.Framework;

namespace Creepy.Systems
{
	public interface ILavaDynamics : IGameComponent, IUpdateable
	{
		Map Map { get; }
	}
}