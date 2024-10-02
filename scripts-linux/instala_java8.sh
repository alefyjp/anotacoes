#!/bin/bash
#================================================================================
# Instalador java 8
# Autor: Alefy
# Alvo: ubuntu 22.04
# ================================================================================

#Atualizando sistema
sudo apt update -y

# Instalando WGET
sudo apt install wget -y

# Baixando o java 8
wget "https://javadl.oracle.com/webapps/download/AutoDL?BundleId=245797_df5ad55fdd604472a86a45a217032c7d" -O java-8.tar.gz

# Extraindo o java 8
sudo mkdir /usr/java

tar -xf java-8.tar.gz -C /usr/java

# checando a versao
cd /usr/java/jre1.8.0_321/bin

./java -version

# Adicionando a pasta ao systen PATH

echo 'PATH="/usr/local/sbin:/usr/local/bin:/usr/sbin:/usr/bin:/sbin:/bin:/usr/games:/usr/local/games:/snap/bin:/usr/java/jre1.8.0_321/bin"' >> /etc/environment

# reload nas variaveis
source /etc/environment

# Testando
java -version

