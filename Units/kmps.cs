using UnityEngine;
using Unity.Mathematics;

#if UNITY_EDITOR
using UnityEditor;
#endif

namespace BasicScience
{
	
	/// <summary> Km per second </summary>
	[System.Serializable]
	public struct kmps
	{
		public double Value;

		public static explicit operator double ( kmps val ) => val.Value;
		public static explicit operator kmps ( double dbl ) => new kmps{ Value=dbl };

		public static implicit operator kmps ( mps val ) => new kmps{ Value=val.Value * 1e-3 };

		public static kmps operator + ( kmps a , kmps b ) => new kmps{ Value = a.Value + b.Value };
		public static kmps operator - ( kmps a , kmps b ) => new kmps{ Value = a.Value - b.Value };

		const string _unit = "km/s";
		public override string ToString () => $"{Value} [{_unit}]";
		#if UNITY_EDITOR
		[CustomPropertyDrawer(typeof(kmps))] public class MyPropertyDrawer : UnitPropertyDrawer { public override string unit => _unit; }
		#endif
	}

	public struct kmps_vector
	{
		public double3 Value;
		
		public kmps X => (kmps) Value.x;		public kmps Y => (kmps) Value.y;		public kmps Z => (kmps) Value.z;
		public double x => Value.x;				public double y => Value.y;				public double z => Value.z;

		public static explicit operator double3 ( kmps_vector val ) => val.Value;
		public static explicit operator kmps_vector ( double3 val ) => new kmps_vector{ Value=val };

		public static implicit operator mps_vector ( kmps_vector val ) => new mps_vector{ Value=val.Value*1e3 };
		public static implicit operator kmps_vector ( mps_vector val ) => new kmps_vector{ Value=val.Value*1e-3 };

		public km Length => (km) length;
		public double length => math.length( this.Value );
		public km2ps2 Lengthsq => (km2ps2) lengthsq;
		public double lengthsq => math.lengthsq( this.Value );

		public override string ToString () => $"[km/s]({Value.x},{Value.y},{Value.z})";
	}
}
