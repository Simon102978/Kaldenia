#region About This Script - Do Not Remove This Header

#endregion About This Script - Do Not Remove This Header

using System;
using System.Threading;
using System.Collections;
using Server;
using Server.Network;
using Server.Items;
using Server.Gumps;
using Server.Mobiles;

namespace Server.Items.Crops
{
    public class Marijuana_Seed : DrugSystem_Engine
    {        
        public override bool CanGrowGarden { get { return true; } }

        [Constructable]
        public Marijuana_Seed(): this(1)
        {
        }

        [Constructable]
        public Marijuana_Seed(int amount): base(0x1AA2)
        {
            Name = "Marijuana Seed";
            Weight = 0.1;
            Hue = 63;
            Stackable = true;
            Movable = true;
            Amount = amount;
        }

        public override void OnDoubleClick(Mobile from)
        {
            if (from.Mounted && !DrugSystem_Helper.CanWorkMounted) 
            { 
                from.SendMessage("You Cannot Plant Any Seeds While Mounted!"); 
                return; 
            }

            Point3D m_pnt = from.Location;
            Map m_map = from.Map;

            if (!IsChildOf(from.Backpack)) 
            { 
                from.SendLocalizedMessage(1042010); 
                return; 
            }
            else if (!DrugSystem_Helper.CheckCanGrow(this, m_map, m_pnt.X, m_pnt.Y)) 
            { 
                from.SendMessage("These Seeds Will Not Grow Here."); 
                return; 
            }

            ArrayList cropshere = DrugSystem_Helper.CheckCrop(m_pnt, m_map, 0);

            if (cropshere.Count > 0) 
            { 
                from.SendMessage("There Is Already A Crop Growing Here."); 
                return; 
            }

            ArrayList cropsnear = DrugSystem_Helper.CheckCrop(m_pnt, m_map, 1);

            if ((cropsnear.Count > 8)) 
            { from.SendMessage("There Are Too Many Crops Nearby To Plant These Seeds."); 
                return; 
            }

            if (this.BumpZ) ++m_pnt.Z;

            if (!from.Mounted) from.Animate(32, 5, 1, true, false, 0);
            from.SendMessage("You Carefully Plant The Seeds.");
            this.Consume();

            Item item = new Marijuana_Seedling(from);
            item.Location = m_pnt;
            item.Map = m_map;
        }

        public Marijuana_Seed(Serial serial): base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write((int)0);
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();
        }
    }
}






    

