#!/bin/bash

# [Global]
ARQUIVO_TOKEN="../git_token.txt"
DATAHORA=$(date)


# ===== Enviar dados ===== #

git add -A
git commit -m "$DATAHORA"

echo "Utilize o token: "
echo ""
cat $ARQUIVO_TOKEN
echo""
git push
