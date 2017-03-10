using Microsoft.Xna.Framework;

namespace Creepy.Systems
{
	/// <summary>
	/// Represents a system that controls the flow of lava
	/// </summary>
	public interface ILavaDynamics : IGameComponent, IUpdateable
	{
		Map Map { get; }
	}
}