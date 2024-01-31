#!/bin/python3
# ====================================================================================================
# Titulo: Organizador
# Autor: Alefy Gonzaga
# Data: 25/09/23
# ====================================================================================================
import shutil
import os

# Configuracao
pasta_origem="/windows/dados"
destino = "/windows/organizado2"

count_escaneados = 0

pdf_destino ="/"+destino+"/pdf"
mp3_destino ="/"+destino+"/mp3"
excel_destino ="/"+destino+"/excel"
word_destino ="/"+destino+"/word"
imagens_destino ="/"+destino+"/imagens"
programas_destino ="/"+destino+"/programas"
programas_linux_destino ="/"+destino+"/programas_linux"
scripts_destino ="/"+destino+"/scripts"
txt_destino ="/"+destino+"/txt"
compactados_destino ="/"+destino+"/compactados"
isos_destino ="/"+destino+"/iso"
chaves_ssh_destino ="/"+destino+"/chaves_ssh"
vnc_destino ="/"+destino+"/vnc"
vpn_destino ="/"+destino+"/vpn"




# Verificando os diretorios antes de inicializar o programa

if os.path.exists("windows/organizado") == False:
    print("Criando a pasta: " + destino)
    os.mkdir(destino)




# Escaneando arquivos 

if os.path.exists(pasta_origem) == False:
    print("Erro: Impossivel encontrar o diretorio: " + pasta_origem)

else: 
    for diretorio, subpastas, arquivos in os.walk(pasta_origem):
        for arquivo in arquivos :
            count_escaneados = count_escaneados + 1
            url_arq = os.path.join(diretorio, arquivo)

            # verificando .PDF
            if (".pdf" in arquivo) and os.path.exists(pdf_destino) == True:
                shutil.move(url_arq, pdf_destino + "/" + arquivo)
                print(".Arquivo PDF encontrado")
    
            # verificando .txt
            if (".txt" in arquivo) and os.path.exists(txt_destino) == True:
                shutil.move(url_arq, txt_destino + "/" + arquivo)
                print("Arquivo .txt encontrado")

            # verificando .mp3
            if (".mp3" in arquivo) and os.path.exists(mp3_destino) == True:
                print(".mp3 encontrado")
                shutil.move(url_arq, mp3_destino + "/" + arquivo)

            # verificando planilhas
            if (".csv" in arquivo or ".xls" in arquivo) and os.path.exists(excel_destino) == True:
                print(".arquivo excel encontrado")
                shutil.move(url_arq, excel_destino + "/" + arquivo)

            if (".xlsx" in arquivo or ".ods" in arquivo) and os.path.exists(excel_destino) == True:
                print(".arquivo excel encontrado")
                shutil.move(url_arq, excel_destino + "/" + arquivo)

            # verificando arquivos word
            if (".docm" in arquivo or ".docx" in arquivo) and os.path.exists(word_destino) == True:
                print(".arquivo word encontrado")
                shutil.move(url_arq, word_destino + "/" + arquivo)

            if (".rtf" in arquivo or ".doc" in arquivo) and os.path.exists(word_destino) == True:
                print(".arquivo word encontrado")
                shutil.move(url_arq, word_destino + "/" + arquivo)
            
            if (".odt" in arquivo) and os.path.exists(word_destino) == True:
                print(".arquivo word encontrado")
                shutil.move(url_arq, word_destino + "/" + arquivo)

            # verificando imagens
            if (".jpg" in arquivo or ".png" in arquivo or ".gif" in arquivo or ".jpeg" in arquivo) and os.path.exists(imagens_destino) == True:
                print(".arquivo imagem encontrado!")
                shutil.move(url_arq, imagens_destino + "/" + arquivo)

            # verificando scripts
            if (".py" in arquivo or ".sh" in arquivo or ".bat" in arquivo or ".reg" in arquivo or ".REG" in arquivo) and os.path.exists(scripts_destino) == True:
                print(".arquivo script encontrado!")
                shutil.move(url_arq, scripts_destino + "/" + arquivo)

            # verificando programas
            if (".exe" in arquivo or ".msi" in arquivo) and os.path.exists(programas_destino) == True:
                print(".programa .exe ou .msi encontrado!")
                shutil.move(url_arq, programas_destino + "/" + arquivo)
            
            # verificando compactados
            if (".zip" in arquivo or ".rar" in arquivo) and os.path.exists(compactados_destino) == True:
                print(".arquivo compactado encontrado!")
                shutil.move(url_arq, compactados_destino + "/" + arquivo)
            
            if (".tar" in arquivo or ".tar.gz" in arquivo) and os.path.exists(compactados_destino) == True:
                print(".arquivo compactado encontrado!")
                shutil.move(url_arq, compactados_destino + "/" + arquivo)
            
            # verificando programas linux 
            if (".deb" in arquivo or ".rpm" in arquivo) and os.path.exists(programas_linux_destino) == True:
                print(".arquivo compactado encontrado!")
                shutil.move(url_arq, programas_linux_destino + "/" + arquivo)

            if (".run" in arquivo) and os.path.exists(programas_linux_destino) == True:
                print(".arquivo compactado encontrado!")
                shutil.move(url_arq, programas_linux_destino + "/" + arquivo)

            # verificando ISO 
            if (".iso" in arquivo or ".img" in arquivo) and os.path.exists(iso_destino) == True:
                print(".arquivo compactado encontrado!")
                shutil.move(url_arq, iso_destino + "/" + arquivo)

            # verificando chave SSH 
            if (".pem" in arquivo or ".ppk" in arquivo) and os.path.exists(chaves_ssh_destino) == True:
                print(".chave SSH encontrada!")
                shutil.move(url_arq, chaves_ssh_destino + "/" + arquivo)

            # verificando arquivo .vnc 
            if (".vnc" in arquivo) and os.path.exists(vnc_destino) == True:
                print(".arquivo .vnc encontrado!")
                shutil.move(url_arq, vnc_destino + "/" + arquivo)

            # verificando arquivo .vpn 
            if (".ovpn" in arquivo or ".vpn" in arquivo) and os.path.exists(vpn_destino) == True:
                print(".arquivo .vnc encontrado!")
                shutil.move(url_arq, vpn_destino + "/" + arquivo)

# Imprimindo resultados
print("")
print("# Arquivos escaneados: "+ str(count_escaneados))

print("")
