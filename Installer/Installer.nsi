;UI Moderno
!include "MUI.nsh"

;Definiciones generales
!define COMPANYNAME   "martinrea"
!define PRODUCT       "Nujit Scheduling System"
!define INSTALLER     "NujitSchInstaller${COMPANYNAME}"
!define COMPANY       "Nujit"
!define UNINSTALLER   "Uninstall"
!define INSDIR        "NujitScheduling"
!define VERSION       "1.0.0.0"


;Definiciones de mensajes
!define INSTALLATION_COMPLETE         "Installation Complete"
!define UNLOADING_PLUGIN 	      "Unloading plugin from memory..."
!define DELETING_INST_FOLDER          "Deleting installation folder..."
!define UNINSTALLATION_COMPLETE       "Uninstallation"
!define DELETING_REGISTRY_ENTRIES     "Deleting registry entries..."


;Variables globales
Var InstallStatus
Var OldUninstallApp

;Variables Framework
Var "URL_DOTNET"
Var "OSLANGUAGE"
Var "DOTNET_RETURN_CODE"


;Configuración general
;Nombre desplegado
Name "${PRODUCT}"
;Nombre del archivo compilado
OutFile "${INSTALLER}.exe"
;Directorio de instalación
InstallDir "$PROGRAMFILES\${COMPANY}\${INSDIR}"
;Algoritmo de compresión -> zlib, bzip2 o lzma
SetCompressor lzma
;Compatible con el estilo de Windows XP
XPStyle on
;Muestra los detalles de la instalación
ShowInstDetails show
;Muestra los detalles de la desinstalación
ShowUninstDetails show
;Cambia el texto por defecto "Nullsoft Install System v2.0"
BrandingText "${COMPANY} Inc."


;Entrada en el registro para la desinstalación
!define REG_UNINSTALL "Software\Microsoft\Windows\CurrentVersion\Uninstall\${PRODUCT}"

;Direcciones desde donde se bajan los archivos
!define NUJIT_URL1 http://www.nujit.com/Nujit_WebService/WebService/AppStart/
!define NUJIT_URL2 http://www.nujit.com/Nujit_WebService/WebService/ERPBuilds/${COMPANYNAME}/

;Definiciones de las páginas de instalación
;Imagen en la página de inicio y final
!define MUI_WELCOMEFINISHPAGE_BITMAP "${NSISDIR}\Contrib\Graphics\Wizard\orange.bmp"
;Título de la página inicial
!define MUI_WELCOMEPAGE_TITLE "Installation of ${PRODUCT}."
;Mensaje cuando se aborta
!define MUI_ABORTWARNING
;Función que se llama cuando se aborta
!define MUI_CUSTOMFUNCTION_ABORT gpAbort
!define MUI_FINISHPAGE_RUN "$INSTDIR\NujitStart.exe"
;No muestro opción de reinicio al finalizar 
!define MUI_FINISHPAGE_NOREBOOTSUPPORT
;Título en la página final
!define MUI_FINISHPAGE_TITLE "${INSTALLATION_COMPLETE}"
;Icono del instalador
!define MUI_ICON "${NSISDIR}\Contrib\Graphics\Icons\orange-install.ico"
;Logo del producto en el cabezal de las páginas
;!define MUI_HEADERIMAGE
;!define MUI_HEADERIMAGE_BITMAP "${PRODUC}.bmp"
;Logo del lado derecho (por defecto en el izquierdo)
;!define MUI_HEADERIMAGE_RIGHT

;Configuración Framework
!define BASE_URL http://download.microsoft.com/download
; .NET Framework
; English
!define URL_DOTNET_1033 "${BASE_URL}/a/a/c/aac39226-8825-44ce-90e3-bf8203e74006/dotnetfx.exe"
; Spanish
!define URL_DOTNET_1034 "${BASE_URL}/8/f/0/8f023ff4-2dc1-4f10-9618-333f5b9f8040/dotnetfx.exe"
; Portuguese (Brazil)
!define URL_DOTNET_1046 "${BASE_URL}/8/c/f/8cf55d0c-235e-4062-933c-64ffdf7e7043/dotnetfx.exe"

