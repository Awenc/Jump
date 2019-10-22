//------------------------------------------------------------
// Game Framework
// Copyright © 2013-2019 Jiang Yin. All rights reserved.
// Homepage: http://gameframework.cn/
// Feedback: mailto:jiangyin@gameframework.cn
//------------------------------------------------------------

using UnityEngine;

namespace StarForce
{
    /// <summary>
    /// 游戏入口。
    /// </summary>
    public partial class GameEntry : MonoBehaviour
    {
        public static BuiltinDataComponent BuiltinData
        {
            get;
            private set;
        }
        /// <summary>
        /// FGUI管理
        /// </summary>
        public static FGuiComponent FGUI
        {
            get;
            private set;
        }
        
        /// <summary>
        /// Camera管理
        /// </summary>
        public static CameraComponent Camera
        {
            get;
            private set;
        }

        public static GroundComponent Ground
        {
            get;
            private set;
        }

        private static void InitCustomComponents()
        {
            BuiltinData = UnityGameFramework.Runtime.GameEntry.GetComponent<BuiltinDataComponent>();
            FGUI = UnityGameFramework.Runtime.GameEntry.GetComponent<FGuiComponent>();
            Camera = UnityGameFramework.Runtime.GameEntry.GetComponent<CameraComponent>();
            Ground = UnityGameFramework.Runtime.GameEntry.GetComponent<GroundComponent>();
        }
    }
}
