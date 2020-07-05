using UnityEngine;
using Unity.Mathematics;

#if UNITY_EDITOR
using UnityEditor;
#endif

namespace SI
{
	/// <summary> SI meter squared </summary>
	[System.Serializable]
	public struct m2
	{
		public double Value;
		
		public static explicit operator double ( m2 val ) => val.Value;
		public static explicit operator m2 ( double val ) => new m2{ Value=val };

		const string _unit = "m^2";
		public override string ToString () => $"{Value} [{_unit}]";
		#if UNITY_EDITOR
		[CustomPropertyDrawer(typeof(m2))] public class MyPropertyDrawer : UnitPropertyDrawer { public override string unit => _unit; }
		#endif
	}
}
