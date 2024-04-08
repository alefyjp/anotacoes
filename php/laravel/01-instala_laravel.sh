#!/bin/bash

# =====================================================================================================
# Titulo: Instala Laravel
# Autor: Alefy Gonzaga
# =====================================================================================================

# Instalar PHP
sudo apt install php-mysql -y

sudo apt install php libapache2-mod-php php-mbstring php-xmlrpc php-soap php-gd php-xml php-cli php-zip php-bcmath php-tokenizer php-json php-pear php-curl -y

sudo systemctl restart apache2.service 

# banco de dados
sudo apt install -y mariadb-server mariadb-client
sudo systemctl enable mariadb.service
sudo mysql_secure_installation

# instalar php composer
curl -sS https://getcomposer.org/installer | php
sudo mv composer.phar /usr/local/bin/composer
sudo chmod +x /usr/local/bin/composer
