#!/bin/bash
#================================================================================================
# Autor: Alefy Gonzaga
# Alvo: Docker
# Atualizacao: 16/06/2023
#================================================================================================

# Configuracao
DOCKER_DIR="/opt/docker"
CONTAINER_DIR="$DOCKER_DIR/nginx"
HTML_DIR="$CONTAINER_DIR/html"

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

if [ -d $HTML_DIR ]; then
   echo "Diretorio $HTML_DIR encontrado!"
else
   echo "Criando $HTML_DIR"
   mkdir $HTML_DIR
   chmod 777 -R $HTML_DIR
fi

# Configurando diretorios
echo "==="
echo "Configurando diretorios"
echo "==="
docker run -it -d --name nginx-modelo nginx
docker cp nginx-modelo:/etc/nginx/. $CONTAINER_DIR 
docker rm -f nginx-modelo

touch $HTML_DIR/index.html
echo "NGINX instalado com sucesso!" > $HTML_DIR/index.html
echo "<br/>Obrigado por utilizar esse script" >> $HTML_DIR/index.html
echo "<br/>Att,"  >> $HTML_DIR/index.html
echo "<br/><b>Alefy Gonzaga</b>"  >> $HTML_DIR/index.html

