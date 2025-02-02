﻿using colab.Business.Models.Entities.Enums;
using Newtonsoft.Json;

namespace colab.Business.Models.Entities;

public class TipoBolsa
{
    public int Id { get; set; }
    
    public String nome { get; set; }
    
    public String descricao { get; set; }
    
    public Escolaridade escolaridade { get; set; }
    
    [JsonIgnore]
    public Bolsa Bolsa { get; set; }
    
    private string escolaridadeDescricao => escolaridade.ToString();
}