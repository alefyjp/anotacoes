#!/bin/bash
#================================================================================================
# Autor: Alefy Gonzaga
# Alvo: Mysql docker
# Atualizacao: 16/06/2023
#================================================================================================

# Configuracao
DOCKER_DIR="/opt/docker"
CONTAINER_DIR="$DOCKER_DIR/mysql"

# Docker
if [ -d $DOCKER_DIR ]; then
   echo "Diretorio docker encontrado!"
else
   echo "Criando diretorio: $DOCKER_DIR"
   mkdir $DOCKER_DIR
   chmod 777 -R $DOCKER_DIR
fi

# Container
if [ -d $CONTAINER_DIR ]; then
   echo "Diretorio $CONTAINER_DIR encontrado!"
else
   echo "Criando diretorio $CONTAINER_DIR"
   mkdir $CONTAINER_DIR
   chmod 777 -R $CONTAINER_DIR
fi
