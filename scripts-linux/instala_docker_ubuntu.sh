#!/bin/bash
#=============================================================================================================================================
# Alvo: Ubuntu 18.04 em diante
# Autor: Alefy
#=============================================================================================================================================
echo "Removendo versões anteriores"

for pkg in docker.io docker-doc docker-compose podman-docker containerd runc; do 
  echo "===================================="
  sudo apt-get remove $pkg -y; 
done

echo "Adicionando repositórios"
sudo apt-get update -y
sudo apt-get install ca-certificates curl gnupg -y

# Adicione a chave GPG oficial do Docker:
sudo install -m 0755 -d /etc/apt/keyrings
curl -fsSL https://download.docker.com/linux/ubuntu/gpg | sudo gpg --dearmor -o /etc/apt/keyrings/docker.gpg
sudo chmod a+r /etc/apt/keyrings/docker.gpg

# Configuração do repositório
echo \
  "deb [arch="$(dpkg --print-architecture)" signed-by=/etc/apt/keyrings/docker.gpg] https://download.docker.com/linux/ubuntu \
  "$(. /etc/os-release && echo "$VERSION_CODENAME")" stable" | \
  sudo tee /etc/apt/sources.list.d/docker.list > /dev/null

echo "Instalação docker engine"
sudo apt-get update -y
sudo apt-get install docker-ce docker-ce-cli containerd.io docker-buildx-plugin docker-compose-plugin -y

echo "Instalação finalizada!"
sudo docker ps
