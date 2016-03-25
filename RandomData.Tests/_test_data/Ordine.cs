using System;
using System.Collections.Generic;

namespace RandomData.Tests
{
    public class Ordine
    {
        public int id { get; set; }
        public int stato { get; set; }
        public string note { get; set; }
        public int idUtente { get; set; }
        public int destinatarioID { get; set; } 
        public UtenteRubrica utente { get; set; }
        public int idHotel { get; set; }
        public DateTime ultimaModifica { get; set; }
        public string room {get; set;}

        //data, non posso metterlo private perchè viene usato dal codice in runtime
        public List<ServizioQT> servizi { get; set; }

        public class ServizioQT //questa è solo per l'ordine
        {
            public int servizioID { get; set; }
            public int QT { get; set; }
        }

        public enum Stato
        {
            NotAvailable,
            Inserted,
            Completed,
            NotPossible
        }
    }
}
