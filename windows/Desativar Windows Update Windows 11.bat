@echo off
chcp 65001 >nul
title Bloqueio Total do Windows Update (Firewall + Serviços)

echo ===============================================
echo 🚫 BLOQUEANDO ATUALIZAÇÕES DO WINDOWS 11
echo ===============================================

:: Desativar serviços principais de atualização
for %%S in (wuauserv bits dosvc usosvc WaaSMedicSvc) do (
    net stop %%S >nul 2>&1
    sc config %%S start= disabled >nul
)

:: Bloquear executáveis de atualização
for %%F in (
    "%SystemRoot%\System32\UsoClient.exe"
    "%SystemRoot%\System32\wuauclt.exe"
    "%SystemRoot%\System32\musnotification.exe"
    "%SystemRoot%\System32\musnotificationux.exe"
) do (
    icacls %%F /inheritance:r /deny SYSTEM:(X) >nul 2>&1
)

:: Criar regras de firewall para domínios conhecidos do Windows Update
call :AddRule "*.windowsupdate.com"
call :AddRule "*.update.microsoft.com"
call :AddRule "*.delivery.mp.microsoft.com"
call :AddRule "*.windowsupdate.microsoft.com"
call :AddRule "*.dl.delivery.mp.microsoft.com"
call :AddRule "*.emdl.ws.microsoft.com"

echo ===============================================
echo ✅ BLOQUEIO TOTAL CONCLUÍDO!
echo Reinicie o PC para aplicar completamente.
echo ===============================================
pause
exit /b

:AddRule
netsh advfirewall firewall add rule name="Bloquear %~1" ^
    dir=out action=block enable=yes profile=any remoteport=80,443 ^
    description="Bloqueia tráfego de atualização" >nul 2>&1
exit /b
