using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Recipes_Web_API.Models
{
    public class Recipe
    {
        public int id { get; set; }
        public string name { get; set; }
        public string time { get; set; }
        public string type { get; set; }
        public string category { get; set; }

        public Recipe(int id, string name, string time, string type, string category)
        {
            this.id = id;
            this.name = name;
            this.time = time;
            this.type = type;
            this.category = category;
        }

        public override string ToString()
        {
            return $"{id}. Name: {name}, Time: {time}, Type: {type}, Category: {category};";
        }
    }
}