!include "LogicLib.nsh"
!include "Win\COM.nsh" ; NSIS v3+
#����ɾ��ʹ�ô˴��룬����������

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
#ϵͳ��ͬ��PinTOB�оٵ��ִ�Ҳ���в�𣬱�����win10�´�����ݷ�ʽ�С�NSIS �����˵�.lnk����win11�½�"NSIS Menu.lnk",ж��ɾ��ʱ�Կ�ݷ�ʽʵ������Ϊ׼
Section
!insertmacro UnpinShortcut "$QUICKLAUNCH\User Pinned\TaskBar\NSIS Menu.lnk"
Delete "$QUICKLAUNCH\User Pinned\TaskBar\NSIS Menu.lnk"
SectionEnd

