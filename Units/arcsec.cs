using UnityEngine;
using Unity.Mathematics;

#if UNITY_EDITOR
using UnityEditor;
#endif

namespace BasicScience
{
	/// <summary> arc second (angle), 1[deg]/3600 </summary>
	[System.Serializable]
	public struct arcsec
	{

		public double Value;

		public static explicit operator double ( arcsec val ) => val.Value;
		public static explicit operator arcsec ( double val ) => new arcsec{ Value=val };
		public static implicit operator arcsec ( deg val ) => new arcsec{ Value=val.Value*3600.0 };

		const string _unit = "arcsec";
		public override string ToString () => $"{Value} [{_unit}]";
		#if UNITY_EDITOR
		[CustomPropertyDrawer(typeof(arcsec))] public class MyPropertyDrawer : UnitPropertyDrawer { public override string unit => _unit; }
		#endif
	}
}
