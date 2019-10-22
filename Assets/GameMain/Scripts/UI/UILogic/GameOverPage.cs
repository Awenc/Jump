using FairyGUI;

namespace StarForce
{
    public class GameOverPage : FGuiForm
    {
        protected override void OnOpen(object userData)
        {
            base.OnOpen(userData);
            Transition t = UI.GetTransition("t0");
            t.Play();
        }
    }
}