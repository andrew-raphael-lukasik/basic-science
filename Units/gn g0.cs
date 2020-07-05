using UnityEngine;
using Unity.Mathematics;

namespace Game.Models.CelestialMechanics.Units
{
	
	/// <summary> Nominal gravitational acceleration of an object in a vacuum near the surface of the Earth. </summary>
	public struct gn
	{
		public const double Value = 9.80665;
		public static mps2 mps2 => new mps2{ Value=gn.Value };
	}
	
	/// <summary> Nominal gravitational acceleration of an object in a vacuum near the surface of the Earth. </summary>
	public struct g0
	{
		public double Value => gn.Value;
		public static mps2 mps2 => new mps2{ Value=gn.Value };
	}
	
}
