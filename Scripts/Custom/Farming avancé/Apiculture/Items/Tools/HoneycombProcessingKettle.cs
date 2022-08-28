using System;
using Server; 
using Server.Items;
using Server.Network;
using Server.Scripts; 


namespace Server.Items 
{ 
   public class HoneycombProcessingKettle : Item 
   { 

      [Constructable] 
      public HoneycombProcessingKettle() : base( 0x9ED ) 
      { 
         Name = "Bouilloire pour le miel"; 
         Weight = 10.0;             
      } 

      public override void OnDoubleClick( Mobile from ) 
      { 
         Container pack = from.Backpack; 

	if( from.InRange( this.GetWorldLocation(), 1 ) )
	{

         if (pack != null && pack.ConsumeTotal( typeof( HoneyComb ), 1 ) ) 
         { 
            from.SendMessage("*Vous centrifugez le produit et séparez le miel et la cire*"); 
                
               { 
					
                from.AddToBackpack( new RawBeeswax() ); 
                from.AddToBackpack( new JarHoney() );
               } 
         } 

         else 
         { 
            from.SendMessage("Vous avez besoin d'un rayon de miel pour utiliser cette bouilloire"); 
            return; 
         } 
      } 



         else 
         { 
            from.SendMessage( "Vous êtes trop loin." ); 
            return; 
         } 

	}
      public HoneycombProcessingKettle( Serial serial ) : base( serial )
		{
		}



	public override void Serialize( GenericWriter writer ) 
      { 
         base.Serialize( writer ); 

         writer.Write( (int) 0 ); // version 
      } 

      public override void Deserialize( GenericReader reader ) 
      { 
         base.Deserialize( reader ); 

         int version = reader.ReadInt(); 
      } 
   } 
  
} 

