
//## Importes
using System;
using System.IO; // Necessário para usar a classe File

//## Funções
void CopiarSubpastas(string origem, string destino)
{
    if (!Directory.Exists(destino))
    {
        Directory.CreateDirectory(destino);
    }

    foreach (string arquivo in Directory.GetFiles(origem))
    {
        string nomeArquivo = Path.GetFileName(arquivo);
        string destinoArquivo = Path.Combine(destino, nomeArquivo);
        File.Copy(arquivo, destinoArquivo, true);
    }

    foreach (string subdiretorio in Directory.GetDirectories(origem))
    {
        string nomeSubdiretorio = Path.GetFileName(subdiretorio);
        string novoDestinoSubdiretorio = Path.Combine(destino, nomeSubdiretorio);
        CopiarSubpastas(subdiretorio, novoDestinoSubdiretorio);
    }
}

//Configuração
string origem= @"C:\Users\magno\AppData\LocalLow\Google\GoogleEarth";
string arqUsuarios = @"C:\Mapas\scripts\usuarios.txt";
string usuario;


//## Inicio
Console.WriteLine("## FibiEarth v1.0 ##");
Console.WriteLine("");
Console.WriteLine("Logs:");

// Verificando se o arquivo de usuários existe
if (!File.Exists(arqUsuarios))
{
    Console.WriteLine(" ");
    Console.WriteLine("- Carregando arquivo de usuários [Erro]");
    Console.WriteLine(" ");
    Console.WriteLine("- Criando arquivo de usuários [OK]");
    File.CreateText(arqUsuarios).Close();
}
else 
{
    Console.WriteLine("- Carregando arquivo de usuários [OK]");
}

// Realizando cópias
try
{
    StreamReader sr = new StreamReader(arqUsuarios);
    usuario= sr.ReadLine();
    while (usuario != null)
    {
        Console.WriteLine("");
        string destino= "C:\\Users\\" + usuario + "\\AppData\\LocalLow\\Google\\GoogleEarth";
        Console.WriteLine("- Copiando arquivos para o destino: ");
        Console.WriteLine(" "+destino);
        usuario = sr.ReadLine();

        //deletando pasta atual
        if(Directory.Exists(destino))
        {
            Directory.Delete(destino, true);
        }

        //Copiando arquivos e pastas
        CopiarSubpastas(origem,destino);
    }
    //fechar arquivo
    sr.Close();
}
catch (Exception e)
{
    Console.WriteLine("Exception: " + e.Message);
}
finally
{
    Console.WriteLine("");
    Console.WriteLine("Finalizado!");
}
//Aguardar 2 minutos antes de fechar
Thread.Sleep(200000);