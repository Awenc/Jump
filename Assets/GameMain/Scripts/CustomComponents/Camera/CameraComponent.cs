using UnityEngine;
using UnityGameFramework.Runtime;

namespace StarForce
{
    public class CameraComponent : GameFrameworkComponent
    {
        [SerializeField]private Camera m_MainCamera;

        public Camera MainCamera
        {
            get { return m_MainCamera; }
            set { m_MainCamera = value; }
        }
    }
}