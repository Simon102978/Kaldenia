#region About This Script - Do Not Remove This Header

#endregion About This Script - Do Not Remove This Header

using System;
using System.Threading;
using System.Collections;
using Server;
using Server.Network;
using Server.Items;
using Server.Items.Crops;
using Server.Commands;
using Server.Commands.Generic;
using Server.Gumps;
using Server.Mobiles;

namespace Server.Misc
{
    public class DrugSystem_Delete
	{
		public static void Initialize()
		{
            CommandSystem.Register("DrugSystem_Delete", AccessLevel.Administrator, new CommandEventHandler(DeleteUnusedCrops_OnCommand));
		}

        [Usage("DrugSystem_Delete")]
		[Description( "Deletes Unused Drug Crops!" )]
		public static void DeleteUnusedCrops_OnCommand( CommandEventArgs e )
		{
			int i_Count = 0;
			ArrayList toDelete = new ArrayList();

			try
			{
				foreach ( Item item in World.Items.Values )
                {
                    #region Add More Crops To This Section

                    if (item is Marijuana_Crop || item is Marijuana_Seedling)

                    #endregion Add More Crops To This Section

                    {
						if ( item.Map == Server.Map.Felucca || item.Map == Server.Map.Trammel || item.Map == Server.Map.Ilshenar || item.Map == Server.Map.Malas || item.Map == Server.Map.Tokuno || item.Map == Server.Map.TerMur )
						{
							string sSowerProp = Properties.GetValue( e.Mobile, item, "Sower" );
							if ( sSowerProp == "Sower = (-null-)" || sSowerProp == "Sower = null" || sSowerProp == "null" )
							{
								i_Count++;
								CommandLogging.WriteLine( e.Mobile, "{0} {1} delete {2} [{3}]: {4} ({5} '{6}'))", e.Mobile.AccessLevel, CommandLogging.Format( e.Mobile ), item.Location, item.Map, item.GetType().Name, item.Name, sSowerProp );
								e.Mobile.SendMessage("{0}", sSowerProp);
								toDelete.Add(item);
							}
						}
					}
				}

				for ( int i = 0; i < toDelete.Count; ++i )
				{
					if ( toDelete[i] is Item ) ((Item)toDelete[i]).Delete();
				}

				e.Mobile.SendMessage( i_Count + " Item's Deleted." );
			}
			catch (Exception err)
			{
				e.Mobile.SendMessage( "Exception: " + err.Message );
			}
		}
	}
}