;Definiciones de las páginas de desinstalación
!define MUI_UNWELCOMEFINISHPAGE_BITMAP "${NSISDIR}\Contrib\Graphics\Wizard\orange-uninstall.bmp"
!define MUI_UNABORTWARNING
!define MUI_UNICON "${NSISDIR}\Contrib\Graphics\Icons\orange-uninstall.ico"
;!define MUI_UNHEADERIMAGE
;!define MUI_UNHEADERIMAGE_BITMAP "${PRODUCT}.bmp"
;!define MUI_UNHEADERIMAGE_RIGHT


;Macros de las páginas de instalación
!insertmacro MUI_PAGE_WELCOME
;!insertmacro MUI_PAGE_LICENSE "license.txt"
!insertmacro MUI_PAGE_DIRECTORY
!insertmacro MUI_PAGE_INSTFILES
;Funcion que se llama al finalizar la instalación
!define MUI_PAGE_CUSTOMFUNCTION_PRE gpTerminar
!insertmacro MUI_PAGE_FINISH


;Las variables que definen el título de la instalación y desinstalación son las mismas
!define MUI_WELCOMEPAGE_TITLE "Uninstallation of ${PRODUCT}."
!define MUI_FINISHPAGE_TITLE "${UNINSTALLATION_COMPLETE}"


;Macros de las páginas de desinstalación
!insertmacro MUI_UNPAGE_WELCOME
;!insertmacro MUI_UNPAGE_LICENSE "license.txt"
!insertmacro MUI_UNPAGE_INSTFILES
!insertmacro MUI_UNPAGE_FINISH

;Lenguaje
!insertmacro MUI_LANGUAGE "English"


;Texto del cabezal de las páginas
LangString TEXT_IO_TITLE ${LANG_ENGLISH} "Installing"

;Textos para el Framework
LangString DESC_REMAINING ${LANG_ENGLISH} " (%d %s%s remaining)"
LangString DESC_PROGRESS ${LANG_ENGLISH} "%d.%01dkB/s" ;"%dkB (%d%%) of %dkB @ %d.%01dkB/s"
LangString DESC_PLURAL ${LANG_ENGLISH} "s"
LangString DESC_HOUR ${LANG_ENGLISH} "hour"
LangString DESC_MINUTE ${LANG_ENGLISH} "minute"
LangString DESC_SECOND ${LANG_ENGLISH} "second"
LangString DESC_CONNECTING ${LANG_ENGLISH} "Connecting..."
LangString DESC_DOWNLOADING ${LANG_ENGLISH} "Downloading %s"
LangString DESC_SHORTDOTNET ${LANG_ENGLISH} "Microsoft .Net Framework 1.1"
LangString DESC_LONGDOTNET ${LANG_ENGLISH} "Microsoft .Net Framework 1.1"
LangString DESC_DOTNET_DECISION ${LANG_ENGLISH} "$(DESC_SHORTDOTNET) is required.$\nIt is strongly \
  advised that you install$\n$(DESC_SHORTDOTNET) before continuing.$\nIf you choose to continue, \
  you will need to connect$\nto the internet before proceeding.$\nWould you like to continue with \
  the installation?"
LangString SEC_DOTNET ${LANG_ENGLISH} "$(DESC_SHORTDOTNET) "
LangString DESC_INSTALLING ${LANG_ENGLISH} "Installing"
LangString DESC_DOWNLOADING1 ${LANG_ENGLISH} "Downloading"
LangString DESC_DOWNLOADFAILED ${LANG_ENGLISH} "Download Failed:"
LangString ERROR_DOTNET_DUPLICATE_INSTANCE ${LANG_ENGLISH} "The $(DESC_SHORTDOTNET) Installer is \
  already running."
LangString ERROR_NOT_ADMINISTRATOR ${LANG_ENGLISH} "You must be an Adminitrator."
LangString ERROR_INVALID_PLATFORM ${LANG_ENGLISH} "Invalid Plataform."
LangString DESC_DOTNET_TIMEOUT ${LANG_ENGLISH} "The installation of the $(DESC_SHORTDOTNET) \
  has timed out."
LangString ERROR_DOTNET_INVALID_PATH ${LANG_ENGLISH} "The $(DESC_SHORTDOTNET) Installation$\n\
  was not found in the following location:$\n"
LangString ERROR_DOTNET_FATAL ${LANG_ENGLISH} "A fatal error occurred during the installation$\n\
  of the $(DESC_SHORTDOTNET)."
LangString FAILED_DOTNET_INSTALL ${LANG_ENGLISH} "The installation of ${PRODUCT} will$\n\
  continue. However, it may not function properly$\nuntil $(DESC_SHORTDOTNET)$\nis installed."


