using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Credit_Suisse
{

    interface ITrade
    {

        double Value { get; } //indicates the transaction amount in dollars
        string ClientSector { get; } //indicates the client ́s sector which can be "Public" or "Private"
        DateTime NextPaymentDate { get; } //indicates when the next payment from the client to the bank is expected
        bool IsPoliticallyExposed { get; } //is political exposed

    }

    public class Trade : ITrade
    {

        double ITrade.Value => TradeAmount;
        string ITrade.ClientSector => ClientSector;
        DateTime ITrade.NextPaymentDate => NextPendingPayment;

        private double tradeAmount;
        private string clientSector="";
        private DateTime nextPendingPayment;
        private DateTime refDate;
        private bool isPoliticallyExposed;

        public double TradeAmount { get => tradeAmount; set => tradeAmount = value; }
        public string ClientSector { get => clientSector; set => clientSector = value; }
        public DateTime NextPendingPayment { get => nextPendingPayment; set => nextPendingPayment = value; }
        public DateTime RefDate { get => refDate; set => refDate = value; }    
        public bool IsPoliticallyExposed { get => isPoliticallyExposed; set => isPoliticallyExposed = value; }

        public string Classify() 
        {
            string Category="";


            // Verify EXPIRED

            if (refDate > nextPendingPayment.AddDays(30))
            {
                Category = "EXPIRED";
            }

            //Verify HIGHRISK

            if ((tradeAmount > 1000000) && (clientSector == "Private"))
            {
                Category = "HIGHRISK";
            }

            //Verify MEDIUMRISK

            if ((tradeAmount > 1000000) && (clientSector == "Public"))
            {
                 Category = "MEDIUMRISK";
                
            }

            //Verify if is Politically Exposed

            if (IsPoliticallyExposed) 
            { 
                Category = "PEP";
            }

            return Category;

        }
    
    }
}
