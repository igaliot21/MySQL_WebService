using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Newtonsoft.Json;
using System.Net.Http;

namespace Test
{
    public class Item
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public double Price { get; set; }
        public Item() { }
        public Item(int Id, string Name, string Category, double Price) {
            this.Id = Id;
            this.Name = Name;
            this.Category = Category;
            this.Price = Price;
        }
    }
    public class ItemRC{
        public int RC { get; set; }
        public string Message { get; set; }
        public int Id { get; set; }
        public ItemRC() { }
        public ItemRC(int RC, string Message,int Id) {
            this.RC = RC;
            this.Message = Message;
            this.Id = Id;
        }
    }
    public class ItemManager {
        private const string URL_ITEM_LIST = "http://192.168.1.20/webservice/ItemList.php?user={0}&password={1}&reg_inicio={2}&max_reg={3}";
        private const string URL_ITEM = "http://192.168.1.20/webservice/Item.php?user={0}&password={1}&id={2}";
        private const string URL_ADD_ITEM = "http://192.168.1.20/webservice/AddItem.php?user={0}&password={1}&name={2}&category={3}&price={4}";
        private const string URL_UPDATE_ITEM = "http://192.168.1.20/webservice/UpdateItem.php?user={0}&password={1}&id={2}&name={3}&category={4}&price={5}";
        private const string URL_DELETE_ITEM = "http://192.168.1.20/webservice/DeleteItem.php?user={0}&password={1}&id={2}";
        private const string CLIENT_ID = "test";
        private const string CLIENT_PASS = "test";

        private static HttpClient getClient() {
            HttpClient client = new HttpClient();

            client.DefaultRequestHeaders.Add("Accept", "application/json");
            client.DefaultRequestHeaders.Add("Connection", "close");

            return client;
        }
        public async static Task<IEnumerable<Item>> getItemList(string Initial_Reg, string Reg_To) {
            HttpClient client = getClient();
            string url = string.Format(URL_ITEM_LIST, CLIENT_ID, CLIENT_PASS, Initial_Reg, Reg_To);
            var resultado = await client.GetAsync(url);
            if (resultado.IsSuccessStatusCode){
                string content = await resultado.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<IEnumerable<Item>>(content);
            }
            else return Enumerable.Empty<Item>();
        }
        public async static Task<IEnumerable<Item>> getItem(string Id){
            HttpClient client = getClient();
            string url = string.Format(URL_ITEM, CLIENT_ID, CLIENT_PASS, Id);
            var resultado = await client.GetAsync(url);
            if (resultado.IsSuccessStatusCode){
                string content = await resultado.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<IEnumerable<Item>>(content);
            }
            else return Enumerable.Empty<Item>();
        }
        public async static Task<IEnumerable<ItemRC>> addItem(string Name, string Category, double Price){
            HttpClient client = getClient();
            string url = string.Format(URL_ADD_ITEM, CLIENT_ID, CLIENT_PASS, Name, Category, Price.ToString());
            url = url.Replace(",", ".");
            var resultado = await client.GetAsync(url);
            if (resultado.IsSuccessStatusCode){
                string content = await resultado.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<IEnumerable<ItemRC>>(content);
            }
            else return Enumerable.Empty<ItemRC>();
        }
        public async static Task<IEnumerable<ItemRC>> updateItem(int Id, string Name, string Category, double Price){
            HttpClient client = getClient();
            string url = string.Format(URL_UPDATE_ITEM, CLIENT_ID, CLIENT_PASS, Id.ToString(), Name, Category, Price.ToString());
            url = url.Replace(",", ".");
            var resultado = await client.GetAsync(url);
            if (resultado.IsSuccessStatusCode){
                string content = await resultado.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<IEnumerable<ItemRC>>(content);
            }
            else return Enumerable.Empty<ItemRC>();
        }
        public async static Task<IEnumerable<ItemRC>> deleteItem(int Id){
            HttpClient client = getClient();
            string url = string.Format(URL_DELETE_ITEM, CLIENT_ID, CLIENT_PASS, Id.ToString());
            var resultado = await client.GetAsync(url);
            if (resultado.IsSuccessStatusCode){
                string content = await resultado.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<IEnumerable<ItemRC>>(content);
            }
            else return Enumerable.Empty<ItemRC>();
        }
    }
}
