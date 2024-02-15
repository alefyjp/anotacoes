#!/bin/bash
# ============================================================================================
# Titulo: FW - Redirect
# Autor: Alefy Gonzaga
# ============================================================================================
DNS="meudns.com.br" # DNS da maquina remota
MEUIP=10.1.2.1 # IP da maquina que esta rodando o script

#Obtendo IP por tras do DNS
IPREMOTO=$(host $DNS | cut -d " " -f4)

# Inicio
iptables -t nat -F

iptables -t nat -A PREROUTING -p tcp --dport 80 -j DNAT --to-destination $IPREMOTO:80
iptables -t nat -A POSTROUTING -p tcp -d $IPREMOTO --dport 80 -j SNAT --to-source $MEUIP

iptables -t nat -A PREROUTING -p tcp --dport 443 -j DNAT --to-destination $IPREMOTO:443
iptables -t nat -A POSTROUTING -p tcp -d $IPREMOTO --dport 443 -j SNAT --to-source $MEUIP

iptables -t nat -A PREROUTING -p tcp --dport 21 -j DNAT --to-destination $IPREMOTO:21
iptables -t nat -A POSTROUTING -p tcp -d $IPREMOTO --dport 21 -j SNAT --to-source $MEUIP

iptables -t nat -A Pclient_loop: send disconnect: Broken pipedestination $IPREMOTO:21
root@VSE-TI-02:~#  POSTROUTING -p tcp -d $IPREMOTO --dport 21 -j SNAT --to-source $MEUIP

iptables -t nat -A PREROUTING -p tcp --dport 20 -j DNAT --to-destination $IPREMOTO:20
iptables -t nat -A POSTROUTING -p tcp -d $IPREMOTO --dport 20 -j SNAT --to-source $MEUIP

iptables -t nat -L -nv


# habilitando encaminhamento de pacotes
echo 1 > /proc/sys/net/ipv4/ip_forward#
