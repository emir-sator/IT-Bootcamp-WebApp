using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RS1SeminarskiRad2020.Models
{
   public class Subscription
   {
      public int SubscriptionID { get; set; }
      public string Client { get; set; }
      public string Endpoint { get; set; }
      public string p256dh { get; set; }
      public string auth { get; set; }
   }
}
