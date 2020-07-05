using UnityEngine;
using Unity.Mathematics;

#if UNITY_EDITOR
using UnityEditor;
#endif

namespace SI
{
	
	/// <summary> Meters per second </summary>
	[System.Serializable]
	public struct mps
	{
		public double Value;

		public static explicit operator double ( mps val ) => val.Value;
		public static explicit operator mps ( double dbl ) => new mps{ Value=dbl };

		public static implicit operator mps ( kmph val ) => (mps)( val.Value * 3.6d );
		public static implicit operator mps ( kmps val ) => (mps)( val.Value * 1000d );

		public static mps operator - ( mps val ) => (mps)( -val.Value );

		public static bool operator == ( mps a , mps b ) => a.Value == b.Value;
		public static bool operator != ( mps a , mps b ) => !(a==b);

		public static mps operator + ( mps a , mps b ) => (mps)( a.Value + b.Value );
		public static mps operator - ( mps a , mps b ) => (mps)( a.Value - b.Value );
		public static m2ps2 operator * ( mps a , mps b ) => (m2ps2)( a.Value * b.Value );
		public static m operator * ( mps a , s b ) => (m)( a.Value * b.Value );
			public static m operator * ( s a , mps b ) => (m)( a.Value * b.Value );
		public static mps operator * ( mps a , double b ) => (mps)( a.Value * b );
			public static mps operator * ( double a , mps b ) => (mps)( a * b.Value );
		public static mps operator / ( mps a , double b ) => (mps)( a.Value / b );

		public double sqrt => math.sqrt( this.Value );
		public double pow2 => math.pow( this.Value , 2.0 );
		public double pow3 => math.pow( this.Value , 3.0 );

		public override int GetHashCode () => this.Value.GetHashCode();
		public override bool Equals ( object obj ) => ((mps)obj).Value.Equals(this.Value);
		
		const string _unit = "m/s";
		public override string ToString () => $"{Value} [{_unit}]";
		#if UNITY_EDITOR
		[CustomPropertyDrawer(typeof(mps))] public class MyPropertyDrawer : UnitPropertyDrawer { public override string unit => _unit; }
		#endif
	}

	public struct mps_vector
	{

		public double3 Value;
		
		public mps X => (mps) Value.x;			public mps Y => (mps) Value.y;			public mps Z => (mps) Value.z;
		public double x => Value.x;				public double y => Value.y;				public double z => Value.z;

		public static explicit operator double3 ( mps_vector val ) => val.Value;
		public static explicit operator mps_vector ( double3 val ) => new mps_vector{ Value=val };
		public static explicit operator float3 ( mps_vector val ) => (float3) val.Value;
		public static explicit operator mps_vector ( float3 val ) => new mps_vector{ Value=val };

		public static mps_vector operator * ( mps_vector a , double3 b ) => (mps_vector)( a.Value * b );
			public static mps_vector operator * ( double3 a , mps_vector b ) => (mps_vector)( a * b.Value );
		public static mps_vector operator + ( mps_vector a , mps_vector b ) => (mps_vector)( a.Value + b.Value );
		public static mps_vector operator - ( mps_vector a , mps_vector b ) => (mps_vector)( a.Value - b.Value );
		public static m_vector operator * ( mps_vector a , s b ) => (m_vector)( a.Value * b.Value );

		// delta V operators:
		public static mps_vector operator + ( mps_vector velocity , mps delta ) => (mps_vector)( velocity.Value + ( velocity.normalized * delta.Value ) );
		public static mps_vector operator + ( mps_vector velocity , (mps_vector vector,float3 up) delta ) => (mps_vector)( velocity.Value + quaternion.LookRotation( (float3)velocity.normalized , delta.up ).Rotate( (double3)delta.vector ) );

		public mps_vector Normalized => (mps_vector) this.normalized;
		public double3 normalized => math.normalize( this.Value );
		public mps Length => (mps) length;
		public double length => math.length( this.Value );
		public m2ps2 Lengthsq => (m2ps2) lengthsq;
		public double lengthsq => math.lengthsq( this.Value );

		public override string ToString () => $"[m/s]({Value.x},{Value.y},{Value.z})";
	}
}
