@echo off
chcp 65001 >nul
title Reativar Windows Update

echo ===============================================
echo 🔓 REATIVANDO SERVIÇOS E FIREWALL
echo ===============================================

:: Restaurar permissões dos executáveis
for %%F in (
    "%SystemRoot%\System32\UsoClient.exe"
    "%SystemRoot%\System32\wuauclt.exe"
    "%SystemRoot%\System32\musnotification.exe"
    "%SystemRoot%\System32\musnotificationux.exe"
) do (
    icacls %%F /reset >nul
)

:: Reativar serviços
for %%S in (wuauserv bits dosvc usosvc WaaSMedicSvc) do (
    sc config %%S start= demand >nul
    net start %%S >nul 2>&1
)

:: Remover regras de firewall
for %%D in (
    "*.windowsupdate.com"
    "*.update.microsoft.com"
    "*.delivery.mp.microsoft.com"
    "*.windowsupdate.microsoft.com"
    "*.dl.delivery.mp.microsoft.com"
    "*.emdl.ws.microsoft.com"
) do (
    netsh advfirewall firewall delete rule name="Bloquear %%D" >nul 2>&1
)

echo ✅ Reativado com sucesso.
pause
