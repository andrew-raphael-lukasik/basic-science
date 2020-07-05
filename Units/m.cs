using UnityEngine;
using Unity.Mathematics;

#if UNITY_EDITOR
using UnityEditor;
#endif

namespace Game.Models.CelestialMechanics.Units
{
	/// <summary> SI meter </summary>
	[System.Serializable]
	public struct m
	{
		public double Value;
		
		public static explicit operator double ( m val ) => val.Value;
		public static explicit operator m ( double val ) => new m{ Value=val };
		public static implicit operator m ( ly val ) => new m{ Value = val.Value * ly.meters.Value };
		public static implicit operator m ( AU val ) => new m{ Value = val.Value * AU.meters.Value };
		public static implicit operator m ( km val ) => new m{ Value = val.Value * 1e3 };
		public static implicit operator m ( pc val ) => new m{ Value = val.Value * pc.meters.Value };
		
		public static bool operator > ( m a , m b ) => a.Value > b.Value;
		public static bool operator < ( m a , m b ) => a.Value < b.Value;

		public static m operator + ( m a , m b ) => new m{ Value = a.Value + b.Value };
		public static m operator - ( m a , m b ) => new m{ Value = a.Value - b.Value };
		public static m operator - ( m a ) => new m{ Value = -a.Value };
		public static m operator * ( m a , double b ) => (m)( a.Value * b );
			public static m operator * ( double a , m b ) => (m)( a * b.Value );
		public static m2 operator * ( m a , m b ) => (m2)( a.Value * b.Value );
		public static double operator / ( m a , m b ) => a.Value / b.Value;
		public static mps operator / ( m a , System.DateTime b ) => (mps)( a.Value / b.Second );
		public static mps operator / ( m a , s b ) => (mps)( a.Value / b.Value );
		public static m operator / ( m a , double b ) => (m)( a.Value / b );
			public static m operator / ( double a , m b ) => (m)( a / b.Value );

		public m2 Pow2 => (m2) this.pow2;		public double pow2 => math.pow( this.Value , 2.0 );
		public m3 Pow3 => (m3) this.pow3;		public double pow3 => math.pow( this.Value , 3.0 );

		const string _unit = "m";
		public override string ToString () => $"{Value} [{_unit}]";
		#if UNITY_EDITOR
		[CustomPropertyDrawer(typeof(m))] public class MyPropertyDrawer : UnitPropertyDrawer { public override string unit => _unit; }
		#endif
	}

	public struct m_vector
	{
		public double3 Value;
		
		public m X => (m) Value.x;			public m Y => (m) Value.y;			public m Z => (m) Value.z;
		public double x => Value.x;			public double y => Value.y;			public double z => Value.z;

		public static explicit operator double3 ( m_vector val ) => val.Value;
		public static explicit operator m_vector ( double3 val ) => new m_vector{ Value=val };
		public static explicit operator float3 ( m_vector val ) => (float3) val.Value;
		public static explicit operator m_vector ( float3 val ) => new m_vector{ Value=val };
		public static explicit operator Vector3 ( m_vector val ) => (Vector3)(float3) val.Value;

		public static implicit operator m_vector ( AU_vector val ) => (m_vector)( val.Value * AU.meters.Value );

		public static m_vector operator - ( m_vector val ) => (m_vector)( -val.Value );
		public static m_vector operator * ( m_vector a , double3 b ) => (m_vector)( a.Value * b );
			public static m_vector operator * ( double3 a , m_vector b ) => (m_vector)( a * b.Value );
		public static m_vector operator + ( m_vector a , m_vector b ) => (m_vector)( a.Value + b.Value );
		public static m_vector operator + ( m_vector a , AU_vector b ) => (m_vector)( a.Value + ((m_vector)b).Value );
		public static m_vector operator - ( m_vector a , m_vector b ) => (m_vector)( a.Value - b.Value );
		public static mps_vector operator / ( m_vector a , s b ) => (mps_vector)( a.Value / b.Value );
		public static double3 operator / ( m_vector a , m b ) => a.Value / b.Value;
		public static double3 operator / ( m_vector a , m_vector b ) => a.Value / b.Value;


		public m_vector Normalized => (m_vector) this.normalized;
		public double3 normalized => math.normalize( this.Value );

		public m Length => (m) length;
		public double length => math.length( this.Value );

		public double3 pow2 => math.pow( this.Value , 2.0 );
		public double3 pow3 => math.pow( this.Value , 3.0 );

		public override string ToString () => $"[m]({Value.x},{Value.y},{Value.z})";
	}
}
