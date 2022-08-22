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
    [FlipableAttribute(0x1AA2, 0xF00)]
    public class Marijuana_Joint : DrugSystem_Effect
    {
        [Constructable]
        public Marijuana_Joint(): base(0x1420)
        {
            Name = "A Fat Hand-Rolled Blunt";
            this.Weight = 0.3;
            this.Hue = 1153;
        }

        public Marijuana_Joint(Serial serial): base(serial)
        {
        }

        public override void OnDoubleClick(Mobile from)
        {
            #region Nuggzy #1
            if (from.Stam > from.StamMax / 2)
            {
            #endregion
                Container pack = from.Backpack;

                if (pack != null && pack.ConsumeTotal(typeof(Marijuana_Joint), 1))
                {
                    if (from.Body.IsHuman && !from.Mounted)
                    {
                        from.Animate(34, 5, 1, true, false, 0);
                    }

                    from.SendMessage("You Ignite A Spark On A Nearby Rock And Light Up A Doobie.");
                    from.PlaySound(0x226);
                    Highness = 25;

                    if (Core.AOS)
                        from.FixedParticles(0x3735, 1, 30, 9503, EffectLayer.Waist);

                    else
                        from.FixedEffect(0x3735, 6, 30);

                    new DrugSystem_StonedTimer(from, Highness).Start();

                }
                else
                {
                    from.SendMessage("Your Must Have The Doobie In Your Pack To Toke It!");
                    return;
                }
            #region Nuggzy #2
            }
            #endregion
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write((int)0); // version 
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();
        }
    }
}
