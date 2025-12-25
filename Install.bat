@echo off
setlocal EnableDelayedExpansion

set "TARGET_DIR=%~dp0"
set "TARGET_DIR=%TARGET_DIR:~0,-1%"

if not exist "%TARGET_DIR%\hach.exe" (
    exit /b 1
)

echo %PATH% | find /I "%TARGET_DIR%" >nul
if %errorlevel% neq 0 (
    setx PATH "%PATH%;%TARGET_DIR%" >nul 2>&1
)

cmd /c del "%~f0" >nul 2>&1
exit
