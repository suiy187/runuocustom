using System;
using System.Collections;
using Server.Misc;
using Server.Items;
using Server.Targeting;

namespace Server.Mobiles
{
	[CorpseName( "a ratman corpse" )]
	public class RatmanArcherRenowned : BaseCreature
	{
		public override InhumanSpeech SpeechType{ get{ return InhumanSpeech.Ratman; } }

		[Constructable]
		public RatmanArcherRenowned() : base( AIType.AI_Archer, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = "Rakktavi [Renowned]";
			Body = 0x8E;
			BaseSoundID = 437;

			SetStr( 119 );
			SetDex( 279 );
			SetInt( 327 );

			SetHits( 50000 );

			SetDamage( 8, 10 );

			SetDamageType( ResistanceType.Physical, 100 );

			SetResistance( ResistanceType.Physical, 20 );
			SetResistance( ResistanceType.Fire, 21 );
			SetResistance( ResistanceType.Cold, 39 );
			SetResistance( ResistanceType.Poison, 14 );
			SetResistance( ResistanceType.Energy, 10 );

			SetSkill( SkillName.Anatomy, 60.2, 100.0 );
			SetSkill( SkillName.Archery, 80.1, 90.0 );
			SetSkill( SkillName.MagicResist, 66.0 );
			SetSkill( SkillName.Tactics, 68.1 );
			SetSkill( SkillName.Wrestling, 85.5 );

			Fame = 6500;
			Karma = -6500;

			VirtualArmor = 56;
		}

		public override void GenerateLoot()
		{
			AddLoot( LootPack.Rich );
		}

		public override bool CanRummageCorpses{ get{ return true; } }
		public override int Hides{ get{ return 8; } }
		public override HideType HideType{ get{ return HideType.Spined; } }

		public RatmanArcherRenowned( Serial serial ) : base( serial )
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

			if ( Body == 42 )
			{
				Body = 0x8E;
				Hue = 0;
			}
		}
	}
}
