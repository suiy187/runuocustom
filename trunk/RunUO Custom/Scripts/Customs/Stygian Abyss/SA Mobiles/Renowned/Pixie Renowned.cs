using System;
using Server;
using Server.Misc;

namespace Server.Mobiles
{
	[CorpseName( "a pixie corpse" )]
	public class PixieRenowned : BaseCreature
	{
		public override bool InitialInnocent{ get{ return true; } }

		[Constructable]
		public PixieRenowned() : base( AIType.AI_Mage, FightMode.Evil, 10, 1, 0.2, 0.4 )
		{
			Name = "a pixie [Renowned]";
			Body = 128;
			BaseSoundID = 0x467;

			SetStr( 361 );
			SetDex( 582 );
			SetInt( 742 );

			SetHits( 9169 );

			SetDamage( 27, 38 );

			SetDamageType( ResistanceType.Physical, 100 );

			SetResistance( ResistanceType.Physical, 72 );
			SetResistance( ResistanceType.Fire, 67 );
			SetResistance( ResistanceType.Cold, 71 );
			SetResistance( ResistanceType.Poison, 64 );
			SetResistance( ResistanceType.Energy, 60 );

			SetSkill( SkillName.EvalInt, 100.0 );
			SetSkill( SkillName.Magery, 107.2 );
			SetSkill( SkillName.Meditation, 100.0 );
			SetSkill( SkillName.MagicResist, 114.3 );
			SetSkill( SkillName.Tactics, 119.6 );
			SetSkill( SkillName.Wrestling, 112.7 );

			Fame = 7000;
			Karma = 7000;

			VirtualArmor = 100;
			if ( 0.02 > Utility.RandomDouble() )
				PackStatue();
		}

		public override void GenerateLoot()
		{
			AddLoot( LootPack.SuperBoss, 1 );
		}

		public override HideType HideType{ get{ return HideType.Spined; } }
		public override int Hides{ get{ return 5; } }
		public override int Meat{ get{ return 1; } }

		public PixieRenowned( Serial serial ) : base( serial )
		{
		}

		public override OppositionGroup OppositionGroup
		{
			get{ return OppositionGroup.FeyAndUndead; }
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
		}
	}
}