;Secciones
Section "Init"
  SectionIn RO
  
  Call IsDotNETInstalled
  Pop $0
  StrCmp $0 1 lbl_NoError
    
  StrCpy $URL_DOTNET "${URL_DOTNET_1033}"
  StrCpy $OSLANGUAGE "1033"
  
  StrCpy $DOTNET_RETURN_CODE "0"
  !ifdef DOTNET_ONCD_1033
    !define DOTNETFILESDIR "Framework"
    StrCmp "$OSLANGUAGE" "1033" 0 lbl_Not1033
    SetOutPath "$PLUGINSDIR"
    file /r "${DOTNETFILESDIR}\dotnetfx.exe"
    DetailPrint "$(DESC_INSTALLING) $(DESC_SHORTDOTNET)..."
    Banner::show /NOUNLOAD "$(DESC_INSTALLING) $(DESC_SHORTDOTNET)..."
    nsExec::ExecToStack '"$PLUGINSDIR\dotnetfx.exe" /q /c:"install.exe /noaspupgrade /q"'
    pop $DOTNET_RETURN_CODE
    Banner::destroy
    SetRebootFlag true
    Goto lbl_NoDownloadRequired
    lbl_Not1033:
  !endif

  ; the following Goto and Label is for consistencey.
  Goto lbl_DownloadRequired
  lbl_DownloadRequired:
  DetailPrint "$(DESC_SHORTDOTNET)..."
  MessageBox MB_ICONEXCLAMATION|MB_YESNO|MB_DEFBUTTON2 "$(DESC_DOTNET_DECISION)" /SD IDNO \
    IDYES +3 IDNO 0
  Call gpAbort
  Abort
  DetailPrint "$(DESC_DOWNLOADING1) $(DESC_SHORTDOTNET)..."
  ; "Downloading Microsoft .Net Framework"
  AddSize 153600
  nsisdl::download /TRANSLATE "$(DESC_DOWNLOADING)" "$(DESC_CONNECTING)" \
    "$(DESC_SECOND)" "$(DESC_MINUTE)" "$(DESC_HOUR)" "$(DESC_PLURAL)" \
    "$(DESC_PROGRESS)" "$(DESC_REMAINING)" \
    /TIMEOUT=30000 "$URL_DOTNET" "$PLUGINSDIR\dotnetfx.exe"
  Pop $0
  StrCmp "$0" "success" lbl_continue
  DetailPrint "$(DESC_DOWNLOADFAILED) $0"
  Call gpAbort
  Abort

  lbl_continue:
    DetailPrint "$(DESC_INSTALLING) $(DESC_SHORTDOTNET)..."
    Banner::show /NOUNLOAD "$(DESC_INSTALLING) $(DESC_SHORTDOTNET)..."
    nsExec::ExecToStack '"$PLUGINSDIR\dotnetfx.exe" /q /c:"install.exe /noaspupgrade /q"'
    pop $DOTNET_RETURN_CODE
    Banner::destroy
    SetRebootFlag true
    ; silence the compiler
    Goto lbl_NoDownloadRequired
    lbl_NoDownloadRequired:

    ; obtain any error code and inform the user ($DOTNET_RETURN_CODE)
    ; If nsExec is unable to execute the process,
    ; it will return "error"
    ; If the process timed out it will return "timeout"
    ; else it will return the return code from the executed process.
    StrCmp "$DOTNET_RETURN_CODE" "" lbl_NoError
    StrCmp "$DOTNET_RETURN_CODE" "0" lbl_NoError
    StrCmp "$DOTNET_RETURN_CODE" "3010" lbl_NoError
    StrCmp "$DOTNET_RETURN_CODE" "8192" lbl_NoError
    StrCmp "$DOTNET_RETURN_CODE" "error" lbl_Error
    StrCmp "$DOTNET_RETURN_CODE" "timeout" lbl_TimeOut
    ; It's a .Net Error
    StrCmp "$DOTNET_RETURN_CODE" "4101" lbl_Error_DuplicateInstance
    StrCmp "$DOTNET_RETURN_CODE" "4097" lbl_Error_NotAdministrator
    StrCmp "$DOTNET_RETURN_CODE" "1633" lbl_Error_InvalidPlatform lbl_FatalError
    ; all others are fatal

  lbl_Error_DuplicateInstance:
    DetailPrint "$(ERROR_DOTNET_DUPLICATE_INSTANCE)"
    GoTo lbl_Done

    lbl_Error_NotAdministrator:
    DetailPrint "$(ERROR_NOT_ADMINISTRATOR)"
    GoTo lbl_Done

    lbl_Error_InvalidPlatform:
    DetailPrint "$(ERROR_INVALID_PLATFORM)"
    GoTo lbl_Done

    lbl_TimeOut:
    DetailPrint "$(DESC_DOTNET_TIMEOUT)"
    GoTo lbl_Done

    lbl_Error:
    DetailPrint "$(ERROR_DOTNET_INVALID_PATH)"
    GoTo lbl_Done

    lbl_FatalError:
    DetailPrint "$(ERROR_DOTNET_FATAL)[$DOTNET_RETURN_CODE]"
    GoTo lbl_Done

    lbl_Done:
    DetailPrint "$(FAILED_DOTNET_INSTALL)"
    lbl_NoError:
