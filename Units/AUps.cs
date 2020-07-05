using UnityEngine;
using Unity.Mathematics;

#if UNITY_EDITOR
using UnityEditor;
#endif

namespace SI
{
	/// <summary> Astronomical unit per second </summary>
	[System.Serializable]
	public struct AUps
	{
		public double Value;
		
		public static explicit operator double ( AUps aups ) => aups.Value;
		public static explicit operator AUps ( double dbl ) => new AUps{ Value=dbl };
		
		const string _unit = "AU/s";
		public override string ToString () => $"{Value} [{_unit}]";
		#if UNITY_EDITOR
		[CustomPropertyDrawer(typeof(AUps))] public class MyPropertyDrawer : UnitPropertyDrawer { public override string unit => _unit; }
		#endif
	}

	public struct AUps_vector
	{
		public double3 Value;

		public AUps X => (AUps) Value.x;		public AUps Y => (AUps) Value.y;		public AUps Z => (AUps) Value.z;
		public double x => Value.x;				public double y => Value.y;				public double z => Value.z;

		public static explicit operator double3 ( AUps_vector val ) => val.Value;
		public static explicit operator AUps_vector ( double3 val ) => new AUps_vector{ Value=val };
		public static explicit operator float3 ( AUps_vector val ) => (float3) val.Value;
		public static explicit operator AUps_vector ( float3 val ) => new AUps_vector{ Value=val };
		public static explicit operator Vector3 ( AUps_vector val ) => (Vector3)(float3) val.Value;

		public static implicit operator AUps_vector ( mps_vector val ) => new AUps_vector{ Value=val.Value / AU.meters.Value };

		public AUps_vector Normalized => (AUps_vector) this.normalized;
		public double3 normalized => math.normalize( this.Value );
		public AUps Length => (AUps) length;
		public double length => math.length( this.Value );

		public override string ToString () => $"[AU/s]({Value.x},{Value.y},{Value.z})";
	}

}
