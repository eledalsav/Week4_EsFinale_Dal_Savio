using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Week4_EsFinale_Dal_Savio.Core;

namespace Week4_EsFinale_Dal_Savio.Client
{
    class Menu
    {
        internal static void Start()
        {
            bool quit = false;
            char choice;
            do
            {
                Console.WriteLine("\nSeleziona un'opzione del menu" +
                "\n[ 1 ] - Aggiungi nuovo cliente" +
                "\n[ 2 ] - Elimina un cliente" +
                "\n[ 3 ] - Gestisci un ordine" +
                "\n[ 4 ] - Visualizza la lista delle attività (clienti/ordini)" +
                "\n[ q ] - ESCI");



                choice = Console.ReadKey().KeyChar;



                switch (choice)
                {
                    case '1':
                        AddClient();
                        break;
                    case '2':
                        DeleteClient();
                        break;
                    case '3':
                        AddOrdine();
                        break;
                    case '4':
                        ShowOrdiniClienti();
                        break;
                    case 'q':
                        quit = true;
                        break;
                    default:
                        Console.WriteLine("\nScelta sconosciuta.");
                        break;
                }



            } while (!quit);
        }

        private static void ShowOrdiniClienti()
        {
            HttpClient client = new HttpClient();

            HttpRequestMessage request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("http://localhost:55037/api/orders")
            };

            HttpResponseMessage response = client.SendAsync(request).Result;

            //if(response.StatusCode == System.Net.HttpStatusCode.OK) //se risp da ok  -> la recupero come stringa
            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;

                //Deserializzazione (da stringa (json) -> oggetto di C#)
                var result = JsonConvert.DeserializeObject<List<OrderContract>>(data);

                foreach (OrderContract p in result)
                {
                    Console.WriteLine($"\nId ordine : {p.OrderId} - IdCliente : {p.CustomerId} - DataOrdine: {p.DataOrdine} - Codice Prodotto : {p.CodiceProdotto}  - Importo : {p.Importo}");
                }
            }
        }

        private static void AddOrdine()
        {
           Customer cliente = GetCliente();
            DateTime dataOrdine = GetDate();
            int idCliente = GetIdCliente();

            HttpClient client = new HttpClient();

            HttpRequestMessage postRequest = new HttpRequestMessage
            {
                Method = HttpMethod.Post,
                RequestUri = new Uri("http://localhost:55037/api/orders")
            };

            OrderContract newPrestito = new OrderContract
            {
                Cliente=cliente,
                CustomerId=idCliente,
                DataOrdine=dataOrdine,
            };

            //passo da c#a json -> lo trasformo in stringa
            string newPrestitoJson = JsonConvert.SerializeObject(newPrestito);//!!!!

            postRequest.Content = new StringContent(
                newPrestitoJson,
                Encoding.UTF8,
                "application/json");

            //recupero la risposta

            HttpResponseMessage postResponse = client.SendAsync(postRequest).Result;

            if (postResponse.StatusCode == System.Net.HttpStatusCode.Created)
            {
                string data = postResponse.Content.ReadAsStringAsync().Result;

                var result = JsonConvert.DeserializeObject<OrderContract>(data);

                Console.WriteLine($"Ordine aggiunto con Id {result.CodiceOrdine}");
            }
        }

        private static Customer GetCliente()
        {
            string nome;
            string cognome;
            string codicecliente;
            do
            {
                Console.WriteLine($"\nInserisci il nome");
                nome = Console.ReadLine();
                if (nome.Length < 10)
                    nome = null;
            } while (string.IsNullOrEmpty(nome));
            do
            {
                Console.WriteLine($"\nInserisci il cognome");
                cognome = Console.ReadLine();
                if (cognome.Length < 10)
                    cognome = null;
            } while (string.IsNullOrEmpty(cognome));
            do
            {
                Console.WriteLine($"\nInserisci il codice cliente");
                codicecliente = Console.ReadLine();
                if (codicecliente.Length < 10)
                    codicecliente = null;
            } while (string.IsNullOrEmpty(codicecliente));

            Customer cliente = new Customer()
            {
                Nome = nome,
                Cognome = cognome,
                CodiceCliente = codicecliente,
            };
            return cliente;
            
        }

        private static void DeleteClient()
        {
            int id = GetIdCliente();
            HttpClient client = new HttpClient();

            HttpRequestMessage request = new HttpRequestMessage
            {
                Method = HttpMethod.Delete,
                RequestUri = new Uri("http://localhost:55037/api/customers/" + $"{id}")
            };

            HttpResponseMessage response = client.SendAsync(request).Result;

            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine("\nCliente eliminato");
            }
            else Console.WriteLine("\nCliente NON eliminato");
        }

            private static void AddClient()
        {
            Customer cliente = GetCliente();

            HttpClient client = new HttpClient();

            HttpRequestMessage postRequest = new HttpRequestMessage
            {
                Method = HttpMethod.Post,
                RequestUri = new Uri("http://localhost:55037/api/customers")
            };

            CustomerContract newBook = new CustomerContract
            {
                Nome = cliente.Nome,
                Cognome=cliente.Cognome,
                CodiceCliente=cliente.CodiceCliente,
            };

            //passo da c#a json -> lo trasformo in stringa
            string newCustomJson = JsonConvert.SerializeObject(newBook);

            postRequest.Content = new StringContent(
                newCustomJson,
                Encoding.UTF8,
                "application/json");

            //recupero la risposta

            HttpResponseMessage postResponse = client.SendAsync(postRequest).Result;

            if (postResponse.StatusCode == System.Net.HttpStatusCode.Created)
            {
                string data = postResponse.Content.ReadAsStringAsync().Result;

                var result = JsonConvert.DeserializeObject<CustomerContract>(data);

                Console.WriteLine($"\nCliente aggiunto con Id {result.CustomerId}");
            }
        }

      
        private static DateTime GetDate()
        {
            DateTime data = new DateTime();
            do
            {
                Console.WriteLine("\nInserisci la data dell'ordine");

            } while (!DateTime.TryParse(Console.ReadLine(), out data) || data < DateTime.Now);

            return data;
        }

    

        private static int GetIdCliente()
        {
            int id;

            do
            {
                Console.WriteLine("\nInserisci l'Id del cliente");
            } while (!int.TryParse(Console.ReadLine(), out id) || id <= 0);
            return id;
        }

  

        private static string GetData(string field)
        {
            string inseredField;
            do
            {
                Console.WriteLine($"\nInserisci il campo {field}");
                inseredField = Console.ReadLine();
                if (inseredField.Length < 10)
                    inseredField = null;
            } while (string.IsNullOrEmpty(inseredField));

            return inseredField;
        }
    }
}
