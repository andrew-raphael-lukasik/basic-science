using UnityEngine;
using Unity.Mathematics;

#if UNITY_EDITOR
using UnityEditor;
#endif

namespace BasicScience
{
	/// <summary> Specific kinetic energy. J/kg is equivalent to m2/s2 </summary>
	[System.Serializable]
	public struct Jpkg
	{
		public double Value;

		public static explicit operator Jpkg ( double dbl ) => new Jpkg{ Value=dbl };
		public static explicit operator double ( Jpkg val ) => val.Value;

		public static implicit operator Jpkg ( m2ps2 val ) => new Jpkg{ Value = val.Value };
		public static implicit operator Jpkg ( km2ps2 val ) => (m2ps2) val;

		public static Jpkg operator + ( Jpkg a , Jpkg b ) => new Jpkg{ Value = a.Value + b.Value };
		public static Jpkg operator - ( Jpkg a , Jpkg b ) => new Jpkg{ Value = a.Value - b.Value };
		public static Jpkg operator * ( Jpkg a , Jpkg b ) => new Jpkg{ Value = a.Value * b.Value };
		public static Jpkg operator * ( Jpkg a , double b ) => new Jpkg{ Value = a.Value * b };
			public static Jpkg operator * ( double a , Jpkg b ) => new Jpkg{ Value = a * b.Value };
		
		const string _unit = "J/kg";
		public override string ToString () => $"{Value} [{_unit}]";
		#if UNITY_EDITOR
		[CustomPropertyDrawer(typeof(Jpkg))] public class MyPropertyDrawer : UnitPropertyDrawer { public override string unit => _unit; }
		#endif
	}
}
