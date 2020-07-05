using UnityEngine;
using Unity.Mathematics;

#if UNITY_EDITOR
using UnityEditor;
#endif

namespace BasicScience
{
	/// <summary> Force unit, [kg⋅m/s2] </summary>
	[System.Serializable]
	public struct N
	{
		public double Value;

		public static explicit operator N ( double val ) => new N{ Value=val };
		public static explicit operator double ( N val ) => val.Value;

		public static implicit operator N ( kgmps2 val ) => new N{ Value=val.Value };
		

		public static N operator + ( N a , N b ) => new N{ Value = a.Value + b.Value };
		public static N operator - ( N a , N b ) => new N{ Value = a.Value - b.Value };
		public static N operator * ( N a , N b ) => new N{ Value = a.Value * b.Value };

		public static J operator * ( N a , m b ) => new J{ Value = a.Value * b.Value };
			public static J operator * ( m a , N b ) => new J{ Value = a.Value * b.Value };
		public static W operator * ( N a , mps b ) => new W{ Value = a.Value * b.Value };
		
		const string _unit = "N";
		public override string ToString () => $"{Value} [{_unit}]";
		#if UNITY_EDITOR
		[CustomPropertyDrawer(typeof(N))] public class MyPropertyDrawer : UnitPropertyDrawer { public override string unit => _unit; }
		#endif
	}

	// 1 [kg*m/s2] == 1 [N]
	public struct kgmps2
	{
		public double Value;
	}
}
