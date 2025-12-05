/* IMPORTAÇÕES */
using System;
using System.IO;

/* CONFIGURAÇÕES */
var raizes = new List<string> { @"X:\" };
string banner = """
 _   _    ___    ____          __           
| \ | |  / _ \  / ___|   __ _ / _|  __ _ ___ 
|  \| | | | | | \___ \  / _` | |_  / _` / __|
| |\  | | |_| |  ___) || (_| |  _|| (_| \__ \
|_| \_|  \___/  |____/  \__,_|_|   \__,_|___/
        NAS  F A X I N A T O R
""";

var arquivosIndesejados = new List<string>
{
    "Trailer.PT-BR.mp4",
    "1XBET.COM_promo_SHREK_dinheiro_livre.mp4",
    "BAIXAR OUTROS FILMES.url",
    "Comando.LA.url",
    "TorrentDosFilmes.SE.url"
};

/* FUNÇÕES */
List<string> BuscaSubpastas(List<string> bases)
{
    var subpastasEncontradas = new List<string>();

    foreach (var pastaBase in bases)
    {
        try
        {
            foreach (string subpasta in Directory.GetDirectories(pastaBase))
            {
                subpastasEncontradas.Add(subpasta);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Erro ao acessar " + pastaBase + ": " + ex.Message);
        }
    }

    return subpastasEncontradas;
}

void DeletaArquivos(List<string> nomesArquivos, List<string> pastasDestino)
{
    foreach (var pasta in pastasDestino)
    {
        foreach (var nomeArquivo in nomesArquivos)
        {
            string caminho = Path.Combine(pasta, nomeArquivo);

            try
            {
                if (File.Exists(caminho))
                {
                    File.Delete(caminho);
                    Console.WriteLine("Removido: " + caminho);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro ao remover " + caminho + ": " + ex.Message);
            }
        }
    }
}

/* INICIO */

//BANNER
Console.WriteLine(banner);
Console.WriteLine("Desenvolvido por: Alefy Gonzaga");

// PESQUISANDO TODAS AS PASTAS NOS DIRETORIOS RAIZES
var resultadoFinal = new List<string>();
var resultadoParcial = BuscaSubpastas(raizes);

resultadoFinal.AddRange(resultadoParcial);

// CONTINUAR ATÉ CHEGAR NAS ÚLTIMAS SUBPASTAS
while (resultadoParcial.Count > 0)
{
    resultadoParcial = BuscaSubpastas(resultadoParcial);
    resultadoFinal.AddRange(resultadoParcial);
}

// REMOVENDO ARQUIVOS INDESEJADOS
DeletaArquivos(arquivosIndesejados, resultadoFinal);