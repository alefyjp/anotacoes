# ==============================================================================================
# Titulo: Script para backup em geral
# Autor: Alefy Gonzaga
# Ultima alteracao: 25/10/2023
# ==============================================================================================

# -- Confs --

# Global
$data_atual = Get-Date -Format "yyyy-MM-dd"
$destino = "\\10.1.131.23\bkp2\bkp-dados"

# Alvos
$arquivos = "D:\musicas\musica1.mp3", "D:\musicas\musica2.mp3", "D:\musicas\musica3.mp3","" # Nao remover o ,"" presente no final
$pastas = "D:\musicas\eletronicas","" # Nao remover o ,"" presente no final


# Mapeando destino como uma unidade
net use n: /delete /y
net use n: $destino /user:bkpnas visualse

# -- Copiando arquivos --
 
# Cria no destino uma pasta com a data de hoje para armazenas os backups do dia
if(![System.IO.Directory]::Exists($destino.ToString()+"\"+$data_atual)) 
{
    mkdir ($destino.ToString()+"\"+$data_atual)
}

# Copia todos os arquivos para o destino
for($i = 0; $i -lt $arquivos.Count; $i++) # LT Menor que
{
    # Copiando somente arquivos com caminhos diferentes de ""
    if($arquivos[$i] -ne "") #-ne NotEquals = nao e igual
    {
        Copy-Item $arquivos[$i] ($destino.ToString()+"\"+$data_atual)
    }
}

# Copia todos os diretorios para o destino
for($i = 0; $i -lt $pastas.Count; $i++) # LT Menor que
{
    # Copiando somente pastas com caminhos diferentes de ""
    if($pastas[$i] -ne "") #-ne NotEquals = nao e igual
    {
        Copy-Item -Path $pastas[$i] ($destino.ToString()+"\"+$data_atual) -Recurse -Force
    }
}

# -- Removendo pastas de backups antigas --

# Obtendo a lista de todos os backups
$lista = @(dir -n $destino) # O @ est  transformando o retorno em um array

# Verificando se h  mais do 5 pastas deste backup
if ($lista.Length -gt 5) # GreaterThan - Maior que
{   
    $utimos = ($lista.Length - 1) - 5 # Preservando as ultimas 5 pastas de backups

    # echo ("Apagando pastas ate a posicao: " + $utimos)

    for($i = 0; $i -le $utimos; $i++) # LE LessEqual Menor ou igual 
    {       
        Remove-Item ($destino.ToString()+"\"+$lista[$i]) -Force -Recurse
    }  
}