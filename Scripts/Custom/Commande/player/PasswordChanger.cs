using Server;
using System;
using Server.Gumps;
using Server.Accounting;
using Server.Commands;
using Server.Network;

namespace Server.Gumps
{
    public class PasswordChanger : Gump
    {
    	
    	public static void Initialize()
		{
			CommandSystem.Register ( "password", AccessLevel.Player, new CommandEventHandler ( Password_OnCommand ) );
		}
    	
		public static void Password_OnCommand( CommandEventArgs e )
		{
			e.Mobile.CloseGump( typeof ( PasswordChanger ) );
			e.Mobile.SendGump( new PasswordChanger() );
		}
		
       public PasswordChanger() : base(0, 0)
       {
           this.Closable = true;
           this.Disposable = true;
           this.Dragable = false;
           this.Resizable = false;
           this.AddPage(0);

           this.AddBackground(133, 77, 514, 206, 3600);

           this.AddLabel(279, 97, 2102, @"Changer de mot de passe");
           this.AddLabel(160, 130, 2102, @"Mot de passe actuel:");
           this.AddLabel(160, 160, 2102, @"Nouveau mot de passe:");
           this.AddLabel(160, 190, 2102, @"Confirmer le nouveau mot de passe:");

           this.AddButton(356, 230, 247, 248, 1, GumpButtonType.Reply, 0);

           this.AddAlphaRegion(421, 190, 200, 20);
           this.AddAlphaRegion(421, 160, 200, 20);
           this.AddAlphaRegion(421, 130, 200, 20);

           this.AddTextEntry( 421, 130, 200, 20, 1175, 1, "");
           this.AddTextEntry( 421, 160, 200, 20, 1175, 2, "");
           this.AddTextEntry( 421, 190, 200, 20, 1175, 3, "");
       }
       
       private string GetString(RelayInfo info, int id)
	   {
			TextRelay t = info.GetTextEntry(id);
			return (t == null ? null : t.Text.Trim());
	   }
       
       public override void OnResponse(NetState sender, RelayInfo info)
       {
            Mobile m = sender.Mobile;
            switch (info.ButtonID)
            {
            	case 0:
            		{
            			m.SendMessage(46, "Votre mot de passe n'a pas été modifié.");
            			return;
            		}
            	case 1:
            		{
            			string origPass = GetString( info, 1 );
            			string newPass = GetString( info, 2 );
            			string confirmNewPass = GetString( info, 3 );
            			
            			if ( newPass != confirmNewPass ) //Two "Nuova Password" i campi non corrispondono
            			{
            				m.SendMessage(37, "Les valeurs ne correspondent pas au nouveau mot de passe");
            				m.CloseGump( typeof( PasswordChanger ) );
            				m.SendGump( new PasswordChanger() );
            				return;
            			}
            			
						for( int i = 0; i < newPass.Length; ++i )
						{
							if( !(char.IsLetterOrDigit( newPass[i] )) ) //Char is NOT a letter or digit
							{
								m.SendMessage(37, "Les mots de passe doivent être composés seulement de lettres (A %%%#$%?%$#@! Z) et des chiffres (0 %%%#$%?%$#@! 9).");
								return;
							}
						}
         	
            			Account a = m.Account as Account;
            
            			if ( !(a.CheckPassword( origPass )) ) //"Password Attuale" è incorretta
            			{
            				m.SendMessage(37, "Le mot de passe actuel est incorrect. [ " + origPass + " ].");
            				m.CloseGump( typeof( PasswordChanger ) );
            				m.SendGump( new PasswordChanger() );
            				return;
            			}
            
	            		if ( (a.CheckPassword( origPass )) && (newPass == confirmNewPass) ) //La "Password Attuale" è corretta.
            			{
            				a.SetPassword( newPass );
            				m.SendMessage(1274, "Votre mot de passe a été modifié avec succès!");
           	 			}
            			break;
            		}
            }
       }
    }
}
