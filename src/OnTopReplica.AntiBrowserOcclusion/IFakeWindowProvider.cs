namespace OnTopReplica.AntiBrowserOcclusion {
  using Windows.Win32.Foundation;

  internal interface IFakeWindowProvider {
    public HWND GetHandle();
  }
}
