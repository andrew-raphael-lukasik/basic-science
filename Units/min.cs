using UnityEngine;
using Unity.Mathematics;

#if UNITY_EDITOR
using UnityEditor;
#endif

namespace BasicScience
{
	
	/// <summary> Minute, 60 seconds </summary>
	[System.Serializable]
	public struct min
	{
		public double Value;

		public static explicit operator double ( min val ) => val.Value;
		public static explicit operator min ( double dbl ) => new min{ Value=dbl };

		public static implicit operator min ( s val ) => new min{ Value = val.Value*(1f/60d) };
		
		public static s operator + ( min a , s b ) => new s{ Value = ((s)a).Value + ((s)b).Value };

		const string _unit = "hour";
		public override string ToString () => $"{Value} [{_unit}]";
		#if UNITY_EDITOR
		[CustomPropertyDrawer(typeof(min))] public class MyPropertyDrawer : UnitPropertyDrawer { public override string unit => _unit; }
		#endif
	}
}
