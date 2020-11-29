using UnityEngine;
using Unity.Mathematics;

#if UNITY_EDITOR
using UnityEditor;
#endif

namespace BasicScience
{
	/// <summary> Kilometer, SI meter * 1e3 </summary>
	[System.Serializable]
	public struct km
	{
		public double Value;

		public static explicit operator double ( km val ) => val.Value;
		public static explicit operator km ( double dbl ) => new km{ Value=dbl };
		public static implicit operator km ( AU au ) => new km{ Value = au.Value * 149597870.700d };
		public static implicit operator km ( m meters ) => new km{ Value = meters.Value * 1e-3 };
		
		public static bool operator > ( km a , km b ) => a.Value > b.Value;
		public static bool operator < ( km a , km b ) => a.Value < b.Value;
		
		public static km operator + ( km a , km b ) => new km{ Value = a.Value + b.Value };
		public static km operator * ( km a , double b ) => new km{ Value = a.Value * b };
		public static double operator / ( km a , km b ) => a.Value / b.Value;

		const string _unit = "km";
		public override string ToString () => $"{Value} [{_unit}]";
		#if UNITY_EDITOR
		[CustomPropertyDrawer(typeof(km))] public class MyPropertyDrawer : UnitPropertyDrawer { public override string unit => _unit; }
		#endif
	}

	public struct km_vector
	{
		public double3 Value;
		
		public km X => (km) Value.x;			public km Y => (km) Value.y;			public km Z => (km) Value.z;
		public double x => Value.x;			public double y => Value.y;			public double z => Value.z;

		public static explicit operator double3 ( km_vector val ) => val.Value;
		public static explicit operator km_vector ( double3 val ) => new km_vector{ Value=val };

		public static implicit operator m_vector ( km_vector val ) => new m_vector{ Value=val.Value*1e3 };
		public static implicit operator km_vector ( m_vector val ) => new km_vector{ Value=val.Value*1e-3 };

		public km Length => (km) length;
		public double length => math.length( this.Value );

		public override string ToString () => $"[km]({Value.x},{Value.y},{Value.z})";
	}
}
