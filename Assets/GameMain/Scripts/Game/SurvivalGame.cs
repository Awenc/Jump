using System.Collections.Generic;
using GameFramework;
using GameFramework.Event;
using UnityEngine;
using UnityGameFramework.Runtime;

namespace StarForce
{
    public class SurvivalGame : GameBase
    {
        public override GameMode GameMode
        {
            get { return GameMode.Survival; }
        }

        public override void Initialize()
        {
            base.Initialize();
            PreLoad();
            GameEntry.Event.Subscribe(CreateNewGroundEventArgs.EventId,OnCreateNewGround);
        }

        public override void Update(float elapseSeconds, float realElapseSeconds)
        {
            base.Update(elapseSeconds, realElapseSeconds);
        }

        public override void Shutdown()
        {
            base.Shutdown();
            GameEntry.Event.Unsubscribe(CreateNewGroundEventArgs.EventId,OnCreateNewGround);
        }

        private void OnCreateNewGround(object sender, GameEventArgs e)
        {
            CreateGround();  
        }

        /// <summary>
        /// 加载游戏资源
        /// </summary>
        private void PreLoad()
        {
            //加载player
            GameEntry.Entity.ShowPlayer(new PlayerData(GameEntry.Entity.GenerateSerialId(), 1, Vector3.forward));

            //初始位置的Ground
            GameEntry.Ground.LoadGround(new Vector3(0, -3, 1), GroundType.Normal);
            GameEntry.Entity.ShowDeathGround(new DeathGroundData(GameEntry.Entity.GenerateSerialId(), 3,
                new Vector3(0, -5.5f, 1), (int) GroundType.DeathGround));

            for (int i = 0; i < 10; i++)
            {
                CreateGround();
            }
        }
        
        
        private void CreateGround()
        {
            GameEntry.Ground.CreateGround();
        }

    }
}