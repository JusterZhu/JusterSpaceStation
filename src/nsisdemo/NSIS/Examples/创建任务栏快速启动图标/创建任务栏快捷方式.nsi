#��д��ˮ��ʯ
OutFile 'PinTOBtest.exe'
#��ע�⣬PinTOB.exe�̶���������������ͼ�꣬ʹ�õ���peע�뼼����ʵ�ֵģ��п��ܻ�������ȫ������� ��\
����΢��Ķ��壬��������ͼ�������û����Ի����õķ��룬ѡ��Ȩ�����û������ǿ�����Ա���������øù��ܡ�

Section
SetOutPath $TEMP
File PinTOB.exe
Sleep 200

nsExec::ExecToStack '"$sysdir\cmd.exe" /C $TEMP\PinTOB.exe "${NSISDIR}\nsis.exe"'

   ; ExecDos::exec '"$sysdir\cmd.exe" /C $TEMP\PinTOB.exe -u "${NSISDIR}\NSIS.exe"'   ;ж��ɾ��
;   ExecDos::exec '$TEMP\PinTOB.exe -r'   ;ˢ��������
SectionEnd

