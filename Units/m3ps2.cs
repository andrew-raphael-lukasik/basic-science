using UnityEngine;
using Unity.Mathematics;

#if UNITY_EDITOR
using UnityEditor;
#endif

namespace BasicScience
{
	/// <summary> Meter cubed per second squared. </summary>
	[System.Serializable]
	public struct m3ps2
	{
		public double Value;

		public static explicit operator m3ps2 ( double dbl ) => new m3ps2{ Value=dbl };
		public static explicit operator double ( m3ps2 m3ps2 ) => m3ps2.Value;
		public static implicit operator m3ps2 ( km3ps2 val ) => new m3ps2{ Value = val.Value * 1e9 };
		public static implicit operator m3ps2 ( kg val ) => new m3ps2{ Value = G.Value * val.Value };//gm

		public static m3ps2 operator - ( m3ps2 a ) => new m3ps2{ Value = -a.Value };
		public static m3ps2 operator + ( m3ps2 a , m3ps2 b ) => new m3ps2{ Value = a.Value + b.Value };
		public static m3ps2 operator - ( m3ps2 a , m3ps2 b ) => new m3ps2{ Value = a.Value - b.Value };
		public static m3ps2 operator * ( m3ps2 a , m3ps2 b ) => new m3ps2{ Value = a.Value * b.Value };
		public static m3ps2 operator * ( m3ps2 a , double b ) => new m3ps2{ Value = a.Value * b };
		public static m3ps2 operator / ( double a , m3ps2 b ) => new m3ps2{ Value = a / b.Value };
		public static double operator / ( m3ps2 a , m3ps2 b ) => a.Value / b.Value;
		public static m2ps2 operator / ( m3ps2 a , m b ) => (m2ps2)( a.Value / b.Value );
		public static m operator / ( m3ps2 a , m2ps2 b ) => (m)( a.Value / b.Value );
		public static mps operator / ( m3ps2 a , m2ps b ) => (mps)( a.Value / b.Value );
		public static m4ps2 operator * ( m3ps2 a , m b ) => (m4ps2)( a.Value * b.Value );
			public static m4ps2 operator * ( m a , m3ps2 b ) => (m4ps2)( a.Value * b.Value );
		
		const string _unit = "m3/s2";
		public override string ToString () => $"{Value} [{_unit}]";
		#if UNITY_EDITOR
		[CustomPropertyDrawer(typeof(m3ps2))] public class MyPropertyDrawer : UnitPropertyDrawer { public override string unit => _unit; }
		#endif
	}
}
