using UnityEngine;
using Unity.Mathematics;

#if UNITY_EDITOR
using UnityEditor;
#endif

namespace SI
{
	
	[System.Serializable]
	public struct eccentricity
	{
		public double Value;

		public static implicit operator double ( eccentricity val ) => val.Value;
		public static implicit operator eccentricity ( double dbl ) => new eccentricity{ Value=dbl };

		public override string ToString () => this.Value.ToString();

		public double pow2 => math.pow( this.Value , 2.0 );

		#if UNITY_EDITOR
		[CustomPropertyDrawer(typeof(eccentricity))] public class MyPropertyDrawer : UnitPropertyDrawer { public override string unit => nameof(eccentricity); }
		#endif
	}

	public struct eccentricity_vector
	{

		public double3 Value;
		
		public eccentricity X => (eccentricity) Value.x;			public eccentricity Y => (eccentricity) Value.y;			public eccentricity Z => (eccentricity) Value.z;
		public double x => Value.x;				public double y => Value.y;				public double z => Value.z;

		public static implicit operator eccentricity_vector ( double3 dbl ) => new eccentricity_vector{ Value=dbl };
		public static implicit operator double3 ( eccentricity_vector val ) => val.Value;

		public eccentricity_vector Normalized => (eccentricity_vector) this.normalized;
		public double3 normalized => math.normalize( this.Value );
		public eccentricity Length => (eccentricity) length;
		public double length => math.length( this.Value );

		public override string ToString () => $"[eccentricity]({Value.x},{Value.y},{Value.z})";
	}
}
