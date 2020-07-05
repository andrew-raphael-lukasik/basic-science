using UnityEngine;
using Unity.Mathematics;

#if UNITY_EDITOR
using UnityEditor;
#endif

namespace BasicScience
{
	
	// solar mass = (Kg) 1.988435e30;
	
	[System.Serializable]
	public struct SolarMass
	{
		
		public double Value;
		
		const double k_kg = 1.988435e30;
		const double k_tons = 1.988435e27;

		public static readonly kg kg = (kg) k_kg;
		
		public static explicit operator SolarMass ( double val ) => new SolarMass{ Value = val };
		public static explicit operator double ( SolarMass val ) => val.Value;

		public static implicit operator kg ( SolarMass val ) => new kg{ Value = k_kg * val.Value };
		public static implicit operator SolarMass ( kg val ) => new SolarMass{ Value = val.Value / k_kg };
		public static implicit operator t ( SolarMass val ) => new t{ Value = k_tons * val.Value };

		// public static SolarMass operator + ( SolarMass lhs , SolarMass rhs ) => new SolarMass{ Value = lhs.Value + rhs.Value };
		// public static SolarMass operator - ( SolarMass lhs , SolarMass rhs ) => new SolarMass{ Value = lhs.Value - rhs.Value };
		
		public static bool operator > ( kg val , SolarMass solarMasses ) => val.Value > ( k_kg * solarMasses.Value );
		public static bool operator < ( kg val , SolarMass solarMasses ) => val.Value < ( k_kg * solarMasses.Value );

		const string _unit = "M☉";
		public override string ToString () => $"{Value} [{_unit}]";
		#if UNITY_EDITOR
		[CustomPropertyDrawer(typeof(SolarMass))] public class MyPropertyDrawer : UnitPropertyDrawer { public override string unit => _unit; }
		#endif
	}
}
