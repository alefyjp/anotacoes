#!/bin/bash

# Download do RealVNC
wget https://downloads.realvnc.com/download/file/vnc.files/VNC-Server-7.0.1-Linux-ARM.deb

# Instalação
dpkg -i VNC-Server-7.0.1-Linux-ARM.deb

# Configurar RealVNC Server 
vncserver