SectionEnd


Section "InitialThings"
  ClearErrors
  CreateDirectory $INSTDIR

  ;Escribo en el registro la información de la desinstalación
  WriteRegStr HKLM "${REG_UNINSTALL}" "DisplayName"       "${PRODUCT}"
  IfErrors 0 Continue
  MessageBox MB_OK|MB_ICONSTOP "You don't have the correct rights."
  Call gpAbort
  Abort
  Continue:
    WriteRegStr HKLM "${REG_UNINSTALL}" "DisplayIcon"     "$INSTDIR\${UNINSTALLER}.exe"
    WriteRegStr HKLM "${REG_UNINSTALL}" "UninstallString" "$INSTDIR\${UNINSTALLER}.exe"
    WriteRegStr HKLM "${REG_UNINSTALL}" "DisplayVersion"  "1.0"
    WriteRegStr HKLM "${REG_UNINSTALL}" "Publisher"       "${COMPANY}"
    WriteRegStr HKLM "${REG_UNINSTALL}" "NoModify"        1
    WriteRegStr HKLM "${REG_UNINSTALL}" "NoRepair"        1
    goto Done
  Done:
    WriteUninstaller "$INSTDIR\${UNINSTALLER}.exe"
SectionEnd


Section "${PRODUCT}"
  ClearErrors
  CreateDirectory "$INSTDIR\${VERSION}"
  CreateDirectory "$INSTDIR\${VERSION}\Config"
  FileOpen $0 $INSTDIR\NujitStart.config w
  IfErrors cancelled
  FileWrite $0 "<Config>$\r$\n"
  FileWrite $0 "$\t<AppFolderName>${VERSION}</AppFolderName>$\r$\n"
  FileWrite $0 "$\t<AppExeName>NujitErp.exe</AppExeName>$\r$\n"
  FileWrite $0 "</Config>"
  FileClose $0

  InetLoad::load "${NUJIT_URL1}NujitStart.exe" "$INSTDIR\NujitStart.exe" \
                 "${NUJIT_URL2}/Config/setting.xml" "$INSTDIR\${VERSION}\Config\setting.xml" \
                 "${NUJIT_URL2}ActiveReports.Design.dll" "$INSTDIR\${VERSION}\ActiveReports.Design.dll" \
                 "${NUJIT_URL2}ActiveReports.dll" "$INSTDIR\${VERSION}\ActiveReports.dll" \
                 "${NUJIT_URL2}ActiveReports.HtmlExport.dll" "$INSTDIR\${VERSION}\ActiveReports.HtmlExport.dll" \
                 "${NUJIT_URL2}ActiveReports.Interop.dll" "$INSTDIR\${VERSION}\ActiveReports.Interop.dll" \
                 "${NUJIT_URL2}ActiveReports.PdfExport.dll" "$INSTDIR\${VERSION}\ActiveReports.PdfExport.dll" \
                 "${NUJIT_URL2}ActiveReports.RtfExport.dll" "$INSTDIR\${VERSION}\ActiveReports.RtfExport.dll" \
                 "${NUJIT_URL2}ActiveReports.TextExport.dll" "$INSTDIR\${VERSION}\ActiveReports.TextExport.dll" \
                 "${NUJIT_URL2}ActiveReports.TiffExport.dll" "$INSTDIR\${VERSION}\ActiveReports.TiffExport.dll" \
                 "${NUJIT_URL2}ActiveReports.Viewer.dll" "$INSTDIR\${VERSION}\ActiveReports.Viewer.dll" \
                 "${NUJIT_URL2}ActiveReports.Web.Design.dll" "$INSTDIR\${VERSION}\ActiveReports.Web.Design.dll" \
                 "${NUJIT_URL2}ActiveReports.Web.dll" "$INSTDIR\${VERSION}\ActiveReports.Web.dll" \
                 "${NUJIT_URL2}ActiveReports.Wizards.Addin.dll" "$INSTDIR\${VERSION}\ActiveReports.Wizards.Addin.dll" \
                 "${NUJIT_URL2}ActiveReports.XlsExport.dll" "$INSTDIR\${VERSION}\ActiveReports.XlsExport.dll" \
                 "${NUJIT_URL2}ADODB.dll" "$INSTDIR\${VERSION}\ADODB.dll" \
                 "${NUJIT_URL2}AGVBN20.dll" "$INSTDIR\${VERSION}\AGVBN20.dll" \
                 "${NUJIT_URL2}AppUpdater.dll" "$INSTDIR\${VERSION}\AppUpdater.dll" \
                 "${NUJIT_URL2}MySql.Data.dll" "$INSTDIR\${VERSION}\MySql.Data.dll" \
                 "${NUJIT_URL2}Interop.COMSVCSLib.dll" "$INSTDIR\${VERSION}\Interop.COMSVCSLib.dll" \
                 "${NUJIT_URL2}Interop.mscoree.dll" "$INSTDIR\${VERSION}\Interop.mscoree.dll" \
                 "${NUJIT_URL2}netchartdir.dll" "$INSTDIR\${VERSION}\netchartdir.dll" \
                 "${NUJIT_URL2}netchartdir_internal.dll" "$INSTDIR\${VERSION}\netchartdir_internal.dll" \
                 "${NUJIT_URL2}NujitCustomWinControls.dll" "$INSTDIR\${VERSION}\NujitCustomWinControls.dll" \
                 "${NUJIT_URL2}NujitERP.exe" "$INSTDIR\${VERSION}\NujitERP.exe" \
                 "${NUJIT_URL2}NujitERPClassLib.dll" "$INSTDIR\${VERSION}\NujitERPClassLib.dll" \
                 "${NUJIT_URL2}TimeCtrl.dll" "$INSTDIR\${VERSION}\TimeCtrl.dll" \
                 "${NUJIT_URL2}WinFormsControls.dll" "$INSTDIR\${VERSION}\WinFormsControls.dll" \
                 "${NUJIT_URL2}WizardControlLibrary.dll" "$INSTDIR\${VERSION}\WizardControlLibrary.dll"

  Pop $0
  StrCmp $0 "OK" continue
  StrCmp $0 "Cancelled" cancelled
  MessageBox MB_OK|MB_ICONSTOP "Download Error, click OK to abort installation." /SD IDOK
  Call gpAbort
  Abort

