using System.Runtime.ConstrainedExecution;
using System.Runtime.InteropServices;

namespace StockChatBot.Models
{
    public class Stock
    {
        public string Symbol { get; set; }
        public string Date { get; set; }
        public string Time { get; set; }
        public string Open { get; set; }
        public string High { get; set; }
        public string Low { get; set; }
        public string Close { get; set; }
        public string Volume { get; set; }

        public string ToChatMessage()
        {

            //contains  N/D

            return $"{this.Symbol} quote is ${this.Close} per share.";


        }

    }
}
