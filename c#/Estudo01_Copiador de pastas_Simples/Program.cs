using System;
using System.IO;

/* Estudo 01 - Copiador de pastas - Simples
*  Autor: Alefy Gonzaga
*  Revisão: 27/08/24
*  Alvo: Windows e Linux
*/

// -- Funções
void copiaPasta(string pastaOrigem, string pastaDestino)
{
    if (!Directory.Exists(pastaDestino))
    {
        Directory.CreateDirectory(pastaDestino);
    }

    foreach (string arquivo in Directory.GetFiles(pastaOrigem))
    {
        /* Anotação
         * A função Path.GetFileName(arquivo), extrai o nome do arquivo (incluindo a extensão) do caminho completo fornecido na variável arquivo.
         * A função Path.Combine combina dois caminhos de diretório e cria um caminho completo para um arquivo ou diretório. 
         * Nesse caso, combina pastaDestino(o diretório onde você deseja copiar o arquivo) com o nome do arquivo extraído.
        */

        string arquivoDestino = Path.Combine(pastaDestino, Path.GetFileName(arquivo));
        Console.WriteLine("Copiando " + arquivo + " para " + arquivoDestino);
        File.Copy(arquivo, arquivoDestino, true);
    }
}

// -- Inicio
string orig = @"D:\ISO";
string dest = @"D:\backups";

copiaPasta(orig, dest);

