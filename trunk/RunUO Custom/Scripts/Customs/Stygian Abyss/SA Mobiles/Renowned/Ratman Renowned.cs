using System;
using System.Collections;
using Server.Misc;
using Server.Items;
using Server.Targeting;

namespace Server.Mobiles
{
	[CorpseName( "a RatmanRenowned's corpse" )]
	public class RatmanRenowned : BaseCreature
	{
//		public override InhumanSpeech SpeechType{ get{ return InhumanSpeech.RatmanRenowned; } }

		[Constructable]
		public RatmanRenowned() : base( AIType.AI_Melee, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = "Tikitavi [Renowned]";
			Body = 42;
			BaseSoundID = 437;

			SetStr( 315 );
			SetDex( 139 );
			SetInt( 243 );

			SetHits( 50000 );

			SetDamage( 7, 9 );

			SetDamageType( ResistanceType.Physical, 100 );

			SetResistance( ResistanceType.Physical, 25, 30 );
			SetResistance( ResistanceType.Fire, 25 );
			SetResistance( ResistanceType.Cold, 30 );
			SetResistance( ResistanceType.Poison, 10, 20 );
			SetResistance( ResistanceType.Energy, 18 );

			SetSkill( SkillName.MagicResist, 40.4 );
			SetSkill( SkillName.Tactics, 73.6 );
			SetSkill( SkillName.Wrestling, 66.5 );

			Fame = 1500;
			Karma = -1500;

			VirtualArmor = 28;
		}

		public override void GenerateLoot()
		{
			AddLoot( LootPack.Rich );
			AddLoot( LootPack.LowScrolls );
		}

		public override bool CanRummageCorpses{ get{ return true; } }
		public override int Hides{ get{ return 8; } }
		public override HideType HideType{ get{ return HideType.Spined; } }

		public RatmanRenowned( Serial serial ) : base( serial )
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
		}
	}
}