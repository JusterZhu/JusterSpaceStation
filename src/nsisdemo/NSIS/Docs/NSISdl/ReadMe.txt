NSISdl 1.3 - HTTP 下载插件
---------------------------------------------

版权所有 (C) 2001-2002 Yaroslav Faybishenko & Justin Frankel

本插件用于 NSIS 通过 HTTP 来下载文件。

要连接到因特网，应该使用 Dialer 插件。

用法
-----

NSISdl::download "http://www.domain.com/服务器文件" "本地文件.exe"

你可以传递 /TIMEOUT 参数来设置超时值，单位为毫秒s:

NSISdl::download /TIMEOUT=30000 "http://www.domain.com/服务器文件" "本地文件.exe"

返回值将会压入堆栈:

  "cancel" 如果用户退出
  "success" 如果成功
  否则是一个描述错误的字符串

如果你不希望出现进度条窗口可以使用 NSISdl::download_quiet。

使用例子:

NSISdl::download "http://www.domain.com/服务器文件" "本地文件.exe"
Pop $R0 ;获取返回值
  StrCmp $R0 "success" +3
    MessageBox MB_OK "下载失败，原因: $R0"
    Quit

其它的例子请看 Examples 目录下的 waplugin.nsi。

代理
-------

NSISdl 仅支持基本的代理配置，而不支持需要验证的代理、自动配置脚本等等。NSISdl 从 IE 的注册表键 HKLM\Software\Microsoft\Windows\CurrentVersion\Internet Settings 读取代理信息，并解析 ProxyEnable 和 ProxyServer。

如果你不希望 NSISdl 使用 IE 的设置，使用 /NOIEPROXY 标记来禁止。/NOIEPROXY 应该放在 /TRANSLATE 和 /TIMEOUT 的后面。例如:

如果你想指定自己的代理的话请使用 /PROXY 参数

NSISdl::download /NOIEPROXY "http://www.domain.com/服务器文件" "本地文件.exe"
NSISdl::download /TIMEOUT=30000 /NOIEPROXY "http://www.domain.com/服务器文件" "本地文件.exe"
NSISdl::download /PROXY proxy.whatever.com http://www.domain.com/file localfile.exe
NSISdl::download /PROXY proxy.whatever.com:8080 http://www.domain.com/file localfile.exe

翻译
---------

要在运行时翻译 NSISdl 请添加下列值到调用行:

/TRANSLATE downloading connecting second minute hour plural progress remianing

默认值为:

  downloading - "Downloading %s"
  connecting - "Connecting ..."
  second - "second"
  minute - "minute"
  hour - "hour"
  plural - "s"
  progress - "%dkB (%d%%) of %dkB @ %d.%01dkB/s"
  remaining -  "(%d %s%s remaining)"

/TRANSLATE 必须在 /TIMEOUT 之前。
