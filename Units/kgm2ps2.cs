using UnityEngine;
using Unity.Mathematics;

#if UNITY_EDITOR
using UnityEditor;
#endif

namespace Game.Models.CelestialMechanics.Units
{
	/// <summary> (kg*m^2)/s^2, also 1J </summary>
	[System.Serializable]
	public struct kgm2ps2
	{
		public double Value;

		public static explicit operator kgm2ps2 ( double dbl ) => new kgm2ps2{ Value=dbl };
		public static explicit operator double ( kgm2ps2 kgm2ps2 ) => kgm2ps2.Value;

		public static implicit operator kgm2ps2 ( J val ) => new kgm2ps2{ Value = val.Value };
		
		const string _unit = "(kg*m^2)/s^2";
		public override string ToString () => $"{Value} [{_unit}]";
		#if UNITY_EDITOR
		[CustomPropertyDrawer(typeof(kgm2ps2))] public class MyPropertyDrawer : UnitPropertyDrawer { public override string unit => _unit; }
		#endif
	}
}
