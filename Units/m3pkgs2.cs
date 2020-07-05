using UnityEngine;
using Unity.Mathematics;

#if UNITY_EDITOR
using UnityEditor;
#endif

namespace Game.Models.CelestialMechanics.Units
{
	/// <summary> m^3/(kg*s^2), gravitational constant G uses this unit </summary>
	[System.Serializable]
	public struct m3pkgs2
	{
		public double Value;

		public static explicit operator m3pkgs2 ( double dbl ) => new m3pkgs2{ Value=dbl };
		public static explicit operator double ( m3pkgs2 m3pkgs2 ) => m3pkgs2.Value;
		
		public static m3pkgs2 operator + ( m3pkgs2 a , m3pkgs2 b ) => new m3pkgs2{ Value = a.Value + b.Value };
		public static m3pkgs2 operator - ( m3pkgs2 a , m3pkgs2 b ) => new m3pkgs2{ Value = a.Value - b.Value };
		public static m3pkgs2 operator * ( m3pkgs2 a , m3pkgs2 b ) => new m3pkgs2{ Value = a.Value * b.Value };
		public static m3pkgs2 operator * ( m3pkgs2 a , double b ) => new m3pkgs2{ Value = a.Value * b };
		public static m3pkgs2 operator / ( m3pkgs2 a , double b ) => new m3pkgs2{ Value = a.Value / b };
		public static double operator / ( m3pkgs2 a , m3pkgs2 b ) => a.Value / b.Value;
		public static m3ps2 operator * ( m3pkgs2 a , kg b ) => new m3ps2{ Value = a.Value * b.Value };
		// public static m4pkgs2 operator * ( m3pkgs2 a , m b ) => new m3pkgs2{ Value = a.Value * b.Value };
		
		const string _unit = "m^3/(kg*s^2)";
		public override string ToString () => $"{Value} [{_unit}]";
		#if UNITY_EDITOR
		[CustomPropertyDrawer(typeof(m3pkgs2))] public class MyPropertyDrawer : UnitPropertyDrawer { public override string unit => _unit; }
		#endif
	}
}
