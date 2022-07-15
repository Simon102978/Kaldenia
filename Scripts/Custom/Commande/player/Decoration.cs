using Server.Network;
using Server.Gumps;
using Server.Targeting;
using Server.Items;
using Server.CustomScripts;

namespace Server.Commands
{
    class DecorationMainCommand
    {
        public static void Initialize()
        {
            CommandSystem.Register("Decoration", AccessLevel.Player, new CommandEventHandler(DecorationMain_OnCommand));
        }

        [Aliases("Deco")]
        [Usage("Decoration")]
        [Description("Aide à la décoration des maisons")]
        public static void DecorationMain_OnCommand(CommandEventArgs e)
        {
            Mobile from = e.Mobile;
            from.SendGump(new DecorationGump(from, DecorationCommand.None));
        }
    }
}

namespace Server.Gumps
{
	public enum DecorationCommand
	{
		None,
		Turn,
		Up,
		Down,
        Lock,
        Unlock
	}

    public class DecorationGump : Gump
    {
        private Mobile m_From;
        private DecorationCommand m_Command;

        public DecorationGump(Mobile from, DecorationCommand command) : base(150, 50)
        {
            m_From = from;
            m_Command = command;

            AddBackground(0, 0, 200, 300, 2600);

            AddButton(50, 45, (m_Command == DecorationCommand.Turn ? 2154 : 2152), 2154, 1, GumpButtonType.Reply, 0);
            AddHtml(90, 50, 70, 40, "Tourner", false, false);//AddHtmlLocalized( 90, 50, 70, 40, 1018323, false, false ); // Turn

            AddButton(50, 95, (m_Command == DecorationCommand.Up ? 2154 : 2152), 2154, 2, GumpButtonType.Reply, 0);
            AddHtml(90, 100, 70, 40, "Monter", false, false); //AddHtmlLocalized( 90, 100, 70, 40, 1018324, false, false ); // Up

            AddButton(50, 145, (m_Command == DecorationCommand.Down ? 2154 : 2152), 2154, 3, GumpButtonType.Reply, 0);
            AddHtml(90, 150, 70, 40, "Descendre", false, false); // AddHtmlLocalized( 90, 150, 70, 40, 1018325, false, false ); // Down

            AddButton(50, 195, (m_Command == DecorationCommand.Lock ? 2154 : 2152), 2154, 4, GumpButtonType.Reply, 0);
            AddHtml(90, 200, 70, 40, "Verrouiller", false, false); // Lock

            AddButton(50, 245, (m_Command == DecorationCommand.Unlock ? 2154 : 2152), 2154, 5, GumpButtonType.Reply, 0);
            AddHtml(90, 250, 70, 40, "Déverrouiller", false, false); // Unlock
        }

        public override void OnResponse(NetState sender, RelayInfo info)
        {
            switch (info.ButtonID)
            {
                case 1: m_Command = DecorationCommand.Turn;   break;
                case 2: m_Command = DecorationCommand.Up;     break;
                case 3: m_Command = DecorationCommand.Down;   break;
                case 4: m_Command = DecorationCommand.Lock;   break;
                case 5: m_Command = DecorationCommand.Unlock; break;
            }

            if (m_Command != DecorationCommand.None)
            {
                sender.Mobile.SendGump(new DecorationGump(m_From, m_Command));
                sender.Mobile.Target = new InternalTarget(m_From, m_Command);
            }
            else
            {
                //Target.Cancel(sender.Mobile);
                sender.Mobile.CloseGump(typeof(DecorationGump));
            }
        }

        private class InternalTarget : Target
        {
            private Mobile m_From;
            private DecorationCommand m_Command;

            public InternalTarget(Mobile from, DecorationCommand command) : base(-1, false, TargetFlags.None)
            {
                CheckLOS = false;

                m_From = from;
                m_Command = command;
            }

            protected override void OnTargetNotAccessible(Mobile from, object targeted)
            {
                OnTarget(from, targeted);
            }

