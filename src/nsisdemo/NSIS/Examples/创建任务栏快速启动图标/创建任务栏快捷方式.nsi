#编写：水晶石
OutFile 'PinTOBtest.exe'
#请注意，PinTOB.exe固定任务栏快速启动图标，使用的是pe注入技术来实现的，有可能会引发安全软件报警 ，\
根据微软的定义，快速启动图标属于用户个性化设置的范畴，选择权在于用户而不是开发人员，请勿滥用该功能。

Section
SetOutPath $TEMP
File PinTOB.exe
Sleep 200

nsExec::ExecToStack '"$sysdir\cmd.exe" /C $TEMP\PinTOB.exe "${NSISDIR}\nsis.exe"'

   ; ExecDos::exec '"$sysdir\cmd.exe" /C $TEMP\PinTOB.exe -u "${NSISDIR}\NSIS.exe"'   ;卸载删除
;   ExecDos::exec '$TEMP\PinTOB.exe -r'   ;刷新任务栏
SectionEnd

