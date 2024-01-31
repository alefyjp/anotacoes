#!/bin/bash

echo "-- Update e upgrade --"
# Update
apt-get update -y ; apt-get upgrade -y
echo ""
echo "-- FFmpeg --"
# FFmpeg
sudo apt-get install ffmpeg -y
echo ""
echo "-- Obs studio --"
# Instalar obs studio
sudo add-apt-repository ppa:obsproject/obs-studio -y
sudo apt update
sudo apt-get update && sudo apt-get install obs-studio
echo ""
echo "-- NDI --"
# NDI
wget https://github.com/obs-ndi/obs-ndi/releases/download/4.7.1/obs-ndi_4.7.1-1_amd64.deb
wget https://github.com/obs-ndi/obs-ndi/releases/download/4.7.1/libndi3_4.0.0-1_amd64.1.deb

dpkg -i obs-ndi_4.7.1-1_amd64.deb libndi3_4.0.0-1_amd64.1.deb
rm obs-ndi_4.7.1-1_amd64.deb libndi3_4.0.0-1_amd64.1.deb


echo ""
echo "Fim :)  "

obs
