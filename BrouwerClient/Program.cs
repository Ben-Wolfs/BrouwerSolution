using BrouwerClient;
using System.Net;

Console.Write("id: ");
var id = int.Parse(Console.ReadLine()!);
using var client = new HttpClient();
var uri = $"http://localhost:5200/brouwers/{id}";
var response = await client.GetAsync(uri);

//if (response.StatusCode == HttpStatusCode.Created)
//{
//    Console.WriteLine($$"""Brouwer is toegevoegd. Zijn URI is {{response.Headers.Location }}.""");
//} else
//{
//    Console.WriteLine("Technisch probleem, contacteer de helpdesk.");
//}

switch (response.StatusCode)
{
    case HttpStatusCode.OK:
        var brouwer = await response.Content.ReadAsAsync<Brouwer>();
        brouwer.Gemeente = brouwer.Gemeente.ToUpper();
        response= await client.PutAsJsonAsync(uri, brouwer);
        if (response.StatusCode == HttpStatusCode.OK)
        {
            Console.WriteLine("Brouwer gewijzigd");
        }
        else
        {
            Console.WriteLine("Technisch probleem, contacteer de helpdesk.");
        }
        break;
    case HttpStatusCode.NotFound:
        Console.WriteLine("Brouwer niet gevonden.");
        break;
    default:
        Console.WriteLine("Technisch probleem, contacteer de helpdesk.");
        break;
}
Console.ReadKey();