using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            MainAsync().GetAwaiter().GetResult();
        }
        private static async Task MainAsync()
        {
            /*
            try {
                var itemsRc = await ItemManager.addItem("ItemX", "CategoryX", 10.50);
                ItemRC itemRc = itemsRc.FirstOrDefault();
                Console.WriteLine($"Add response code: {itemRc.RC}, response message {itemRc.Message}");
            }
            catch (Exception ex) {
                Console.WriteLine(ex.Message);
            }
            */

            /*
            try{
                var items = await ItemManager.getItemList("0", "10");
                foreach (var item in items){
                    Console.WriteLine($"Item: {item.Name}, Category: {item.Category}, Price: {item.Price}, Id: {item.Id}");
                }
            }
            catch (Exception ex) {
                Console.WriteLine(ex.Message);
            }
            */
            var itemsRc = await ItemManager.addItem("ItemXY", "CategoryX", 10.50);
            ItemRC itemRc = itemsRc.FirstOrDefault();
            Console.WriteLine($"Add response code: {itemRc.RC}, response message: {itemRc.Message}, New Id; {itemRc.Id}");

            string IdBuscar = itemRc.Id.ToString();
            var items = await ItemManager.getItem(IdBuscar);
            if (items.Count() == 0) Console.WriteLine($"No existe el item con id: {IdBuscar}");
            else{
                foreach (var item in items){
                    Console.WriteLine($"Item: {item.Name}, Category: {item.Category}, Price: {item.Price}, Id: {item.Id}");
                }
            }   
            
            itemsRc = await ItemManager.updateItem(int.Parse(IdBuscar), "ItemY", "CategoryY", 20.90);
            itemRc = itemsRc.FirstOrDefault();
            Console.WriteLine($"Update response code: {itemRc.RC}, response message: {itemRc.Message}");

            items = await ItemManager.getItem(IdBuscar);
            if (items.Count() == 0) Console.WriteLine($"No existe el item con id: {IdBuscar}");
            else{
                foreach (var item in items){
                    Console.WriteLine($"Item: {item.Name}, Category: {item.Category}, Price: {item.Price}, Id: {item.Id}");
                }
            }

            itemsRc = await ItemManager.deleteItem(int.Parse(IdBuscar));
            itemRc = itemsRc.FirstOrDefault();
            Console.WriteLine($"Delete response code: {itemRc.RC}, response message: {itemRc.Message}");

            items = await ItemManager.getItem(IdBuscar);
            if (items.Count() == 0) Console.WriteLine($"No existe el item con id: {IdBuscar}");
            else{
                foreach (var item in items){
                    Console.WriteLine($"Item: {item.Name}, Category: {item.Category}, Price: {item.Price}, Id: {item.Id}");
                }
            }
        }
    }
}
