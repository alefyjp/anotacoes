#!/bin/bash
# ======================================================================================
# Titulo: Instala Emby - Docker
# Autor: Alefy
# ======================================================================================

echo "Baixando ultima versao do emby"
docker pull emby/embyserver:latest

echo "Criando diretorigos emby"
mkdir /opt/emby
mkdir /opt/emby/config
mkdir /opt/emby/tvshows
mkdir /opt/emby/movies
