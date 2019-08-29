//------------------------------------------------------------
// Game Framework
// Copyright © 2013-2019 Jiang Yin. All rights reserved.
// Homepage: http://gameframework.cn/
// Feedback: mailto:jiangyin@gameframework.cn
//------------------------------------------------------------

using GameFramework.Event;
using UnityEngine;
using UnityGameFramework.Runtime;

namespace StarForce
{
    public abstract class GameBase
    {
        public abstract GameMode GameMode
        {
            get;
        }

        protected ScrollableBackground SceneBackground
        {
            get;
            private set;
        }

        public bool GameOver
        {
            get;
            protected set;
        }

        public virtual void Initialize()
        {
            
        }

        public virtual void Shutdown()
        {
   
        }

        public virtual void Update(float elapseSeconds, float realElapseSeconds)
        {
           
        }

        protected virtual void OnShowEntitySuccess(object sender, GameEventArgs e)
        {
            
        }

        protected virtual void OnShowEntityFailure(object sender, GameEventArgs e)
        {
            
        }
    }
}
