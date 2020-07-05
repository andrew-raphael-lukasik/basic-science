using UnityEngine;
using Unity.Mathematics;

#if UNITY_EDITOR
using UnityEditor;
#endif

namespace Game.Models.CelestialMechanics.Units
{
	/// <summary>
	/// Kilometer cubed per second squared.
	/// </summary>
	[System.Serializable]
	public struct km3ps2
	{
		public double Value;

		public static explicit operator km3ps2 ( double dbl ) => new km3ps2{ Value=dbl };
		public static explicit operator double ( km3ps2 km3ps2 ) => km3ps2.Value;
		public static implicit operator km3ps2 ( m3ps2 val ) => new km3ps2{ Value = val.Value * 1e-9 };
		public static implicit operator km3ps2 ( kg val ) => (km3ps2)(m3ps2)val * G.Value;//gm

		public static km3ps2 operator + ( km3ps2 a , km3ps2 b ) => new km3ps2{ Value = a.Value + b.Value };
		public static km3ps2 operator - ( km3ps2 a , km3ps2 b ) => new km3ps2{ Value = a.Value - b.Value };
		public static km3ps2 operator * ( km3ps2 a , km3ps2 b ) => new km3ps2{ Value = a.Value * b.Value };
		public static km3ps2 operator * ( km3ps2 a , double b ) => new km3ps2{ Value = a.Value * b };
		
		const string _unit = "km3/s2";
		public override string ToString () => $"{Value} [{_unit}]";
		#if UNITY_EDITOR
		[CustomPropertyDrawer(typeof(km3ps2))] public class MyPropertyDrawer : UnitPropertyDrawer { public override string unit => _unit; }
		#endif
	}
}
