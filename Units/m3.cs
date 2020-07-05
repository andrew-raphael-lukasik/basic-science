using UnityEngine;
using Unity.Mathematics;

#if UNITY_EDITOR
using UnityEditor;
#endif

namespace SI
{
	/// <summary> SI meter cubed </summary>
	[System.Serializable]
	public struct m3
	{
		public double Value;
		
		public static explicit operator double ( m3 val ) => val.Value;
		public static explicit operator m3 ( double val ) => new m3{ Value=val };

		const string _unit = "m^3";
		public override string ToString () => $"{Value} [{_unit}]";
		#if UNITY_EDITOR
		[CustomPropertyDrawer(typeof(m3))] public class MyPropertyDrawer : UnitPropertyDrawer { public override string unit => _unit; }
		#endif
	}
}
