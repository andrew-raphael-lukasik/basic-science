using UnityEngine;
using Unity.Mathematics;

#if UNITY_EDITOR
using UnityEditor;
#endif

namespace Game.Models.CelestialMechanics.Units
{
	/// <summary> Astronomical unit </summary>
	[System.Serializable]
	public struct AU
	{
		public double Value;

		public static readonly m meters = (m) 149597870700d;
		
		public static explicit operator double ( AU au ) => au.Value;
		public static explicit operator AU ( double dbl ) => new AU{ Value=dbl };
		public static implicit operator AU ( km val ) => (AU)( val.Value / (meters.Value/1e3) );
		public static implicit operator AU ( m val ) => (AU)( val.Value / meters.Value );
		
		public static bool operator > ( AU lhs , AU rhs ) => lhs.Value > rhs.Value;
		public static bool operator < ( AU lhs , AU rhs ) => lhs.Value < rhs.Value;

		public static AU operator + ( AU a , AU b ) => (AU)( a.Value + b.Value );
		public static AU operator - ( AU a , AU b ) => (AU)( a.Value - b.Value );
		public static AU operator - ( AU a ) => (AU)( -a.Value );
		public static double operator / ( AU a , AU b ) => a.Value / b.Value;
		public static AU operator * ( AU a , double b ) => (AU)( a.Value * b );
			public static AU operator * ( double a , AU b ) => (AU)( a * b.Value );
		public static AU operator / ( AU a , double b ) => (AU)( a.Value / b );
			public static AU operator / ( double a , AU b ) => (AU)( a / b.Value );
		public static m operator + ( AU a , m b ) => (m)a + b;
		public static m operator - ( AU a , m b ) => (m)a - b;
		
		const string _unit = "AU";
		public override string ToString () => $"{Value} [{_unit}]";
		#if UNITY_EDITOR
		[CustomPropertyDrawer(typeof(AU))] public class MyPropertyDrawer : UnitPropertyDrawer { public override string unit => _unit; }
		#endif
	}

	public struct AU_vector
	{
		public double3 Value;

		public AU X => (AU) Value.x;		public AU Y => (AU) Value.y;		public AU Z => (AU) Value.z;
		public double x => Value.x;			public double y => Value.y;			public double z => Value.z;

		public static explicit operator double3 ( AU_vector val ) => val.Value;
		public static explicit operator AU_vector ( double3 val ) => new AU_vector{ Value=val };
		public static explicit operator float3 ( AU_vector val ) => (float3) val.Value;
		public static explicit operator AU_vector ( float3 val ) => new AU_vector{ Value=val };
		public static explicit operator Vector3 ( AU_vector val ) => (Vector3)(float3) val.Value;
		
		public static implicit operator AU_vector ( m_vector val ) => (AU_vector)( val.Value / AU.meters.Value );

		public static AU_vector operator + ( AU_vector a , AU_vector b ) => (AU_vector)( a.Value + b.Value );
		public static AU_vector operator - ( AU_vector a , AU_vector b ) => (AU_vector)( a.Value - b.Value );

		public AU_vector Normalized => (AU_vector) this.normalized;
		public double3 normalized => math.normalize( this.Value );
		public AU Length => (AU) length;
		public double length => math.length( this.Value );

		public override string ToString () => $"[AU]({Value.x},{Value.y},{Value.z})";
	}
}
