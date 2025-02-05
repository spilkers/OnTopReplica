namespace OnTopReplica.AntiBrowserOcclusion {
    using Windows.Win32.Foundation;

    internal class FakeTaskListThumbnailWndProvider : IFakeWindowProvider {
    public HWND GetHandle() {
      return FakeTaskListThumbnailWnd.GetHandle();
    }
  }
}
