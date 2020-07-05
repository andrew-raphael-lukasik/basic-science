using UnityEngine;
using Unity.Mathematics;

#if UNITY_EDITOR
using UnityEditor;
#endif

namespace BasicScience
{
	/// <summary>
	/// Meter squared per second.
	/// </summary>
	[System.Serializable]
	public struct m2ps
	{
		public double Value;

		public static explicit operator m2ps ( double dbl ) =>	new m2ps{ Value=dbl };
		public static explicit operator double ( m2ps m2ps ) => m2ps.Value;
		
		const string _unit = "m2/s";
		public override string ToString () => $"{Value} [{_unit}]";
		#if UNITY_EDITOR
		[CustomPropertyDrawer(typeof(m2ps))] public class MyPropertyDrawer : UnitPropertyDrawer { public override string unit => _unit; }
		#endif
	}

	public struct m2ps_vector
	{
		public double3 Value;
		
		public m2ps X => (m2ps) Value.x;		public m2ps Y => (m2ps) Value.y;		public m2ps Z => (m2ps) Value.z;
		public double x => Value.x;				public double y => Value.y;				public double z => Value.z;

		public static explicit operator double3 ( m2ps_vector val ) => val.Value;
		public static explicit operator m2ps_vector ( double3 val ) => new m2ps_vector{ Value=val };
		public static explicit operator AU_vector ( m2ps_vector val ) => new AU_vector{ Value=(double3)(AU_vector)(m_vector)(double3)val };
		
		public static implicit operator m2ps_vector ( km2ps_vector val ) => (m2ps_vector)( val.Value * 1e6 );
		

		public m2ps_vector Normalized => (m2ps_vector) this.normalized;
		public double3 normalized => math.normalize( this.Value );

		public m2ps Length => (m2ps) length;
		public double length => math.length( this.Value );

		public double3 pow2 => math.pow( this.Value , 2.0 );
		public double3 pow3 => math.pow( this.Value , 3.0 );

		public override string ToString () => $"[km^2/s]({Value.x},{Value.y},{Value.z})";
	}

}
