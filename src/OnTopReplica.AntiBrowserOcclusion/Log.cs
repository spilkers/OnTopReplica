namespace OnTopReplica.AntiBrowserOcclusion {
    using System;

    internal static class Log {

    internal static Action<string> write;

    public static void Write(string message) {
      write?.Invoke(message);
    }
  }
}
