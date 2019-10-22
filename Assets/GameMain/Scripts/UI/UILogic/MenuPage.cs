using GameFramework;

namespace StarForce
{
    public class MenuPage : FGuiForm
    {
        protected override void OnOpen(object userData)
        {
            base.OnOpen(userData);
            UI.GetChild("n1").onClick.Add(() =>
            {
                GameEntry.Event.Fire(this,ReferencePool.Acquire<StartGameEventArgs>().Fill());
            });
        }
    }
}
