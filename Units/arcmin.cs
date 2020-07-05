using UnityEngine;
using Unity.Mathematics;

#if UNITY_EDITOR
using UnityEditor;
#endif

namespace SI
{
	/// <summary> arc minute (angle), 1[deg]/60 </summary>
	[System.Serializable]
	public struct arcmin
	{

		public double Value;

		public static explicit operator double ( arcmin val ) => val.Value;
		public static explicit operator arcmin ( double val ) => new arcmin{ Value=val };
		public static implicit operator arcmin ( deg val ) => new arcmin{ Value=val.Value*60.0 };

		const string _unit = "arcmin";
		public override string ToString () => $"{Value} [{_unit}]";
		#if UNITY_EDITOR
		[CustomPropertyDrawer(typeof(arcmin))] public class MyPropertyDrawer : UnitPropertyDrawer { public override string unit => _unit; }
		#endif
	}
}
