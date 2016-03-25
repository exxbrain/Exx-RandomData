using System;
using System.Collections.Generic;

namespace RandomData.Tests
{

    public class UtenteRubrica
    {
        public int id { get; set; }
        public string nome { get; set; }
        public string cognome { get; set; }
        public int sesso { get; set; }
        public int relazione { get; set; }
        public string mail { get; set; }
        public string img { get; set; }
        public int status { get; set; } //vedi UtenteStatus
        public int eta { get; set; }
        public DateTime ultimoAccesso { get; set; }
        public bool isSelezionato { get; set; }
        public string frase  { get; set; }
        public int doNotDisturb  { get; set; }
        public string nazionalita  { get; set; }
        public int online  { get; set; }
        public int relatedChatID  { get; set; }
    }
    
}
