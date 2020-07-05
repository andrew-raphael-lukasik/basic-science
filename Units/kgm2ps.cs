using UnityEngine;
using Unity.Mathematics;

#if UNITY_EDITOR
using UnityEditor;
#endif

namespace Game.Models.CelestialMechanics.Units
{
	/// <summary> (kg*m^2)/s </summary>
	[System.Serializable]
	public struct kgm2ps
	{
		public double Value;

		public static explicit operator kgm2ps ( double dbl ) => new kgm2ps{ Value=dbl };
		public static explicit operator double ( kgm2ps kgm2ps ) => kgm2ps.Value;

		public static implicit operator kgm2ps ( J val ) => new kgm2ps{ Value = val.Value };
		public static kg2m4ps2 operator * ( kgm2ps a , kgm2ps b ) => new kg2m4ps2{ Value = a.Value * b.Value };
		
		const string _unit = "(kg*m^2)/s";
		public override string ToString () => $"{Value} [{_unit}]";
		#if UNITY_EDITOR
		[CustomPropertyDrawer(typeof(kgm2ps))] public class MyPropertyDrawer : UnitPropertyDrawer { public override string unit => _unit; }
		#endif
	}
}
