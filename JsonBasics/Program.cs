using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;

Console.WriteLine("---------Serialize Object to json-----------------");
Product product = new Product();
product.Name = "Apple";
product.Expiry = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
product.Sizes = new string[] { "Small" };

// When class object is need to be converted into equivalent json string with beautifier
string json = JsonConvert.SerializeObject(product, Formatting.Indented);

//// When class object is need to be converted into equivalent json string without
//string json = JsonConvert.SerializeObject(product);
Console.WriteLine(json);


Console.WriteLine("---------Deserialize Object-----------------");
string jsonstr = @"{
  'Name': 'Bad Boys',
  'Expiry': '1995-4-7T00:00:00',
  'Sizes': [
    'Large',
    'Small'
  ]
}";

Product m = JsonConvert.DeserializeObject<Product>(jsonstr);

string name = m.Name;

Console.WriteLine($"Name is {m.Name} Expiry date : {m.Expiry.ToShortDateString()},  Sizes are  {m.Sizes[0]} and {m.Sizes[1]}");


Console.WriteLine("---------Linq to Json-----------------");
JArray array = new JArray();
array.Add("Orange");
array.Add(new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day));
array.Add(new string[] { "African", "Asian"});

JObject oJObject = new JObject();
oJObject["Product"] = array;

string jsonProd = oJObject.ToString();
Console.WriteLine(jsonProd);



Console.ReadKey();
