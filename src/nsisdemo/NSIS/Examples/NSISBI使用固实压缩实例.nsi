#想要使用固实压缩命令，必须添加NSISBI版专用外部命令OutFileMode，这与你制作的文件大小无关
#参数必须设置为aio（制作一体式安装包）
#否则脚本定义的压缩方式会被自动忽略  -- 水晶石注释
OutFileMode aio
SetCompressor /SOLID lzma
SetCompressorDictSize 32

OutFile 'NsisBItest.exe'

Section
sleep 100
sleep 100
sleep 100
sleep 100
SectionEnd

