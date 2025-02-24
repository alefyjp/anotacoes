
//Mapedando as extensões de arquivo com suas respectivas pastas de destino
Dictionary<string, string> mapeamento = new Dictionary<string, string>();
mapeamento.Add(".txt", "Textos");
mapeamento.Add(".docx", "Textos");
mapeamento.Add(".doc", "Textos");
mapeamento.Add(".odt", "Textos");
mapeamento.Add(".rtf", "Textos");
mapeamento.Add(".ods", "Planilhas");
mapeamento.Add(".xlsx", "Planilhas");
mapeamento.Add(".csv", "Planilhas");
mapeamento.Add(".pdf", "PDF");
mapeamento.Add(".png", "Imagens");
mapeamento.Add(".icfg", "Backups");
mapeamento.Add(".bkp", "Backups");
mapeamento.Add(".sql", "Backups");
mapeamento.Add(".rsc", "Backups");
mapeamento.Add(".zip", "Compactados");
mapeamento.Add(".rar", "Compactados");
mapeamento.Add(".gz", "Compactados");
mapeamento.Add(".tar", "Compactados");
mapeamento.Add(".gz2", "Compactados");
mapeamento.Add(".drawio", "Projetos");
mapeamento.Add(".exe", "Programas");
mapeamento.Add(".msi", "Programas");
mapeamento.Add(".jar", "Programas");
mapeamento.Add(".py", "Programas");
mapeamento.Add(".sh", "Programas");
mapeamento.Add(".dll", "Programas");
mapeamento.Add(".iso", "ISO");
mapeamento.Add(".vnc", "Arquivos de configuração");
mapeamento.Add(".mov", "Videos");
mapeamento.Add(".mp4", "Videos");
mapeamento.Add(".wmv", "Videos");
mapeamento.Add(".avi", "Videos");
mapeamento.Add(".mvk", "Videos");
mapeamento.Add(".webm", "Videos");
mapeamento.Add(".appxbundle", "Dependencias - Windows");
mapeamento.Add(".html", "HTML");
mapeamento.Add(".cer", "Certificados");
mapeamento.Add(".pfx", "Certificados");
mapeamento.Add(".pem", "Certificados");
mapeamento.Add(".mp3", "Musicas");


//Funções -----
void organizaArquivos(string pastaOrigem, string pastaDestino)
{
    //Obtendo lista de arquivos da pasta de origem
    var arquivos = Directory.GetFiles(pastaOrigem);

    foreach (var arquivo in arquivos)
    {
        var arqExtensao = Path.GetExtension(arquivo);

        /* Movendo arquivos
         * Verificando se a extensão do arquivo possui mapeamento de pasta
        */
        if (mapeamento.ContainsKey(arqExtensao.ToLower()))
        {
            //Caso sim, obtennha a pasta mapeada com base na chave (extensão)
            var pastaMapeada = mapeamento[arqExtensao.ToLower()];

            //Verificando se a pasta mapeada para a extensão existe no destino
            if (!Directory.Exists(pastaMapeada))
            {
                Directory.CreateDirectory(Path.Combine(pastaDestino, pastaMapeada));
            }
            //Criando a string do arquivo de destino
            var arquivoDestino = Path.Combine(pastaDestino, pastaMapeada, Path.GetFileName(arquivo));

            Console.WriteLine("Movendo: ");
            Console.WriteLine(arquivo);
            Console.WriteLine("Para: ");
            Console.WriteLine(arquivoDestino);
            File.Move(arquivo, arquivoDestino, true);
        }
        else
        {
            Console.WriteLine("------------------");
            Console.WriteLine("Aviso: Encontrei a seguinte extensões sem mapeamento: " + arqExtensao.ToLower());
            Console.WriteLine("------------------");
        }
    }
}

//Inicio ----
string destino = @"C:\Users\alefygonzaga\Desktop\Dados\Organizados";
string[] origens =
{ 
    @"C:\Users\alefygonzaga\Desktop\Dados\Brutos"
};

foreach (var origem in origens)
{
    organizaArquivos(origem, destino);
}
