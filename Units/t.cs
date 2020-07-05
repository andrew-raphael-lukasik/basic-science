using UnityEngine;
using Unity.Mathematics;

#if UNITY_EDITOR
using UnityEditor;
#endif

namespace Game.Models.CelestialMechanics.Units
{
	/// <summary> Tonne, SI gram * 1e6 </summary>
	[System.Serializable]
	public struct t
	{
		public double Value;

		public static explicit operator double ( t val ) => val.Value;
		public static explicit operator t ( double dbl ) => new t{ Value=dbl };
		public static implicit operator t ( kg kg ) => new t{ Value = kg.Value * 1e-3 };

		public override string ToString () => $"{Value} [t]";
	}

	#if UNITY_EDITOR
	[CustomPropertyDrawer(typeof(t))]
	public class TonsPropertyDrawer : PropertyDrawer
	{
		public override void OnGUI ( Rect position , SerializedProperty property , GUIContent label )
		{
			label = new GUIContent($"[t] {label.text}");
			EditorGUI.BeginProperty( position , label , property );
			{
				position = EditorGUI.PrefixLabel( position , GUIUtility.GetControlID(FocusType.Passive) , label );
				EditorGUI.PropertyField( position , property.FindPropertyRelative("Value") , GUIContent.none );
			}
			EditorGUI.EndProperty();
		}
	}
	#endif
}
