#!/bin/bash
# ========================================================================================================
# Autor: Alefy
# Alvo: Linux em geral
# ========================================================================================================

echo "Verificando diretorios"

# Diretorio da aplicacao
if [ -d '/opt/docker/phpipam' ]; then
   echo "Diretorio da aplicacao encontrado!"
else
   echo "Criando /opt/docker/phpipam"
   mkdir /opt/docker/phpipam
   chmod 777 -R /opt/docker/phpipam
fi

# Diretorio Certificados
if [ -d '/opt/docker/phpipam/certificates' ]; then
   echo "Diretorio HTML encontrado!"   
else
   echo "Criando diretorio certificates"	
   mkdir /opt/docker/phpipam/certificates
   chmod 777 -R /opt/docker/phpipam/certificates
fi

