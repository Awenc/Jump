using System.Collections.Generic;
using FairyGUI;
using GameFramework;
using UnityEditor;
using UnityGameFramework.Editor;

namespace StarForce.Editor
{
     [CustomEditor(typeof(FGuiForm), true)]
    internal class FGuiFormEditor : GameFrameworkInspector
    {
        private SerializedProperty m_FguiDependencies;

        private List<string> m_FguiDependenciesList = new List<string>();

        protected virtual void OnEnable()
        {
            m_FguiDependencies = serializedObject.FindProperty("m_FGuiDependencies");
        }

        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            FGuiForm fGuiForm = (FGuiForm) target;

            string packageName = fGuiForm.GetComponent<UIPanel>().packageName;

            InternalFind(packageName);

            EditorGUI.BeginDisabledGroup(true);
            {
                EditorGUILayout.PropertyField(m_FguiDependencies, true);
            }
            EditorGUI.EndDisabledGroup();

            serializedObject.ApplyModifiedProperties();
        }

        private void InternalFind(string packageName)
        {
            m_FguiDependenciesList.Clear();
            m_FguiDependencies.ClearArray();

            FindDependencies(packageName);

            for (int i = 0; i < m_FguiDependenciesList.Count; i++)
            {
                m_FguiDependencies.InsertArrayElementAtIndex(i);
                var em = m_FguiDependencies.GetArrayElementAtIndex(i);
                em.stringValue = m_FguiDependenciesList[i];
            }
        }

        private void FindDependencies(string packageName)
        {
            UIPackage uiPackage =
                UIPackage.AddPackage(Utility.Text.Format("Assets/GameMain/FGUIResource/{0}/{0}", packageName));
            for (int i = 0; i < uiPackage.dependencies.Length; i++)
            {
                if (m_FguiDependenciesList.Contains(uiPackage.dependencies[i]["name"]))
                {
                    continue;
                }

                m_FguiDependenciesList.Add(uiPackage.dependencies[i]["name"]);
                FindDependencies(uiPackage.dependencies[i]["name"]);
            }
        }
    }
}