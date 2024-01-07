using API.Models;
using Newtonsoft.Json;
using Projeto3v2.Entidades;
using System.Net.Http.Headers;
using System.Text;

string token = "";
string urlBase = "https://localhost:7245/api/";


using (var client = new HttpClient())
{
    client.BaseAddress = new Uri(urlBase);

    string json = JsonConvert.SerializeObject(
        new
        {
            login = "admin",
            password = "admin"
        });

    var body = new StringContent(json, Encoding.UTF8, "application/json");

    var resposta = await client.PostAsync("Auth/login", body);
    var mensagem = resposta.Content.ReadAsStringAsync().Result;

    if (resposta.IsSuccessStatusCode)
    {
        TokenModel tokenModel = JsonConvert.DeserializeObject<TokenModel>(mensagem);

        token = tokenModel.token;
        Console.WriteLine($"Token adqurido. token: {token}\n");
    }
    else
    {
        Console.WriteLine($"Erro ao obter o token: {mensagem}");
    }
}

//GET - Retorna a lista inteira de filmes

using (var client = new HttpClient())
{
    client.BaseAddress = new Uri(urlBase);

    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

    var resposta = await client.GetAsync("Filme");
    var mensagem = resposta.Content.ReadAsStringAsync().Result;

    if (resposta.IsSuccessStatusCode)
    {
        List<Filme> filmes = JsonConvert.DeserializeObject<List<Filme>>(mensagem);

        foreach (Filme filme in filmes)
        {
            Console.WriteLine(filme.ToString());
            Console.WriteLine("");
        }
    }
    else
    {
        Console.WriteLine($"Erro ao realizar o GET: {mensagem}");
    }
}


//POST - Insere um novo filme na lista de filmes
/*
using (var client = new HttpClient())
{
    client.BaseAddress = new Uri(urlBase);

    client.DefaultRequestHeaders.Authorization =
                       new AuthenticationHeaderValue("Bearer", token);

    Filme filme         = new Filme();
    filme.Id            = 3;
    filme.Nome          = "O Farol";
    filme.Genero        = "Terror";
    filme.DuracaoMin    =  150;
    filme.Ano           = "2021";

    string json = JsonConvert.SerializeObject(filme);

    var body = new StringContent(json, Encoding.UTF8, "application/json");

    var resposta = await client.PostAsync("Filme", body);
    var mensagem = resposta.Content.ReadAsStringAsync().Result;

    if (resposta.IsSuccessStatusCode)
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"O filme ({filme.Nome}) foi inserido com sucesso!");
        Console.ResetColor();
    }
    else
    {
        Console.WriteLine($"Erro ao realizar o POST: {mensagem}");
    }
}
*/


//PUT - Atualiza um filme dentro do BD
/*
using (var client = new HttpClient())
{
    client.BaseAddress = new Uri(urlBase);

    client.DefaultRequestHeaders.Authorization =
                       new AuthenticationHeaderValue("Bearer", token);

    Filme filme         = new Filme();
    filme.Id            = 2;
    filme.Nome          = "O resgate do soldado Ryan";
    filme.Genero        = "Guerra";
    filme.DuracaoMin    = 170;
    filme.Ano           = "1998";

    string json = JsonConvert.SerializeObject(filme);

    var body = new StringContent(json, Encoding.UTF8, "application/json");

    var resposta = await client.PutAsync("Filme", body);
    var mensagem = resposta.Content.ReadAsStringAsync().Result;

    if (resposta.IsSuccessStatusCode)
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"O filme ({filme.Nome}) atualizado com sucesso!");
        Console.ResetColor();
        Console.WriteLine("-----------------------------------------------");
        filme.ToString();
    }
    else
    {
        Console.WriteLine($"Erro ao realizar o PUT: {mensagem}");
    }
}
*/


//GET - busca um filme pelo ID
/*
using (var client = new HttpClient())
{
    client.BaseAddress = new Uri(urlBase);

    client.DefaultRequestHeaders.Authorization =
                       new AuthenticationHeaderValue("Bearer", token);

    var resposta = await client.GetAsync("Filme/2"); //buscando o filme do ID 2
    var mensagem = resposta.Content.ReadAsStringAsync().Result;

    if (resposta.IsSuccessStatusCode)
    {
        Filme filme = JsonConvert.DeserializeObject<Filme>(mensagem);

        if (filme != null)
        {
            Console.WriteLine(filme.ToString());
        }                
    }
    else
    {
        Console.WriteLine($"Erro ao realizar o GET: {mensagem}");
    }
}
*/


//DELETE -> delete um cliente do banco de dados pelo seu ID
/*
using (var client = new HttpClient())
{
    client.BaseAddress = new Uri(urlBase);

    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

    var resposta = await client.DeleteAsync("Filme/3");
    var mensagem = resposta.Content.ReadAsStringAsync().Result;

    if (resposta.IsSuccessStatusCode)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("FILME EXCLUIDO");
        Console.ResetColor();
    }
    else
    {
        Console.WriteLine($"Erro ao realizar o GET por ID: {mensagem}");
    }
}
*/

//Para a execução para ver o resultado
Console.WriteLine("Pressione qualquer tecla para continuar...");
Console.ReadKey();