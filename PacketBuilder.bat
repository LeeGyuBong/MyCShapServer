Windows.flatc.binary\flatc --csharp --gen-onefile -o SharedPacket\ Fbs\test.fbs

copy SharedPacket\*.cs GameServer\Packet\
copy SharedPacket\*.cs Test\Packet\

pause