using UnityEngine;
using Unity.Mathematics;

#if UNITY_EDITOR
using UnityEditor;
#endif

namespace Game.Models.CelestialMechanics.Units
{
	// https://en.wikipedia.org/wiki/Parsec
	[System.Serializable]
	public struct pc
	{
		public double Value;

		public static readonly m meters = (m) 30856775814913673d;
		
		public static explicit operator double ( pc parsec ) => parsec.Value;
		public static explicit operator pc ( double dbl ) => new pc{ Value=dbl };

		public static implicit operator pc ( m meters ) => new pc{ Value = meters.Value * ( 1d / meters.Value ) };
		
		public static bool operator > ( pc lhs , pc rhs ) => lhs.Value > rhs.Value;
		public static bool operator < ( pc lhs , pc rhs ) => lhs.Value < rhs.Value;

		const string _unit = "pc";
		public override string ToString () => $"{Value} [{_unit}]";
		#if UNITY_EDITOR
		[CustomPropertyDrawer(typeof(pc))] public class MyPropertyDrawer : UnitPropertyDrawer { public override string unit => _unit; }
		#endif
	}
}