cancelled:
  Call gpAbort
  Abort
  
continue:
  CreateDirectory "$SMPROGRAMS\${COMPANY}"
  CreateDirectory "$SMPROGRAMS\${COMPANY}\${PRODUCT}"
  CreateShortCut "$SMPROGRAMS\${COMPANY}\${PRODUCT}\Uninstall.lnk" "$INSTDIR\${UNINSTALLER}.exe" "" "$INSTDIR\${UNINSTALLER}.exe" 0
  CreateShortCut "$SMPROGRAMS\${COMPANY}\${PRODUCT}\${PRODUCT}.lnk" "$INSTDIR\NujitStart.exe" "" "$INSTDIR\NujitStart.exe" 0
  !insertmacro MUI_INSTALLOPTIONS_WRITE "ioSpecial.ini" "Settings" "CancelShow" "0"
SectionEnd


Section "Uninstall"
  ;Habilito la opción de reinicio
  ;al finalizar la desinstalación
  SetRebootFlag false
  
  ;Descargo el plugin
  DetailPrint "${UNLOADING_PLUGIN}"
  SetPluginUnload manual
  System::Free 0
	
  ;Borro el directorio de instalación
  DetailPrint "${DELETING_INST_FOLDER}"
  RMDir /r $INSTDIR
  RMDir "$PROGRAMFILES\${COMPANY}"
  ;Borro el directorio en el Start Menu
  RMDir /r "$SMPROGRAMS\${COMPANY}\${PRODUCT}"
  RMDir "$SMPROGRAMS\${COMPANY}"
  
  ;Borro la entrada en el registro
  DetailPrint "${DELETING_REGISTRY_ENTRIES}"
  DeleteRegKey HKLM "${REG_UNINSTALL}"
