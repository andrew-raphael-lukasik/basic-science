using UnityEngine;
using Unity.Mathematics;

#if UNITY_EDITOR
using UnityEditor;
#endif

namespace BasicScience
{
	/// <summary>
	/// Kilometer squared per second squared.
	/// </summary>
	[System.Serializable]
	public struct km2ps2
	{
		public double Value;

		public static explicit operator km2ps2 ( double dbl ) =>	new km2ps2{ Value=dbl };
		public static explicit operator double ( km2ps2 val ) => val.Value;
		public static implicit operator m2ps2 ( km2ps2 val ) => new m2ps2{ Value=val.Value*1e6 };
		public static implicit operator km2ps2 ( m2ps2 val ) => new km2ps2{ Value=val.Value*1e-6 };
		public static implicit operator km2ps2 ( Jpkg val ) => (m2ps2) val;

		public static km2ps2 operator / ( km2ps2 a , double b ) => new km2ps2{ Value = a.Value / b };

		public kmps Sqrt => (kmps) math.sqrt( this.Value );
		public double sqrt => math.sqrt( this.Value );
		
		const string _unit = "km2/s2";
		public override string ToString () => $"{Value} [{_unit}]";
		#if UNITY_EDITOR
		[CustomPropertyDrawer(typeof(km2ps2))] public class MyPropertyDrawer : UnitPropertyDrawer { public override string unit => _unit; }
		#endif
	}
}
