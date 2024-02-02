#!/bin/bash

# [Global]
ARQUIVO_TOKEN="../git_token.txt"
DATAHORA=$(date)


# ===== Enviar dados ===== #
echo "=="
echo "Arquivos que serao enviados"
git add -A
git commit -m "$DATAHORA"

echo "=="
echo "Utilize o token: "
echo ""
cat $ARQUIVO_TOKEN
echo""

echo "=="
echo "Realizando envio dos arquivos"
git push
