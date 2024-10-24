; Include the MUI language file
!include "MUI2.nsh"
!include "x64.nsh"

Outfile "GeneralUpdate.Admin_Installer测试.exe" 
InstallDir $PROGRAMFILES\GeneralUpdate.Admin 

; Define the pages of the installer
!insertmacro MUI_PAGE_WELCOME
!insertmacro MUI_PAGE_LICENSE "D:\github_project\GeneralSpacestation\build\source\LICENSE\LICENSE-chs.rtf"
!insertmacro MUI_PAGE_DIRECTORY
!insertmacro MUI_PAGE_INSTFILES

Section "MainSection" SEC01 
    SetOutPath $INSTDIR 
    File /r "D:\github_project\GeneralSpacestation\build\source\*.*" 

    ; Create a shortcut named "测试快捷方式" on the desktop
    CreateShortcut "$DESKTOP\测试快捷方式.lnk" "$INSTDIR\GeneralUpdate.Admin.exe"

    ; Create a shortcut in the Start Menu Programs directory
    CreateShortcut "$SMPROGRAMS\测试快捷方式\测试快捷方式.lnk" "$INSTDIR\GeneralUpdate.Admin.exe"

    ; Create a shortcut in the Startup directory for auto start
    CreateShortcut "$SMSTARTUP\测试快捷方式.lnk" "$INSTDIR\GeneralUpdate.Admin.exe"

     ; Execute custom.bat
    ExecWait '"$INSTDIR\custom.bat"'
    DetailPrint "After executing custom.bat"
SectionEnd 

Section "Install"
    ${DisableX64FSRedirection}
      nsExec::Exec '"$SYSDIR\PnPutil.exe" /a "$INSTDIR\driver\mt7612us_RL.inf"'
    ${EnableX64FSRedirection}
SectionEnd

Section "Uninstall"
    Delete $INSTDIR\*.* 
    RMDir /r $INSTDIR 
    Delete "$DESKTOP\测试快捷方式.lnk"
    Delete "$SMPROGRAMS\测试快捷方式\测试快捷方式.lnk"
    Delete "$SMSTARTUP\测试快捷方式.lnk"

    ${DisableX64FSRedirection}
      nsExec::Exec '"$SYSDIR\PnPutil.exe" /d "$INSTDIR\driver\mt7612us_RL.inf"'
    ${EnableX64FSRedirection}
SectionEnd

; The function to run the program after the installation
Function .onInstSuccess
    ExecShell "" "$INSTDIR\GeneralUpdate.Admin.exe"
FunctionEnd
