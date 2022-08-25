using System; 
using Server.Items;

namespace Server.Items
{ 
   public class DrugPlant: Item 
   { 
      [Constructable]
       public DrugPlant()
           : base(0x0D06) 
      { 
         Movable = false;
         Name = "Shimyshisha";
         timer_pousse = new Timer_Pousse(this);
         timer_pousse.Debuter();
			Donne = true;
        
      }

       private bool m_Donne;
       private double m_Ticks;
       private Timer_Pousse timer_pousse;

       [CommandProperty(AccessLevel.GameMaster)]
       public bool Donne
       {
           get { return m_Donne; }
           set { m_Donne = value; }
       }


       [CommandProperty(AccessLevel.GameMaster)]
       public double Ticks
       {
           get { return m_Ticks; }
           set { m_Ticks = value; }
       }

      public override void OnDoubleClick( Mobile from ) 
      {

			if( from.InRange(this.Location,2) )
			{
				if (this.Donne == true)
				{
					BatWing itemadd = new BatWing();
					from.AddToBackpack(itemadd);
					this.ItemID = 1;
					this.Donne = false;
					from.SendMessage("Vous les récoltez."); this.timer_pousse.Debuter();
				 
				}
			}
      } 

      public DrugPlant( Serial serial ) : base( serial ) 
      { 
      } 

      public override void Serialize( GenericWriter writer ) 
      { 
         base.Serialize( writer );
         writer.Write(m_Donne);
         writer.Write(m_Ticks);
         writer.Write( (int) 0 ); // version 
      } 

      public override void Deserialize( GenericReader reader ) 
      { 
         base.Deserialize( reader );
         m_Donne = reader.ReadBool();
         m_Ticks = reader.ReadDouble();
         int version = reader.ReadInt(); 

		 timer_pousse = new Timer_Pousse(this);
         timer_pousse.Debuter();
      }




       public class Timer_Pousse : Timer
       {
           private DrugPlant who;
           private DrugPlant m_item;

           public void Arreter()
           {
               //m_Timer_Pousse.Remove(who.Serial.Value);
               this.Stop();
           }
           public void Debuter()
           {
               m_item = (DrugPlant)who;
               
               this.Start();
           }

           // Apres 2.5 secondes, le timer sera declanché tout les secondes. apres 5 ticks, ça s'arretera
           public Timer_Pousse(DrugPlant from)
               : base(TimeSpan.Zero, TimeSpan.FromHours(1.0))
           {
               m_item = (DrugPlant)from;
               who = (DrugPlant)from;
               m_item.Ticks = Utility.Random(2,7);
               this.Start();
           }

          

 

           protected override void OnTick()
           {
               if (m_item.Ticks <= 0)
               {
                   m_item.Ticks = Utility.Random(2,7);
                   if (m_item.Donne == false)
                   {
							  this.Stop();
                       m_item.ItemID = 0x1E8C;
                       m_item.Donne = true;
                   }  
               }
               else
               {
                   m_item.Ticks -= 1;
               }

           }
       }

   } 
} 