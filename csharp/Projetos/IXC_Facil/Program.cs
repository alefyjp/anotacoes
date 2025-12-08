/* IMPORTAÇÕES */
using System;
using System.IO;
using IXC_Facil;

/* FUNÇÕES */
List<string> BuscaCredenciais(string caminhoArquivo)
{
    var resposta = new List<string>();

    /* CONTEUDO DO ARQUIVO DE CREDENCIAIS
    Usuário:
    E-mail:
    Senha:
    Token:
    Host:
     */

    using (StreamReader sr = new StreamReader(caminhoArquivo))
    {
        var linha = sr.ReadLine();
        resposta.Add(linha);

        while (linha != null)
        {
            linha = sr.ReadLine();
            resposta.Add(linha);
        }
    }
    return resposta;
}

/* CONFIGURAÇÕES */
var localCredenciais = @"C:\IXC\credenciais_api.txt";
var credenciais = BuscaCredenciais(localCredenciais);
var usuario = new UsuarioIXC
{
    Nome = credenciais[0],
    Email = credenciais[1],
    Senha = credenciais[2],
    Token = credenciais[3],
    Host = credenciais[4]
};

var api = new IXCAPI();
api.Usuario = usuario;

// TESTE API
//api.Teste();
await api.ConexoesRadius();
//await api.BuscaStatusLogin();


