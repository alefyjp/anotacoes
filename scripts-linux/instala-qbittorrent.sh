#!/bin/bash
#qbittorrent
sudo apt install qbittorrent-nox -y

echo "Passo01 - Primeiro acesso"
echo "Entre com o comando: qbittorrent-nox" 
echo "http://meuip>8080" 
echo " " 
echo " " 
echo " " 

echo "Passo02 - Iniciar qbittorrent junto ao Linux"
echo "Adicione o seguinte comando ao crontab: @reboot setsid qbittorrent-nox" 
