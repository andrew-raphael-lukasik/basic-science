using UnityEngine;
using Unity.Mathematics;

#if UNITY_EDITOR
using UnityEditor;
#endif

namespace BasicScience
{
	/// <summary> Joule, unit of energy [kg·m^2/s^2] </summary>
	[System.Serializable]
	public struct J
	{
		public double Value;

		public static explicit operator J ( double dbl ) => new J{ Value=dbl };
		public static explicit operator double ( J val ) => val.Value;

		public static implicit operator J ( kgm2ps2 val ) => new J{ Value = val.Value };
		public static W operator / ( J a , s b ) => new W{ Value = a.Value / b.Value };

		public static J operator + ( J L , J R ) => new J{ Value = L.Value + R.Value };
		public static J operator - ( J L , J R ) => new J{ Value = L.Value - R.Value };
		public static J operator * ( J L , J R ) => new J{ Value = L.Value * R.Value };
				
		const string _unit = "J";
		public override string ToString () => $"{Value} [{_unit}]";
		#if UNITY_EDITOR
		[CustomPropertyDrawer(typeof(J))] public class MyPropertyDrawer : UnitPropertyDrawer { public override string unit => _unit; }
		#endif
	}
}
