using UnityEngine;
using Unity.Mathematics;

#if UNITY_EDITOR
using UnityEditor;
#endif

namespace BasicScience
{
	/// <summary>
	/// Meter squared per second squared.
	/// Equivalent to J/kg.
	/// </summary>
	[System.Serializable]
	public struct m2ps2
	{
		public double Value;

		public static explicit operator m2ps2 ( double dbl ) =>	new m2ps2{ Value=dbl };
		public static explicit operator double ( m2ps2 m2ps2 ) => m2ps2.Value;

		public static implicit operator m2ps2 ( Jpkg val ) => (m2ps2)val.Value;

		public static m2ps2 operator - ( m2ps2 a ) => (m2ps2)( -a.Value );
		public static m2ps2 operator + ( m2ps2 a , m2ps2 b ) => (m2ps2)( a.Value + b.Value );
		public static m2ps2 operator - ( m2ps2 a , m2ps2 b ) => (m2ps2)( a.Value - b.Value );
		public static m2ps2 operator * ( m2ps2 a , m2ps2 b ) => (m2ps2)( a.Value * b.Value );
		public static m2ps2 operator * ( m2ps2 a , double b ) => (m2ps2)( a.Value * b );
			public static m2ps2 operator * ( double a , m2ps2 b ) => (m2ps2)( a * b.Value );
		public static m3ps2 operator * ( m2ps2 a , m b ) => (m3ps2)( a.Value * b.Value );
			public static m3ps2 operator * ( m a , m2ps2 b ) => (m3ps2)( a.Value * b.Value );
		public static m2ps2 operator / ( m2ps2 a , double b ) => (m2ps2)( a.Value / b );
		public static double operator / ( m2ps2 a , m2ps2 b ) => a.Value / b.Value;
		public static m operator / ( m2ps2 a , m3ps2 b ) => (m)( a.Value / b.Value );

		public mps Sqrt => (mps) math.sqrt( this.Value );
		public double sqrt => math.sqrt( this.Value );
		
		const string _unit = "m2/s2";
		public override string ToString () => $"{Value} [{_unit}]";
		#if UNITY_EDITOR
		[CustomPropertyDrawer(typeof(m2ps2))] public class MyPropertyDrawer : UnitPropertyDrawer { public override string unit => _unit; }
		#endif
	}
}
