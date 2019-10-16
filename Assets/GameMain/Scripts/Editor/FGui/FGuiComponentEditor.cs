using System.Collections.Generic;
using FairyGUI;
using GameFramework;
using UnityEditor;
using UnityGameFramework.Editor;

namespace StarForce.Editor
{
    [CustomEditor(typeof(FGuiComponent), true)]
    public class FGuiComponentEditor : GameFrameworkInspector
    {
        private SerializedProperty m_UICamera = null;

        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            serializedObject.Update();

            EditorGUILayout.PropertyField(m_UICamera);

            if (!EditorApplication.isPlaying)
            {
                EditorGUILayout.HelpBox("Available during runtime only.", MessageType.Info);
            }
            else
            {
                EditorGUILayout.LabelField("UIPackage All Count", UIPackage.GetPackages().Count.ToString());

                FGuiComponent fGuiComponent = (FGuiComponent) target;

                EditorGUILayout.BeginVertical("box");
                {
                    foreach (KeyValuePair<string, int> valuePair in fGuiComponent.FguiRef)
                    {
                        EditorGUILayout.LabelField(Utility.Text.Format("{0}  RefCount:{1}", valuePair.Key, valuePair.Value));
                    }
                }
                EditorGUILayout.EndVertical();
            }

            Repaint();

            serializedObject.ApplyModifiedProperties();
        }

        private void OnEnable()
        {
            m_UICamera = serializedObject.FindProperty("m_UICamera");
        }
    }
}