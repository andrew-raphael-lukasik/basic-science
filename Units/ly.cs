using UnityEngine;
using Unity.Mathematics;

#if UNITY_EDITOR
using UnityEditor;
#endif

namespace Game.Models.CelestialMechanics.Units
{
	// https://en.wikipedia.org/wiki/Light-year
	/// <summary> Light year </summary>
	[System.Serializable]
	public struct ly
	{
		public double Value;
		
		public static readonly m meters = (m) 9460730472580800d;
		
		public static explicit operator double ( ly val ) => val.Value;
		public static explicit operator ly ( double val ) => new ly{ Value=val };

		public static implicit operator ly ( m val ) => new ly{ Value = val.Value / meters.Value };
		
		public static bool operator > ( ly lhs , ly rhs ) => lhs.Value > rhs.Value;
		public static bool operator < ( ly lhs , ly rhs ) => lhs.Value < rhs.Value;

		const string _unit = "ly";
		public override string ToString () => $"{Value} [{_unit}]";
		#if UNITY_EDITOR
		[CustomPropertyDrawer(typeof(ly))] public class MyPropertyDrawer : UnitPropertyDrawer { public override string unit => _unit; }
		#endif
	}
}
