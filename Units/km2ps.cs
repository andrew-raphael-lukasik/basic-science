using UnityEngine;
using Unity.Mathematics;

#if UNITY_EDITOR
using UnityEditor;
#endif

namespace Game.Models.CelestialMechanics.Units
{
	
	/// <summary> Kilometers squared per second </summary>
	[System.Serializable]
	public struct km2ps
	{
		public double Value;

		public static explicit operator double ( km2ps val ) => val.Value;
		public static explicit operator km2ps ( double dbl ) => new km2ps{ Value=dbl };

		public static implicit operator km2ps ( m2ps val ) => (km2ps)( val.Value * 1e-6 );
		public static implicit operator m2ps ( km2ps val ) => (m2ps)( val.Value * 1e6 );
		
		const string _unit = "km^2/s";
		public override string ToString () => $"{Value} [{_unit}]";
		#if UNITY_EDITOR
		[CustomPropertyDrawer(typeof(km2ps))] public class MyPropertyDrawer : UnitPropertyDrawer { public override string unit => _unit; }
		#endif
	}

	public struct km2ps_vector
	{
		public double3 Value;
		
		public km2ps X => (km2ps) Value.x;		public km2ps Y => (km2ps) Value.y;		public km2ps Z => (km2ps) Value.z;
		public double x => Value.x;				public double y => Value.y;				public double z => Value.z;

		public static explicit operator double3 ( km2ps_vector val ) => val.Value;
		public static explicit operator km2ps_vector ( double3 val ) => new km2ps_vector{ Value=val };

		public static implicit operator km2ps_vector ( m2ps_vector val ) => (km2ps_vector)( val.Value * 1e-6 );

		public km2ps_vector Normalized => (km2ps_vector) this.normalized;
		public double3 normalized => math.normalize( this.Value );

		public km2ps Length => (km2ps) length;
		public double length => math.length( this.Value );

		public double3 pow2 => math.pow( this.Value , 2.0 );
		public double3 pow3 => math.pow( this.Value , 3.0 );

		public override string ToString () => $"[km^2/s]({Value.x},{Value.y},{Value.z})";
	}

}
