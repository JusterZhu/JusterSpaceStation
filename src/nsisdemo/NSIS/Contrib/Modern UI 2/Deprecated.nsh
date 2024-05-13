
!macro MUI_LEGACY_MAP_NOSTRETCH NAME R
  !if "${R}" != ""
    !ifdef ${NAME}NOSTRETCH
        !define /IfNDef ${NAME}STRETCH NoStretchNoCropNoAlign
    !endif
  !else
    !insertmacro ${__MACRO__} ${NAME}BITMAP_ 1
    !insertmacro ${__MACRO__} ${NAME}BITMAP_RTL_ 1
    !insertmacro ${__MACRO__} ${NAME}UNBITMAP_ 1
    !insertmacro ${__MACRO__} ${NAME}UNBITMAP_RTL_ 1
  !endif
!macroend


;--------------------------------
;InstallOptions

!define INSTALLOPTIONS_ERROR "MUI_INSTALLOPTIONS_* 宏已不再是 MUI2 的一部分。请包含 InstallOptions.nsh 并改用 INSTALLOPTIONS_* 宏。建议升级到 nsDialogs。"

!macro MUI_INSTALLOPTIONS_EXTRACT FILE

  !error "${INSTALLOPTIONS_ERROR}"

!macroend

!macro MUI_INSTALLOPTIONS_EXTRACT_AS FILE FILENAME

  !error "${INSTALLOPTIONS_ERROR}"

!macroend

!macro MUI_INSTALLOPTIONS_DISPLAY FILE

  !error "${INSTALLOPTIONS_ERROR}"

!macroend

!macro MUI_INSTALLOPTIONS_DISPLAY_RETURN FILE

  !error "${INSTALLOPTIONS_ERROR}"

!macroend

!macro MUI_INSTALLOPTIONS_INITDIALOG FILE

  !error "${INSTALLOPTIONS_ERROR}"

!macroend

!macro MUI_INSTALLOPTIONS_SHOW

  !error "${INSTALLOPTIONS_ERROR}"

!macroend

!macro MUI_INSTALLOPTIONS_SHOW_RETURN

  !error "${INSTALLOPTIONS_ERROR}"

!macroend

!macro MUI_INSTALLOPTIONS_READ VAR FILE SECTION KEY

  !error "${INSTALLOPTIONS_ERROR}"

!macroend

!macro MUI_INSTALLOPTIONS_WRITE FILE SECTION KEY VALUE

  !error "${INSTALLOPTIONS_ERROR}"

!macroend

!macro MUI_RESERVEFILE_INSTALLOPTIONS

  !error `MUI_RESERVEFILE_INSTALLOPTIONS 不再被MUI2支持，因为InstallOptions不再使用。请改为使用“ReserveFile /plugin InstallOptions.dll”。建议升级到nsDialogs。`

!macroend
