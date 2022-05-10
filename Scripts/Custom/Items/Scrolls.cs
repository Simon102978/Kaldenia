using System;
using Server;

namespace Server.Items
{
	public class MindRotScroll : SpellScroll
	{
		[Constructable]
	public MindRotScroll() : this(1)
	{
	}

	[Constructable]
	public MindRotScroll(int amount) : base(752, 7993, amount)
	{
		Name ="Pourriture";
		Hue = 37;
	}

	public MindRotScroll(Serial serial) : base(serial)
	{
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

public class WraithFormScroll : SpellScroll
	{
	[Constructable]
	public WraithFormScroll() : this(1)
		{
	}

	[Constructable]
	public WraithFormScroll(int amount) : base(753, 7993, amount)
		{
		Name ="Spectre";
		Hue = 37;
	}

	public WraithFormScroll(Serial serial) : base(serial)
		{
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
public class ConfidenceScroll : SpellScroll
	{
	[Constructable]
	public ConfidenceScroll() : this(1)
		{
	}

	[Constructable]
	public ConfidenceScroll(int amount) : base(853, 7993, amount)
		{
		Name ="Confiance";
		Hue = 182;
	}

	public ConfidenceScroll(Serial serial) : base(serial)
		{
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
public class ImmolatingWeaponScroll : SpellScroll
	{
	[Constructable]
	public ImmolatingWeaponScroll() : this(1)
		{
	}

	[Constructable]
	public ImmolatingWeaponScroll(int amount) : base(750, 7993, amount)
		{
		Name ="Arme d'immolation";

												Hue = 37;
	}

	public ImmolatingWeaponScroll(Serial serial) : base(serial)
		{
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
public class SleepScroll : SpellScroll
	{
	[Constructable]
	public SleepScroll() : this(1)
		{
	}

	[Constructable]
	public SleepScroll(int amount) : base(755, 7993, amount)
		{
		Name ="Dormir";
		Hue = 37;
	}

	public SleepScroll(Serial serial) : base(serial)
		{
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
public class CurseScroll : SpellScroll
	{
	[Constructable]
	public CurseScroll() : this(1)
		{
	}

	[Constructable]
	public CurseScroll(int amount) : base(756, 7993, amount)
		{
		Name ="Malédiction";
		Hue = 37;
	}

	public CurseScroll(Serial serial) : base(serial)
		{
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
public class PoisonScroll : SpellScroll
	{
	[Constructable]
	public PoisonScroll() : this(1)
		{
	}

	[Constructable]
	public PoisonScroll(int amount) : base(757, 7993, amount)
		{
		Name ="Poison";
		Hue = 37;
	}

	public PoisonScroll(Serial serial) : base(serial)
		{
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
public class IncognitoScroll : SpellScroll
	{
	[Constructable]
	public IncognitoScroll() : this(1)
		{
	}

	[Constructable]
	public IncognitoScroll(int amount) : base(758, 7993, amount)
		{
		Name ="Incognito";
		Hue = 37;
	}

	public IncognitoScroll(Serial serial) : base(serial)
		{
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
public class InvisibilityScroll : SpellScroll
	{
	[Constructable]
	public InvisibilityScroll() : this(1)
		{
	}

	[Constructable]
	public InvisibilityScroll(int amount) : base(759, 7993, amount)
		{
		Name ="Invisibilité";
		Hue = 37;
	}

	public InvisibilityScroll(Serial serial) : base(serial)
		{
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
public class ManaVampireScroll : SpellScroll
	{
	[Constructable]
	public ManaVampireScroll() : this(1)
		{
	}

	[Constructable]
	public ManaVampireScroll(int amount) : base(760, 7993, amount)
		{
		Name ="Drain vampirique";
		Hue = 37;
	}

	public ManaVampireScroll(Serial serial) : base(serial)
		{
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
public class CounterAttackScroll : SpellScroll
	{
	[Constructable]
	public CounterAttackScroll() : this(1)
		{
	}

	[Constructable]
	public CounterAttackScroll(int amount) : base(852, 7993, amount)
		{
		Name ="Contre - attaque";
		Hue = 182;
	}

	public CounterAttackScroll(Serial serial) : base(serial)
		{
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
public class EvasionScroll : SpellScroll
	{
	[Constructable]
	public EvasionScroll() : this(1)
		{
	}

	[Constructable]
	public EvasionScroll(int amount) : base(837, 7993, amount)
		{
		Name ="Évasion";
		Hue = 140;
	}

	public EvasionScroll(Serial serial) : base(serial)
		{
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
public class EtherealVoyageScroll : SpellScroll
	{
	[Constructable]
	public EtherealVoyageScroll() : this(1)
		{
	}

	[Constructable]
	public EtherealVoyageScroll(int amount) : base(751, 7993, amount)
		{
		Name ="Voyage éthéré";
		Hue = 37;
	}

	public EtherealVoyageScroll(Serial serial) : base(serial)
		{
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
public class FlameStrikeScroll : SpellScroll
	{
	[Constructable]
	public FlameStrikeScroll() : this(1)
		{
	}

	[Constructable]
	public FlameStrikeScroll(int amount) : base(763, 7993, amount)
		{
		Name ="Jet de feu";
		Hue = 37;
	}

	public FlameStrikeScroll(Serial serial) : base(serial)
		{
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
public class VengefulSpiritScroll : SpellScroll
	{
	[Constructable]
	public VengefulSpiritScroll() : this(1)
		{
	}

	[Constructable]
	public VengefulSpiritScroll(int amount) : base(764, 7993, amount)
		{
		Name ="Esprit Vengeur";
		Hue = 37;
	}

	public VengefulSpiritScroll(Serial serial) : base(serial)
		{
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
public class EnergyVortexScroll : SpellScroll
	{
	[Constructable]
	public EnergyVortexScroll() : this(1)
		{
	}

	[Constructable]
	public EnergyVortexScroll(int amount) : base(765, 7993, amount)
		{
		Name ="Vortex d'energie";

												Hue = 37;
	}

	public EnergyVortexScroll(Serial serial) : base(serial)
		{
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
public class ReactiveArmorScroll : SpellScroll
	{
	[Constructable]
	public ReactiveArmorScroll() : this(1)
		{
	}

	[Constructable]
	public ReactiveArmorScroll(int amount) : base(766, 7993, amount)
		{
		Name ="Armure réactive";
		Hue = 498;
	}

	public ReactiveArmorScroll(Serial serial) : base(serial)
		{
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
public class CreateFoodScroll : SpellScroll
	{
	[Constructable]
	public CreateFoodScroll() : this(1)
		{
	}

	[Constructable]
	public CreateFoodScroll(int amount) : base(767, 7993, amount)
		{
		Name ="Nourriture";
		Hue = 498;
	}

	public CreateFoodScroll(Serial serial) : base(serial)
		{
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
public class NightSightScroll : SpellScroll
	{
	[Constructable]
	public NightSightScroll() : this(1)
		{
	}

	[Constructable]
	public NightSightScroll(int amount) : base(768, 7993, amount)
		{
		Name ="Vision de nuit";
		Hue = 498;
	}

	public NightSightScroll(Serial serial) : base(serial)
		{
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
public class HealScroll : SpellScroll
	{
	[Constructable]
	public HealScroll() : this(1)
		{
	}

	[Constructable]
	public HealScroll(int amount) : base(769, 7993, amount)
		{
		Name ="Guérison";
		Hue = 498;
	}

	public HealScroll(Serial serial) : base(serial)
		{
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
public class MagicArrowScroll : SpellScroll
	{
	[Constructable]
	public MagicArrowScroll() : this(1)
		{
	}

	[Constructable]
	public MagicArrowScroll(int amount) : base(770, 7993, amount)
		{
		Name ="Flèche magique";
		Hue = 498;
	}

	public MagicArrowScroll(Serial serial) : base(serial)
		{
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
public class ClumsyScroll : SpellScroll
	{
	[Constructable]
	public ClumsyScroll() : this(1)
		{
	}

	[Constructable]
	public ClumsyScroll(int amount) : base(771, 7993, amount)
		{
		Name ="Maladresse";
		Hue = 498;
	}

	public ClumsyScroll(Serial serial) : base(serial)
		{
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
public class FeeblemindScroll : SpellScroll
	{
	[Constructable]
	public FeeblemindScroll() : this(1)
		{
	}

	[Constructable]
	public FeeblemindScroll(int amount) : base(772, 7993, amount)
		{
		Name ="Abrutissement";
		Hue = 498;
	}

	public FeeblemindScroll(Serial serial) : base(serial)
		{
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
public class WeakenScroll : SpellScroll
	{
	[Constructable]
	public WeakenScroll() : this(1)
		{
	}

	[Constructable]
	public WeakenScroll(int amount) : base(773, 7993, amount)
		{
		Name ="Faiblesse";
		Hue = 498;
	}

	public WeakenScroll(Serial serial) : base(serial)
		{
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
public class AgilityScroll : SpellScroll
	{
	[Constructable]
	public AgilityScroll() : this(1)
		{
	}

	[Constructable]
	public AgilityScroll(int amount) : base(774, 7993, amount)
		{
		Name ="Agilité";
		Hue = 498;
	}

	public AgilityScroll(Serial serial) : base(serial)
		{
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
public class CunningScroll : SpellScroll
	{
	[Constructable]
	public CunningScroll() : this(1)
		{
	}

	[Constructable]
	public CunningScroll(int amount) : base(775, 7993, amount)
		{
		Name ="Astuce";
		Hue = 498;
	}

	public CunningScroll(Serial serial) : base(serial)
		{
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
public class StrengthScroll : SpellScroll
	{
	[Constructable]
	public StrengthScroll() : this(1)
		{
	}

	[Constructable]
	public StrengthScroll(int amount) : base(776, 7993, amount)
		{
		Name ="Force";
		Hue = 498;
	}

	public StrengthScroll(Serial serial) : base(serial)
		{
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
public class ProtectionScroll : SpellScroll
	{
	[Constructable]
	public ProtectionScroll() : this(1)
		{
	}

	[Constructable]
	public ProtectionScroll(int amount) : base(777, 7993, amount)
		{
		Name ="Protection";
		Hue = 498;
	}

	public ProtectionScroll(Serial serial) : base(serial)
		{
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
public class CureScroll : SpellScroll
	{
	[Constructable]
	public CureScroll() : this(1)
		{
	}

	[Constructable]
	public CureScroll(int amount) : base(778, 7993, amount)
		{
		Name ="Antidote";
		Hue = 498;
	}

	public CureScroll(Serial serial) : base(serial)
		{
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
public class HarmScroll : SpellScroll
	{
	[Constructable]
	public HarmScroll() : this(1)
		{
	}

	[Constructable]
	public HarmScroll(int amount) : base(779, 7993, amount)
		{
		Name ="Malaise";
		Hue = 498;
	}

	public HarmScroll(Serial serial) : base(serial)
		{
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
public class MagicTrapScroll : SpellScroll
	{
	[Constructable]
	public MagicTrapScroll() : this(1)
		{
	}

	[Constructable]
	public MagicTrapScroll(int amount) : base(780, 7993, amount)
		{
		Name ="Piège Magique";
		Hue = 498;
	}

	public MagicTrapScroll(Serial serial) : base(serial)
		{
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
public class RemoveTrapScroll : SpellScroll
	{
	[Constructable]
	public RemoveTrapScroll() : this(1)
		{
	}

	[Constructable]
	public RemoveTrapScroll(int amount) : base(781, 7993, amount)
		{
		Name ="Sup.De Piège";
		Hue = 498;
	}

	public RemoveTrapScroll(Serial serial) : base(serial)
		{
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
public class MagicLockScroll : SpellScroll
	{
	[Constructable]
	public MagicLockScroll() : this(1)
		{
	}

	[Constructable]
	public MagicLockScroll(int amount) : base(782, 7993, amount)
		{
		Name ="Fermeture Mag.";
		Hue = 498;
	}

	public MagicLockScroll(Serial serial) : base(serial)
		{
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
public class UnlockScroll : SpellScroll
	{
	[Constructable]
	public UnlockScroll() : this(1)
		{
	}

	[Constructable]
	public UnlockScroll(int amount) : base(783, 7993, amount)
		{
		Name ="Crochetage";
		Hue = 498;
	}

	public UnlockScroll(Serial serial) : base(serial)
		{
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
public class TelekinesisScroll : SpellScroll
	{
	[Constructable]
	public TelekinesisScroll() : this(1)
		{
	}

	[Constructable]
	public TelekinesisScroll(int amount) : base(784, 7993, amount)
		{
		Name ="Télékinésie";
		Hue = 498;
	}

	public TelekinesisScroll(Serial serial) : base(serial)
		{
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
public class TeleportScroll : SpellScroll
	{
	[Constructable]
	public TeleportScroll() : this(1)
		{
	}

	[Constructable]
	public TeleportScroll(int amount) : base(785, 7993, amount)
		{
		Name ="Téléportation";
		Hue = 498;
	}

	public TeleportScroll(Serial serial) : base(serial)
		{
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
public class RecallScroll : SpellScroll
	{
	[Constructable]
	public RecallScroll() : this(1)
		{
	}

	[Constructable]
	public RecallScroll(int amount) : base(786, 7993, amount)
		{
		Name ="Rappel";
		Hue = 498;
	}

	public RecallScroll(Serial serial) : base(serial)
		{
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
public class MindBlastScroll : SpellScroll
	{
	[Constructable]
	public MindBlastScroll() : this(1)
		{
	}

	[Constructable]
	public MindBlastScroll(int amount) : base(787, 7993, amount)
		{
		Name ="Souffle d'esprit";

												Hue = 498;
	}

	public MindBlastScroll(Serial serial) : base(serial)
		{
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
public class FireballScroll : SpellScroll
	{
	[Constructable]
	public FireballScroll() : this(1)
		{
	}

	[Constructable]
	public FireballScroll(int amount) : base(788, 7993, amount)
		{
		Name ="Boule de feu";
		Hue = 498;
	}

	public FireballScroll(Serial serial) : base(serial)
		{
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
public class FireElementalScroll : SpellScroll
	{
	[Constructable]
	public FireElementalScroll() : this(1)
		{
	}

	[Constructable]
	public FireElementalScroll(int amount) : base(789, 7993, amount)
		{
		Name ="Élém. : Feu";
		Hue = 498;
	}

	public FireElementalScroll(Serial serial) : base(serial)
		{
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
public class EarthElementalScroll : SpellScroll
	{
	[Constructable]
	public EarthElementalScroll() : this(1)
		{
	}

	[Constructable]
	public EarthElementalScroll(int amount) : base(790, 7993, amount)
		{
		Name ="Élém. : Terre";
		Hue = 498;
	}

	public EarthElementalScroll(Serial serial) : base(serial)
		{
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
public class AirElementalScroll : SpellScroll
	{
	[Constructable]
	public AirElementalScroll() : this(1)
		{
	}

	[Constructable]
	public AirElementalScroll(int amount) : base(791, 7993, amount)
		{
		Name ="Élém. : Air";
		Hue = 498;
	}

	public AirElementalScroll(Serial serial) : base(serial)
		{
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
public class SummonFamiliarScroll : SpellScroll
	{
	[Constructable]
	public SummonFamiliarScroll() : this(1)
		{
	}

	[Constructable]
	public SummonFamiliarScroll(int amount) : base(794, 7993, amount)
		{
		Name ="Familier";
		Hue = 72;
	}

	public SummonFamiliarScroll(Serial serial) : base(serial)
		{
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
public class CorpseSkinScroll : SpellScroll
	{
	[Constructable]
	public CorpseSkinScroll() : this(1)
		{
	}

	[Constructable]
	public CorpseSkinScroll(int amount) : base(795, 7993, amount)
		{
		Name ="Peau de mort";
		Hue = 72;
	}

	public CorpseSkinScroll(Serial serial) : base(serial)
		{
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
public class NatureFuryScroll : SpellScroll
	{
	[Constructable]
	public NatureFuryScroll() : this(1)
		{
	}

	[Constructable]
	public NatureFuryScroll(int amount) : base(792, 7993, amount)
		{
		Name ="Fureur de la nature";
		Hue = 72;
	}

	public NatureFuryScroll(Serial serial) : base(serial)
		{
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
public class EnchantScroll : SpellScroll
	{
	[Constructable]
	public EnchantScroll() : this(1)
		{
	}

	[Constructable]
	public EnchantScroll(int amount) : base(796, 7993, amount)
		{
		Name ="Enchanter";
		Hue = 72;
	}

	public EnchantScroll(Serial serial) : base(serial)
		{
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
public class WitherScroll : SpellScroll
	{
	[Constructable]
	public WitherScroll() : this(1)
		{
	}

	[Constructable]
	public WitherScroll(int amount) : base(797, 7993, amount)
		{
		Name ="Flétrissement";
		Hue = 72;
	}

	public WitherScroll(Serial serial) : base(serial)
		{
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
public class FireFieldScroll : SpellScroll
	{
	[Constructable]
	public FireFieldScroll() : this(1)
		{
	}

	[Constructable]
	public FireFieldScroll(int amount) : base(798, 7993, amount)
		{
		Name ="Mur de feu";
		Hue = 72;
	}

	public FireFieldScroll(Serial serial) : base(serial)
		{
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
public class PolymorphScroll : SpellScroll
	{
	[Constructable]
	public PolymorphScroll() : this(1)
		{
	}

	[Constructable]
	public PolymorphScroll(int amount) : base(799, 7993, amount)
		{
		Name ="Transformation";
		Hue = 72;
	}

	public PolymorphScroll(Serial serial) : base(serial)
		{
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
public class AnimateDeadScroll : SpellScroll
	{
	[Constructable]
	public AnimateDeadScroll() : this(1)
		{
	}

	[Constructable]
	public AnimateDeadScroll(int amount) : base(800, 7993, amount)
		{
		Name ="Réanimation";
		Hue = 72;
	}

	public AnimateDeadScroll(Serial serial) : base(serial)
		{
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
public class ReaperFormScroll : SpellScroll
	{
	[Constructable]
	public ReaperFormScroll() : this(1)
		{
	}

	[Constructable]
	public ReaperFormScroll(int amount) : base(793, 7993, amount)
		{
		Name ="Forme de faucheuse";
		Hue = 72;
	}

	public ReaperFormScroll(Serial serial) : base(serial)
		{
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
public class SummonCreatureScroll : SpellScroll
	{
	[Constructable]
	public SummonCreatureScroll() : this(1)
		{
	}

	[Constructable]
	public SummonCreatureScroll(int amount) : base(801, 7993, amount)
		{
		Name ="Créatures";
		Hue = 72;
	}

	public SummonCreatureScroll(Serial serial) : base(serial)
		{
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
public class MarkScroll : SpellScroll
	{
	[Constructable]
	public MarkScroll() : this(1)
		{
	}

	[Constructable]
	public MarkScroll(int amount) : base(802, 7993, amount)
		{
		Name ="Marquage";
		Hue = 72;
	}

	public MarkScroll(Serial serial) : base(serial)
		{
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
public class ExplosionScroll : SpellScroll
	{
	[Constructable]
	public ExplosionScroll() : this(1)
		{
	}

	[Constructable]
	public ExplosionScroll(int amount) : base(803, 7993, amount)
		{
		Name ="Explosion";
		Hue = 72;
	}

	public ExplosionScroll(Serial serial) : base(serial)
		{
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
public class HailStormScroll : SpellScroll
	{
	[Constructable]
	public HailStormScroll() : this(1)
		{
	}

	[Constructable]
	public HailStormScroll(int amount) : base(804, 7993, amount)
		{
		Name ="Orage de grêle";
		Hue = 72;
	}

	public HailStormScroll(Serial serial) : base(serial)
		{
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
public class NetherCycloneScroll : SpellScroll
	{
	[Constructable]
	public NetherCycloneScroll() : this(1)
		{
	}

	[Constructable]
	public NetherCycloneScroll(int amount) : base(805, 7993, amount)
		{
		Name ="Cyclone du Néant";
		Hue = 72;
	}

	public NetherCycloneScroll(Serial serial) : base(serial)
		{
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
public class GateTravelScroll : SpellScroll
	{
	[Constructable]
	public GateTravelScroll() : this(1)
		{
	}

	[Constructable]
	public GateTravelScroll(int amount) : base(806, 7993, amount)
		{
		Name ="Trou de ver";
		Hue = 72;
	}

	public GateTravelScroll(Serial serial) : base(serial)
		{
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
public class EarthquakeScroll : SpellScroll
	{
	[Constructable]
	public EarthquakeScroll() : this(1)
		{
	}

	[Constructable]
	public EarthquakeScroll(int amount) : base(807, 7993, amount)
		{
		Name ="Séisme";
		Hue = 72;
	}

	public EarthquakeScroll(Serial serial) : base(serial)
		{
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
public class CurseWeaponScroll : SpellScroll
	{
	[Constructable]
	public CurseWeaponScroll() : this(1)
		{
	}

	[Constructable]
	public CurseWeaponScroll(int amount) : base(809, 7993, amount)
		{
		Name ="Calamite";
		Hue = 2052;
	}

	public CurseWeaponScroll(Serial serial) : base(serial)
		{
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
public class EvilOmenScroll : SpellScroll
	{
	[Constructable]
	public EvilOmenScroll() : this(1)
		{
	}

	[Constructable]
	public EvilOmenScroll(int amount) : base(810, 7993, amount)
		{
		Name ="Mauvais présage";
		Hue = 2052;
	}

	public EvilOmenScroll(Serial serial) : base(serial)
		{
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
public class HorrificBeastScroll : SpellScroll
	{
	[Constructable]
	public HorrificBeastScroll() : this(1)
		{
	}

	[Constructable]
	public HorrificBeastScroll(int amount) : base(811, 7993, amount)
		{
		Name ="Bête Horrifique";
		Hue = 2052;
	}

	public HorrificBeastScroll(Serial serial) : base(serial)
		{
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
public class GiftOfRenewalScroll : SpellScroll
	{
	[Constructable]
	public GiftOfRenewalScroll() : this(1)
		{
	}

	[Constructable]
	public GiftOfRenewalScroll(int amount) : base(808, 7993, amount)
		{
		Name ="Don du renouveau";
		Hue = 2052;
	}

	public GiftOfRenewalScroll(Serial serial) : base(serial)
		{
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
public class AnimatedWeaponScroll : SpellScroll
	{
	[Constructable]
	public AnimatedWeaponScroll() : this(1)
		{
	}

	[Constructable]
	public AnimatedWeaponScroll(int amount) : base(812, 7993, amount)
		{
		Name ="Arme Animée";
		Hue = 2052;
	}

	public AnimatedWeaponScroll(Serial serial) : base(serial)
		{
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
public class ManaDrainScroll : SpellScroll
	{
	[Constructable]
	public ManaDrainScroll() : this(1)
		{
	}

	[Constructable]
	public ManaDrainScroll(int amount) : base(813, 7993, amount)
		{
		Name ="Drain de mana";
		Hue = 2052;
	}

	public ManaDrainScroll(Serial serial) : base(serial)
		{
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
public class MassCurseScroll : SpellScroll
	{
	[Constructable]
	public MassCurseScroll() : this(1)
		{
	}

	[Constructable]
	public MassCurseScroll(int amount) : base(814, 7993, amount)
		{
		Name ="Malédiction de groupe";
		Hue = 2052;
	}

	public MassCurseScroll(Serial serial) : base(serial)
		{
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
public class DispelFieldScroll : SpellScroll
	{
	[Constructable]
	public DispelFieldScroll() : this(1)
		{
	}

	[Constructable]
	public DispelFieldScroll(int amount) : base(815, 7993, amount)
		{
		Name ="Dissipation de mur";
		Hue = 2052;
	}

	public DispelFieldScroll(Serial serial) : base(serial)
		{
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
public class PoisonFieldScroll : SpellScroll
	{
	[Constructable]
	public PoisonFieldScroll() : this(1)
		{
	}

	[Constructable]
	public PoisonFieldScroll(int amount) : base(816, 7993, amount)
		{
		Name ="Mur de poison";
		Hue = 2052;
	}

	public PoisonFieldScroll(Serial serial) : base(serial)
		{
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
public class BloodOathScroll : SpellScroll
	{
	[Constructable]
	public BloodOathScroll() : this(1)
		{
	}

	[Constructable]
	public BloodOathScroll(int amount) : base(817, 7993, amount)
		{
		Name ="Serment de sang";
		Hue = 2052;
	}

	public BloodOathScroll(Serial serial) : base(serial)
		{
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
public class CloseWoundsScroll : SpellScroll
	{
	[Constructable]
	public CloseWoundsScroll() : this(1)
		{
	}

	[Constructable]
	public CloseWoundsScroll(int amount) : base(844, 7993, amount)
		{
		Name ="Fermer les plaies";
		Hue = 182;
	}

	public CloseWoundsScroll(Serial serial) : base(serial)
		{
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
public class PoisonStrikeScroll : SpellScroll
	{
	[Constructable]
	public PoisonStrikeScroll() : this(1)
		{
	}

	[Constructable]
	public PoisonStrikeScroll(int amount) : base(819, 7993, amount)
		{
		Name ="Jet de poison";
		Hue = 2052;
	}

	public PoisonStrikeScroll(Serial serial) : base(serial)
		{
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
public class StrangleScroll : SpellScroll
	{
	[Constructable]
	public StrangleScroll() : this(1)
		{
	}

	[Constructable]
	public StrangleScroll(int amount) : base(820, 7993, amount)
		{
		Name ="Étranglement";
		Hue = 2052;
	}

	public StrangleScroll(Serial serial) : base(serial)
		{
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
public class LichFormScroll : SpellScroll
	{
	[Constructable]
	public LichFormScroll() : this(1)
		{
	}

	[Constructable]
	public LichFormScroll(int amount) : base(821, 7993, amount)
		{
		Name ="Liche";
		Hue = 2052;
	}

	public LichFormScroll(Serial serial) : base(serial)
		{
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
public class VampiricEmbraceScroll : SpellScroll
	{
	[Constructable]
	public VampiricEmbraceScroll() : this(1)
		{
	}

	[Constructable]
	public VampiricEmbraceScroll(int amount) : base(822, 7993, amount)
		{
		Name ="Vampirisme";
		Hue = 2052;
	}

	public VampiricEmbraceScroll(Serial serial) : base(serial)
		{
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
public class SummonDaemonScroll : SpellScroll
	{
	[Constructable]
	public SummonDaemonScroll() : this(1)
		{
	}

	[Constructable]
	public SummonDaemonScroll(int amount) : base(823, 7993, amount)
		{
		Name ="Démon";
		Hue = 2052;
	}

	public SummonDaemonScroll(Serial serial) : base(serial)
		{
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
public class RemoveCurseScroll : SpellScroll
	{
	[Constructable]
	public RemoveCurseScroll() : this(1)
		{
	}

	[Constructable]
	public RemoveCurseScroll(int amount) : base(824, 7993, amount)
		{
		Name ="Supprimer la malédiction";
		Hue = 140;
	}

	public RemoveCurseScroll(Serial serial) : base(serial)
		{
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
public class WallOfStoneScroll : SpellScroll
	{
	[Constructable]
	public WallOfStoneScroll() : this(1)
		{
	}

	[Constructable]
	public WallOfStoneScroll(int amount) : base(825, 7993, amount)
		{
		Name ="Mur de pierre";
		Hue = 140;
	}

	public WallOfStoneScroll(Serial serial) : base(serial)
		{
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
public class CleanseByFireScroll : SpellScroll
	{
	[Constructable]
	public CleanseByFireScroll() : this(1)
		{
	}

	[Constructable]
	public CleanseByFireScroll(int amount) : base(829, 7993, amount)
		{
		Name ="Nettoyer par le feu";
		Hue = 140;
	}

	public CleanseByFireScroll(Serial serial) : base(serial)
		{
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
public class BladeSpiritsScroll : SpellScroll
	{
	[Constructable]
	public BladeSpiritsScroll() : this(1)
		{
	}

	[Constructable]
	public BladeSpiritsScroll(int amount) : base(827, 7993, amount)
		{
		Name ="Esprit de Lame";
		Hue = 140;
	}

	public BladeSpiritsScroll(Serial serial) : base(serial)
		{
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
public class LightningScroll : SpellScroll
	{
	[Constructable]
	public LightningScroll() : this(1)
		{
	}

	[Constructable]
	public LightningScroll(int amount) : base(828, 7993, amount)
		{
		Name ="Éclair";
		Hue = 140;
	}

	public LightningScroll(Serial serial) : base(serial)
		{
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
public class ConsecrateWeaponScroll : SpellScroll
	{
	[Constructable]
	public ConsecrateWeaponScroll() : this(1)
		{
	}

	[Constructable]
	public ConsecrateWeaponScroll(int amount) : base(830, 7993, amount)
		{
		Name ="Consacrer l'arme";

												Hue = 140;
	}

	public ConsecrateWeaponScroll(Serial serial) : base(serial)
		{
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
public class DivineFuryScroll : SpellScroll
	{
	[Constructable]
	public DivineFuryScroll() : this(1)
		{
	}

	[Constructable]
	public DivineFuryScroll(int amount) : base(836, 7993, amount)
		{
		Name ="Fureur divine";
		Hue = 140;
	}

	public DivineFuryScroll(Serial serial) : base(serial)
		{
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
public class ArchProtectionScroll : SpellScroll
	{
	[Constructable]
	public ArchProtectionScroll() : this(1)
		{
	}

	[Constructable]
	public ArchProtectionScroll(int amount) : base(831, 7993, amount)
		{
		Name ="Protection de groupe";
		Hue = 140;
	}

	public ArchProtectionScroll(Serial serial) : base(serial)
		{
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
public class MagicReflectScroll : SpellScroll
	{
	[Constructable]
	public MagicReflectScroll() : this(1)
		{
	}

	[Constructable]
	public MagicReflectScroll(int amount) : base(832, 7993, amount)
		{
		Name ="Armure magique";
		Hue = 140;
	}

	public MagicReflectScroll(Serial serial) : base(serial)
		{
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
public class DispelScroll : SpellScroll
	{
	[Constructable]
	public DispelScroll() : this(1)
		{
	}

	[Constructable]
	public DispelScroll(int amount) : base(833, 7993, amount)
		{
		Name ="Dissipation";
		Hue = 140;
	}

	public DispelScroll(Serial serial) : base(serial)
		{
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
public class DispelEvilScroll : SpellScroll
	{
	[Constructable]
	public DispelEvilScroll() : this(1)
		{
	}

	[Constructable]
	public DispelEvilScroll(int amount) : base(846, 7993, amount)
		{
		Name ="Dissiper le mal";
		Hue = 182;
	}

	public DispelEvilScroll(Serial serial) : base(serial)
		{
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
public class ParalyzeFieldScroll : SpellScroll
	{
	[Constructable]
	public ParalyzeFieldScroll() : this(1)
		{
	}

	[Constructable]
	public ParalyzeFieldScroll(int amount) : base(835, 7993, amount)
		{
		Name ="Mur de paralysie";
		Hue = 140;
	}

	public ParalyzeFieldScroll(Serial serial) : base(serial)
		{
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
public class EnemyOfOneScroll : SpellScroll
	{
	[Constructable]
	public EnemyOfOneScroll() : this(1)
		{
	}

	[Constructable]
	public EnemyOfOneScroll(int amount) : base(826, 7993, amount)
		{
		Name ="Ennemi d'un";

												Hue = 140;
	}

	public EnemyOfOneScroll(Serial serial) : base(serial)
		{
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
public class HolyLightScroll : SpellScroll
	{
	[Constructable]
	public HolyLightScroll() : this(1)
		{
	}

	[Constructable]
	public HolyLightScroll(int amount) : base(850, 7993, amount)
		{
		Name ="Lumière sacrée";
		Hue = 182;
	}

	public HolyLightScroll(Serial serial) : base(serial)
		{
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
public class MassDispelScroll : SpellScroll
	{
	[Constructable]
	public MassDispelScroll() : this(1)
		{
	}

	[Constructable]
	public MassDispelScroll(int amount) : base(838, 7993, amount)
		{
		Name ="Dissipation massive";
		Hue = 140;
	}

	public MassDispelScroll(Serial serial) : base(serial)
		{
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
public class ResurrectionScroll : SpellScroll
	{
	[Constructable]
	public ResurrectionScroll() : this(1)
		{
	}

	[Constructable]
	public ResurrectionScroll(int amount) : base(839, 7993, amount)
		{
		Name ="Résurrection";
		Hue = 140;
	}

	public ResurrectionScroll(Serial serial) : base(serial)
		{
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
public class WaterElementalScroll : SpellScroll
	{
	[Constructable]
	public WaterElementalScroll() : this(1)
		{
	}

	[Constructable]
	public WaterElementalScroll(int amount) : base(840, 7993, amount)
		{
		Name ="Élém. : Eau";
		Hue = 498;
	}

	public WaterElementalScroll(Serial serial) : base(serial)
		{
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
public class RevealScroll : SpellScroll
	{
	[Constructable]
	public RevealScroll() : this(1)
		{
	}

	[Constructable]
	public RevealScroll(int amount) : base(843, 7993, amount)
		{
		Name ="Révélation";
		Hue = 182;
	}

	public RevealScroll(Serial serial) : base(serial)
		{
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
public class AttuneWeaponScroll : SpellScroll
	{
	[Constructable]
	public AttuneWeaponScroll() : this(1)
		{
	}

	[Constructable]
	public AttuneWeaponScroll(int amount) : base(841, 7993, amount)
		{
		Name ="Harmonisation";
		Hue = 182;
	}

	public AttuneWeaponScroll(Serial serial) : base(serial)
		{
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
public class NobleSacrificeScroll : SpellScroll
	{
	[Constructable]
	public NobleSacrificeScroll() : this(1)
		{
	}

	[Constructable]
	public NobleSacrificeScroll(int amount) : base(851, 7993, amount)
		{
		Name ="Nobles sacrifices";
		Hue = 182;
	}

	public NobleSacrificeScroll(Serial serial) : base(serial)
		{
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
public class BlessScroll : SpellScroll
	{
	[Constructable]
	public BlessScroll() : this(1)
		{
	}

	[Constructable]
	public BlessScroll(int amount) : base(845, 7993, amount)
		{
		Name ="Bénédiction";
		Hue = 182;
	}

	public BlessScroll(Serial serial) : base(serial)
		{
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
public class AnimalFormScroll : SpellScroll
	{
	[Constructable]
	public AnimalFormScroll() : this(1)
		{
	}

	[Constructable]
	public AnimalFormScroll(int amount) : base(761, 7993, amount)
		{
		Name ="Forme animale";
		Hue = 37;
	}

	public AnimalFormScroll(Serial serial) : base(serial)
		{
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
public class ArchCureScroll : SpellScroll
	{
	[Constructable]
	public ArchCureScroll() : this(1)
		{
	}

	[Constructable]
	public ArchCureScroll(int amount) : base(847, 7993, amount)
		{
		Name ="Antidote de masse";
		Hue = 182;
	}

	public ArchCureScroll(Serial serial) : base(serial)
		{
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
public class GreaterHealScroll : SpellScroll
	{
	[Constructable]
	public GreaterHealScroll() : this(1)
		{
	}

	[Constructable]
	public GreaterHealScroll(int amount) : base(848, 7993, amount)
		{
		Name ="Guérison majeure";
		Hue = 182;
	}

	public GreaterHealScroll(Serial serial) : base(serial)
		{
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
public class ParalyzeScroll : SpellScroll
	{
	[Constructable]
	public ParalyzeScroll() : this(1)
		{
	}

	[Constructable]
	public ParalyzeScroll(int amount) : base(849, 7993, amount)
		{
		Name ="Paralysie";
		Hue = 182;
	}

	public ParalyzeScroll(Serial serial) : base(serial)
		{
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
public class MirrorImageScroll : SpellScroll
	{
	[Constructable]
	public MirrorImageScroll() : this(1)
		{
	}

	[Constructable]
	public MirrorImageScroll(int amount) : base(754, 7993, amount)
		{
		Name ="Image miroir";
		Hue = 37;
	}

	public MirrorImageScroll(Serial serial) : base(serial)
		{
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
public class ShadowjumpScroll : SpellScroll
	{
	[Constructable]
	public ShadowjumpScroll() : this(1)
		{
	}

	[Constructable]
	public ShadowjumpScroll(int amount) : base(762, 7993, amount)
		{
		Name ="Saut d'ombre";

												Hue = 37;
	}

	public ShadowjumpScroll(Serial serial) : base(serial)
		{
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
public class DeathStrikeScroll : SpellScroll
	{
	[Constructable]
	public DeathStrikeScroll() : this(1)
		{
	}

	[Constructable]
	public DeathStrikeScroll(int amount) : base(818, 7993, amount)
		{
		Name ="Frappe mortelle";
		Hue = 2052;
	}

	public DeathStrikeScroll(Serial serial) : base(serial)
		{
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
public class KiAttackScroll : SpellScroll
	{
	[Constructable]
	public KiAttackScroll() : this(1)
		{
	}

	[Constructable]
	public KiAttackScroll(int amount) : base(834, 7993, amount)
		{
		Name ="Attaque Ki";
		Hue = 140;
	}

	public KiAttackScroll(Serial serial) : base(serial)
		{
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
public class GiftOfLifeScroll : SpellScroll
	{
	[Constructable]
	public GiftOfLifeScroll() : this(1)
		{
	}

	[Constructable]
	public GiftOfLifeScroll(int amount) : base(842, 7993, amount)
		{
		Name ="Don de vie";
		Hue = 182;
	}

	public GiftOfLifeScroll(Serial serial) : base(serial)
		{
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
public class EnergyBoltScroll : SpellScroll
	{
	[Constructable]
	public EnergyBoltScroll() : this(1)
		{
	}

	[Constructable]
	public EnergyBoltScroll(int amount) : base(854, 7993, amount)
		{
		Name ="Boule d'énergie";

												Hue = 182;
	}

	public EnergyBoltScroll(Serial serial) : base(serial)
		{
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
public class EnergyFieldScroll : SpellScroll
	{
	[Constructable]
	public EnergyFieldScroll() : this(1)
		{
	}

	[Constructable]
	public EnergyFieldScroll(int amount) : base(855, 7993, amount)
		{
		Name ="Mur d'energie";

												Hue = 182;
	}

	public EnergyFieldScroll(Serial serial) : base(serial)
		{
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
public class RisingColossusScroll : SpellScroll
	{
	[Constructable]
	public RisingColossusScroll() : this(1)
		{
	}

	[Constructable]
	public RisingColossusScroll(int amount) : base(856, 7993, amount)
		{
		Name ="Colosse montant";
		Hue = 182;
	}

	public RisingColossusScroll(Serial serial) : base(serial)
		{
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