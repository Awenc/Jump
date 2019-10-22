using UnityEngine;
using UnityGameFramework.Runtime;

namespace StarForce
{
    public class DeathGround : BaseGround
    {
        private void Update()
        {
            //始终处于摄像机下面一点点
            transform.SetPositionY(GameEntry.Camera.MainCamera.transform.position.y-5.5f);
        }
    }
}