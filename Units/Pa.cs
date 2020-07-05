using UnityEngine;
using Unity.Mathematics;

#if UNITY_EDITOR
using UnityEditor;
#endif

namespace BasicScience
{
	// https://en.wikipedia.org/wiki/Pascal_(unit)
	/// <summary> Pascal, pressure unit, SI kg⋅m−1⋅s−2 </summary>
	[System.Serializable]
	public struct Pa
	{
		public double Value;
		
		public static explicit operator double ( Pa val ) => val.Value;
		public static explicit operator Pa ( double val ) => new Pa{ Value=val };
		
		public static implicit operator Pa ( kgpms2 val ) => new Pa{ Value=val.Value };
		public static implicit operator Pa ( Npm2 val ) => new Pa{ Value=val.Value };
		
		public static bool operator > ( Pa lhs , Pa rhs ) => lhs.Value > rhs.Value;
		public static bool operator < ( Pa lhs , Pa rhs ) => lhs.Value < rhs.Value;

		const string _unit = "Pa";
		public override string ToString () => $"{Value} [{_unit}]";
		#if UNITY_EDITOR
		[CustomPropertyDrawer(typeof(Pa))] public class MyPropertyDrawer : UnitPropertyDrawer { public override string unit => _unit; }
		#endif
	}
	
	// 1 [kg⋅m−1⋅s−2] == 1 [Pa]
	public struct kgpms2
	{
		public double Value;
	}

	// 1 [N/m^2] == 1 [Pa]
	public struct Npm2
	{
		public double Value;
	}
}
