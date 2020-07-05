using UnityEngine;
using Unity.Mathematics;

#if UNITY_EDITOR
using UnityEditor;
#endif

namespace BasicScience
{
	/// <summary> kg*m^2/s^3 </summary>
	[System.Serializable]
	public struct kgm2ps3
	{
		public double Value;

		public static explicit operator kgm2ps3 ( double dbl ) => new kgm2ps3{ Value=dbl };
		public static explicit operator double ( kgm2ps3 kgm2ps3 ) => kgm2ps3.Value;
		
		const string _unit = "kg*m^2/s^3";
		public override string ToString () => $"{Value} [{_unit}]";
		#if UNITY_EDITOR
		[CustomPropertyDrawer(typeof(kgm2ps3))] public class MyPropertyDrawer : UnitPropertyDrawer { public override string unit => _unit; }
		#endif
	}
}
