using UnityEngine;
using Unity.Mathematics;

#if UNITY_EDITOR
using UnityEditor;
#endif

namespace BasicScience
{
	[System.Serializable]
	public struct m4ps2
	{
		public double Value;

		public static explicit operator m4ps2 ( double dbl ) => new m4ps2{ Value=dbl };
		public static explicit operator double ( m4ps2 m4ps2 ) => m4ps2.Value;

		public static m4ps2 operator - ( m4ps2 a ) => new m4ps2{ Value = -a.Value };
		public static m4ps2 operator + ( m4ps2 a , m4ps2 b ) => new m4ps2{ Value = a.Value + b.Value };
		
		public m2ps Sqrt => (m2ps) math.sqrt( this.Value );
		public double sqrt => math.sqrt( this.Value );

		const string _unit = "m4/s2";
		public override string ToString () => $"{Value} [{_unit}]";
		#if UNITY_EDITOR
		[CustomPropertyDrawer(typeof(m4ps2))] public class MyPropertyDrawer : UnitPropertyDrawer { public override string unit => _unit; }
		#endif
	}
}
