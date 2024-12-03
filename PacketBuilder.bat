Windows.flatc.binary\flatc --csharp --gen-onefile -o SharedPacket\ Fbs\test.fbs

copy SharedPacket\*.cs WebPacketLib\Packet\

pause