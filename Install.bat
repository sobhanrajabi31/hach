@echo off
setlocal EnableDelayedExpansion

set "TARGET_DIR=%~dp0"
set "TARGET_DIR=%TARGET_DIR:~0,-1%"

if not exist "%TARGET_DIR%\hach.exe" (
    echo ERROR: hach.exe not found in:
    echo %TARGET_DIR%
    pause
    exit /b 1
)

echo %PATH% | find /I "%TARGET_DIR%" >nul
if %errorlevel%==0 (
    echo Path already exists.
) else (
    echo Adding to PATH:
    echo %TARGET_DIR%
    setx PATH "%PATH%;%TARGET_DIR%" >nul
    echo Added successfully.
)

cmd /c del "%~f0"
exit
