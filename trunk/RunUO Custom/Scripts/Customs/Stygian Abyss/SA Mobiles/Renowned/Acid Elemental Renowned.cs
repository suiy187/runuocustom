using System;
using Server;
using Server.Items;

namespace Server.Mobiles
{
	[CorpseName( "an acid elemental corpse" )]
	public class AcidElementalRenowned : BaseCreature
	{
		[Constructable]
		public AcidElementalRenowned () : base( AIType.AI_Mage, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = "an acid elemental [Renowned]";
			Body = 0x9E;
			BaseSoundID = 278;

			SetStr( 553 );
			SetDex( 138 );
			SetInt( 394 );

			SetHits( 2226 );

			SetDamage( 9, 15 );

			SetDamageType( ResistanceType.Physical, 25 );
			SetDamageType( ResistanceType.Fire, 50 );
			SetDamageType( ResistanceType.Energy, 25 );

			SetResistance( ResistanceType.Physical, 46 );
			SetResistance( ResistanceType.Fire, 41 );
			SetResistance( ResistanceType.Cold, 30 );
			SetResistance( ResistanceType.Poison, 17 );
			SetResistance( ResistanceType.Energy, 30 );

			SetSkill( SkillName.Anatomy, 72.0 );
			SetSkill( SkillName.EvalInt, 94.9 );
			SetSkill( SkillName.Magery, 93.1 );
			SetSkill( SkillName.MagicResist, 70.5 );
			SetSkill( SkillName.Tactics, 99.6 );
			SetSkill( SkillName.Wrestling, 98.7 );

			Fame = 10000;
			Karma = -10000;

			VirtualArmor = 40;
		}

		public override void GenerateLoot()
		{
			AddLoot( LootPack.Rich );
			AddLoot( LootPack.Average );
		}

		public override bool BleedImmune{ get{ return true; } }
		public override Poison HitPoison{ get{ return Poison.Lethal; } }
		public override double HitPoisonChance{ get{ return 0.6; } }

		public override int TreasureMapLevel{ get{ return Core.AOS ? 2 : 3; } }

		public AcidElementalRenowned( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 0 );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();

			if ( BaseSoundID == 263 )
				BaseSoundID = 278;

			if ( Body == 13 )
				Body = 0x9E;

			if ( Hue == 0x4001 )
				Hue = 0;
		}
	}
}