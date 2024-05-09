#!/bin/bash
# ============================================================================================
# Titulo: FW - Redirect
# Autor: Alefy Gonzaga
# ============================================================================================
MEUIP=10.1.70.118
#Obtendo IP por tras do DNS
IPREMOTO=10.1.2.20

# Inicio
iptables -t nat -F
iptables -F

iptables -t nat -I PREROUTING -p tcp --dport 80 -j DNAT --to-destination $IPREMOTO:80
iptables -t nat -I POSTROUTING -p tcp -d $IPREMOTO --dport 80 -j SNAT --to-source $MEUIP


#iptables -I FORWARD -p tcp -d $IPREMOTO --dport 80 -j ACCEPT

iptables -t nat -L -nv

# habilitando encaminhamento de pacotes
echo 1 > /proc/sys/net/ipv4/ip_forward
