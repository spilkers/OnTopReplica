namespace OnTopReplica.AntiBrowserOcclusion {
  using System;
  using System.Reflection;
  using System.Runtime.CompilerServices;

  internal class DummyReference {
    
    public static Assembly ForUnsafe() {
      return typeof(Unsafe).Assembly;
    }

    public static Assembly ForMemory() {
      return typeof(Memory<>).Assembly;
    }
  }
}