SectionEnd


;Funciones
Function .onInit
  Call IsUserAdmin
  Pop $R0
  StrCmp $R0 "false" adminError
  
  ;Verifico si existe una versión previa en el registro
  ReadRegStr $OldUninstallApp HKLM "${REG_UNINSTALL}" "UninstallString"
  StrCmp $OldUninstallApp "" continue
	
  MessageBox MB_YESNO|MB_ICONINFORMATION "You must uninstall the previous version of ${PRODUCT}. Do you want to do it now?" IDNO error
  ;El parámetro extra hace que se espere hasta que termine la desinstalación
  ExecWait '"$OldUninstallApp" _?=$INSTDIR'
	
  ;Verifico que realmente se haya desinstalado todo según el registro
  ReadRegStr $OldUninstallApp HKLM "${REG_UNINSTALL}" "UninstallString"
  StrCmp $OldUninstallApp "" continue error
	
  error:
    Abort
    
  adminError:
    MessageBox MB_OK|MB_ICONSTOP "You must have Administrator rights to execute the Installer."
    Abort
    
  continue:
FunctionEnd


Function IsDotNETInstalled
  Push $0
  Push $1
  Push $2
  Push $3
  Push $4

  ReadRegStr $4 HKEY_LOCAL_MACHINE \
  "Software\Microsoft\.NETFramework" "InstallRoot"
  # remove trailing back slash
  Push $4
  Exch $EXEDIR
  Exch $EXEDIR
  Pop $4
  # if the root directory doesn't exist .NET is not installed
  IfFileExists $4 0 noDotNET

  StrCpy $0 0

  EnumStart:

  EnumRegKey $2 HKEY_LOCAL_MACHINE \
  "Software\Microsoft\.NETFramework\Policy"  $0
  IntOp $0 $0 + 1
  StrCmp $2 "" noDotNET

  StrCpy $1 0

  EnumPolicy:

  EnumRegValue $3 HKEY_LOCAL_MACHINE \
  "Software\Microsoft\.NETFramework\Policy\$2" $1
  IntOp $1 $1 + 1
  StrCmp $3 "" EnumStart
  IfFileExists "$4\$2.$3" foundDotNET EnumPolicy

  noDotNET:
  StrCpy $0 0
  Goto done

  foundDotNET:
  StrCpy $0 1

  done:
  Pop $4
  Pop $3
  Pop $2
  Pop $1
  Exch $0
FunctionEnd


Function IsUserAdmin
  Push $R0
  Push $R1
  Push $R2

  ClearErrors
  UserInfo::GetName
  IfErrors Win9x
  Pop $R1
  UserInfo::GetAccountType
  Pop $R2

  StrCmp $R2 "Admin" 0 Continue
  StrCpy $R0 "true"
  Goto Done

  Continue:
  StrCpy $R0 "false"
  Goto Done

  Win9x:
  ; comment/message below is by UserInfo.nsi author:
  ; This one means you don't need to care about admin or
  ; not admin because Windows 9x doesn't either
  StrCpy $R0 "true"

  Done:
  ;MessageBox MB_OK 'User= "$R1"  AccountType= "$R2"  IsUserAdmin= "$R0"'

Pop $R2
Pop $R1
Exch $R0
FunctionEnd


Function UnloadPlugin
  DetailPrint "${UNLOADING_PLUGIN}"
  ;Descargo el DLL y libero la memoria
  SetPluginUnload manual
  System::Free 0
FunctionEnd


Function DeleteInstFolder
  DetailPrint "${DELETING_INST_FOLDER}"
  RMDir /r $INSTDIR
  RMDir "$PROGRAMFILES\${COMPANY}"
FunctionEnd


Function DeleteRegistryEntries
  DetailPrint "${DELETING_REGISTRY_ENTRIES}"
  DeleteRegKey HKLM "${REG_UNINSTALL}"
FunctionEnd


Function gpTerminar
  ;Descargo el plugin
  Call UnloadPlugin
FunctionEnd


Function gpAbort
  StrCpy $InstallStatus "aborting_ir_install"
  ;Descargo el plugin
  Call UnloadPlugin
  ;Borro el directorio de instalación
  Call DeleteInstFolder
  ;Borro las entradas en el registro
  Call DeleteRegistryEntries
FunctionEnd