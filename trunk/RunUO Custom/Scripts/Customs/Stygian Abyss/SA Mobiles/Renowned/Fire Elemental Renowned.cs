using System;
using Server;
using Server.Items;

namespace Server.Mobiles
{
	[CorpseName( "a fire elemental corpse" )]
	public class FireElementalRenowned : BaseCreature
	{
		public override double DispelDifficulty{ get{ return 117.5; } }
		public override double DispelFocus{ get{ return 45.0; } }

		[Constructable]
		public FireElementalRenowned () : base( AIType.AI_Mage, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = "a fire elemental [Renowned]";
			Body = 15;
			BaseSoundID = 838;

			SetStr( 490 );
			SetDex( 203 );
			SetInt( 334 );

			SetHits( 1408 );

			SetDamage( 7, 9 );

			SetDamageType( ResistanceType.Physical, 25 );
			SetDamageType( ResistanceType.Fire, 75 );

			SetResistance( ResistanceType.Physical, 55 );
			SetResistance( ResistanceType.Fire, 100 );
			SetResistance( ResistanceType.Cold, 5 );
			SetResistance( ResistanceType.Poison, 43 );
			SetResistance( ResistanceType.Energy, 50 );

			SetSkill( SkillName.EvalInt, 108.2 );
			SetSkill( SkillName.Magery, 106.6 );
			SetSkill( SkillName.MagicResist, 119.9 );
			SetSkill( SkillName.Tactics, 101.1 );
			SetSkill( SkillName.Wrestling, 99.8 );

			Fame = 4500;
			Karma = -4500;

			VirtualArmor = 40;

			PackItem( new SulfurousAsh( 3 ) );
		}

		public override void GenerateLoot()
		{
			AddLoot( LootPack.Average );
			AddLoot( LootPack.Meager );
			AddLoot( LootPack.Gems );
		}

		public override bool BleedImmune{ get{ return true; } }
		public override int TreasureMapLevel{ get{ return 2; } }

		public FireElementalRenowned( Serial serial ) : base( serial )
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

			if ( BaseSoundID == 274 )
				BaseSoundID = 838;
		}
	}
}
