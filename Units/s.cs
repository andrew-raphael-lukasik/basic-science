using UnityEngine;
using Unity.Mathematics;

#if UNITY_EDITOR
using UnityEditor;
#endif

namespace Game.Models.CelestialMechanics.Units
{
	
	/// <summary> Second </summary>
	[System.Serializable]
	public struct s
	{
		public double Value;

		public static explicit operator double ( s val ) => val.Value;
		public static explicit operator s ( double dbl ) => new s{ Value=dbl };

		public static implicit operator s ( h val ) => new s{ Value = val.Value*60d*60d };
		public static implicit operator s ( min val ) => new s{ Value = val.Value*60d };

		public static s operator + ( s a , s b ) => new s{ Value = a.Value + b.Value };
		public static s operator - ( s a , s b ) => new s{ Value = a.Value - b.Value };
		public static s operator * ( s a , s b ) => new s{ Value = a.Value * b.Value };
		public static s operator / ( s a , s b ) => new s{ Value = a.Value / b.Value };

		public static Hz operator / ( double a , s b ) => new Hz{ Value = a / b.Value };

		const string _unit = "s";
		public override string ToString () => $"{Value} [{_unit}]";
		#if UNITY_EDITOR
		[CustomPropertyDrawer(typeof(s))] public class MyPropertyDrawer : UnitPropertyDrawer { public override string unit => _unit; }
		#endif
	}
}
