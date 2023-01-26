namespace Modules.UIFramework.Interface
{
    public interface IPanelController
    {
        IPanelView PanelView { get; }

        void OnOpen();
        void OnClose();
        void Close();
    }
}