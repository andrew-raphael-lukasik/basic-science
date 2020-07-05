using UnityEngine;
using Unity.Mathematics;

#if UNITY_EDITOR
using UnityEditor;
#endif

namespace Game.Models.CelestialMechanics.Units
{
	/// <summary> Mega Joule, unit of energy [kg·m^2/s^2] </summary>
	[System.Serializable]
	public struct MJ
	{
		public double Value;

		public static explicit operator MJ ( double dbl ) => new MJ{ Value=dbl };
		public static explicit operator double ( MJ val ) => val.Value;
		
		public static explicit operator J ( MJ val ) => (J)( val.Value * 1e6 );

		public static MJ operator + ( MJ a , MJ b ) => new MJ{ Value = a.Value + b.Value };
		public static MJ operator - ( MJ a , MJ b ) => new MJ{ Value = a.Value - b.Value };
		public static MJ operator * ( MJ a , MJ b ) => new MJ{ Value = a.Value * b.Value };
		
		const string _unit = "MJ";
		public override string ToString () => $"{Value} [{_unit}]";
		#if UNITY_EDITOR
		[CustomPropertyDrawer(typeof(MJ))] public class MyPropertyDrawer : UnitPropertyDrawer { public override string unit => _unit; }
		#endif
	}
}