            protected override void OnTarget(Mobile from, object targeted)
            {
                if (targeted is AddonComponent || targeted is AddonContainerComponent || targeted is BaseAddonContainer || targeted is BaseAddon)
                {
                    from.SendMessage("Les objets provenant de deeds ne peuvent pas être ciblé.");
                    return;
                }
                else if (targeted is Item)
                {
                    Item item = (Item)targeted;

                    if (from.AccessLevel == AccessLevel.Player && from.GetDistanceToSqrt(item.Location) > 1)
                    {
                        from.SendMessage("Vous devez être à moins de 2 cases de l'objet.");
                        return;
                    }

                    if ((item.RootParent == from) || item.IsChildOf(from.Backpack))
                    {
                        from.SendMessage("Vous ne pouvez pas utiliser cette commande sur un objet dans votre sac ou sur vous.");
                        return;
                    }

                    if (!item.GmLocked && !(item is BaseDoor) && !(item is BaseWall))
                    {
                        bool isDecorableComponent = false;

                        if (item is AddonComponent || item is AddonContainerComponent || item is BaseAddonContainer)
                        {
                            object addon = null;
                            int count = 0;

                            if (item is AddonComponent)
                            {
                                AddonComponent component = (AddonComponent)item;
                                count = component.Addon.Components.Count;
                                addon = component.Addon;
                            }
                            else if (item is AddonContainerComponent)
                            {
                                AddonContainerComponent component = (AddonContainerComponent)item;
                                count = component.Addon.Components.Count;
                                addon = component.Addon;
                            }
                            else if (item is BaseAddonContainer)
                            {
                                BaseAddonContainer container = (BaseAddonContainer)item;
                                count = container.Components.Count;
                                addon = container;
                            }

                            if (count == 1 && Core.SE)
                                isDecorableComponent = true;

                            if (m_Command == DecorationCommand.Turn)
                            {
                                FlipableAddonAttribute[] attributes = (FlipableAddonAttribute[])addon.GetType().GetCustomAttributes(typeof(FlipableAddonAttribute), false);

                                if (attributes.Length > 0)
                                    isDecorableComponent = true;
                            }
                        }

                        if (item is VendorRentalContract)
                        {
                            from.SendMessage("Vous ne pouvez pas utiliser le décorateur sur cet objet."); //from.SendLocalizedMessage( 1062491 ); // You cannot use the house decorator on that object.
                        }
                        else if (item.TotalWeight + item.PileWeight > 2500)
                        {
                            from.SendMessage("Ceci est trop lourd pour être déplacé"); //from.SendLocalizedMessage(1042272); // That is too heavy.
                        }
                        else
                        {
                            switch (m_Command)
                            {
                                case DecorationCommand.Up: Up(item, from); break;
                                case DecorationCommand.Down: Down(item, from); break;
                                case DecorationCommand.Turn: Turn(item, from); break;
                                case DecorationCommand.Lock: Lock(item, from); break;
                                case DecorationCommand.Unlock: Unlock(item, from); break;
                            }
                        }
                    }
                    else
                    {
                        from.SendMessage("Vous ne pouvez pas utiliser le décorateur sur cet objet.");
                    }
                }

                from.Target = new InternalTarget(m_From, m_Command);
            }

            protected override void OnTargetCancel(Mobile from, TargetCancelType cancelType)
            {
                if (cancelType == TargetCancelType.Canceled)
                    from.CloseGump(typeof(DecorationGump));
            }

            private static void Turn(Item item, Mobile from)
            {
                if (item is AddonComponent || item is AddonContainerComponent || item is BaseAddonContainer)
                {
                    object addon = null;

                    if (item is AddonComponent)
                        addon = ((AddonComponent)item).Addon;
                    else if (item is AddonContainerComponent)
                        addon = ((AddonContainerComponent)item).Addon;
                    else if (item is BaseAddonContainer)
                        addon = (BaseAddonContainer)item;

                    FlipableAddonAttribute[] aAttributes = (FlipableAddonAttribute[])addon.GetType().GetCustomAttributes(typeof(FlipableAddonAttribute), false);

                    if (aAttributes.Length > 0)
                    {
                        aAttributes[0].Flip(from, (Item)addon);
                        return;
                    }
                }

                FlipableAttribute[] attributes = (FlipableAttribute[])item.GetType().GetCustomAttributes(typeof(FlipableAttribute), false);

                if (attributes.Length > 0)
                    attributes[0].Flip(item);
                else
                    from.SendMessage("Vous ne pouvez pas tourner ceci"); //from.SendLocalizedMessage( 1042273 ); // You cannot turn that.
            }

            private static void Up(Item item, Mobile from)
            {
                int floorZ = GetFloorZ(item);

                if (floorZ > int.MinValue && item.Z < (floorZ + 15)) // Confirmed : no height checks here
                    item.Location = new Point3D(item.Location, item.Z + 1);
                else
                    from.SendMessage("Vous ne pouvez pas monter ceci plus haut.") ; // from.SendLocalizedMessage( 1042274 ); // You cannot raise it up any higher.
            }

            private static void Lock(Item item, Mobile from)
            {
                item.Movable = false;
            }

            private static void Unlock(Item item, Mobile from)
            {
                item.Movable = true;
            }

            private static void Down(Item item, Mobile from)
            {
                int floorZ = GetFloorZ(item);

                if (floorZ > int.MinValue && item.Z > GetFloorZ(item))
                    item.Location = new Point3D(item.Location, item.Z - 1);
                else
                    from.SendMessage("Vous ne pouvez pas descendre ceci plus bas."); // from.SendLocalizedMessage( 1042275 ); // You cannot lower it down any further.
            }

            private static int GetFloorZ(Item item)
            {
                Map map = item.Map;

                if (map == null)
                    return int.MinValue;

                int z = int.MinValue;

                LandTile landTile = map.Tiles.GetLandTile(item.X, item.Y);
                ItemData landId = TileData.ItemTable[landTile.ID & TileData.MaxItemValue];

                int top = landTile.Z; // Confirmed : no height checks here

                if (top > z && top <= item.Z)
                    z = top;

                StaticTile[] tiles = map.Tiles.GetStaticTiles(item.X, item.Y, false);

                for (int i = 0; i < tiles.Length; ++i)
                {
                    StaticTile tile = tiles[i];
                    ItemData id = TileData.ItemTable[tile.ID & TileData.MaxItemValue];

                    top = tile.Z; // Confirmed : no height checks here

                    if (top > z && top <= item.Z)
                        z = top;
                }

                return z;
            }
        }
    }
}