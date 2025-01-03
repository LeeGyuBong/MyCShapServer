// <auto-generated>
//  automatically generated by the FlatBuffers compiler, do not modify
// </auto-generated>

namespace NetGame
{

using global::System;
using global::System.Collections.Generic;
using global::Google.FlatBuffers;

public enum PacketID : short
{
  TestReq = 1,
  TestAck = 2,
};

public struct Test : IFlatbufferObject
{
  private Table __p;
  public ByteBuffer ByteBuffer { get { return __p.bb; } }
  public static void ValidateVersion() { FlatBufferConstants.FLATBUFFERS_24_3_25(); }
  public static Test GetRootAsTest(ByteBuffer _bb) { return GetRootAsTest(_bb, new Test()); }
  public static Test GetRootAsTest(ByteBuffer _bb, Test obj) { return (obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb)); }
  public void __init(int _i, ByteBuffer _bb) { __p = new Table(_i, _bb); }
  public Test __assign(int _i, ByteBuffer _bb) { __init(_i, _bb); return this; }

  public int A { get { int o = __p.__offset(4); return o != 0 ? __p.bb.GetInt(o + __p.bb_pos) : (int)0; } }
  public double B { get { int o = __p.__offset(6); return o != 0 ? __p.bb.GetDouble(o + __p.bb_pos) : (double)0.0; } }
  public string C { get { int o = __p.__offset(8); return o != 0 ? __p.__string(o + __p.bb_pos) : null; } }
#if ENABLE_SPAN_T
  public Span<byte> GetCBytes() { return __p.__vector_as_span<byte>(8, 1); }
#else
  public ArraySegment<byte>? GetCBytes() { return __p.__vector_as_arraysegment(8); }
#endif
  public byte[] GetCArray() { return __p.__vector_as_array<byte>(8); }

  public static Offset<NetGame.Test> CreateTest(FlatBufferBuilder builder,
      int a = 0,
      double b = 0.0,
      StringOffset cOffset = default(StringOffset)) {
    builder.StartTable(3);
    Test.AddB(builder, b);
    Test.AddC(builder, cOffset);
    Test.AddA(builder, a);
    return Test.EndTest(builder);
  }

  public static void StartTest(FlatBufferBuilder builder) { builder.StartTable(3); }
  public static void AddA(FlatBufferBuilder builder, int a) { builder.AddInt(0, a, 0); }
  public static void AddB(FlatBufferBuilder builder, double b) { builder.AddDouble(1, b, 0.0); }
  public static void AddC(FlatBufferBuilder builder, StringOffset cOffset) { builder.AddOffset(2, cOffset.Value, 0); }
  public static Offset<NetGame.Test> EndTest(FlatBufferBuilder builder) {
    int o = builder.EndTable();
    return new Offset<NetGame.Test>(o);
  }
}


static public class TestVerify
{
  static public bool Verify(Google.FlatBuffers.Verifier verifier, uint tablePos)
  {
    return verifier.VerifyTableStart(tablePos)
      && verifier.VerifyField(tablePos, 4 /*A*/, 4 /*int*/, 4, false)
      && verifier.VerifyField(tablePos, 6 /*B*/, 8 /*double*/, 8, false)
      && verifier.VerifyString(tablePos, 8 /*C*/, false)
      && verifier.VerifyTableEnd(tablePos);
  }
}

}
