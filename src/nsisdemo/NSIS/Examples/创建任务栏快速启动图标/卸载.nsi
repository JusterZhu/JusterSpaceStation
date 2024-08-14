!include "LogicLib.nsh"
!include "Win\COM.nsh" ; NSIS v3+
#建议删除使用此代码，更方便引用

OutFile 'UNPinTOBtest.exe'

!macro UnpinShortcut lnkpath
Push $0
Push $1
!insertmacro ComHlpr_CreateInProcInstance ${CLSID_StartMenuPin} ${IID_IStartMenuPinnedList} r0 ""
${If} $0 P<> 0
    System::Call 'SHELL32::SHCreateItemFromParsingName(ws, p0, g "${IID_IShellItem}", *p0r1)' "${lnkpath}"
    ${If} $1 P<> 0
        ${IStartMenuPinnedList::RemoveFromList} $0 '(r1)'
        ${IUnknown::Release} $1 ""
    ${EndIf}
    ${IUnknown::Release} $0 ""
${EndIf}
Pop $1
Pop $0
!macroend
#系统不同，PinTOB列举的字串也略有差别，比如在win10下创建快捷方式叫“NSIS 启动菜单.lnk”，win11下叫"NSIS Menu.lnk",卸载删除时以快捷方式实际名称为准
Section
!insertmacro UnpinShortcut "$QUICKLAUNCH\User Pinned\TaskBar\NSIS Menu.lnk"
Delete "$QUICKLAUNCH\User Pinned\TaskBar\NSIS Menu.lnk"
SectionEnd

