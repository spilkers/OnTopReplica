namespace OnTopReplica.AntiBrowserOcclusion {

  using System;
  using Windows.Win32;
  using Windows.Win32.UI.WindowsAndMessaging;
  using Windows.Win32.Foundation;

  internal static class FakeMultitaskingViewFrame {

    #region Fields

    private static readonly Lazy<HWND> Hwnd =
      new Lazy<HWND>(() => {
        _ = RegisterWindowClass();
        return CreateWindow();
      });

    // https://chromium.googlesource.com/chromium/src/+/refs/heads/main/ui/aura/native_window_occlusion_tracker_win.cc
    // if ((hwnd_class_name == "MultitaskingViewFrame" ||
    //       hwnd_class_name == "TaskListThumbnailWnd"))
    private static readonly string WindowClassName = "MultitaskingViewFrame";

    #endregion Fields

    #region Methods

    public static HWND GetHandle() {
      return Hwnd.Value;
    }

    private static unsafe HWND CreateWindow() {
      return
        PInvoke.CreateWindowEx(
          0,
          WindowClassName,
          typeof(FakeMultitaskingViewFrame).FullName,
          WINDOW_STYLE.WS_OVERLAPPED,
          0,
          0,
          0,
          0,
          default,
          default,
          default,
          default);
    }

    private static unsafe ushort RegisterWindowClass() {
      fixed(char* className = WindowClassName) {
        var wndClass = new WNDCLASSW {
          lpszClassName = new PCWSTR(className),
          lpfnWndProc = PInvoke.DefWindowProc,
          hInstance = PInvoke.GetModuleHandle(default(PCWSTR))
        };

        return PInvoke.RegisterClass(wndClass);
      }
    }

    #endregion Methods
  }
}
