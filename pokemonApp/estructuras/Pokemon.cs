using System;
using System.Collections.Generic;
using Newtonsoft.Json;
namespace pokemonApp.estructuras
{
    public class Resultado
    {
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "url")]
        public string Url { get; set; }
    }

    public class Listado
    {
        [JsonProperty(PropertyName = "count")]
        public int Count { get; set; }

        [JsonProperty(PropertyName = "results")]
        public List<Resultado> Results { get; set; }
    }

    public class Sprites
    {
        [JsonProperty(PropertyName = "front_default")]
        public string Front_default { get; set; }

        [JsonProperty(PropertyName = "back_default")]
        public string Back_default { get; set; }
    }

    public class Pokemon
    {
        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }

        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "height")]
        public int Height { get; set; }

        [JsonProperty(PropertyName = "weight")]
        public int Weight { get; set; }

        [JsonProperty(PropertyName = "base_experience")]
        public int base_experience { get; set; }

        [JsonProperty(PropertyName = "sprites")]
        public Sprites Sprite { get; set; }
    }

    public class Habilidad2
    {
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "url")]
        public string Url { get; set; }
    }

    public class Habilidad
    {
        [JsonProperty(PropertyName = "ability")]
        public Habilidad2 Ability { get; set; }
    }

    public class Habilidades
    {
        [JsonProperty(PropertyName = "abilities")]
        public List<Habilidad> Abilities { get; set; }
    }

}
