using UnityEngine;
using Unity.Mathematics;

#if UNITY_EDITOR
using UnityEditor;
#endif

namespace BasicScience
{
	// [m^3/(kg*s^2)]
	public struct G
	{
		public const double Value = 6.67430e-11;//[m3⋅kg−1⋅s−2]
		public static readonly m3pkgs2 m3pkgs2 = (m3pkgs2) Value;

		public static m3ps2 operator * ( G _ , kg rhs ) => new kg{ Value = Value * rhs.Value };
		public static m3ps2 operator * ( kg a , G _ ) => new m3ps2{ Value = a.Value * G.Value };
		

		const string _unit = "m^3/(kg*s^2)";
		public override string ToString () => $"{Value} [{_unit}]";
		#if UNITY_EDITOR
		[CustomPropertyDrawer(typeof(G))] public class MyPropertyDrawer : UnitPropertyDrawer { public override string unit => _unit; }
		#endif
	}
}
